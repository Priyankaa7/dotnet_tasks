namespace employee
{
    interface IEmployee
    {
        void AcceptDetails();
        void DisplayDetails();
        void CalculateSalary();
    }

    class Employee : IEmployee
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public double Salary { get; set; }
        public DateTime Doj { get; set; }

        public void AcceptDetails()
        {
            Console.WriteLine("Enter Employee ID:");
            Empid = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Employee Name:");
            Empname = Console.ReadLine();

            Console.WriteLine("Enter Salary:");
            Salary = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Date of Joining:");
            Doj = DateTime.Parse(Console.ReadLine());
        }

        public virtual void CalculateSalary()
        {        
            Salary += 1000;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Employee ID: {Empid}");
            Console.WriteLine($"Employee Name: {Empname}");
            Console.WriteLine($"Salary: {Salary}");
            Console.WriteLine($"Date of Joining: {Doj}");
        }
    }

}
