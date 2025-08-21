using Advanced_C__Assignment05.HR_System;
using Advanced_C__Assignment05.HR_System.Members;

namespace Advanced_C__Assignment05
{
    internal class Program
    {
        static void Main(string[] args)
        {


            #region tetsing 
            //var employee = new Employee(1,40,5);
            //employee.EmployeeLayOff += (s, ev) => Console.WriteLine($"[EVENT] Layoff cause: {ev.Cause}");
            //employee.RequestVacation(DateTime.Today, DateTime.Today.AddDays(1)); // goes to -1 → fires event

            //Employee e1 = new Employee(1, 25, 10); // young employee, enough vacation stock
            //Employee e2 = new Employee(2, 59, 5);  // near retirement, low vacation stock
            //Employee e3 = new Employee(3, 62, 7);  // older employee, will trigger layoff immediately


            //Department dept = new Department
            //{
            //    DeptID = 1,
            //    DeptName = "IT Department"
            //};


            //e1.EmployeeLayOff += (s, ev) =>
            //    Console.WriteLine($"[EVENT] Employee #{((Employee)s).EmployeeID} got laid off → Cause: {ev.Cause}");
            //e2.EmployeeLayOff += (s, ev) =>
            //    Console.WriteLine($"[EVENT] Employee #{((Employee)s).EmployeeID} got laid off → Cause: {ev.Cause}");
            //e3.EmployeeLayOff += (s, ev) =>
            //    Console.WriteLine($"[EVENT] Employee #{((Employee)s).EmployeeID} got laid off → Cause: {ev.Cause}");

            //Console.WriteLine("\n=== Adding Employees to Department ===");
            //dept.AddStaff(e1);
            //dept.AddStaff(e2);
            //dept.AddStaff(e3); // Will be laid off immediately because age >= 60


            //Console.WriteLine("\n=== Department Staff After Adding ===");

            //dept.PrintStaff();
            //employee.EndOfYearOperation();

            //e2.RequestVacation(DateTime.Today, DateTime.Today.AddDays(7));
            #endregion testing

            Console.WriteLine("testing the employee and department classes");
            Department dept = new Department
            {
                DeptID = 1,
                DeptName = "IT Department"
            };

            // === Create Employees ===
            Employee e1 = new Employee(1, 25, 10); // normal employee
            Employee e2 = new Employee(2, 59, 5);  // near retirement
            Employee e3 = new Employee(3, 62, 7);  // auto-fired due to age >= 60

            // === Subscribe to Layoff Event for Debugging ===
            e1.EmployeeLayOff += (s, ev) => Console.WriteLine($"[EVENT] #{((Employee)s).EmployeeID} fired ==> {ev.Cause}");
            e2.EmployeeLayOff += (s, ev) => Console.WriteLine($"[EVENT] #{((Employee)s).EmployeeID} fired ==> {ev.Cause}");
            e3.EmployeeLayOff += (s, ev) => Console.WriteLine($"[EVENT] #{((Employee)s).EmployeeID} fired ==> {ev.Cause}");

            // === Add Employees to Department ===
            Console.WriteLine("\n=== Adding Employees ===");
            dept.AddStaff(e1);
            dept.AddStaff(e2);
            dept.AddStaff(e3); // will be removed immediately due to age

            // === Print Staff After Adding ===
            Console.WriteLine("\n=== Staff After Adding ===");
            dept.PrintStaff();

            // === e2 Requests Vacation of 7 Days ===
            Console.WriteLine("\n=== Employee #2 Requests Vacation ===");
            e2.RequestVacation(DateTime.Today, DateTime.Today.AddDays(7));

            // === Print Staff After Vacation Layoff ===
            Console.WriteLine("\n=== Staff After Vacation Layoff ===");
            dept.PrintStaff();

            // === End of Year Check ===
            Console.WriteLine("\n=== End of Year Check ===");
            e1.EndOfYearOperation();
            e2.EndOfYearOperation();

            // === Final Staff ===
            Console.WriteLine("\n=== Final Staff ===");
            dept.PrintStaff();


            //Console.Clear();
            Console.WriteLine("\b \n============================================================================================ \n");
            Console.WriteLine("testing the Clubs , Sales and Board Members classes");



            Club itClub = new Club
            {
                ClubID = 1,
                ClubName = "IT Club"
            };

            itClub.AddMember(e1);
            itClub.AddMember(e2);
            itClub.AddMember(e3);

            Console.WriteLine("\n=== Club Members After Adding ===");
            itClub.PrintMembers();

            // Force e2 to run out of vacation stock
            e2.RequestVacation(DateTime.Today, DateTime.Today.AddDays(10));

            Console.WriteLine("\n=== Club Members After Vacation Layoff ===");
            itClub.PrintMembers();



            Sales s1 = new Sales(1, 30, 10000);
            s1.AchievedTarget = 8000;

            BoardMember b1 = new BoardMember(2, 65, "CEO");

            // Create Department
            Department dept2 = new Department
            {
                DeptID = 1,
                DeptName = "Sales Department"
            };

            dept.AddStaff(s1);
            dept.AddStaff(b1);

            // Create Club
            Club club = new Club
            {
                ClubID = 1,
                ClubName = "Executive Club"
            };

            club.AddMember(s1);
            club.AddMember(b1);

            Console.WriteLine("\n=== BEFORE END OF YEAR ===");
            dept.PrintStaff();
            club.PrintMembers();

            Console.WriteLine("\n=== Checking Sales Targets ===");
            s1.EndOfYearSalesCheck();

            Console.WriteLine("\n=== AFTER END OF YEAR ===");
            dept.PrintStaff();
            club.PrintMembers();

        }
    }
}
