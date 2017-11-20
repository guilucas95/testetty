using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace TTYClient.Models
{
    public class FornecedorServiceClient
    {
        private String BASE_URL = "http://localhost:64005/Service.svc/";

        public List<Fornecedor> obterTodos()
        {
            try
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString(BASE_URL + "obterTodos");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Fornecedor>>(json);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Fornecedor obter(string id)
        {
            try
            {
                var webClient = new WebClient();
                string url = string.Format(BASE_URL + "obter/{0}", id);
                var json = webClient.DownloadString(BASE_URL + "obter");
                var js = new JavaScriptSerializer();

                return js.Deserialize<Fornecedor>(json);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool novo(Fornecedor fornecedor)
        {
            try
            {
                DataContractJsonSerializer ser = new  DataContractJsonSerializer(typeof(Fornecedor));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, fornecedor);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-Type"] = "application/json";
                webClient.UploadString(BASE_URL + "novo", "POST", data);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool editar(Fornecedor fornecedor)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Fornecedor));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, fornecedor);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-Type"] = "application/json";
                webClient.UploadString(BASE_URL + "editar", "PUT", data);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool excluir(Fornecedor fornecedor)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Fornecedor));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, fornecedor);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-Type"] = "application/json";
                webClient.UploadString(BASE_URL + "excluir", "DELETE", data);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}