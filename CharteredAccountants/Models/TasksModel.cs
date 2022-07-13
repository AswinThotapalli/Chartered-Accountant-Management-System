using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharteredAccountantsFYP.Models;
using CharteredAccountantsFYP.Helpers;

namespace CharteredAccountantsFYP.Models
{
    public class TasksModel
    {
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Discription { get; set; }
        public string Assignee { get; set; }
        public long AssigneeId { get; set; }
        public string Priority { get; set; }
        public string ImageLink { get; set; }
        public int Status { get; set; }

        public string StatusInline 
        { 
            get
            {
                if (Status == 1)
                { 
                    return "Remaining";
                }
                else
                {
                    return "Finished";
                }
            }
        }

        public string Comment { get; set; }
        public long TaskId { get; set; }

        //public int? StatusLastChangedBy { get; set; }
        //public string StatusLastChangedName 
        //{
            
        //    get
        //    {
        //        return Object.ReturnNamebyId(StatusLastChangedBy);
        //    }
        //}
    }
}