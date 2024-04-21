using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Your Name");
        string nameInput = Console.ReadLine();

        Console.WriteLine("\nEnter Your Initial Account Number");
        string accountNumberInput = Console.ReadLine();
        int.TryParse(accountNumberInput, out var accountNumber);

        Console.WriteLine("\nEnter Your Initial Balance");
        string balanceInput = Console.ReadLine();
        double.TryParse(balanceInput, out var balance);

        BankAccount userAccount = new BankAccount(nameInput, accountNumber, balance);

        int operationChosen = 0;
        while (operationChosen != 5)
        {
            Console.WriteLine("\nWhat Operation do you need?\n1)Deposit \n2)Withdrawal \n3)View Balance \n4)Transactional History\n5)Exit\n");
            string operationInput = Console.ReadLine();
            int.TryParse(operationInput, out operationChosen);

            if (operationChosen == 1)
            {
                Console.WriteLine("Please Enter Deposit amount");
                string depositInput = Console.ReadLine();
                double.TryParse(depositInput, out var deposit);
                userAccount.Deposit(deposit);
            }
            else if (operationChosen == 2)
            {
                Console.WriteLine("Please Enter Withdrawal amount");
                string withdrawalInput = Console.ReadLine();
                double.TryParse(withdrawalInput, out var withdrawal);
                userAccount.Withdraw(withdrawal);
            }
            else if (operationChosen == 3)
            {
                Console.WriteLine($"This is your balance: {userAccount.GetBalance()}");
            }
            else if (operationChosen == 4)
            {
                Console.WriteLine($"This is your transactional history ");
                foreach (var transaction in userAccount.GetTransactionHistory())
                {
                    Console.WriteLine(transaction);
                }
            }
            else if (operationChosen == 5)
            {
                Console.WriteLine("Thank You For Banking With Us");
            }
            else
            {
                Console.WriteLine("Invalid operation. Please try again.");
            }
        }
    }
}

public class BankAccount
{
    public string Name { get; set; }
    public int AccountNumber { get; set; }
    public double Balance { get; set; }
    private List<double> transactionHistory = new List<double>();

    public BankAccount(string name, int accountNumber, double balance)
    {
        Name = name;
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
        transactionHistory.Add(amount);
    }

    public void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            transactionHistory.Add(-amount); 
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public double GetBalance()
    {
        return Balance;
    }

    public IEnumerable<double> GetTransactionHistory()
    {
        return transactionHistory;
    }
}