using System;

public class CommissionEmployee : object
{
    private decimal grossSales;        // gross weekly sales
    private decimal commissionRate;    // commission percentage

    public string FirstName { get; }
    public string LastName { get; }
    public string SocialSecurityNumber { get; }

    // five-parameter constructor
    public CommissionEmployee(string firstName, string lastName,
        string socialSecurityNumber, decimal grossSales,
        decimal commissionRate)
    {
        // implicit call to object constructor occurs here 
        FirstName = firstName;
        LastName = lastName;
        SocialSecurityNumber = socialSecurityNumber;

        GrossSales = grossSales;             // validates gross sales
        CommissionRate = commissionRate;     // validates commission rate
    }

    // property that gets and sets commission employee's gross sales
    public decimal GrossSales
    {
        get
        {
            return grossSales;
        }
        set
        {
            if (value < 0) // validation
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(GrossSales)} must be >= 0");
            }

            grossSales = value;
        }
    }

    // property that gets and sets commission employee's commission rate
    public decimal CommissionRate
    {
        get
        {
            return commissionRate;
        }
        set
        {
            if (value <= 0 || value >= 1) // validation
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(CommissionRate)} must be > 0 and < 1");
            }

            commissionRate = value;
        }
    }

    // calculate commission employee's pay
    public decimal Earnings() => grossSales * commissionRate;

    // return string representation of CommissionEmployee object
    public override string ToString() =>
        $"commission employee: {FirstName} {LastName}\n" +
        $"social security number: {SocialSecurityNumber}\n" +
        $"gross sales: {grossSales:C}\n" +
        $"commission rate: {commissionRate:F2}";

       class CommisionEmployeeTest
    {
        static void Main()
        {
            var employee = new CommissionEmployee("Sue", "jones", "222-22-2222", 100000.00M, .06M);

            Console.WriteLine("Employee information obtained by properties  and methods: \n ");
            Console.WriteLine(($"First name is {employee.FirstName }"));
            Console.WriteLine($"Last name is {employee.LastName}");
            Console.WriteLine($"Social Secuity Number is {employee.SocialSecurityNumber}");
            Console.WriteLine($"Gross Sales are {employee.GrossSales}");
            Console.WriteLine($"Commision rate is {employee.commissionRate}");
            Console.WriteLine($"Your Earning is {employee.Earnings}");

            employee.GrossSales = 5000.00M;
            employee.commissionRate = .1M;

            Console.WriteLine(
                "\nUpdated employee information obtained by ToString: \n");
            Console.WriteLine(employee);
            Console.WriteLine($"earnings: {employee.Earnings}");

        }
        
    }
}
