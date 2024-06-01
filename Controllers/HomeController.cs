using ASCO.Models;
using ASCO.Services;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ASCO.Controllers
{
    public class HomeController : Controller
    {
        DBACSOEntities db = new DBACSOEntities();
        Models.DBACSOEntities entity = new DBACSOEntities();

        public LoanService loanService = new LoanService();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(Admin adm)
        {
            if (string.IsNullOrWhiteSpace(adm.admin_pass))
            {
                ModelState.AddModelError("admin_pass", "Password cannot be empty.");

                return View(adm);
            }
            var checkLogin = db.Admins.Where(x => x.admin_name.Equals(adm.admin_name) && x.admin_pass.Equals(adm.admin_pass)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["admin_id"] = adm.admin_id.ToString();
                Session["admin_name"] = adm.admin_name.ToString();
                return RedirectToAction("AdminPage", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "Incorrect Credentials";
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult AdminPage()
        {
            return View();
        }

        public ActionResult ListFarmers()
        {
            var data = entity.Farmers.ToList();
            return View(data);
        }

        public ActionResult ListFarmersCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListFarmersCreate(Farmer farmer)
        {
            try
            {
                db.Farmers.Add(farmer);
                db.SaveChanges();
                TempData["Message"] = "A user for farmer was created succesfully";
                return RedirectToAction("ListFarmers", "Home");

            }
            catch (Exception ex)
            {
                TempData["Message"] = "Failed to create a user " + ex.Message;
                return View(farmer);
            }
        }

        public ActionResult ListFarmersEdit(int id)
        {
            var farmer = db.Farmers.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListFarmersEdit(Farmer f)
        {
            try
            {
                db.Entry(f).State = EntityState.Modified;
                TempData["Message"] = "Data Updated Succesfully!";
                db.SaveChanges();
                return RedirectToAction("ListFarmers", "Home");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Failed to update data: " + ex.Message;
                return View();
            }
        }

        public ActionResult ListFarmersDelete(int id)
        {
            var farmer = db.Farmers.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        [HttpPost]
        [ActionName("ListFarmersDelete")]
        public ActionResult ListFarmersDeleteConfirmed(int id)
        {
            try
            {
                var farmer = db.Farmers.Find(id);
                if (farmer == null)
                {
                    return HttpNotFound();
                }
                db.Farmers.Remove(farmer);
                db.SaveChanges();
                TempData["Message"] = "Data Deleted Successfully!";
                return RedirectToAction("ListFarmers", "Home");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Failed to Delete Data " + ex.Message;
                return RedirectToAction("ListFarmers", "Home");
            }
        }

        public ActionResult ListMachineries()
        {
            var data = entity.Machineries.ToList();
            return View(data);
        }

        public ActionResult ListMachineriesCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListMacheneriesCreate(Machinery machinery)
        {
            try
            {
                db.Machineries.Add(machinery);
                db.SaveChanges();
                TempData["Message"] = "A new machinery was added succesfully";
                return RedirectToAction("ListMachinery", "Home");

            }
            catch (Exception ex)
            {
                TempData["Message"] = "Failed to create a user " + ex.Message;
                return View(machinery);
            }
        }

        public ActionResult ListMachineriesEdit(int id)
        {
            var machinery = db.Machineries.Find(id);
            if (machinery == null)
            {
                return HttpNotFound();
            }
            return View(machinery);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListMachineriesEdit(Machinery m)
        {
            try
            {
                db.Entry(m).State = EntityState.Modified;
                TempData["Message"] = "Data Updated Succesfully!";
                db.SaveChanges();
                return RedirectToAction("ListMachineries", "Home");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Failed to update data: " + ex.Message;
                return View();
            }
        }

        public ActionResult ListMachineriesDelete(int id)
        {
            var machinery = db.Machineries.Find(id);
            if (machinery == null)
            {
                return HttpNotFound();
            }
            return View(machinery);
        }

        [HttpPost]
        [ActionName("ListMachineriesDelete")]
        public ActionResult ListMachineriesDeleteConfirmed(int id)
        {
            try
            {
                var machinery = db.Machineries.Find(id);
                if (machinery == null)
                {
                    return HttpNotFound();
                }
                db.Machineries.Remove(machinery);
                db.SaveChanges();
                TempData["Message"] = "Data Deleted Successfully!";
                return RedirectToAction("ListMachineries", "Home");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Failed to Delete Data " + ex.Message;
                return RedirectToAction("ListMachineries", "Home");
            }
        }

        public ActionResult ListSeeds()
        {
            var data = entity.Seeds.ToList();
            return View(data);
        }

        public ActionResult ListSeedsCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListSeedsCreate(Seed seed)
        {
            try
            {
                db.Seeds.Add(seed);
                db.SaveChanges();
                TempData["Message"] = "A new seed was added succesfully";
                return RedirectToAction("ListSeeds", "Home");

            }
            catch (Exception ex)
            {
                TempData["Message"] = "Failed to create a user " + ex.Message;
                return View(seed);
            }
        }

        public ActionResult ListSeedsEdit(int id)
        {
            var seed = db.Seeds.Find(id);
            if (seed == null)
            {
                return HttpNotFound();
            }
            return View(seed);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListSeedsEdit(Seed s)
        {
            try
            {
                db.Entry(s).State = EntityState.Modified;
                TempData["Message"] = "Data Updated Succesfully!";
                db.SaveChanges();
                return RedirectToAction("ListSeeds", "Home");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Failed to update data: " + ex.Message;
                return View();
            }
        }

        public ActionResult ListSeedsDelete(int id)
        {
            var seed = db.Seeds.Find(id);
            if (seed == null)
            {
                return HttpNotFound();
            }
            return View(seed);
        }

        [HttpPost]
        [ActionName("ListSeedsDelete")]
        public ActionResult ListSeedsDeleteConfirmed(int id)
        {
            try
            {
                var seed = db.Seeds.Find(id);
                if (seed == null)
                {
                    return HttpNotFound();
                }
                db.Seeds.Remove(seed);
                db.SaveChanges();
                TempData["Message"] = "Data Deleted Successfully!";
                return RedirectToAction("ListSeeds", "Home");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Failed to Delete Data " + ex.Message;
                return RedirectToAction("ListSeeds", "Home");
            }
        }


        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLogin(Farmer f)
        {
            if (string.IsNullOrWhiteSpace(f.farmer_password))
            {
                ModelState.AddModelError("farmer_password", "Password cannot be empty.");

                return View(f);
            }
            var checkLogin = db.Farmers.Where(x => x.farmer_name.Equals(f.farmer_name) && x.farmer_password.Equals(f.farmer_password)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["farmer_id"] = f.farmer_id.ToString();
                Session["farmer_name"] = f.farmer_name.ToString();
                return RedirectToAction("UserPage", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "Incorrect Credentials";
            }
            return View();
        }

        public ActionResult UserPage()
        {
            return View();
        }

        public ActionResult RequestLoan()
        {
            return View(new LoanRequestViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestLoan(LoanRequestViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                //Session["farmer_id"] = model.farmer_id.ToString();
                string errorMessage;

                // Check if the farmer has an existing request and retrieve the not_valid_until date
                var farmerLoan = db.Farmer_Loan_RS
                                  .Where(flr => flr.farmer_id == model.farmer_id)
                                  .OrderByDescending(flr => flr.loan_takendate)
                                  .FirstOrDefault();

                if (farmerLoan != null && farmerLoan.not_valid_until > DateTime.Now)
                {
                    TempData["Message"] = $"You have already made your request before, you can make another request after {farmerLoan.not_valid_until:MMMM dd, yyyy}";
                    return RedirectToAction("UserLoans", "Home", new { farmerId = model.farmer_id });
                }

                if (loanService.RequestLoan(model, out errorMessage))
                {
                    TempData["Message"] = "A request was made successfully";
                    return RedirectToAction("UserLoans", "Home", new { farmerId = model.farmer_id });
                }
                else
                {
                    TempData["Message"] = $"You have already made your request before, you can make another request after {farmerLoan.not_valid_until:MMMM dd, yyyy}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TempData["Message"] = "Failed to make your request: " + ex.Message;
                return View(model);
            }

            return View(model);
        }

        public ActionResult RequestList()
        {
            var model = loanService.GetPendingLoans();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveLoan(int loanId)
        {
            string errorMessage;
            if (loanService.UpdateLoanStatus(loanId, "Approved", out errorMessage))
            {
                TempData["Message"] = "Loan approved successfully.";
            }
            else
            {
                TempData["Message"] = errorMessage;
            }

            return RedirectToAction("RequestList", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DenyLoan(int loanId)
        {
            string errorMessage;
            if (loanService.UpdateLoanStatus(loanId, "Denied", out errorMessage))
            {
                TempData["Message"] = "Loan denied successfully.";
            }
            else
            {
                TempData["Message"] = errorMessage;
            }

            return RedirectToAction("RequestList", "Home");
        }

        public ActionResult UserLoans(int farmerId)
        {
            var model = loanService.GetLoansByFarmer(farmerId);
            return View(model);
        }



        //private readonly RequestService requestService = new RequestService();

        //public ActionResult RequestMachinery()
        //{
        //    return View(new MachineryRequestViewModel());
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult RequestMachinery(MachineryRequestViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    try
        //    {
        //        string errorMessage;

        //        var farmerMachinery = db.Farmer_Machinery_RS
        //                              .Where(fmr => fmr.farmer_id == model.farmer_id)
        //                              .OrderByDescending(fmr => fmr.machinery_takendate)
        //                              .FirstOrDefault();

        //        if (farmerMachinery != null && farmerMachinery.not_valid_until > DateTime.Now)
        //        {
        //            TempData["Message"] = $"You have already requested machinery before. You can make another request after {farmerMachinery.not_valid_until:MMMM dd, yyyy}";
        //            return RedirectToAction("UserMachineries", "Home", new { farmerId = model.farmer_id });
        //        }

        //        if (requestService.RequestMachinery(model, out errorMessage))
        //        {
        //            TempData["Message"] = "A request was made successfully";
        //            return RedirectToAction("UserMachineries", "Home", new { farmerId = model.farmer_id });
        //        }
        //        else
        //        {
        //            TempData["Message"] = errorMessage;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        TempData["Message"] = "Failed to make your request: " + ex.Message;
        //        return View(model);
        //    }

        //    return View(model);
        //}

        //public ActionResult MachineryRequestList()
        //{
        //    var model = requestService.GetPendingMachineryRequests();
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ApproveMachineryRequest(int requestId)
        //{
        //    string errorMessage;
        //    if (requestService.UpdateMachineryRequestStatus(requestId, "Approved", out errorMessage))
        //    {
        //        TempData["Message"] = "Machinery request approved successfully.";
        //    }
        //    else
        //    {
        //        TempData["Message"] = errorMessage;
        //    }

        //    return RedirectToAction("MachineryRequestList", "Home");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult DenyMachineryRequest(int requestId)
        //{
        //    string errorMessage;
        //    if (requestService.UpdateMachineryRequestStatus(requestId, "Denied", out errorMessage))
        //    {
        //        TempData["Message"] = "Machinery request denied successfully.";
        //    }
        //    else
        //    {
        //        TempData["Message"] = errorMessage;
        //    }

        //    return RedirectToAction("MachineryRequestList", "Home");
        //}

        //public ActionResult UserMachineries(int farmerId)
        //{
        //    var model = requestService.GetMachineryRequestsByFarmer(farmerId);
        //    return View(model);
        //}
    }
}