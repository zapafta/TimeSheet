using DataAccess.ExtraModels;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
   public class LocalizacaoRepository
    {
        ApplicationDbContext context;
        public LocalizacaoRepository(ApplicationDbContext pContext)
        {
            context = pContext;
        }

        public List<SampleObject> GetAllLocalizacao()
        {
         
            var ListReturn = context.Localizacao.Select(t => new SampleObject()
            {
                Id = t.Id,
                Description = t.Descrição

            }).ToList();

            return ListReturn;

        }

        public Localizacao GetColaboradorById(Guid IdLocalizacao)
        {
            return context.Localizacao.FirstOrDefault(t => t.Id == IdLocalizacao);
        }


    }
}
