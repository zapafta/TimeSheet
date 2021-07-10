using DataAccess.ExtraModels;
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


        public List<SampleObject> GetAllTipoServicoToObjectSample()
        {


            var ListReturn = context.TipoServico.Select(t => new SampleObject()
            {
                Id=t.Id,
                Description=t.Descrição

            }).ToList();

            return ListReturn;
        }

    }

}

