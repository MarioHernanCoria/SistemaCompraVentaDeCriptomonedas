using Microsoft.EntityFrameworkCore;
using SistemaCompraVentaDeCriptomonedas.DataAccess;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Helpers;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;

namespace SistemaCompraVentaDeCriptomonedas.Repositories
{
    public class CuentaRepository : GenericService<Cuenta>, ICuentaRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogMovimientoService _logMovimientoService;

        public CuentaRepository(AppDbContext context,
                                ILogMovimientoService logMovimientoService) : base(context)
        {
            _context = context;
            _logMovimientoService = logMovimientoService;
        }

        public async Task<bool> Create(Cuenta entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> Update(Cuenta cuenta)
        {
            _context.Cuentas.Update(cuenta);
            return true;
        }

        public async Task<bool> UpdateTrasferSqlAsync(Cuenta cuenta)
        {
            var sql = $"UPDATE Cuentas " +
                      $"SET Saldo = {cuenta.Saldo.ToString("F16", System.Globalization.CultureInfo.GetCultureInfo("en"))} " +
                      $"WHERE Discriminator = '{cuenta.Discriminator}' " +
                      $"AND Id = {cuenta.Id}";

            await _context.Database.ExecuteSqlRawAsync(sql);

            return true;
        }


        public async Task<bool> Transferir(TransferirDto trans)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                await UpdateTrasferSqlAsync(trans.CuentaOrigen);
                await UpdateTrasferSqlAsync(trans.CuentaDestino);

                var mov = new Movimiento()
                {
                    Fecha = DateTime.Now,
                    Monto = trans.Monto,
                    MovimientaCuenta = new MovimientoCuenta()
                    {
                        CuentaDestino = trans.CuentaDestino,
                        CuentaOrigen = trans.CuentaOrigen,
                    },
                    MovimientoUsuario = new MovimientoUsuario()
                    {
                        UsuarioDestino = trans.UsuarioDestino,
                        UsuarioOrigen = trans.UsuarioOrigen
                    },
                };

                mov.MovimientaCuenta.CuentaDestino.Saldo = trans.CuentaOrigen.Saldo;
                mov.MovimientaCuenta.CuentaOrigen.Saldo = trans.CuentaDestino.Saldo;

                //_context.Update(mov);

                //Registro el movimiento.
                await _logMovimientoService.LogTransferencia(mov);

                transaction.Commit();


                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }


        }


        public async Task<Cuenta> GetById(string id)
        {
            return await _context.Cuentas.FirstOrDefaultAsync(x => x.Discriminator == Constantes.CUENTACRIPTO ?
                                                             ((CuentaCripto)x).UUID == id :
                                                             ((CuentaFiduciaria)x).NumeroCuenta == id);
        }

        public async Task<bool> Depositar(DepositarRequestDto depDto)
        {
            using var trasaction = _context.Database.BeginTransaction();

            try
            {

                var cuentas = await _context.Cuentas.Where(x =>
                             x.Discriminator == Constantes.CUENTAFIDUCIARIA).
                             ToListAsync();

                if (cuentas == null)
                    return false;

                var cuenta = cuentas.Find(x => ((CuentaFiduciaria)x).NumeroCuenta == depDto.NumeroCuenta);

                cuenta.Saldo += depDto.Monto;

                _context.Cuentas.Update(cuenta);
                await _context.SaveChangesAsync();


                await _logMovimientoService.LogDeposito(depDto);

                trasaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                trasaction.Rollback();
                return false;
            }
        }

        public async Task<MovimientosResponseDto> ConsultarMovimientos(MovimientosRequestDto movDto)
        {
            var movimientos = await _context.LogMovimientos
                             .Where(x => x.EmailUsuario == movDto.EmailUsuario) 
                             .ToListAsync();

            var movimientosDto = new List<LogMovimientoDto>();

            foreach (var m in movimientos)
            {
                if (m.Discriminator == Constantes.LOGMOVIMIENTO)
                {
                    movimientosDto.Add(new LogMovimientoDto()
                    {
                        EmailUsuario = m.EmailUsuario,
                        Fecha = m.Fecha,
                        Monto = m.Monto,
                        //EmailDestino = m.EmailDestino,
                        NumeroCuenta = m.NumeroCuenta,
                        TipoCuenta = m.TipoCuenta,
                        TipoMovimiento = m.TipoMovimiento
                    });
                }
                else if (m.Discriminator == Constantes.LOGTRANSFERENCIA)
                {
                    movimientosDto.Add(new LogMovimientoDto()
                    {
                        EmailUsuario = ((LogTransferencia)m).EmailUsuario,
                        Fecha = m.Fecha,
                        Monto = m.Monto,
                        EmailDestino = ((LogTransferencia)m).EmailDestino,
                        NumeroCuenta = m.NumeroCuenta,
                        TipoCuenta = m.TipoCuenta,
                        TipoMovimiento = m.TipoMovimiento
                    });
                }
            }


            return new MovimientosResponseDto()
            {
                EmailUsuario = movDto.EmailUsuario,
                Movimientos = movimientosDto
            };

        }

        public Task<bool> Extraer(ExtraerRequestDto exDto)
        {
            return Depositar(new DepositarRequestDto()
            {
                Monto = exDto.Monto,
                NumeroCuenta = exDto.NumeroCuenta
            });
        }

        public async Task<double> GetSaldo(string email)
        {
            var saldo = await _context.Usuarios.Where(x => x.Email == email)
                                               .Include(x => x.Cuentas)
                                               .Select(x => x.Cuentas.Sum(x => x.Saldo))
                                               .FirstOrDefaultAsync();

            return saldo;
                               
    }    }
}
