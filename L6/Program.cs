using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace L6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Company> companies = new List<Company>();

            void SerializeData()
            {
                try
                {

                    FileStream FS = new FileStream("empresas.txt", FileMode.Create, FileAccess.Write, FileShare.None);
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(FS, companies);
                    FS.Flush();
                    FS.Close();
                }

                catch(Exception ex)
                {
                    Console.WriteLine("Error en serialiacion"+ ex);
                    System.Threading.Thread.Sleep(1000);

                }
            }

            void DeserializeData()
            {
                try
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    FileStream FS = new FileStream("empresas.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    companies = (List<Company>)binaryFormatter.Deserialize(FS);
                    FS.Close();

                }
                catch
                {
                    Console.WriteLine("#ERROR# ARCHIVO NO EXISTE");
                    System.Threading.Thread.Sleep(1000);
                    CrearCompany();

                }
            }

            void CrearCompany()
            {
                Console.Clear();
                Console.WriteLine("Crear Empresa");
                Console.Write("Ingrese el Nombre:");
                string name = Console.ReadLine();
                Console.Write("Ingrese el Rut:");
                string rut = Console.ReadLine();
                Company company = new Company(name, rut);
                companies.Add(company);
                SerializeData();
            }

            {
                string[] options = { "Si", "No" };
                bool searchmenu = true;
                ConsoleKeyInfo selectedOption;
                while (searchmenu)
                {
                    Console.Clear();
                    Console.WriteLine("Quiere utilizar un archivo para cargar la informaciónde la empresa?");
                    Console.WriteLine("Elije una opcion\n");
                    int optionIndex = 1;
                    foreach (string option in options)
                    {
                        Console.WriteLine($"{optionIndex} - {option}");

                        optionIndex += 1;
                    }
                    selectedOption = Console.ReadKey();
                    System.Threading.Thread.Sleep(300);
                    Console.Clear();
                    switch (selectedOption.Key.ToString())
                    {
                        case "D1":
                            DeserializeData();
                            break;
                        case "D2":
                            CrearCompany();
                            break;
                        case "D3":
                            foreach (Company i in companies)
                            {
                                Console.WriteLine(i.Name);
                                Console.WriteLine(i.Rut);
                            }
                            searchmenu = false;
                            break;
                        default:
                            Console.WriteLine("Ingrese option valida...");
                            System.Threading.Thread.Sleep(500);
                            break;
                    }
                }
            }

        }
    }
}

