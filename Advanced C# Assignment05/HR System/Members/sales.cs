using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_C__Assignment05.HR_System
{
    public class Sales:Employee
    {

        public int AchievedTarget { get; set; }
        public double RequiredTarget { get; set; }

        public Sales()
        {
        }

        public Sales(int employeeID, int age, int RequiredTarget) : base(employeeID, age, 0)
        {
            this.RequiredTarget = RequiredTarget;
        }

        public void EndOfYearSalesCheck()
        {
            if (AchievedTarget < RequiredTarget)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs
                {
                    Cause = LayOffCause.SalesTargetNotMet
                });

                Console.WriteLine($"[SalesPerson] #{EmployeeID} fired due to underperformance.");
            }
            else
            {
                Console.WriteLine($"[SalesPerson] #{EmployeeID} achieved the sales target successfully!");
            }
        }




        public override string ToString()
        {
            return $"SalesPerson ID: {EmployeeID}, Age: {age}, Target: {AchievedTarget}/{RequiredTarget}";
        }




        public bool CheckTarget(int Quota)
        {
            throw new NotImplementedException();
        }


    }
}
