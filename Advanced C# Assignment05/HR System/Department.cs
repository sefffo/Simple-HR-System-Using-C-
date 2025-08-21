using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_C__Assignment05.HR_System
{
    public class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        List<Employee> Staff;
        public void AddStaff(Employee E)
        {
            if (Staff == null)
            {
                Staff = new List<Employee>();
            }
            if(! Staff.Contains(E)) 
            {
               Staff.Add(E);
                Console.WriteLine($"[Department: {DeptName}] Added employee #{E.EmployeeID}");
                // Subscribe to layoff event
                E.EmployeeLayOff += RemoveStaff; // 3shan lma el mozaf hykon enrolled already enta htshylo lw 3ml trigger llevent 
                if (E.age >= 60)//hna 3shan w ana b3ml add a3ml el check bta3y 3la tool 
                {
                    E.OnEmployeeLayOff(new EmployeeLayOffEventArgs
                    {
                        Cause = LayOffCause.AgeAbove60
                    });
                }
            }
            ///Try Register for EmployeeLayOff Event Here
        }

        ///CallBackMethod using recuresion 
        public void RemoveStaff(object sender,EmployeeLayOffEventArgs e)
        {
            Employee emp = sender as Employee;
            if (emp != null && Staff.Contains(emp)) 
            {
                Staff.Remove(emp);

                // Unsubscribe from event to avoid memory leaks
                emp.EmployeeLayOff -= RemoveStaff;

                Console.WriteLine($"[Department: {DeptName}] Removed employee #{emp.EmployeeID} due to {e.Cause}");
            }
        }
        // Print current staff list
        public void PrintStaff()
        {
            Console.WriteLine($"\n[Department: {DeptName}] Staff Members:");

            if (Staff.Count == 0)
            {
                Console.WriteLine("No employees in this department.");
                return;
            }

            foreach (var emp in Staff)
            {
                Console.WriteLine($"- Employee ID: {emp.EmployeeID}, Age: {emp.age}, Vacation Stock: {emp.VacationStock}");
            }
        }
    }
}
