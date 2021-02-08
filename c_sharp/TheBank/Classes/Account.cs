using System;

namespace TheBank
{
    public class Account
    {

        
        //attributes 
        private AccountType AccountType{get;set;}
        private double Balance {get;set;}
        private double Credit {get;set;}
        private string Name {get;set;}

        //methods
        public Account(AccountType typeAccount, double balance, double credit, string name){
            this.AccountType = AccountType;
            this.Balance = balance;
            this.Name = name; 
            this.Credit = credit;
        }

        public bool DrawMoney(double drawValue){
            if (this.Balance - drawValue <(this.Credit * -1)){
                Console.WriteLine("Insufficient Balance");
                return false;
            }

            this.Balance -= drawValue;
            Console.WriteLine("{0}'s current balance is {1}",
                              this.Name,
                              this.Balance);
            return true; 
        }

        public bool DepositMoney(double depositValue){
            this.Balance += depositValue;
            Console.WriteLine("{0}'s current balance is {1}",
                              this.Name,
                              this.Balance);
            return true; 
        }

        public void TransferMoney(double transferValue, Account targetAccount){
            if (this.DrawMoney(transferValue)){
                targetAccount.DepositMoney(transferValue);
            }
        }

        //toString in a pretty format
        public override string ToString()
        {
            string pretty_format = "";
            pretty_format +="Type Account: " + this.AccountType+ " | ";
            pretty_format +="Name: " + this.Name+ " | ";
            pretty_format +="Balance: " + this.Balance+ " | ";
            pretty_format +="Credit: " + this.Credit + " | ";
            return pretty_format;
        }
    }
}