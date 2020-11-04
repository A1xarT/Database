using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Npgsql;

namespace DBManagement
{
    class View
    {
        Controller controller;
        Model model;
        
        public View()
        {
            model = new Model();
            controller = new Controller();
        }
        public void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. View Db content");
            Console.WriteLine("2. Insert");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. SQL tool");
            Console.WriteLine("6. Random insert to \"Тренер\"");
            Console.WriteLine("7. Exit");
            int dbPart;
            int userChoice = controller.MainMenuChoice();
            List<string> lst;
            Console.Clear();
            switch (userChoice)
            {
                case 1:
                    dbPart = controller.TableChoice();
                    if (dbPart == 0)
                    {
                        ShowMainMenu();
                        return;
                    }
                    controller.cmd.CommandText = ShowTable.ContentOut(model.Tables[dbPart]);
                    lst = controller.ExecuteReading(dbPart);
                    Console.Clear();
                    foreach (string item in lst)
                        Console.WriteLine(item);
                    Console.ReadKey();
                    ShowMainMenu();
                    return;
                case 2:
                    dbPart = controller.TableChoice();
                    if (dbPart == 0)
                    {
                        ShowMainMenu();
                        return;
                    }
                    controller.cmd.CommandText = Insert.InsertItem(model.Tables[dbPart]);
                    controller.ExecuteInserting(dbPart);
                    Console.ReadKey();
                    ShowMainMenu();
                    return;
                case 3:
                    dbPart = controller.TableChoice();
                    if (dbPart == 0)
                    {
                        ShowMainMenu();
                        return;
                    }
                    controller.cmd.CommandText = Update.UpdateItem(model.Tables[dbPart]);
                    controller.ExecuteUpdating(dbPart);
                    Console.ReadKey();
                    ShowMainMenu();
                    return;
                case 4:                    
                    dbPart = controller.TableChoice();
                    if (dbPart == 0)
                    {
                        ShowMainMenu();
                        return;
                    }
                    controller.cmd.CommandText = Delete.DeleteItem(model.Tables[dbPart]);
                    controller.ExecuteDeleting();
                    Console.ReadKey();
                    ShowMainMenu();
                    return;
                case 5:
                    Console.WriteLine("1. Пошук команд та їх тренерів за назвою команди, спонсором та датою народження тренера команди");
                    Console.WriteLine("2. Пошук стадіонів та змагань за кількістю місць, на яких заплановані змагання у заданий проміжок дати та часу");
                    Console.WriteLine("3. Пошук команд і змагань за загальною кількістю очок, тривалістю змагань і арбітром");
                    Console.WriteLine("0. Back");
                    int choice = controller.SqlChoice();
                    if(choice == 0)
                    {
                        ShowMainMenu();
                        return;
                    }
                    long ms = 0;
                    lst = controller.ExecuteSQL(choice, ref ms);
                    foreach(string item in lst)
                        Console.WriteLine(item);
                    Console.WriteLine($"Execution time: {ms}");
                    Console.ReadKey();
                    ShowMainMenu();
                    return;
                case 6:
                    controller.ExecuteRandomCoachInsert();
                    Console.ReadKey();
                    ShowMainMenu();
                    return;
                default:
                    break;
            }
        }
        public static void PrintTables()
        {
            Console.WriteLine("1. Команда");
            Console.WriteLine("2. Тренер");
            Console.WriteLine("3. Стадіон");
            Console.WriteLine("4. Змагання");
            Console.WriteLine("5. Результати_вправ");
            Console.WriteLine("6. Команда_Змагання");
            Console.WriteLine("0. Back");
        }
        public static void WrongNumber()
        {
            Console.WriteLine("Wrong number. Try again");
        }
    }
    
}
