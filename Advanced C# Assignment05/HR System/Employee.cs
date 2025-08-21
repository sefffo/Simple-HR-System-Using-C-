using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_C__Assignment05.HR_System
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        //public DateTime BirthDate
        //{
        //    set; get;
        //}
        //private int vacationStock;

        // Backing fields to avoid recursion
        private int _age;
        private int _vacationStock;
        public int VacationStock
        {
            get => _vacationStock;
            set => _vacationStock = value;
        }
        public int age
        {
            get { return _age; }
            //set   
            
            //it wont be seen in the department cuz it already added throw the constructor 

            //{
            //    _age = value ;
            //    if(_age >= 60)
            //    {
            //        OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.AgeAbove60});
            //    }
            //}
        }
        public Employee() { }
        public Employee(int employeeID, int age  , int vacationStock)
        {
            EmployeeID = employeeID;
            _vacationStock = vacationStock;
            _age = age;
        }
        public bool RequestVacation(DateTime From, DateTime To)
        {
            if (To.Date < From.Date)
            {
                Console.WriteLine("Invalid date range.");
                return false;
            }

            int days = (To.Date - From.Date).Days+ 1 ; // inclusive
            _vacationStock -= days;

            if(_vacationStock < 0)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs
                {
                    Cause = LayOffCause.OutOFVacationStock
                });
                Console.WriteLine("You have no vaction stock And Unfortunately You will be laid Off   ==>  layoff triggered.");
                return false;
            }
            else
            {
                Console.WriteLine($"Vaction Booked And your Vaction stock is {_vacationStock}");
            }
            return true;
        }
        public void EndOfYearOperation()
        {
            if (_age >= 60)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs
                {
                    Cause = LayOffCause.AgeAbove60
                });
            }
        }
        public override string ToString()
        {
            return $"Emp ID : {EmployeeID} , Age : {_age} , Vaction Stock : {_vacationStock}";
        }
        //=======================================Event Impelemenation===============================================//
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;
        public virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }
    }
    public enum LayOffCause:byte
    { ///Implement it YourSelf
        OutOFVacationStock = 0,
        AgeAbove60=1,
        SalesTargetNotMet = 2,  
        ResignFromBoardMember=3

    }
    public class EmployeeLayOffEventArgs :EventArgs
    {
        public LayOffCause Cause { get; set; }

    }
}
