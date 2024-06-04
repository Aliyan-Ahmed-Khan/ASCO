//using ASCO.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace ASCO.Services
//{
//    public class RequestService
//    {
//        private readonly DBACSOEntities db = new DBACSOEntities();

//        public bool RequestMachinery(MachineryRequestViewModel model, out string errorMessage)
//        {
//            try
//            {
//                var farmer = db.Farmers.FirstOrDefault(f => f.farmer_id == model.farmer_id);

//                if (farmer == null)
//                {
//                    errorMessage = "Farmer not found.";
//                    return false;
//                }

//                var selectedMachineryType = model.SelectedMachineryType.ToString(); // Convert enum to string
//                var machinery = db.Machineries.FirstOrDefault(m => m.machinery_type == selectedMachineryType);

//                if (machinery == null || machinery.machinery_quantity <= 0)
//                {
//                    errorMessage = "Machinery not available.";
//                    return false;
//                }

//                var existingRequest = db.Farmer_Machinery_RS
//                    .Where(fm => fm.farmer_id == model.farmer_id && fm.Machinery.status == "Pending")
//                    .Select(fm => fm.Machinery)
//                    .FirstOrDefault();

//                if (existingRequest != null)
//                {
//                    errorMessage = "A pending machinery request already exists for this farmer.";
//                    return false;
//                }

//                var request = new Farmer_Machinery_RS
//                {
//                    farmer_id = model.farmer_id,
//                    machinery_id = machinery.machinery_id,
//                    machinery_takendate = DateTime.Now,
//                    not_valid_until = DateTime.Now.AddMonths(6)
//                };

//                machinery.status = "Pending";
//                db.Farmer_Machinery_RS.Add(request);
//                db.SaveChanges();

//                errorMessage = string.Empty;
//                return true;
//            }
//            catch (Exception ex)
//            {
//                errorMessage = "Failed to make your request: " + ex.Message;
//                return false;
//            }
//        }

//        public List<Machinery> GetPendingMachineryRequests()
//        {
//            var pendingMachinery = db.Machineries
//                    .Join(db.Farmer_Machinery_RS,
//                    machinery => machinery.machinery_id,
//                    fmr => fmr.machinery_id,
//                    (machinery, fmr) => new { Machinery = machinery, FarmerMachineryRS = fmr })
//                    .Where(joined => joined.Machinery.status == "Pending" && joined.FarmerMachineryRS.farmer_id != null)
//                    .Select(joined => joined.Machinery)
//                    .ToList();

//            return pendingMachinery;
//        }

//        public bool UpdateMachineryRequestStatus(int requestId, string status, out string errorMessage)
//        {
//            try
//            {
//                var request = db.Farmer_Machinery_RS.FirstOrDefault(fm => fm.relationship_id == requestId);

//                if (request == null)
//                {
//                    errorMessage = "Request not found.";
//                    return false;
//                }

//                var machinery = db.Machineries.FirstOrDefault(m => m.machinery_id == request.machinery_id);

//                if (status == "Approved" && machinery != null)
//                {
//                    machinery.machinery_quantity -= 1;
//                    db.SaveChanges();
//                }

//                machinery.status = status;
//                db.SaveChanges();

//                errorMessage = string.Empty;
//                return true;
//            }
//            catch (Exception ex)
//            {
//                errorMessage = "Failed to update request status: " + ex.Message;
//                return false;
//            }
//        }

//        public List<Farmer_Machinery_RS> GetMachineryRequestsByFarmer(int farmerId)
//        {
//            return db.Farmer_Machinery_RS
//                .Where(fm => fm.farmer_id == farmerId)
//                .ToList();
//        }
//    }
//}
