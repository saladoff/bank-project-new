using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_project_new
{
    public class Bank
    {
        public static void DisplayStartScreen()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("WYBIERZ OPCJĘ: ");
                Console.WriteLine("");
                Console.WriteLine("1 => LISTA WSZYSTKICH KLIENTÓW BANKU ");
                Console.WriteLine("");
                Console.WriteLine("2 => LOGOWANIE ");
                Console.WriteLine("");
                Console.WriteLine("3 => ZAKOŃCZ PROGRAM ");
                var userText = Console.ReadLine();
                int userChoice = 0;
                bool success = int.TryParse(userText, out userChoice);


                if (success)
                {
                    if (userChoice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("ID | IMIĘ I NAZWISKO | NR KONTA | SALDO");
                        ShowClientsList();
                    }
                    else if (userChoice == 2)
                    {
                        Login();
                        Console.Clear();
                        Console.WriteLine("PRZELEW ZOSTAŁ WYKONANY");
                        Console.WriteLine("ID | IMIĘ I NAZWISKO | NR KONTA | SALDO");
                        ShowClientsList();
                        flag = false;
                    }
                    else if (userChoice == 3)
                    {
                        Console.WriteLine("ZAKONCZ PROGRAM");
                        flag = false;
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
                else
                {
                    Console.Clear();
                }
            }
        }


        public static void Login()
        {
            Console.Write("ZALOGUJ SIĘ WYBIERAJĄC ID KLIENTA: ");
            var userText = Console.ReadLine();
            int logInd = 0;
            bool done = int.TryParse(userText, out logInd);
            if (done)
            {
                Console.Clear();
                Console.WriteLine("ZALOGOWANY KLIENT");
                Console.WriteLine($"ID: {Clients.clients[logInd-1].id}");
                Console.WriteLine($"IMIĘ I NAZWISKO: {Clients.clients[logInd-1].fullName}");
                Console.WriteLine($"NR KONTA: {Clients.clients[logInd - 1].nrKonta}");
                Console.WriteLine($"SALDO: {Clients.clients[logInd - 1].Saldo}");
            }
            else
            {
                Console.WriteLine("Logowanie nieudane");

            }
            Console.Write("WPISZ NUMER KONTA NA KTÓRY CHCESZ WYKONAĆ PRZELEW: ");
            
            userText = Console.ReadLine();
            int accNumb = 0;
            done = int.TryParse(userText, out accNumb);
            int cAccNumb = int.Parse(Clients.clients[logInd - 1].nrKonta);
            if (cAccNumb == accNumb)
            {
                Console.WriteLine("Nieprawidlowy numer konta");
            }
            else
            {
                if (done)
                {
                    Console.Clear();
                    Console.Write("PODAJ KWOTĘ PRZELEWU: ");

                    userText = Console.ReadLine();
                    int transAmount = 0;
                    done = int.TryParse(userText, out transAmount);
                    decimal cBalance = Clients.clients[logInd - 1].Saldo;
                    if (cBalance >= transAmount)
                    {
                        if (done)
                        {
                            Clients.clients[logInd - 1].Saldo -= transAmount;
                            Clients.clients[accNumb - 1].Saldo += transAmount;
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidlowa kwota");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidlowa kwota");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Nieprawidlowy numer konta");
                    Console.ReadLine();
                }
            }

            
        }


        void ClientsBaseAdd()
        {
            Clients.GetData(Clients.clients, out Clients _, 1, "Jan", "Nowak", "001", 1457.23m);
            Clients.GetData(Clients.clients, out Clients _, 2, "Agnieszka", "Kowalska", "002", 3600.18m);
            Clients.GetData(Clients.clients, out Clients _, 3, "Robert", "Lewandowski", "003", 2745.03m);
            Clients.GetData(Clients.clients, out Clients _, 4, "Zofia", "Plucińska", "004", 7344.00m);
            Clients.GetData(Clients.clients, out Clients _, 5, "Grzegorz", "Braun", "005", 455.38m);
        }



        static void ShowClientsList()
        {
            foreach (var client in Clients.clients)
            {
                Console.WriteLine($" {client.id} | {client.firstName} | {client.lastName} | {client.nrKonta} | {client.Saldo}");
            }
        }
    }
}
