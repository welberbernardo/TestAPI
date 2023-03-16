using BLL.Services.Models;
using DAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class Operacao
    {
        public List<Models.Controle> GetOperacao()
        {
            var listOperacao = new List<Models.Controle>();
            try
            {
                using (var ctx = new CryptoEntities())
                {
                    //var idParameter = new SqlParameter //
                    //{
                    //    ParameterName = "nome",
                    //    Value = nome
                    //};

                    List<Models.Controle> operacaoList = ctx.Database.SqlQuery<Models.Controle>("exec GetOperacao").ToList<Models.Controle>();

                    if (operacaoList.Count() > 0)
                    {
                        foreach (var item in operacaoList)
                        {
                            listOperacao.Add(new Models.Controle
                            {
                                Id = item.Id,
                                Pedido = item.Pedido,
                                Cripto = item.Cripto,
                                Operacao = item.Operacao,
                                Data = item.Data,
                                Valor_RS = item.Valor_RS,
                                Qtde_Cripto = item.Qtde_Cripto,
                                Taxa_RS = item.Taxa_RS,
                                Taxa_Cripto = item.Taxa_Cripto,
                                Hash = item.Hash,
                                Banco = item.Banco,
                                Id_Cliente = item.Id_Cliente,
                                Cliente = item.Cliente,
                                Ref = item.Ref,
                                Statu_Operacao = item.Statu_Operacao


                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listOperacao;
        }
    }
}
