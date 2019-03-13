using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_test
{
    
        ///<summary>
        /// Bank Account demo class.
        /// </summary>
        public class BankAccount
        {
            private string m_CustomerName;
            private double m_balance;
            private bool m_frozen = false;
        public const string DebitAmountExceedbalanceMessage = "Debit amount exceed balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
            private BankAccount()
            {

            }
            public BankAccount(string CustomerName, Double balance)
            {
                m_CustomerName = CustomerName;
                m_balance = balance;

            }
            public string CustomerName
            {
                get { return m_CustomerName; }
            }
            public double Balance
            {
                get { return m_balance; }
            }
            public void Debit(double amount)
            {
                if (m_frozen)
                {
                    throw new Exception("Account frozen");
                }
                if (amount > m_balance)
                {
                    throw new ArgumentOutOfRangeException("amount",amount, DebitAmountExceedbalanceMessage);
                }
                if (amount < 0)
                {
                    throw new ArgumentOutOfRangeException("amount",amount,DebitAmountLessThanZeroMessage);
                }
                m_balance -= amount; // intentionally incorrect code
            }

            public void Credit(double amount)
            {
                if (m_frozen)
                {
                    throw new Exception("Account frozen");

                }

                if (amount < 0)
                {
                    throw new ArgumentOutOfRangeException("amount");

                }

                m_balance += amount;

            }
            private void FreezeAccount()
            {
                m_frozen = true;

            }
            private void UnfreezeAccount()
            {
                m_frozen = false;

            }
            public static void Main()
            {

                BankAccount ba = new BankAccount("Mr. bryan Walton", 11.99);

                ba.Credit(5.77);
                ba.Debit(11.22);
                Console.WriteLine("Current balance is ${0}", ba.Balance);
            }


        }
    }

