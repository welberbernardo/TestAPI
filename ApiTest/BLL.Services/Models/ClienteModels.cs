using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Models
{
    public class ClienteModels
    {
        public int Id { get; set; }
        public string Nome_Completo { get; set; }
        public int CPF_CNPJ { get; set; }
        public string Ultimo_Negoc { get; set; }
        public string Ref { get; set; }
        public string Endereco { get; set; }
        public string Pais { get; set; }
        public string Nivel_KYC { get; set; }
        public string Email { get; set; }
        public Nullable<int> Telefone { get; set; }
        public Nullable<int> RG { get; set; }
        public Nullable<System.DateTime> Data_Nasc { get; set; }
        public string PPE { get; set; }
        public string Valor_Pret_Nego { get; set; }
        public string Cod_Parceiro { get; set; }
        public string Lim_Anual_BRL { get; set; }
    }
}
