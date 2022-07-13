using CharteredAccountantsFYP.Models;
using CharteredAccountantsFYP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharteredAccountantsFYP.Helpers
{
    public partial class Logic
    {
        //public static List<TasksModel> ListUserTasks(int userId)
        //{
        //    DataContext db = new DataContext();
        //    var result = from t in db.TblTasks
        //                 join u in db.TblUsers on t.Assignee equals u.Id
        //                 orderby t.Id descending
        //                 where t.IsDeleted == false && t.Assignee == userId
        //                 select new TasksModel
        //                 {
        //                     Name = t.Name,
        //                     Id = t.Id,
        //                     Priority = t.Priority,
        //                     Assignee = u.Name,
        //                     Discription = t.Discription,
        //                     ImageLink = t.ImageLink,
        //                     Status = t.Status
        //                 };
        //    return result.ToList();
        //}

        public static void UpdatedPassword(int id, string pass)
        {
            TblUser user = new TblUser();
            DataContext db = new DataContext();
            TblUser res = (from u in db.TblUsers
                           where u.Id == id
                           select u).SingleOrDefault();
            res.Password = pass;
            db.SubmitChanges();
        }

        public static bool CheckCurrentPassword(int id,string c_pass)
        {
            TblUser user = new TblUser();
            DataContext db = new DataContext();
            var res = (from u in db.TblUsers
                       where u.Password == c_pass && u.Id == id
                       select u).FirstOrDefault();
            if (res != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static UsersModel ReturnUsersList(int Currentid)
        {
            TblUser user = new TblUser();
            DataContext db = new DataContext();
            var res = (from u in db.TblUsers
                       where u.Id == Currentid
                       select new UsersModel 
                       {
                           Id = u.Id,
                           Name = u.Name,
                           Email = u.Email,
                           ImageURL = u.imageURL,
                           ImageURLDDL = u.ImageURL_DDL
                       }).FirstOrDefault();
            return res;
        }

        public static void SaveTasksRemark(int currentId, int taskId, string comment)
        {
            DataContext db = new DataContext();
            TblTasksRemark tbl = new TblTasksRemark();
            tbl.CommenterId = currentId;
            tbl.TaskId = taskId;
            tbl.Comment = comment;
            db.TblTasksRemarks.InsertOnSubmit(tbl);
            db.SubmitChanges();
            db.Dispose();
        }

        public static void SaveEventsRemark(int currentId, int eventId, string comment)
        {
            DataContext db = new DataContext();
            TblEventsRemark tbl = new TblEventsRemark();
            tbl.CommenterId = currentId;
            tbl.EventId = eventId;
            tbl.Comment = comment;
            db.TblEventsRemarks.InsertOnSubmit(tbl);
            db.SubmitChanges();
            db.Dispose();
        }


        public static List<TasksModel> ListTaskComments(int taskId)
        {
            DataContext db = new DataContext();
            var result = from t in db.TblTasksRemarks
                         join u in db.TblUsers on t.CommenterId equals u.Id
                         where t.TaskId == taskId
                         orderby t.Id descending
                         select new TasksModel
                         {
                             Id = t.Id,
                             Name = u.Name,
                             Comment = t.Comment
                         };
            return result.ToList();
        }

        public static List<EventsModel> ListEventsComments(int eventId)
        {
            DataContext db = new DataContext();
            var result = from e in db.TblEventsRemarks
                         join u in db.TblUsers on e.CommenterId equals u.Id
                         where e.EventId == eventId
                         orderby e.Id descending
                         select new EventsModel
                         {
                             Id = e.Id,
                             Name = u.Name,
                             Comment = e.Comment
                         };
            return result.ToList();
        }

        public static ClientsModel returnClientAuditDataByClientIdAndYear(int clientId, int year)
        {
            DataContext db = new DataContext();
            var result = from a in db.TblAudits
                         join c in db.TblClients on a.ClientId equals c.Id
                         join u in db.TblUsers on a.UserId equals u.Id
                         join y in db.TblYears on a.YearId equals y.Id
                         where a.ClientId == clientId && y.Year == year
                         select new ClientsModel
                         {
                             Id = a.Id,
                             Name = u.Name,
                             FilePathNew = a.FilePathNew,
                             FilePathOld = a.FilePathOld,
                             LastChanges = a.LastChangesInfo
                         };
            return result.FirstOrDefault();
        }

        public static ClientsModel returnClientCorporateDataByClientIdAndYear(int clientId, int year)
        {
            DataContext db = new DataContext();
            var result = from a in db.TblCorporates
                         join c in db.TblClients on a.ClientId equals c.Id
                         join u in db.TblUsers on a.UserId equals u.Id
                         join y in db.TblYears on a.YearId equals y.Id
                         where a.ClientId == clientId && y.Year == year
                         select new ClientsModel
                         {
                             Id = a.Id,
                             Name = u.Name,
                             FilePathNew = a.FilePathNew,
                             FilePathOld = a.FilePathOld,
                             LastChanges = a.LastChangesInfo
                         };
            return result.FirstOrDefault();
        }

        public static ClientsModel returnClientTaxDataByClientIdAndYear(int clientId, int year)
        {
            DataContext db = new DataContext();
            var result = from a in db.TblTaxes
                         join c in db.TblClients on a.ClientId equals c.Id
                         join u in db.TblUsers on a.UserId equals u.Id
                         join y in db.TblYears on a.YearId equals y.Id
                         where a.ClientId == clientId && y.Year == year
                         select new ClientsModel
                         {
                             Id = a.Id,
                             Name = u.Name,
                             FilePathNew = a.FilePathNew,
                             FilePathOld = a.FilePathOld,
                             LastChanges = a.LastChangesInfo
                         };
            return result.FirstOrDefault();
        }
        public static void SaveClientAudit(ClientsModel model, int clientId)
        {
            DataContext db = new DataContext();
            TblAudit tbl = new TblAudit();
            tbl.UpdatedBy = model.UpdatedById;
            tbl.FilePathNew = model.FilePathNew;
            tbl.FilePathOld = model.FilePathOld;
            tbl.ClientId = clientId;
            tbl.UserId = model.UserId;
            tbl.YearId = model.YearId;
            tbl.LastChangesInfo = model.LastChanges;
            db.TblAudits.InsertOnSubmit(tbl);
            db.SubmitChanges();
            db.Dispose();
        }

        public static void UpdateClientAudit(ClientsModel model, int clientId)
        {
            DataContext db = new DataContext();
            TblAudit result = (from a in db.TblAudits
                         join c in db.TblClients on a.ClientId equals c.Id
                         join u in db.TblUsers on a.UserId equals u.Id
                         join y in db.TblYears on a.YearId equals y.Id
                         where a.ClientId == clientId && y.Year == model.Year
                         select a).SingleOrDefault();
            result.LastChangesInfo = model.LastChanges;
            result.FilePathNew = model.FilePathNew;
            result.FilePathOld= model.FilePathOld;
            result.UpdatedBy = model.UpdatedById;
            result.UserId = model.UserId;
            InsertForUniqueId();
            db.SubmitChanges();
        }

        public static void SaveClientCorporate(ClientsModel model, int clientId)
        {
            DataContext db = new DataContext();
            TblCorporate tbl = new TblCorporate();
            tbl.UpdatedBy = model.UpdatedById;
            tbl.FilePathNew = model.FilePathNew;
            tbl.FilePathOld = model.FilePathOld;
            tbl.ClientId = clientId;
            tbl.UserId = model.UserId;
            tbl.YearId = model.YearId;
            tbl.LastChangesInfo = model.LastChanges;
            db.TblCorporates.InsertOnSubmit(tbl);
            db.SubmitChanges();
            db.Dispose();
        }

        public static void UpdateClientCorporate(ClientsModel model, int clientId)
        {
            DataContext db = new DataContext();
            TblCorporate result = (from a in db.TblCorporates
                               join c in db.TblClients on a.ClientId equals c.Id
                               join u in db.TblUsers on a.UserId equals u.Id
                               join y in db.TblYears on a.YearId equals y.Id
                               where a.ClientId == clientId && y.Year == model.Year
                               select a).SingleOrDefault();
            result.LastChangesInfo = model.LastChanges;
            result.FilePathNew = model.FilePathNew;
            result.FilePathOld = model.FilePathOld;
            result.UpdatedBy = model.UpdatedById;
            result.UserId = model.UserId;
            InsertForUniqueId();
            db.SubmitChanges();
        }

        public static void SaveClientTax(ClientsModel model, int clientId)
        {
            DataContext db = new DataContext();
            TblTax tbl = new TblTax();
            tbl.UpdatedBy = model.UpdatedById;
            tbl.FilePathNew = model.FilePathNew;
            tbl.FilePathOld = model.FilePathOld;
            tbl.ClientId = clientId;
            tbl.UserId = model.UserId;
            tbl.YearId = model.YearId;
            tbl.LastChangesInfo = model.LastChanges;
            db.TblTaxes.InsertOnSubmit(tbl);
            db.SubmitChanges();
            db.Dispose();
        }

        public static void UpdateClientTax(ClientsModel model, int clientId)
        {
            DataContext db = new DataContext();
            TblTax result = (from a in db.TblTaxes
                                   join c in db.TblClients on a.ClientId equals c.Id
                                   join u in db.TblUsers on a.UserId equals u.Id
                                   join y in db.TblYears on a.YearId equals y.Id
                                   where a.ClientId == clientId && y.Year == model.Year
                                   select a).SingleOrDefault();
            result.LastChangesInfo = model.LastChanges;
            result.FilePathNew = model.FilePathNew;
            result.FilePathOld = model.FilePathOld;
            result.UpdatedBy = model.UpdatedById;
            result.UserId = model.UserId;
            InsertForUniqueId();
            db.SubmitChanges();
        }

        public static int ReturnLastAuditId()
        {
            DataContext db = new DataContext();
            TblAudit obj = new TblAudit();
            var result = (from e in db.TblAudits
                          orderby e.Id descending
                          select e).FirstOrDefault();
            obj = result;
            if (result != null)
            {
                return obj.Id;
            }
            else
            {
                return 0;
            }
        }

        public static int ReturnLastCorporateId()
        {
            DataContext db = new DataContext();
            TblCorporate obj = new TblCorporate();
            var result = (from e in db.TblCorporates
                          orderby e.Id descending
                          select e).FirstOrDefault();
            obj = result;
            if (result != null)
            {
                return obj.Id;
            }
            else
            {
                return 0;
            }
        }

        public static void InsertForUniqueId()
        {
            DataContext db = new DataContext();
            TblCounter tbl = new TblCounter();
            tbl.count = "1";
            db.TblCounters.InsertOnSubmit(tbl);
            db.SubmitChanges();
            db.Dispose();
        }


        public static int ReturnUniqueId()
        {
            DataContext db = new DataContext();
            TblCounter obj = new TblCounter();

            var result = (from e in db.TblCounters
                          orderby e.Id descending
                          select e).FirstOrDefault();
            obj = result;
            if (result != null)
            {
                return obj.Id;
            }
            else
            {
                return 0;
            }

        }

        public static void AddNewYear(int year)
        {
            DataContext db = new DataContext();
            TblYear tbl = new TblYear();
            tbl.Year = year;
            db.TblYears.InsertOnSubmit(tbl);
            db.SubmitChanges();
            db.Dispose();
        }

        public static bool ValidateYear(int yearToValidated)
        {
            DataContext db = new DataContext();
            TblYear tbl = new TblYear();
            var result = from e in db.TblYears where e.Year == yearToValidated select e;
            tbl = result.SingleOrDefault();

            if (tbl == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ReturnImageURLByEmail(string email)
        {
            DataContext db = new DataContext();
            TblUser res = (from u in db.TblUsers
                           where u.Email == email
                           select u).SingleOrDefault();
            if (res == null)
            {
                return "";
            }
            else
            {
                return res.ImageURL_DDL;
            }
        }

        public static List<UsersModel> ShowOnlineUsers()
        {
            DataContext db = new DataContext();
            var result = from u in db.TblUsers
                         where u.IsOnline == true
                         orderby u.Id
                         select new UsersModel
                         {
                             Id = u.Id,
                             Name = u.Name,
                             Email = u.Email,
                             ImageURL = "~/Uploads/UserImages/" + u.imageURL
                         };
            return result.ToList();
        }

        public static List<UsersModel> ViewAttendance()
        {
            DataContext db = new DataContext();
            var result = from att in db.tblAttendances
                         join u in db.TblUsers on att.UserId equals u.Id
                         orderby att.Id
                         select new UsersModel
                         {
                             Id = u.Id,
                             Name = u.Name,
                             Email = u.Email,
                             EnteranceTime = att.EnteranceTime,
                             ExitTime = att.ExitTime,
                             IsPresent = att.IsPresent,
                             ImageURL = "~/Uploads/UserImages/" + u.imageURL
                         };
            return result.ToList();
        }

    }
}