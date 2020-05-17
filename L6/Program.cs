using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization.Formatters.Binary;

namespace L6
{
    class MainClass
    {
        public static void SerializeData(List<Company> companies)
        {
            try
            {

                FileStream FS = new FileStream("empresas.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(FS, companies);
                FS.Flush();
                FS.Close();
            }

            catch (FileLoadException ex)
            {
                Console.WriteLine(ex.Message);
                System.Threading.Thread.Sleep(1000);
            }
        }

        public static List<Company> DeserializeData(List<Company> companies)
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream FS = new FileStream("empresas.bin", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                companies = (List<Company>)binaryFormatter.Deserialize(FS);
                FS.Close();
                return companies;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                System.Threading.Thread.Sleep(1000);
            }

            return null;
        }

        public static Company CrearCompany(List<Person> persons)
        {
            Console.Clear();
            List<Person> people = new List<Person>(RandomEmploee(persons));
            List<Division> divisions = new List<Division>();
            Console.WriteLine("Crear Empresa\n");
            Console.Write("Ingrese el Nombre:");
            string name = Console.ReadLine();
            Console.Write("Ingrese el Rut:");
            string rut = Console.ReadLine();
            Department department = new Department("Departamento:", people[0]);
            people[0].Position = "Encargado Departameto";
            divisions.Add(department);
            Section section = new Section("Seccion:", people[1]);
            people[1].Position = "Encargado Seccion";
            divisions.Add(section);
            Block block1 = new Block("Bloque: ", people[2], people[3], people[4]);
            divisions.Add(block1);
            people[2].Position = "Encargado Bloque";
            people[3].Position = "Trabajador Bloque";
            people[4].Position = "Trabajador Bloque";
            Block block2 = new Block("Bloque: ", people[5], people[6], people[7]);
            divisions.Add(block2);
            people[5].Position = "Encargado Bloque";
            people[6].Position = "Trabajador Bloque";
            people[7].Position = "Trabajador Bloque";
            Company company = new Company(name, rut, divisions);
            Console.Clear();
            Console.WriteLine("Nombre Empresa: " + name);
            Console.WriteLine("Rut Empresa: " + rut);
            Console.WriteLine("Diviciones:");
            foreach (Division division in divisions)
            {
                Console.WriteLine("\n" + division.Divisioname);
                Console.WriteLine(division.Employee1.Name + " " + division.Employee1.LastName);
                Console.WriteLine(division.Employee1.Rut);
                Console.WriteLine(division.Employee1.Position + "\n");

                if (division.Divisioname == "Bloque: ")
                {
                    Console.WriteLine(division.Employee2.Name + " " + division.Employee2.LastName);
                    Console.WriteLine(division.Employee2.Rut);
                    Console.WriteLine(division.Employee2.Position + "\n");
                    Console.WriteLine(division.Employee3.Name + " " + division.Employee3.LastName);
                    Console.WriteLine(division.Employee3.Rut);
                    Console.WriteLine(division.Employee3.Position);

                }

            }
            Console.WriteLine("\nEmpresa creada con Exito...");
            Console.WriteLine("Pressione cualquier tecla para continunar...");
            Console.ReadKey();
            return company;
        }

        public static List<Person> RandomEmploee(List<Person> persons)
        {
            List<Person> toandompersons = new List<Person>(persons);
            List<Person> randomlist = new List<Person>();
            Random random = new Random();
            while (toandompersons.Count > 0)
            {
                int ran = random.Next(0, toandompersons.Count - 1);
                randomlist.Add(toandompersons[ran]);
                toandompersons.RemoveAt(ran);
            }
            return randomlist;
        }

        public static void ShowCompamy(List<Company> companies)
        {
            Console.Clear();
            foreach (Company company in companies)
            {
                Console.WriteLine("Nombre Empresa: " +company.Name);
                Console.WriteLine("Rut Empresa: "+ company.Rut);
                Console.WriteLine("Diviciones:");
                foreach (Division division in company.Divisions)
                {
                    Console.WriteLine("\n"+ division.Divisioname);
                    Console.WriteLine(division.Employee1.Name +" "+ division.Employee1.LastName);
                    Console.WriteLine(division.Employee1.Rut);
                    Console.WriteLine(division.Employee1.Position + "\n");

                    if (division.Divisioname == "Bloque: ")
                    {
                        Console.WriteLine(division.Employee2.Name + " " + division.Employee2.LastName);
                        Console.WriteLine(division.Employee2.Rut);
                        Console.WriteLine(division.Employee2.Position + "\n");
                        Console.WriteLine(division.Employee3.Name + " " + division.Employee3.LastName);
                        Console.WriteLine(division.Employee3.Rut);
                        Console.WriteLine(division.Employee3.Position);

                    }
                   
                }
                Console.WriteLine("\n Pressione cualquier tecla para continunar...");
                Console.ReadKey();

            }
        }

        public static void Main(string[] args)
        {
            List<Company> companies = new List<Company>();
            List<Person> persons = new List<Person>();
            Person person1 = new Person("Felipe", "Fuentes",null, "11789455-k");
            persons.Add(person1);
            Person person2 = new Person("Emilia", "Garcia", null, "15947076-8");
            persons.Add(person2);
            Person person3 = new Person("Elisa", "Stick", null, "5753120-7");
            persons.Add(person3);
            Person person4 = new Person("Nicolas", "Ruiz", null, "19610091-3");
            persons.Add(person4);
            Person person5 = new Person("Pablo", "Silva", null, "20398539-0");
            persons.Add(person5);
            Person person6 = new Person("Juan", "Gonzales", null, "17616083-7");
            persons.Add(person6);
            Person person7 = new Person("Luiz", "Gomes", null, "16638463-7");
            persons.Add(person7);
            Person person8 = new Person("Fernando", "Suarez", null, "13748383-7");
            persons.Add(person8);

            {
                string[] options = { "Si", "No" ,"Salir"};
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
                            List<Company> company = DeserializeData(companies);
                            if (company != null)
                            {
                                companies = company;
                                Console.WriteLine("1-Quieres ver la inofrmacion de la empresa?");
                                int SeeData = Convert.ToInt16(Console.ReadLine());
                                if (SeeData == 1)
                                {
                                    ShowCompamy(companies);
                                }
                            }
                            else
                            {
                                Company conn = CrearCompany(persons);
                                companies.Add(conn);
                                SerializeData(companies);
                            }
                            break;
                        case "D2":
                            Company con = CrearCompany(persons);
                            companies.Add(con);
                            SerializeData(companies);
                            System.Threading.Thread.Sleep(500);
                            break;
                        case "D3":
                            SerializeData(companies);
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

