using DataAccess.ExtraModels;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
   public class ColaboradorRepository
    {
        ApplicationDbContext context;
        public ColaboradorRepository(ApplicationDbContext pContext)
        {
            context = pContext;
        }

        public List<Colaborador> GetAllColaboradores()
        {
            return context.Colaborador.ToList();
        }

        public Colaborador  GetColaboradorById(Guid IdColaborador)
        {
            return context.Colaborador.FirstOrDefault(t => t.Id == IdColaborador);
        }


        public List<SampleObject> GetAllColaboradoresSampleObject()
        {

            var ListReturn = context.Colaborador.Select(t => new SampleObject()
            {
                Id = t.Id,
                Description = t.Nome

            }).ToList();

            return ListReturn;

        }


    }
}
