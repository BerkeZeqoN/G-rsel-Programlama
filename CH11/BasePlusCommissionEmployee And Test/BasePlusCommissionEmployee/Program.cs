// Fig. 11.6: BasePlusCommissionEmployee.cs
// BasePlusCommissionEmployee class represents an employee that receives
// a base salary in addition to a commission.

using System;

public class BasePlusCommissionEmployee
{
    public string FirstName { get; }
    public string LastName { get; }
    public string SocialSecurityNumber { get; }

    private decimal grossSales;     // gross weekly sales
    private decimal commissionRate; // commission percentage
    private decimal baseSalary;     // base salary per week

    // six-parameter constructor
    public BasePlusCommissionEmployee(string firstName, string lastName,
        string socialSecurityNumber, decimal grossSales,
        decimal commissionRate, decimal baseSalary)
    {
        FirstName = firstName;
        LastName = lastName;
        SocialSecurityNumber = socialSecurityNumber;

        GrossSales = grossSales;           // validates grossSales
        CommissionRate = commissionRate;   // validates commissionRate
        BaseSalary = baseSalary;           // validates baseSalary
    }

    // property for gross sales
    public decimal GrossSales
    {
        get => grossSales;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(GrossSales)} must be >= 0");
            }
            grossSales = value;
        }
    }

    // property for commission rate
    public decimal CommissionRate
    {
        get => commissionRate;
        set
        {
            if (value <= 0 || value >= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(CommissionRate)} must be > 0 and < 1");
            }
            commissionRate = value;
        }
    }

    // property for base salary
    public decimal BaseSalary
    {
        get => baseSalary;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(BaseSalary)} must be >= 0");
            }
            baseSalary = value;
        }
    }

    // calculate earnings
    public decimal Earnings() =>
        BaseSalary + (CommissionRate * GrossSales);

    // string representation
    public override string ToString() =>
        $"base-salaried commission employee: {FirstName} {LastName}\n" +
        $"social security number: {SocialSecurityNumber}\n" +
        $"gross sales: {GrossSales:C}\n" +
        $"commission rate: {CommissionRate:F2}\n" +
        $"base salary: {BaseSalary:C}";
        
}
class BasePlusCommissionEmployeeTest
{
    static void Main()
    {
        var employee = new BasePlusCommissionEmployee("Bob", "Lewis", "44-444-4444", 5000.00M, .04M, 300.00M);

        Console.WriteLine(
            "Employee informations are obtained by properties and methods: \n ");
        Console.WriteLine($" First Name İs {employee.FirstName}");
        Console.WriteLine($"Last Name İs {employee.LastName}");
        Console.WriteLine($"Social Security Number is {employee.SocialSecurityNumber}");
        Console.WriteLine($"GrossSales are {employee.GrossSales}");
        Console.WriteLine($" Commision rate is {employee.CommissionRate}");
        Console.WriteLine($"Employee earning is {employee.Earnings}");
        Console.WriteLine($"Base Salary is {employee.BaseSalary}");
        employee.BaseSalary = 1000.00M;

        Console.WriteLine(
            "\nUpdated empoloyee information obtained by ToString \n ");
        Console.WriteLine(employee);
        Console.WriteLine($"Earning is {employee.Earnings()}");
    }

}