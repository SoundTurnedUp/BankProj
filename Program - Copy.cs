int Balance = 0;
string[] statement = new string[5];
void BankMenu()
{
    Console.WriteLine("= MENU =");
    Console.WriteLine("Deposit");
    Console.WriteLine("Withdraw");
    Console.WriteLine("View balance");
    Console.WriteLine("View statement of account");
    Console.WriteLine("Exit");
}
void AccountCreator()
{
    string Username; string Password = ""; string PasswordConfirm;
    Console.WriteLine("Enter username");
    Username = Console.ReadLine();
    bool PasswordEntered = false;
    while (PasswordEntered == false)
    {
        Console.WriteLine("Enter password");
        Password = Console.ReadLine();
        Console.WriteLine("Confirm password");
        PasswordConfirm = Console.ReadLine();
        if (Password != PasswordConfirm)
        {
            Console.WriteLine("Passwords do not match");
        }
        else
        {
            PasswordEntered = true;
        }
    }
    Console.WriteLine("Account created");
    Random rnd = new Random();
    int AccountNum = rnd.Next(000000, 999999);
    Console.WriteLine("Your account number is " + AccountNum);
    File.WriteAllText("Account.txt", AccountNum + Username + Password + Balance);
}
void LogIn()
{
    Console.WriteLine("Enter your username");
}
if (File.Exists("Balance.txt"))
{
    Balance = Convert.ToInt32(File.ReadAllText("Balance.txt"));
}
AccountCreator();
bool exit = false;
while (exit == false)
{
    int Deposit = 0; int Withdraw = 0;
    for (int i = 0; i < 5; i++)
    {
        BankMenu();
        string choice = Console.ReadLine();
        if (choice == "Deposit")
        {
            bool Deposited = false;
            while (Deposited == false)
            {
                Console.WriteLine("How much would you like to deposit?");
                Deposit = Convert.ToInt32(Console.ReadLine());
                if (Deposit > 0)
                {
                    Balance = Balance + Deposit;
                    Console.WriteLine("New balance is " + Balance);
                    File.WriteAllText("Balance.txt", Convert.ToString(Balance));
                    Balance = Convert.ToInt32(Balance);
                    statement[i] = "Deposited " + Deposit + " Balance after deposit = " + Balance;
                    Deposited = true;
                }
                else
                {
                    Console.WriteLine("Invalid deposit, try again");
                }
            }
        }
        if (choice == "Withdraw")
        {
            bool Withdrawn = false;
            while (Withdrawn == false)
            {
                Console.WriteLine("How much would you like to withdraw?");
                Withdraw = Convert.ToInt32(Console.ReadLine());
                if (Withdraw < Balance)
                {
                    Balance = Balance - Withdraw;
                    Console.WriteLine("New balance is " + Balance);
                    File.WriteAllText("Balance.txt", Convert.ToString(Balance));
                    Balance = Convert.ToInt32(Balance);
                    statement[i] = "Withdrew " + Withdraw + " Balance after withdraw = " + Balance;
                    Withdrawn = true;
                }
                if (Withdraw > Balance)
                {
                    Console.WriteLine("Invalid withdrawal");
                }
            }
        }
        if (choice == "View statement")
        {
            Console.WriteLine(statement[0]);
            Console.WriteLine(statement[1]);
            Console.WriteLine(statement[2]);
            Console.WriteLine(statement[3]);
            Console.WriteLine(statement[4]);
        }
        if (choice == "View balance")
        {
            Console.WriteLine("Your balance is " + Balance);
        }
        if (choice == "Exit")
            exit = true;
    }
}