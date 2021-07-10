using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
   public class TipoServicoRepository
    {
        ApplicationDbContext context;
        public TipoServicoRepository(ApplicationDbContext pContext)
        {
            context = pContext;
        }

        public List<TipoServico> GetAllTipoServico()
        {
            return context.TipoServico.ToList();
        }

        public TipoServico GetTipoServicoById(Guid IdTipoServico)
        {
            return context.TipoServico.FirstOrDefault(t => t.Id == IdTipoServico);
        }


    }
}
