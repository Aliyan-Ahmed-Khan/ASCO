using ASCO.Models;
using System;

namespace ASCO.Services
{
    public class LoanService
    {
        public DBACSOEntities db = new DBACSOEntities();

        public bool RequestLoan(LoanRequestViewModel model, out string errorMessage)
        {
            try
            {
                var loan = new Loan
                {
                    loan_amount = model.SelectedLoanAmount
                };

                db.Loans.Add(loan);
                db.SaveChanges();

                var farmerLoan = new Farmer_Loan_RS
                {
                    farmer_id = model.farmer_id,
                    loan_takendate = DateTime.Now,
                    not_valid_until = DateTime.Now.AddMonths(6),
                    loan_id = loan.loan_id
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
    }
}