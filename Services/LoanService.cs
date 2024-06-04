using ASCO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASCO.Services
{
    public class LoanService
    {
        private readonly DBACSOEntities db = new DBACSOEntities();

        public bool RequestLoan(LoanRequestViewModel model, out string errorMessage)
        {
            try
            {
                var farmer = db.Farmers.FirstOrDefault(f => f.farmer_id == model.farmer_id);

                if (farmer == null)
                {
                    errorMessage = "Farmer not found.";
                    return false;
                }

                // Check for existing pending loan request
                var existingLoan = db.Farmer_Loan_RS
                    .Where(fl => fl.farmer_id == model.farmer_id && fl.Loan.status == "Pending")
                    .Select(fl => fl.Loan)
                    .FirstOrDefault();

                if (existingLoan != null)
                {
                    errorMessage = "A pending loan request already exists for this farmer.";
                    return false;
                }

                var loan = new Loan
                {
                    loan_amount = model.SelectedLoanAmount,
                    status = "Pending" // Ensure status is set to Pending
                };

                db.Loans.Add(loan);
                db.SaveChanges();

                var farmerLoan = new Farmer_Loan_RS
                {
                    farmer_id = model.farmer_id,
                    loan_id = loan.loan_id,
                    loan_takendate = DateTime.Now,
                    not_valid_until = DateTime.Now.AddMonths(6)
                };

                db.Farmer_Loan_RS.Add(farmerLoan);
                db.SaveChanges();

                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "Failed to make your request: " + ex.Message;
                return false;
            }
        }

        public List<Loan> GetPendingLoans()
        {
            var pendingLoans = db.Loans
                    .Join(db.Farmer_Loan_RS,
                    loan => loan.loan_id,
                    flr => flr.loan_id,
                    (loan, flr) => new { Loan = loan, FarmerLoanRS = flr })
                    .Where(joined => joined.Loan.status == "Pending" && joined.FarmerLoanRS.farmer_id != null)
                    .Select(joined => joined.Loan)
                    .ToList();

            return pendingLoans;
        }

        public bool UpdateLoanStatus(int loanId, string status, out string errorMessage)
        {
            try
            {
                var loan = db.Loans.FirstOrDefault(l => l.loan_id == loanId);

                if (loan == null)
                {
                    errorMessage = "Loan not found.";
                    return false;
                }

                loan.status = status;
                db.SaveChanges();

                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "Failed to update loan status: " + ex.Message;
                return false;
            }
        }

        public List<Loan> GetLoansByFarmer(int farmerId)
        {
            return db.Farmer_Loan_RS
                .Where(fl => fl.farmer_id == farmerId)
                .Select(fl => fl.Loan)
                .ToList();
        }
    }
}