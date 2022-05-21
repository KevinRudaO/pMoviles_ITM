using System;
using System.Collections.Generic;
using System.Text;
using SQLite; //Para crear las tablas
using SQLiteNetExtensions.Attributes; //Para crear las relaciones

namespace pMoviles_ITM.Models
{
    [Table("tblClientes")]
    public class viewCliente
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(20)]
        public string Documento { get; set; }
        [MaxLength(50)]
        public string Nombres { get; set; }
        [MaxLength(80)]
        public string Apellidos { get; set; }
        [MaxLength(20)]
        public string Telefono { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
    }
    [Table("tblProductos")]
    public class viewProductos
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(80)]
        public string Producto { get; set; }
        public double Valor { get; set; }
        public int Inventario { get; set; }
    }
    [Table("tblPedidos")]
    public class viewPedidos
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int NumeroPedido { get; set; }
        [ForeignKey(typeof(viewCliente))]
        public int IDCliente { get; set; }
        [ForeignKey(typeof(viewProductos))]
        public int IDProducto { get; set; }
        [MaxLength(20)]
        public string Fecha { get; set; }
        public int Cantidad { get; set; }
        public double ValorUnitario { get; set; }
    }
}
