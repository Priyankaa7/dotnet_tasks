using employee;
using permanent;
using trainee;
internal class Program
{
    private static void Main(string[] args)
    {
        Permenant permanentEmployee = new Permenant();
        permanentEmployee.AcceptDetails();
        permanentEmployee.GetDetails();
        permanentEmployee.CalculateSalary();
        permanentEmployee.DisplayDetails();
        permanentEmployee.ShowDetails();

        Trainee traineeEmployee = new Trainee();
        traineeEmployee.AcceptDetails();
        traineeEmployee.GetTraineeDetails();
        traineeEmployee.CalculateSalary();
        traineeEmployee.DisplayDetails();
        traineeEmployee.ShowTraineeDetails();
    }
}