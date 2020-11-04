using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Npgsql;

namespace DBManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            View menu = new View();
            menu.ShowMainMenu();
        }                                                                                                                       
    }
}
