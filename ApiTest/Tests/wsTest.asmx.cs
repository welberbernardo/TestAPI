using BLL.Services;
using BLL.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Tests
{
    /// <summary>
    /// Summary description for wsTest
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class wsTest : System.Web.Services.WebService
    {

        [WebMethod]
        public List<ClienteModels> GetCliente()
        {
            var listCliente = new List<ClienteModels>();

            try
            {
                ServiceCliente getClientes = new ServiceCliente();
                List<ClienteModels> listClientes = new List<ClienteModels>();

                listClientes.AddRange(getClientes.GetClientes());

                foreach(var item in listClientes)
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listCliente;
        }

        [WebMethod]
        public List<Controle> GetOperacao()
        {
            var listOperacao = new List<Controle>();

            try
            {
                Operacao getOperacao = new Operacao();
                List<Controle> listOperacaos = new List<Controle>();

                listOperacaos.AddRange(getOperacao.GetOperacao());

                foreach (var item in listOperacaos)
                {
                    listOperacao.Add(new Controle
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listOperacao;
        }
    }
}
