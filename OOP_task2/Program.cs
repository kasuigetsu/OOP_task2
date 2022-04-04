using System;

namespace OOP_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {   //Вызов конструкторов
                BancAccount nullAccount = new BancAccount();
                BancAccount firstAccount = new BancAccount(12345);
                BancAccount secondAccount = new BancAccount("active");
                BancAccount thirdAccount = new BancAccount(3022,"frozen");
                //Список аккаунтов
                BancAccount[] accounts =
                {
                    nullAccount,
                    firstAccount,
                    secondAccount,
                    thirdAccount
                };

                Console.WriteLine("Введите номер счета, с которым хотите работать:");
                int num = Convert.ToInt32(Console.ReadLine());
                accounts[num-1].getInfo(num);

                //Внесение на счет
                Console.WriteLine("\nВведите сумму, которую хотите внести на счет:");
                int sumToDepos = Convert.ToInt32(Console.ReadLine());
                accounts[num - 1].toDeposit(sumToDepos);
                accounts[num - 1].getInfo(num);

                //Снятие со счета
                Console.WriteLine("Введите сумму, которую хотите снять со счета: ");
                int sumWithdraw = Convert.ToInt32(Console.ReadLine());
                accounts[num - 1].withdraw(sumWithdraw);
                accounts[num - 1].getInfo(num);

                //Перевод с одного счета на другой (task 3.1)
                Console.WriteLine("Введите номер счета, с которого хотите перевести деньги и сумму через enter:");
                int numTranslating = Convert.ToInt32(Console.ReadLine());
                int sumToTranslate = Convert.ToInt32(Console.ReadLine());
                if (accounts[numTranslating-1].Equals(accounts[num-1]))
                {
                    Console.WriteLine("Вы выбрали один и тот же счет.");
                }
                else
                {
                    accounts[num - 1].translation(accounts[numTranslating - 1], sumToTranslate);
                    accounts[num - 1].getInfo(num);
                }



            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    class BancAccount 
    {
        static int accountNumber { get; set; } = 0;
        private double balance{ get; set; } = 0;
        private int type { get; set; } = 1;
      
        public enum AccountType
        {
            Active=1,
            Frozen=2,
            Locked=3
        }
        public BancAccount()
        {
            generateAccountNumb();
            Console.WriteLine($"Номер счета: {accountNumber}\nБаланс: {balance}\nТип бансковского счета: { (AccountType)1} ");
            
        }
       public BancAccount(double balance)//Конструктор 1
        {
            generateAccountNumb();
            this.balance = balance;
            Console.WriteLine($"Номер счета: {accountNumber}\nБаланс: {balance}");
            
        }
        public BancAccount(string type)//Конструктор 2
        {
            generateAccountNumb();
            if (type=="active")
            {
                Console.WriteLine($"Номер счета: {accountNumber}\nТип бансковского счета: {(AccountType)1}");
                this.type = 1;
            }
         else if(type=="frozen")
            {
                Console.WriteLine($"Номер счета: {accountNumber}\nТип бансковского счета: {(AccountType)2}");
                this.type = 2;
            }
            else if(type=="locked")
            {
                Console.WriteLine($"Номер счета: {accountNumber}\nТип бансковского счета: {(AccountType)3}");
                this.type = 3;
            }
            
        }
        public BancAccount(double balance, string type)//Конструктор 3
        {
            generateAccountNumb();
            this.balance = balance;
            if (type == "active")
            {
                Console.WriteLine($"Номер счета: {accountNumber}\nБаланс: {balance}\nТип бансковского счета: {(AccountType)1}");
                this.type = 1;
            }
            else if (type == "frozen")
            {
                Console.WriteLine($"Номер счета: {accountNumber}\nБаланс: {balance}\nТип бансковского счета: {(AccountType)2}");
                this.type = 2;
            }
            else if(type=="locked")
            {
                Console.WriteLine($"Номер счета: {accountNumber}\nБаланс: {balance}\nТип бансковского счета: {(AccountType)3}");
                this.type = 3;
            }
           
        }
        private void generateAccountNumb()//генерация номера счета
        {
            accountNumber++;
        }
        public void translation(BancAccount account, double sum)//перевод
        {
            if(account.balance>=sum)
            {
                this.balance = this.balance + sum;
                account.balance = account.balance - sum;
                Console.WriteLine("Перевод выполнен.");
            }
            else Console.WriteLine("На указанном счете недостаточно средств.");
           
        }
        public void withdraw(int sum)//снять
        {
            if(balance>=sum)
            {
               this.balance = balance - sum;
            }
            else Console.WriteLine("На вашем счете недостаточно средств.");
        }

        public void toDeposit(int sum)//положить
        {
            this.balance = balance + sum;
        }
        /*
        public void inputInfo()
        {
            Console.WriteLine("Введите данные о банковском аккаунте через Enter(баланс, тип счета(1-Active,2-Frozen,3-Blocked))");
            int balance = Convert.ToInt32(Console.ReadLine());
            char type = Convert.ToChar(Console.ReadLine());

            this.balance = balance;
            
        }*/
        public void getInfo(int num)
        {
            accountNumber = num;
            Console.WriteLine($"Информация о бансковском счете: \nНомер вашего счета: {accountNumber}\nБаланс: {balance}\nТип вашего бансковского счета:{(AccountType)type}");
        }


    }

}

