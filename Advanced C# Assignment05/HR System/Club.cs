using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_C__Assignment05.HR_System
{
    public class Club
    {
        public int ClubID { get; set; }
        public String ClubName { get; set; }

        List<Employee> Members;
        public void AddMember(Employee E)
        {
            if (Members == null)
            {
                Members = new List<Employee>();
            }
            if (!Members.Contains(E))
            {
                Members.Add(E);
                Console.WriteLine($"[Club: {ClubName}] Added employee #{E.EmployeeID}");
                // Subscribe to layoff event
                E.EmployeeLayOff += RemoveMember; // 3shan lma el mozaf hykon enrolled already enta htshylo lw 3ml trigger llevent 
                if (E.VacationStock <0)//hna 3shan w ana b3ml add a3ml el check bta3y 3la tool 
                {
                    E.OnEmployeeLayOff(new EmployeeLayOffEventArgs
                    {
                        Cause = LayOffCause.OutOFVacationStock
                    });
                }
            }
           
        }
        ///CallBackMethod
        public void RemoveMember(object sender, EmployeeLayOffEventArgs e)

        {
            Employee emp = sender as Employee;
            if (emp != null && Members.Contains(emp)) 
            {
                Members.Remove(emp);

                // Unsubscribe from event to avoid memory leaks
                emp.EmployeeLayOff -= RemoveMember;

                Console.WriteLine($"[Club: {ClubName}] Removed employee #{emp.EmployeeID} due to {e.Cause}");
            }
            ///Employee Will not be removed from the Club if Age>60
            ///Employee will be removed from Club if Vacation Stock < 0
        }
        public void PrintMembers()
        {
            Console.WriteLine($"\n[Club: {ClubName}] Members:");

            if (Members == null || Members.Count == 0)
            {
                Console.WriteLine("No members in this club.");
                return;
            }

            foreach (var emp in Members)
            {
                Console.WriteLine($"- Employee ID: {emp.EmployeeID}, Age: {emp.age}, Vacation Stock: {emp.VacationStock}");
            }
        }
    }
}
