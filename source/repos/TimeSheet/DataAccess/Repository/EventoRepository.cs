using DataAccess.ExtraModels;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
   public class EventoRepository
    {
        ApplicationDbContext context;
        public EventoRepository(ApplicationDbContext pContext)
        {
            context = pContext;
        }


        public List<Evento> GetAllEvents()
        {
            return context.Evento.ToList();
        }

        public List<Evento> GetEventsByDate(DateTime date)
        {
            return context.Evento.Where(t => t.StartDate.Date == date.Date).ToList();
        }



        public Evento GetEventoById(Guid IdEvento)
        {
            return context.Evento.FirstOrDefault(t => t.Id == IdEvento);
        }



        public void SaveEvento(Evento EventoToSave)
        {
            


            context.Entry(EventoToSave).State = EventoToSave.Id == Guid.Empty ? EntityState.Added : EntityState.Modified;
            context.SaveChanges();


        }

        public List<EventsScheduler> GetAllEventsByUserLogad(Guid guid)
        {


           return context.Evento.Include(t => t.Colaborador)
                           .Include(t => t.Cliente)
                           .Include(t => t.Localizacao)
                           .Include(t => t.TipoServico).Select(t => new EventsScheduler()
                           {

                               Cliente = t.Cliente.Nome,
                               Colaborador = t.Colaborador.Nome,
                               Location = t.Localizacao.Descrição,
                               Subject = t.Colaborador.Nome  + "-"  + t.TipoServico.Descrição,
                               Obs=t.Obs,
                               StartTime=t.StartDate,
                               EndTime=t.EndDate,
                               IsAllDay=true,
                               isBlock=true


                           }).ToList();
          
        }
    }
}
