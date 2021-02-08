using System;
using System.Collections.Generic;

namespace TheBank
{
	class Program
	{
		static List<Account> accounts = new List<Account>();
		
        static void Main(string[] args)
		{
			string userOption = GetUserOption();

			while (userOption.ToUpper() != "X")
			{
				switch (userOption)
				{
					case "1":
						ListAccounts();
						break;
					case "2":
						InsertAccount();
						break;
					case "3":
						TransferMoney();
						break;
					case "4":
						DrawMoney();
						break;
					case "5":
						DepositMoney();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				userOption = GetUserOption();
			}
			
			Console.WriteLine("Thank you for using our services.");
			//Console.ReadLine();
		}

		private static void ListAccounts()
		{
			Console.WriteLine("List all accounts");

			if (accounts.Count <= 0)
			{
				Console.WriteLine("No account registered.");
				return;
			}

			for (int i = 0; i < accounts.Count; i++)
			{
				Account account = accounts[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(account);
			}
		}

		private static void InsertAccount()
		{
			Console.WriteLine("Insert new account");

			Console.Write("Enter 1 for Physical Account or 2 for Juridical: ");
			int accountType = int.Parse(Console.ReadLine());

			Console.Write("Enter the customer name: ");
			string name = Console.ReadLine();

			Console.Write("Enter the opening balance: ");
			double balance = double.Parse(Console.ReadLine());

			Console.Write("Enter the credit: ");
			double credit = double.Parse(Console.ReadLine());

			Account newAccount = new Account((AccountType)accountType, 
                                            balance,
                                            credit,
                                            name);
			accounts.Add(newAccount);
		}

		private static void DepositMoney()
		{
			Console.Write("Enter account number: ");
			int accountNumber = int.Parse(Console.ReadLine());

			Console.Write("Enter the amount to be deposited: ");
			double depositValue = double.Parse(Console.ReadLine());

            accounts[accountNumber].DepositMoney(depositValue);
		}


		private static void TransferMoney()
		{
			Console.Write("Enter the origin account number: ");
			int originAccount = int.Parse(Console.ReadLine());

            Console.Write("Enter the target account number: ");
			int targetAccount= int.Parse(Console.ReadLine());

			Console.Write("Enter the amount to be transferred: ");
			double transferValue = double.Parse(Console.ReadLine());

            accounts[originAccount].TransferMoney(transferValue, 
                                               accounts[targetAccount]);
		}

		private static void DrawMoney()
		{
			Console.Write("Enter the account number: ");
			int accountNumber = int.Parse(Console.ReadLine());

			Console.Write("Enter the amount to be withdrawn: ");
			double drawValue = double.Parse(Console.ReadLine());

            accounts[accountNumber].DrawMoney(drawValue);
		}

		private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("TheBank at your service!!!");
			Console.WriteLine("Enter the desired option :");

			Console.WriteLine("1- List accounts");
			Console.WriteLine("2- Insert new account");
			Console.WriteLine("3- Transfer money");
			Console.WriteLine("4- Draw money");
			Console.WriteLine("5- Deposit money");
            Console.WriteLine("C- Clean the screen");
			Console.WriteLine("X- Exit");
			Console.WriteLine();

			string userOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userOption;
		}
	}
}