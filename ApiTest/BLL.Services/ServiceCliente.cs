using BLL.Services.Models;
using DAL.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ServiceCliente
    {
        public List<ClienteModels> GetClientes()
        {
            var listCliente = new List<ClienteModels>();
            try
            {
                using (var ctx = new CryptoEntities())
                {
                    //var idParameter = new SqlParameter //
                    //{
                    //    ParameterName = "nome",
                    //    Value = nome
                    //};

                    List<ClienteModels> nomeList = ctx.Database.SqlQuery<ClienteModels>("exec GetCliente").ToList<ClienteModels>();

                    if (nomeList.Count() > 0)
                    {
                        foreach (var item in nomeList)
                        {
                            listCliente.Add(new ClienteModels
                            {
                                Id = item.Id,
                                Nome_Completo = item.Nome_Completo,
                                CPF_CNPJ = item.CPF_CNPJ,
                                Ultimo_Negoc = item.Ultimo_Negoc,
                                Ref = item.Ref,
                                Endereco = item.Endereco,
                                Pais = item.Pais,
                                Nivel_KYC = item.Nivel_KYC,
                                Email = item.Email,
                                Telefone = item.Telefone,
                                RG = item.RG,
                                Data_Nasc = item.Data_Nasc,
                                PPE = item.PPE,
                                Valor_Pret_Nego = item.Valor_Pret_Nego,
                                Cod_Parceiro = item.Cod_Parceiro,
                                Lim_Anual_BRL = item.Lim_Anual_BRL


                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listCliente;
        }
    }
}
