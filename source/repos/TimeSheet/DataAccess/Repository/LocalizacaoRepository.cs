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

        public List<Localizacao> GetAllLocalizacao()
        {
            return context.Localizacao.ToList();
        }

        public Localizacao GetColaboradorById(Guid IdLocalizacao)
        {
            return context.Localizacao.FirstOrDefault(t => t.Id == IdLocalizacao);
        }


    }
}
