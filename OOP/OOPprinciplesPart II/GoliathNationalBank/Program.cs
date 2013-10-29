using System;
using System.Collections.Generic;
using GoliathNationalBank;

class Program
{
    static void Main()
    {
        List<Customers> clients = new List<Customers>();
        clients.Add(new Individuals("Sashka", 'f', 20));        
        clients.Add(new Individuals("Goshko", 'm', 19));        
        clients.Add(new Individuals("Lelq Stefka", 'f', 45)); 
        clients.Add(new Individuals("Frodo", 'f', 30));
        clients.Add(new Companies("Electron", 976));
        clients.Add(new Companies("Hrup-hap", 50));
        
        List<Accounts> accounts = new List<Accounts>();
        accounts.Add(new DepositAccounts(clients[0], 1500, 0.8m, 20));
        accounts.Add(new DepositAccounts(clients[1], 5000, 2m, 10));
        accounts.Add(new DepositAccounts(clients[2], 1000, 1, 5));
        accounts.Add(new DepositAccounts(clients[3], 500, 3, 25));
        accounts.Add(new DepositAccounts(clients[4], 2000, 0.8m, 20));
        accounts.Add(new DepositAccounts(clients[5], 4000, 0.8m, 20));

        foreach (var acc in accounts)
    	{
            Console.WriteLine(acc.CalculateInterest());
            acc.Deposit(1000);
            if(acc is DepositAccounts)
            {
                acc.Drow(200);
                Console.WriteLine("I've drow 200 crocodiles");
            }
	    }
    }
}

