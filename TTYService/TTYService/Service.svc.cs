using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TTYService;

namespace TTYService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public List<EntityFornecedor> obterTodos()
        {
            using (TesteEntities contexto = new TesteEntities())
            {
                return contexto.EntityFornecedors.Select(a => new EntityFornecedor
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    Estado = a.Estado,
                    Cidade = a.Cidade,
                    Status = a.Status,
                    Demanda = a.Demanda.Value,
                    Vigencia = a.Vigencia.Date,
                }).ToList();
            }
        }

        public bool editar(EntityFornecedor fornecedor)
        {
            using (TesteEntities contexto = new TesteEntities())
            {
                try
                {
                    EntityFornecedor newFornecedor = contexto.EntityFornecedors.Single(a => a.Id == fornecedor.Id);
                    newFornecedor.Nome = fornecedor.Nome;
                    newFornecedor.Estado = fornecedor.Estado;
                    newFornecedor.Cidade = fornecedor.Cidade;
                    newFornecedor.Status = fornecedor.Status;
                    newFornecedor.Demanda = fornecedor.Demanda;
                    newFornecedor.Vigencia = fornecedor.Vigencia;
                    newFornecedor.contato.nome = fornecedor.contato.nome;
                    newFornecedor.contato.email = fornecedor.contato.email;
                    newFornecedor.contato.email = fornecedor.contato.email;
                    //Salvando as alterações no banco
                    contexto.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
        }

        public bool excluir(EntityFornecedor fornecedor)
        {
            using (TesteEntities contexto = new TesteEntities())
            {
                try
                {
                    EntityFornecedor newFornecedor = contexto.EntityFornecedors.Single(a => a.Id == fornecedor.Id);
                    contexto.EntityFornecedors.Remove(newFornecedor);
                    //Salvando as alterações no banco
                    contexto.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
        }

        public bool novo(EntityFornecedor fornecedor)
        {
            using (TesteEntities contexto = new TesteEntities())
            {
                try
                {
                    EntityFornecedor newFornecedor = new EntityFornecedor();
                    newFornecedor.Nome = fornecedor.Nome;
                    newFornecedor.Estado = fornecedor.Estado;
                    newFornecedor.Cidade = fornecedor.Cidade;
                    newFornecedor.Status = fornecedor.Status;
                    newFornecedor.Demanda = fornecedor.Demanda;
                    newFornecedor.Vigencia = fornecedor.Vigencia;
                    newFornecedor.contato.nome = fornecedor.contato.nome;
                    newFornecedor.contato.email = fornecedor.contato.email;
                    newFornecedor.contato.telefone = fornecedor.contato.telefone;
                    //Adicionando e Salvando as Informações cadastradas
                    contexto.EntityFornecedors.Add(newFornecedor);
                    contexto.SaveChanges();

                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
        }

        public EntityFornecedor obter(string id)
        {

            using (TesteEntities contexto = new TesteEntities())
            {
                int nid = Convert.ToInt32(id);
                return contexto.EntityFornecedors.Where(k => k.Id == nid).Select(k => new EntityFornecedor
                {
                    Id = k.Id,
                    Nome = k.Nome,
                    Estado = k.Estado,
                    Cidade = k.Cidade,
                    Status = k.Status,
                    Demanda = k.Demanda.Value,
                    Vigencia = k.Vigencia,
                }).First();
            }
        }

    }
}







