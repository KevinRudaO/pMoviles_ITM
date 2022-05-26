using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using pMoviles_ITM.Models;
using System.Threading.Tasks;

namespace pMoviles_ITM.Datos
{
   public class BrokerPedidos
    {
        private readonly SQLiteAsyncConnection oBaseDatos;

        public BrokerPedidos(string RutaBD)
        {
            oBaseDatos = new SQLiteAsyncConnection(RutaBD);
        }
        public Task<List<viewPedidos>> GetPedidos()
        {
            return oBaseDatos.Table<viewPedidos>().ToListAsync();
        }

        public Task<List<viewPedidos>> GetPedidosXNumero(int NumeroPedido)
        {
            return oBaseDatos.Table<viewPedidos>()
                .Where(pedido => pedido.NumeroPedido == NumeroPedido)
                .ToListAsync();
        }
        public Task<int?> GetNumeroPedido()
        {
            int? NroPedidos = oBaseDatos.ExecuteScalarAsync<int>("SELECT MAX (NumeroPedido)+1 AS NroPedido FROM tblPedidos").Result;
            if (NroPedidos==null)
            {
                NroPedidos = 1;
            }
            return Task.FromResult(NroPedidos);
        }

        public Task<int?> GetPedidosxProducto(int NumeoPedido)
        {
            int? NroPproductos = oBaseDatos.ExecuteScalarAsync<int>("SELECT COUNT(1) AS NroElementos FROM tblPedidos WHERE NumeroPedido = ?;",new string[1] { NumeoPedido.ToString()}).Result;
            if (NroPproductos == null)
            {
                NroPproductos = 0;
            }
            return Task.FromResult(NroPproductos);
        }

        public Task<int> GrabarPedidos(viewPedidos vPedidos)
        {
            if (vPedidos.ID == 0)
            {
                return oBaseDatos.InsertAsync(vPedidos);
            }
            else
            {
                return oBaseDatos.UpdateAsync(vPedidos);
            }
        }
        public Task<int> EliminarPedidos(viewPedidos vPedidos)
        {
            return oBaseDatos.DeleteAsync(vPedidos);
        }
    }
}
