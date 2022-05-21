using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using pMoviles_ITM.Models;
using System.Threading.Tasks;

namespace pMoviles_ITM.Datos
{
    public class BrokerCliente
    {
        private readonly SQLiteAsyncConnection oBaseDatos;

        public BrokerCliente(string RutaBD)
        {
            oBaseDatos = new SQLiteAsyncConnection(RutaBD);
        }
        public Task<List<viewCliente>> GetClientes()
        {
            return oBaseDatos.Table<viewCliente>().ToListAsync();
        }
        public Task<viewCliente> GetClienteXID(int Id)
        {
            return oBaseDatos.Table<viewCliente>()
                .Where(vCliente => vCliente.ID == Id)
                .FirstOrDefaultAsync();
        }
        public Task<viewCliente> GetClienteXDocumento(string Documento)
        {
            return oBaseDatos.Table<viewCliente>()
                .Where(vCliente => vCliente.Documento == Documento)
                .FirstOrDefaultAsync();
        }
        public Task<int> GrabarCliente(viewCliente vCliente)
        {
            if (vCliente.ID == 0)
            {
                return oBaseDatos.InsertAsync(vCliente);
            }
            else
            {
                return oBaseDatos.UpdateAsync(vCliente);
            }
        }
        public Task<int> EliminarCliente(viewCliente vCliente)
        {
            return oBaseDatos.DeleteAsync(vCliente);
        }
    }
}
