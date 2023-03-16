using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Models
{
    public class Controle
    {
        public int Id { get; set; }
        public int Pedido { get; set; }
        public string Cripto { get; set; }
        public string Operacao { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public Nullable<decimal> Valor_RS { get; set; }
        public Nullable<int> Qtde_Cripto { get; set; }
        public Nullable<decimal> Taxa_RS { get; set; }
        public Nullable<decimal> Taxa_Cripto { get; set; }
        public string Hash { get; set; }
        public string Banco { get; set; }
        public int Id_Cliente { get; set; }
        public string Cliente { get; set; }
        public string Ref { get; set; }
        public Nullable<bool> Statu_Operacao { get; set; }
    }
}
