using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_assgn06
{
    public class Program
    {
        public delegate void delPrintDetail();
        public static void Main()
        {
            Console.WriteLine("Executing the Employee Management System using Delegates !");
            Employee employee1 = new Manager("A","Manager",100000);
            Employee employee2 = new MarketingExecutive("ME_A", "Marketing Executive", 120000, 50);
            Employee employee3 = new MarketingExecutive("ME_B", "Marketing Executive", 120000, 150);
            employee1.CalculateSalary();
            employee2.CalculateSalary();
            employee3.CalculateSalary();
            //employee1.printDetails();
            //Console.WriteLine("dfbs");
            delPrintDetail del1 = new delPrintDetail(print_emp1);
            delPrintDetail del2 = new delPrintDetail(print_emp2);   
            delPrintDetail del3 = new delPrintDetail(print_emp3);
            del1 += del2;
            del1+=del3;
            del1();
            Console.ReadLine();
            void print_emp1()
            {
                employee1.printDetails();
            }
            void print_emp2()
            {
                employee2.printDetails();
            }
            void print_emp3()
            {
                employee3.printDetails();
            }
        }
    }
    public class Employee
    {
        public string Name, designation;
        public double netSalary, grossSalary;

        protected Employee()
        {
            this.Name = "";
            this.designation = "";
            this.netSalary = 0.0;
            this.grossSalary = 0.0;
        }

        protected Employee(string name, string designation, double salary)
        {
            this.Name = name;
            this.designation = designation;
            this.netSalary = salary;
        }

        public virtual void CalculateSalary()
        {
            Console.WriteLine("Calculating Salary"); //It will be overrided!
        }

        public void printDetails()
        {
            Console.WriteLine("\n---------Details of the Employee---------\n");
            Console.WriteLine("Name: {0}", this.Name);
            Console.WriteLine("Designation: {0}", this.designation);
            Console.WriteLine("Net Salary: {0}", this.netSalary);
            Console.WriteLine("Gross Salary: {0}\n", this.grossSalary);
        }
    }

    public class Manager : Employee
    {
        private double petrolAllowance, foodAllowance, otherAllowance;

        public Manager(string name, string designation, double salary) : base(name, designation, salary)
        {
            this.petrolAllowance = 0.08 * salary;
            this.foodAllowance = 0.13 * salary;
            this.otherAllowance = 0.03 * salary;
        }

        public override void CalculateSalary()//Overriding
        {
            grossSalary = petrolAllowance + foodAllowance + otherAllowance + netSalary;

        }
    }

    public class MarketingExecutive : Employee
    {
        double kilometerTravel, tourAllowance;
        double telephoneAllowance;

        public MarketingExecutive(string name, string designation, double salary, double kilometers) : base(name, designation, salary)
        {
            this.kilometerTravel = kilometers;
            tourAllowance = 5 * this.kilometerTravel;
            telephoneAllowance = 1000;
        }

        public override void CalculateSalary()
        {
            grossSalary = netSalary + kilometerTravel + tourAllowance + telephoneAllowance;
        }
    }
}