using System;

class Account
{
    public string Name { get; set; }
    private decimal balance;
    public Account(string accountName, decimal initialBalance)
    {
        Name = accountName;
        Balance = initialBalance;
    }
    public decimal Balance
    {
        get
        {
            return balance;
        }
        private set
        {
            if (value > 0.0m)
            {
                balance = value;
            }
        }
    }
    public void Deposit(decimal depositAmount)
    {
        if (depositAmount > 0.0m)
        {
            balance = balance + depositAmount;
        }
    }

}

class AccountTest
{
    static void Main()
    {
        Account account1 = new Account("Jane Green", 50.00m);
        Account account2 = new Account("John Blue ", -7.53m);

        Console.WriteLine(
            $"{account1.Name}'s balance: {account1.Balance:(}");
        Console.WriteLine(
            $"{account2.Name}'s balance: {account2.Balance:(}");

        Console.Write("\nEnter deposit amount for account1: ");
        decimal depositAmount = decimal.Parse(Console.ReadLine());
        Console.WriteLine(
            $"adding to account1 balance\n");
        account1.Deposit(depositAmount); // add to account1's balance
        Console.WriteLine(
            $"{account1.Name}'s balance: {account1.Balance:C}");
        Console.WriteLine(
            $"{account2.Name}'s balance: {account2.Balance:C}");

        Console.Write("\nEnter deposit amount for account2: ");
        depositAmount = decimal.Parse(Console.ReadLine());
        Console.WriteLine(
            $"adding {depositAmount:C} to account2 balance\n");
        account2.Deposit(depositAmount); // add to account2's balance

        Console.WriteLine(
            $"{account1.Name}'s balance: {account1.Balance:C}");
        Console.WriteLine(
            $"{account2.Name}'s balance: {account2.Balance:C}");



    }
}