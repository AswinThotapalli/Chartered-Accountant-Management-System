using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharteredAccountantsFYP.Models
{
    public class EventsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public string PosterName { get; set; }
        public DateTime EventDate { get; set; }
        public string ShortEventDate
        { 
            get
            {
                return EventDate.ToString("dd/MM/yy");
            }
        }
        public string ImageLink { get; set; }

        public string Name { get; set; }
        public string Comment { get; set; }
        public long TaskId { get; set; }
    }
}