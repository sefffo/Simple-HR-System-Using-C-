# Simple-HR-System-Using-C-#


Advanced C# HR System

A C# console application built as part of Assignment 05 for Advanced C#.
The project simulates an HR Management System where we manage employees, departments, clubs, sales staff, and board members, including event-driven layoffs and resignations.

📌 Features
1. Employees

Store basic info like EmployeeID, Age, and VacationStock.

Request vacation days.

Automatic layoff if:

Age ≥ 60

Vacation stock runs out.

2. Departments

Manage a list of employees.

Automatically remove employees from the department when a layoff event is triggered.

Can print current staff members.

3. Clubs

Manage membership lists.

Automatically remove employees from the club if they are laid off.

Board members remain unaffected.

4. Sales Employees

Special employee type without vacation stock.

Layoff triggered if sales target is not achieved.

5. Board Members

Immune to automatic layoffs (age, vacation, or sales).

Can resign voluntarily if needed.


🛠️ Tech Stack

Language: C#

Framework: .NET

Paradigm: Object-Oriented Programming

Concepts Used:

Inheritance & Polymorphism

Events & Delegates

Encapsulation

Collections (List<T>)



📦 Advanced_C__Assignment05
├── HR_System
│   ├── Employee.cs
│   ├── Department.cs
│   ├── Club.cs
│   ├── Members
│   │    ├── Sales.cs
│   │    └── BoardMember.cs
├── Program.cs
└── README.md
