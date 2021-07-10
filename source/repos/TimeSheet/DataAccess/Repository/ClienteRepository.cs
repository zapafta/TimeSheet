using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
   public class ClienteRepository
    {
        ApplicationDbContext context;
        public ClienteRepository(ApplicationDbContext pContext)
        {
            context = pContext;
        }

        public List<Cliente> GetAllCliente()
        {
            return context.Cliente.ToList();
        }

        public Cliente GetClienteById(Guid IdCliente)
        {
            return context.Cliente.FirstOrDefault(t => t.Id == IdCliente);
        }


    }
}
