using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharteredAccountantsFYP.Models;
using CharteredAccountantsFYP.Helpers;
using System.Drawing;
using System.Collections;
using System.Data.Linq.SqlClient;

namespace CharteredAccountantsFYP.Helpers
{
    public partial class Logic
    {
        // DB object
        DataContext DBContext = new DataContext();

        public static bool IsAuthenticatAdmin(String UserEmailCheck, String password)
        {
            DataContext db = new DataContext();
            TblUser tbl = new TblUser();
            var queryUserName = (from u in db.TblUsers
                                 where u.Email.Equals(UserEmailCheck) &&
                                       u.Password.Equals(password) &&
                                       u.IsAdmin == true &&
                                       u.IsActive == true
                                 select u).FirstOrDefault();

            if (queryUserName == null) // Invalid user name or password
            {
                return false;
            }
            else // Success
            {
                return true;
            }
        }

        public static void Login_IsOnline(int UserId) 
        {
            DataContext db = new DataContext();
            TblUser res = (from u in db.TblUsers
                       where u.Id.Equals(UserId)
                       select u).Single();

            res.IsOnline = true;
            db.SubmitChanges();
        }

        public static void LogOut_IsOnline(int UserId)
        {
            DataContext db = new DataContext();
            TblUser res = (from u in db.TblUsers
                           where u.Id.Equals(UserId)
                           select u).Single();
            res.IsOnline = false;
            db.SubmitChanges();
        }

        public static bool IsAuthenticatUser(String UserEmailCheck, String password)
        {
            DataContext db = new DataContext();
            TblUser tbl = new TblUser();
            var queryUserName = (from u in db.TblUsers
                                 where u.Email.Equals(UserEmailCheck) &&
                                       u.Password.Equals(password) &&
                                       u.IsAdmin == false &&
                                       u.IsActive == true
                                 select u).FirstOrDefault();

            if (queryUserName == null) // Invalid user name or password
            {
                return false;
            }
            else // Success
            {
                return true;
            }
        }

        //public static bool IsAuthenticatUserCheck(String UserEmailCheck, bool check)
        //{
        //    DataContext db = new DataContext();
        //    TblUser tbl = new TblUser();
        //    var queryUserName = (from u in db.TblUsers
        //                         where u.Email.Equals(UserEmailCheck) &&
        //                               u.IsAdmin.Equals(check)
        //                         select u).FirstOrDefault();

        //    if (queryUserName == null) // Invalid user name or password
        //    {
        //        return false;
        //    }
        //    else // Success
        //    {
        //        return true;
        //    }
        //}

        public static void SaveUser(UsersModel model)
        {
            DataContext db = new DataContext();
            TblUser tbl = new TblUser();
            tbl.Name = model.Name;
            tbl.Email = model.Email;
            tbl.Password = model.Password;
            tbl.IsAdmin = false;
            tbl.IsActive = false;
            tbl.CreationDate = System.DateTime.Now;
            tbl.imageURL = model.ImageURL;
            tbl.ImageURL_DDL = model.ImageURLDDL;
            db.TblUsers.InsertOnSubmit(tbl);
            db.SubmitChanges();
            db.Dispose();
        }

        public static void UpdateUser(UsersModel model)
        {
            DataContext db = new DataContext();
            TblUser tbl = (from u in db.TblUsers
                           where u.Id == model.Id
                           select u).FirstOrDefault();

            tbl.Name = model.Name;
            tbl.Email = model.Email;
            if (model.ImageURL != null)
            {
                tbl.imageURL = model.ImageURL;
                tbl.ImageURL_DDL = model.ImageURLDDL;
            }
            db.SubmitChanges();
        }

        public static bool ValidateEmail(String emailToValidate)
        {
            DataContext db = new DataContext();
            TblUser tbl = new TblUser();
            var result = from e in db.TblUsers where e.Email == emailToValidate select e;
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

        public static bool ValidateEmailExcludeCurrentID(String emailToValidate, int ExcludeId)
        {
            DataContext db = new DataContext();
            TblUser tbl = new TblUser();
            var result = from e in db.TblUsers
                         where e.Email == emailToValidate && e.Id != ExcludeId
                         select e;
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
        public static int ReturnID_ByEmail(String Email)
        {
            DataContext db = new DataContext();
            TblUser obj = new TblUser();
            var result = from e in db.TblUsers where e.Email == Email select e;

            obj = result.SingleOrDefault();

            if (obj != null)
            {
                return (int)obj.Id;
            }
            else
            {
                return -1;
            }
        }

        public static string ReturnName_ByEmail(String Email)
        {
            DataContext db = new DataContext();
            TblUser obj = new TblUser();
            var result = from e in db.TblUsers where e.Email == Email select e;

            obj = result.SingleOrDefault();

            if (obj != null)
            {
                return (string)obj.Name;
            }
            else
            {
                return "";
            }
        }

        public static void AddEvent(string Title, string imgURL, string Discription, string Datepicker, int PostedBy)
        {
            DataContext db = new DataContext();
            TblEvent tbl = new TblEvent();
            tbl.Title = Title;
            tbl.IsDeleted = false;
            tbl.imageURL = imgURL;
            tbl.UserId = PostedBy;
            tbl.Discription = Discription;
            tbl.EventDate = Convert.ToDateTime(Datepicker);
            db.TblEvents.InsertOnSubmit(tbl);
            db.SubmitChanges();
            db.Dispose();
        }

        public static void UpdateEvent(int EventId, string title, string discription, string imgURL, string Eventdate, int postedby)
        {
            DataContext db = new DataContext();
            TblTask tbl = new TblTask();

            TblEvent result = (from t in db.TblEvents
                               where t.Id == EventId
                               select t).SingleOrDefault();

            result.Title = title;
            result.Discription = discription;
            result.imageURL = imgURL;
            result.EventDate = Convert.ToDateTime(Eventdate);
            result.UpdatedBy = postedby;
            db.SubmitChanges();
            db.Dispose();
        }

        public static void AddTask(string name, string discription, string imgURL, int assignee, string proirity, int postedby)
        {
            DataContext db = new DataContext();
            TblTask tbl = new TblTask();
            tbl.Name = name;
            tbl.Discription = discription;
            tbl.ImageLink = imgURL;
            tbl.IsDeleted = false;
            tbl.Assignee = assignee;
            tbl.Priority = proirity;
            tbl.Status = 1; //1 for remaining
            tbl.UserId = postedby;
            db.TblTasks.InsertOnSubmit(tbl);
            db.SubmitChanges();
            db.Dispose();
        }

        public static void UpdateTask(int taskId, string name, string discription, string imgURL, int assignee, string proirity, int postedby)
        {
            DataContext db = new DataContext();
            TblTask tbl = new TblTask();

            TblTask result = (from t in db.TblTasks
                              where t.Id == taskId
                              select t).SingleOrDefault();

            result.Name = name;
            result.Discription = discription;
            result.ImageLink = imgURL;
            result.Assignee = assignee;
            result.Priority = proirity;
            result.UpdatedBy = postedby;
            db.SubmitChanges();
            db.Dispose();
        }

        
        public static IQueryable<string> LoadUsersDropDown()
        {
            DataContext db = new DataContext();
            var result = from e in db.TblUsers
                         where e.IsAdmin == false
                         orderby e.Name
                         select e.Name;
            return result;

        }

        public static List<EventsModel> ListEvents()
        {
            DateTime sssss = DateTime.Now;
            DataContext db = new DataContext();
            var result = from e in db.TblEvents
                         join u in db.TblUsers on e.UserId equals u.Id
                         orderby e.Id descending
                         where e.IsDeleted == false
                         && e.EventDate >= DateTime.Now
                         select new EventsModel
                         {
                             Id = e.Id,
                             Title = e.Title,
                             PosterName = u.Name,
                             Discription = e.Discription,
                             EventDate = e.EventDate,
                             ImageLink = e.imageURL
                         };
            return result.ToList();
        }

        public static List<UsersModel> ListDisableUser()
        {
            DataContext db = new DataContext();
            var result = from u in db.TblUsers
                         where u.IsDeleted == false
                         && u.IsActive == false
                         select new UsersModel
                         {
                             Id = u.Id,
                             Name = u.Name,
                             Email = u.Email,
                             CreationDate = u.CreationDate,
                             ImageURL = "~/Uploads/UserImages/" + u.imageURL,
                             IsActive = u.IsActive,
                             IsAdmin = u.IsAdmin
                         };
            return result.ToList();
        }

        public static List<UsersModel> ListAdmins()
        {
            DataContext db = new DataContext();
            var result = from u in db.TblUsers
                         where u.IsDeleted == false
                         && u.IsAdmin == true
                         select new UsersModel
                         {
                             Id = u.Id,
                             Name = u.Name,
                             Email = u.Email,
                             CreationDate = u.CreationDate,
                             ImageURL = "~/Uploads/UserImages/" + u.imageURL,
                             IsActive = u.IsActive,
                             IsAdmin = u.IsAdmin
                         };
            return result.ToList();
        }

        public static List<EventsModel> ListExpiredEvents()
        {
            DataContext db = new DataContext();
            var result = from e in db.TblEvents
                         join u in db.TblUsers on e.UserId equals u.Id
                         orderby e.Id descending
                         where e.IsDeleted == false 
                         && e.EventDate < DateTime.Now
                         select new EventsModel
                         {
                             Id = e.Id,
                             Title = e.Title,
                             PosterName = u.Name,
                             Discription = e.Discription,
                             EventDate = e.EventDate,
                             ImageLink = e.imageURL
                         };
            return result.ToList();
        }


        public static List<TasksModel> ListTasks()
        {
            DataContext db = new DataContext();
            var result = from t in db.TblTasks
                         join u in db.TblUsers on t.Assignee equals u.Id
                         orderby t.Id descending
                         where t.IsDeleted == false
                         && t.Status == 1
                         select new TasksModel
                         {
                             Name = t.Name,
                             Id = t.Id,
                             Priority = t.Priority,
                             Assignee = u.Name,
                             Discription = t.Discription,
                             ImageLink = t.ImageLink,
                             Status = t.Status
                         };
            return result.ToList();
        }

        public static List<TasksModel> ListUserTasks(int userId)
        {
            DataContext db = new DataContext();
            var result = from t in db.TblTasks
                         join u in db.TblUsers on t.Assignee equals u.Id
                         orderby t.Id descending
                         where t.IsDeleted == false 
                         && (t.Assignee == userId && t.Status == 1)
                         select new TasksModel
                         {
                             Name = t.Name,
                             Id = t.Id,
                             Priority = t.Priority,
                             Assignee = u.Name,
                             Discription = t.Discription,
                             ImageLink = t.ImageLink,
                             Status = t.Status
                         };
            return result.ToList();
        }

        public static List<TasksModel> ListUserProfileTasks(int userId)
        {
            DataContext db = new DataContext();
            var result = from t in db.TblTasks
                         join u in db.TblUsers on t.Assignee equals u.Id
                         orderby t.Id descending
                         where t.IsDeleted == false
                         && t.StatusChangedBy == userId
                         && t.Status == 2

                         select new TasksModel
                         {
                             Name = t.Name,
                             Id = t.Id,
                             Priority = t.Priority,
                             Assignee = u.Name,
                             Discription = t.Discription,
                             ImageLink = t.ImageLink,
                             Status = t.Status
                         };
            return result.ToList();
        }

        public static List<TasksModel> ListResolvedTasks()
        {
            DataContext db = new DataContext();
            var result = from t in db.TblTasks
                         join u in db.TblUsers on t.Assignee equals u.Id
                         orderby t.Id descending
                         where t.IsDeleted == false
                         && t.Status == 2

                         select new TasksModel
                         {
                             Name = t.Name,
                             Id = t.Id,
                             Priority = t.Priority,
                             Assignee = u.Name,
                             Discription = t.Discription,
                             ImageLink = t.ImageLink,
                             Status = t.Status
                         };
            return result.ToList();
        }

        public static List<UsersModel> LoadUsers()
        {
            DataContext db = new DataContext();
            var result = from u in db.TblUsers
                         where u.IsDeleted == false
                         select new UsersModel
                         {
                             Id = u.Id,
                             Name = u.Name,
                             Email = u.Email,
                             CreationDate = u.CreationDate,
                             ImageURL = "~/Uploads/UserImages/" + u.imageURL,
                             IsActive = u.IsActive,
                             IsAdmin = u.IsAdmin,
                             Password = u.Password
                         };
            return result.ToList();
        }
        public static Image ScaleImage(System.Drawing.Image image, int maxHeight)
        {
            var ratio = (double)maxHeight / image.Height;

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        public static long ReturnLastUserId()
        {
            DataContext db = new DataContext();
            TblUser obj = new TblUser();

            var result = (from e in db.TblUsers
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

        public static long ReturnLastIssueId()
        {
            DataContext db = new DataContext();
            TblTask obj = new TblTask();

            var result = (from e in db.TblTasks
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
        public static int ReturnLastEventId()
        {
            DataContext db = new DataContext();
            TblEvent obj = new TblEvent();

            var result = (from e in db.TblEvents
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
        public static EventsModel ListViewEvents(int Id)
        {
            DataContext db = new DataContext();
            var result = from e in db.TblEvents
                         join u in db.TblUsers on e.UserId equals u.Id
                         where e.Id == Id
                         select new EventsModel
                         {
                             Id = e.Id,
                             Title = e.Title,
                             PosterName = u.Name,
                             Discription = e.Discription,
                             EventDate = e.EventDate,
                             ImageLink = e.imageURL
                         };

            if (result.Count() > 0)
                return result.ToList()[0];
            else
                return new EventsModel();
        }

        public static TasksModel ListViewTasks(int Id)
        {
            DataContext db = new DataContext();
            var result = from t in db.TblTasks
                         join u in db.TblUsers on t.Assignee equals u.Id
                         where t.Id == Id
                         select new TasksModel
                         {
                             Name = t.Name,
                             Id = t.Id,
                             Priority = t.Priority,
                             AssigneeId = t.Assignee,
                             Assignee = u.Name,
                             Email = u.ImageURL_DDL,
                             Discription = t.Discription,
                             ImageLink = t.ImageLink,
                             Status = t.Status,
                         };

            if (result.Count() > 0)
                return result.ToList()[0];
            else
                return new TasksModel();
        }

        public static void UpdateIssueStatus(int IssueId, int CurrentUserId, int statusValue)
        {
            DataContext db = new DataContext();
            TblTask result = (from t in db.TblTasks
                              where t.Id == IssueId
                              select t).Single();
            result.Status = statusValue;
            result.StatusChangedBy = CurrentUserId;
            db.SubmitChanges();
        }

        public string ReturnNamebyId(int Id)
        {
            TblUser res = (from t in DBContext.TblTasks
                           join u in DBContext.TblUsers on t.StatusChangedBy equals u.Id
                           where t.Id == Id
                           select u).SingleOrDefault();
            if (res == null)
            {
                return "";
            }
            else
            {
                return res.Name;
            }
        }

        public static void DeleteTask(int Id)
        {
            try
            {
                DataContext db = new DataContext();
                TblTask result = (from t in db.TblTasks
                                  where t.Id == Id
                                  select t).Single();
                result.IsDeleted = true;
                db.SubmitChanges();
                db.Dispose();
            }
            catch (Exception e)
            {

            }
        }

        public static void DeleteEvent(int Id)
        {
            try
            {
                DataContext db = new DataContext();
                TblEvent result = (from e in db.TblEvents
                                  where e.Id == Id
                                  select e).Single();
                result.IsDeleted = true;
                db.SubmitChanges();
                db.Dispose();
                //DataContext db = new DataContext();
                //db.TblEvents.DeleteOnSubmit(db.TblEvents.Single(e => e.Id == Id));
                //db.SubmitChanges();
                //db.Dispose();
            }
            catch (Exception e)
            {

            }
        }

        
        public static void AddClient(ClientsModel model, ServicesModel ModelServices, int postedbyId)
        {
            DataContext db = new DataContext();
            TblClient tbl = new TblClient();
            TblBusinessType tblBusinessType = new TblBusinessType();
            tbl.Name = model.Name;
            
            tbl.TypeOfCompany = model.TypeOfCompany;
            tbl.LimitedBy = model.LimitedBy;
            tbl.ShareValue1 = model.ShareValue1;
            tbl.ShareValue2 = model.ShareValue2;
            tbl.ShareCapitalProduct = model.ProductOfShareValues;
            tbl.BusinessObjectives = model.BusinessObjectives;
            tbl.CNIC = model.CNIC;

            tbl.NTN = model.NTN;
            tbl.PINCode = model.PINCode;
            tbl.FBRLogin = model.FBRLogin;
            tbl.FBRPassword = model.FBRPassword;

            tbl.IncorporationNo = model.IncorporationNo;
            tbl.RegistrationNo = model.RegistrationNo;
            tbl.RegisteredWith = model.RegisteredWith;
            tbl.Address = model.Address;
            tbl.Email = model.Email;
            tbl.PhoneNo = model.PhoneNo;
            tbl.MobileNo = model.MobileNo;
            tbl.FaxNo = model.FaxNo;
            tbl.CreatedById = postedbyId;
            tbl.CreatedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            tbl.IsActive = true;
            db.TblClients.InsertOnSubmit(tbl);
            
            db.SubmitChanges();

            TblService tblServices = new TblService();
            var res = (from c in db.TblClients
                          orderby c.Id descending
                          select c).FirstOrDefault();
            tbl = res;
            int currentClientId = tbl.Id;
            tblServices.ClientId = currentClientId;

            tblBusinessType.BusinessType = model.BusinessType;
            tblBusinessType.ClientId = currentClientId;
            tblServices.Accounting = true ? ModelServices.Accounting == "Accounting" : false;
            tblServices.Audit = true ? ModelServices.Audit == "Audit" : false;
            tblServices.Legal = true ? ModelServices.Legal == "Legal" : false;
            tblServices.Taxation = true ? ModelServices.Taxation == "Taxation" : false;
            tblServices.Corporate = true ? ModelServices.Corporate == "Corporate" : false;

            db.TblBusinessTypes.InsertOnSubmit(tblBusinessType);
            db.TblServices.InsertOnSubmit(tblServices);
            db.SubmitChanges();
            db.Dispose();
            //UpdateAndSaveService( ModelServices, currentClientId);
           
        }

        public static void UpdatedClient(ClientsModel model, ServicesModel ModelServices, int postedbyId, int ClientId)
        {
            DataContext db = new DataContext();

            TblClient result = (from c in db.TblClients
                                   where c.Id == ClientId
                                   select c).Single();
            result.Name = model.Name;
            result.TypeOfCompany = model.TypeOfCompany;
            result.LimitedBy = model.LimitedBy;
            result.BusinessObjectives = model.BusinessObjectives;
            result.ShareValue1 = model.ShareValue1;
            result.ShareValue2 = model.ShareValue2;
            result.ShareCapitalProduct = model.ProductOfShareValues;
            result.CNIC = model.CNIC;
            result.IncorporationNo = model.IncorporationNo;
            result.RegistrationNo = model.RegistrationNo;
            result.RegisteredWith = model.RegisteredWith;
            result.Address = model.Address;
            result.Email = model.Email;
            result.PhoneNo = model.PhoneNo;
            result.MobileNo = model.MobileNo;
            result.FaxNo = model.FaxNo;
            result.UpdatedById = postedbyId;
            result.UpdatedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            db.SubmitChanges();

            /****************************************************************************************/

            TblService resultServices = (from s in db.TblServices
                                   where s.ClientId == ClientId
                                   select s).SingleOrDefault();
            resultServices.Accounting = true ? ModelServices.Accounting == "Accounting" : false;
            resultServices.Audit = true ? ModelServices.Audit == "Audit" : false;
            resultServices.Legal = true ? ModelServices.Legal == "Legal" : false;
            resultServices.Taxation = true ? ModelServices.Taxation == "Taxation" : false;
            resultServices.Corporate = true ? ModelServices.Corporate == "Corporate" : false;

            /***************************************************************************************/

            TblBusinessType resultBusinessType = (from b in db.TblBusinessTypes
                                         where b.ClientId == ClientId
                                         select b).SingleOrDefault();
            resultBusinessType.BusinessType = model.BusinessType;
            db.SubmitChanges();
            db.Dispose();
        }
        
        public static List<ClientsModel> ReturnSearchValues(string searchValue)
        {
            DataContext db = new DataContext();
            TblClient tblClient = new TblClient();

            var result = from c in db.TblClients
                         join s in db.TblServices on c.Id equals s.ClientId
                         join b in db.TblBusinessTypes on c.Id equals b.ClientId
                         where c.Name.Contains(searchValue) || string.IsNullOrEmpty(searchValue)
                         || c.CNIC.Contains(searchValue) || string.IsNullOrEmpty(searchValue)
                         || c.IncorporationNo.Contains(searchValue) || string.IsNullOrEmpty(searchValue)
                         || c.RegistrationNo.Contains(searchValue) || string.IsNullOrEmpty(searchValue)
                         || c.Email.Contains(searchValue) || string.IsNullOrEmpty(searchValue)
                         select new ClientsModel
                         {
                               Id = c.Id,
                               Name = c.Name,
                               TypeOfCompany = c.TypeOfCompany,
                               BusinessType = b.BusinessType,
                               LimitedBy = c.LimitedBy,
                               BusinessObjectives = c.BusinessObjectives,
                               ProductOfShareValues = c.ShareCapitalProduct,
                               ServiceAudit = s.Audit,
                               ServiceCorporate = s.Corporate,
                               ServiceAccounting = s.Accounting,
                               ServiceLegal = s.Legal,
                               ServiceTaxation = s.Taxation,
                               CNIC = c.CNIC,
                               IncorporationNo = c.IncorporationNo,
                               RegistrationNo = c.RegistrationNo,
                               RegisteredWith = c.RegisteredWith,
                               Address = c.Address,
                               Email = c.Email,
                               PhoneNo = c.PhoneNo,
                               MobileNo = c.MobileNo,
                               FaxNo = c.FaxNo
                         };
            return result.ToList();
        }

        public static ClientsModel ReturnEditedClientValues(int c_Id)
        {
            DataContext db = new DataContext();
            var result = (from c in db.TblClients
                         join s in db.TblServices on c.Id equals s.ClientId
                         join b in db.TblBusinessTypes on c.Id equals b.ClientId
                         where c.Id == c_Id
                         select new ClientsModel
                         {
                             Id = c.Id,
                             Name = c.Name,
                             TypeOfCompany = c.TypeOfCompany,
                             BusinessType = b.BusinessType,
                             LimitedBy = c.LimitedBy,
                             BusinessObjectives = c.BusinessObjectives,
                             ShareValue1 = c.ShareValue1,
                             ShareValue2 = c.ShareValue2,
                             ProductOfShareValues = c.ShareCapitalProduct,
                             ServiceAudit = s.Audit,
                             ServiceCorporate = s.Corporate,
                             ServiceAccounting = s.Accounting,
                             ServiceLegal = s.Legal,
                             ServiceTaxation = s.Taxation,
                             CNIC = c.CNIC,
                             IncorporationNo = c.IncorporationNo,
                             NTN = c.NTN,
                             PINCode = c.PINCode,
                             FBRLogin = c.FBRLogin,
                             FBRPassword = c.FBRPassword,
                             RegistrationNo = c.RegistrationNo,
                             RegisteredWith = c.RegisteredWith,
                             Address = c.Address,
                             Email = c.Email,
                             PhoneNo = c.PhoneNo,
                             MobileNo = c.MobileNo,
                             FaxNo = c.FaxNo
                         }).FirstOrDefault();
                return result;
 
        }

        public static void EnableOrDisableUser(int enableId) 
        {
            TblUser user = new TblUser();
            DataContext db = new DataContext();
            TblUser res = (from u in db.TblUsers
                          where u.Id == enableId
                          select u).SingleOrDefault();
            res.IsActive = true ? res.IsActive == false : false;
            db.SubmitChanges();
        }

        public static void DeleteUser(int Id)
        {
            try
            {
                DataContext db = new DataContext();
                TblUser res = (from e in db.TblUsers
                               where e.Id == Id
                               select e).SingleOrDefault();
                res.IsDeleted = true;
                db.SubmitChanges();

                //DataContext db = new DataContext();
                //db.TblUsers.DeleteOnSubmit(db.TblUsers.Single(u => u.Id == Id));
                //db.SubmitChanges();
                //db.Dispose();
            }
            catch (Exception e)
            {

            }
        }
        public static void ChangeAdminPower(int userId)
        {
            TblUser user = new TblUser();
            DataContext db = new DataContext();
            TblUser res = (from u in db.TblUsers
                           where u.Id == userId
                           select u).SingleOrDefault();
            res.IsAdmin = true ? res.IsAdmin == false : false;
            db.SubmitChanges();
        }
    }
}