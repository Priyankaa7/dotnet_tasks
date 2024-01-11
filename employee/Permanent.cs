using employee;

namespace permanent
{
    class Permenant : Employee
    {
        public double Basicpay { get; set; }
        public double HRA { get; set; }
        public double DA { get; set; }
        public double PF { get; set; }

        public void GetDetails()
        {
            Console.WriteLine("Enter Basic Pay:");
            Basicpay = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter HRA:");
            HRA = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter DA:");
            DA = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter PF:");
            PF = double.Parse(Console.ReadLine());
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Basic Pay: {Basicpay}");
            Console.WriteLine($"HRA: {HRA}");
            Console.WriteLine($"DA: {DA}");
            Console.WriteLine($"PF: {PF}");
        }

        public override void CalculateSalary()
        {
            Salary = Basicpay + HRA + DA - PF;
        }
    }

}
