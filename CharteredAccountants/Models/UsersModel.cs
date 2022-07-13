using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharteredAccountantsFYP.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool IsOnline { get; set; }
        public string ImageURL { get; set; }
        public string ImageURLDDL { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsPresent { get; set; }
        public DateTime EnteranceTime { get; set; }
        public DateTime ExitTime { get; set; }
    }
}