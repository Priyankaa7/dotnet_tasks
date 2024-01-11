using employee;

namespace trainee
{
    class Trainee : Employee
    {
        public double Bonus { get; set; }
        public string Projectname { get; set; }

        public void GetTraineeDetails()
        {
            Console.WriteLine("Enter Bonus:");
            Bonus = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Project Name: (banking or insurance)");
            Projectname = Console.ReadLine();
        }

        public void ShowTraineeDetails()
        {
            Console.WriteLine($"Bonus: {Bonus}");
            Console.WriteLine($"Project Name: {Projectname}");
        }

        public override void CalculateSalary()
        {
            // Bonus calculation based on Projectname
            if (Projectname == "banking")
                Salary += Salary * 0.05;
            else if (Projectname == "insurance")
                Salary += Salary * 0.1;
        }
    }

}