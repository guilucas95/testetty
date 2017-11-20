using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TTYService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService


    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "obterTodos", ResponseFormat =
            WebMessageFormat.Json)]
        List<EntityFornecedor> obterTodos();
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "obter/{id}", ResponseFormat =
            WebMessageFormat.Json)]
        EntityFornecedor obter(string id);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "novo", ResponseFormat =
           WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool novo(EntityFornecedor fornecedor);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "editar", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool editar(EntityFornecedor fornecedor);


        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "excluir", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool excluir(EntityFornecedor fornecedor);

    }
}
