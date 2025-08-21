using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_C__Assignment05.HR_System.Members
{
    public class BoardMember :  Employee
    {
        public string Position { get; set; }

        public BoardMember() { }

        public BoardMember(int employeeID, int age, string position)
            : base(employeeID, age, 0) // ✅ BoardMembers don't care about vacation stock
        {
            Position = position;
        }

        // Override to prevent layoff completely
        public override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            Console.WriteLine($"[BoardMember] #{EmployeeID} is a board member and cannot be laid off. Ignoring cause: {e.Cause}");
            // DO NOT call base.OnEmployeeLayOff(e)
        }
        public void Resign(Employee e)
        {
            Console.WriteLine($"[BoardMember] #{EmployeeID} resigned manually.");
            e.OnEmployeeLayOff(new EmployeeLayOffEventArgs
            {
                Cause =  LayOffCause.ResignFromBoardMember
            });
        }
        public override string ToString()
        {
            return $"Board Member ID: {EmployeeID}, Position: {Position}, Age: {age}";
        }
     
    }
}
