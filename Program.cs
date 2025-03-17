namespace ProjektTest
{
    internal class Program
    {
        static string DBFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Database.txt");

        static void Main(string[] args)
        {
            string menuValg, brugerNavn, adgangsKode;
            bool fortsætMenu = true;

            // Opretter tekstfilen, hvis den ikke allerede eksistere. (!) betyder not, så det er en måde man inverterer sandt og falsk.
            if (!File.Exists(DBFile))
            {
                File.Create(DBFile).Dispose();
            }
            bool IsRunning = true; // bool til at holde om programmet skal køre

            do
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                // Start menu
                Console.Title = "CMIS - Informationsstander";
                Console.WriteLine("Velkommen til CMIS.\nHer kan du tilmelde dig til vores nyhedsbrev!\n");
                Console.WriteLine("────────── [ MENU ] ──────────");
                Console.WriteLine("Indtast en af de nedstående typer. (f.eks. 1, 2, 3 eller 4)");
                Console.WriteLine(" ");
                Console.WriteLine("[1] ■ Tilmeld nyhedsbrev - hver måned.");
                Console.WriteLine(" ");
                Console.WriteLine("[2] ■ Tilmeld nyhedsbrev - hver tredje måned.");
                Console.WriteLine(" ");
                Console.WriteLine("[3] ■ Tilmeld nyhedsbrev - hvert år.");
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("[4] ■ Login - Admin");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(" ");
                Console.WriteLine("──────────────────────────────");
                Console.WriteLine(" ");
                Console.Write("Valg: ");

                // Afventer tastetryk.
                menuValg = Console.ReadLine().ToUpper();
                Console.WriteLine(" ");
                switch (menuValg)
                {
                    case "1":
                        Console.WriteLine("Du har valgt overstående (Nyhedsbrev hver måned).");
                        Console.WriteLine(" ");
                        Create();
                        break;

                    case "2":
                        Console.WriteLine("Du har valgt overstående (Nyhedsbrev hver tredje måned).");
                        Console.WriteLine(" ");
                        Create();
                        break;

                    case "3":
                        Console.WriteLine("Du har valgt overstående (Nyhedsbrev hvert år).");
                        Console.WriteLine(" ");
                        Create();
                        break;

                    case "4":
                        fortsætMenu = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Login - Admin\n");
                        Console.WriteLine("[USERNAME] : \n");
                        Console.WriteLine("[PASSWORD] : ");
                        Console.SetCursorPosition(13, 3);
                        brugerNavn = Console.ReadLine().ToUpper();
                        Console.SetCursorPosition(13, 5);
                        adgangsKode = Console.ReadLine().ToUpper();

                        if (adgangsKode == "PASSWORD" && brugerNavn == "CMIS")
                        {
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            Console.WriteLine("Logger ind.");
                            System.Threading.Thread.Sleep(500);
                            Console.Clear();
                            Console.WriteLine("Logger ind..");
                            System.Threading.Thread.Sleep(300);
                            Console.Clear();
                            Console.WriteLine("Logger ind...");
                            System.Threading.Thread.Sleep(800);
                            Console.Clear();

                            do
                            {
                                Console.WriteLine("Admin Panel\n");
                                Console.WriteLine("1. Opret" +
                                    "\n2. Se alle" +
                                    "\n3. Søg" +
                                    "\n4. Opdater" +
                                    "\n5. Slet" +
                                    "\n0. Afslut");
                                int.TryParse(Console.ReadLine(), out int choice);

                                Console.Clear();

                                switch (choice)
                                {
                                    case 1:
                                        // Kalder på Create metoden.
                                        Create();
                                        break;

                                    case 2:
                                        // Kalder på ReadAll metoden.
                                        ReadAll();
                                        break;

                                    case 3:
                                        // Kalder på Read metoden.
                                        Read();
                                        break;

                                    case 4:
                                        // Kalder på Update metoden.
                                        Update();
                                        break;

                                    case 5:
                                        // Kalder på Delete metoden.
                                        Delete();
                                        break;

                                    case 0:
                                        Console.WriteLine("Vender tilbage til menuen..");
                                        IsRunning = false;
                                        fortsætMenu = true;
                                        break;

                                    default:
                                        Console.WriteLine("Fejlindtastning");
                                        break;
                                }
                                Console.ReadKey();
                            } while (IsRunning);
                        }
                        else
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Forkert brugernavn eller adgangskode..\n");
                            Console.WriteLine("Vender tilbage til menuen om 3 sekunder");
                            System.Threading.Thread.Sleep(3000);
                            fortsætMenu = true;
                            break;
                        }
                        break;
                }
            } while (fortsætMenu); // Afslut do-while loopet, som styrer hele programmet.

            // Metode til at oprette en person
            static void Create()
            {
                Console.WriteLine("Indtast dit fulde navn");
                Console.Write("Navn: ");
                string name = Console.ReadLine();
                Console.WriteLine("Indtast dit telefonnummer");
                Console.Write("Telefonnummer: ");
                string phone = Console.ReadLine();

                // Tjek om telefonnummeret allerede findes i databasen
                bool phoneExists = false;
                if (File.Exists(DBFile))
                {
                    // Læs filens indhold og tjek om telefonnummeret allerede er der
                    string[] lines = File.ReadAllLines(DBFile);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length >= 1 && parts[0] == phone)
                        {
                            phoneExists = true;
                            break;
                        }
                    }
                }

                if (phoneExists)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("FEJL: Telefonnummeret findes allerede.");
                    
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Indtast din adresse"); ;
                    Console.Write("Adresse: ");
                    string adresse = Console.ReadLine();

                    // Skriv til filen, hvis telefonnummeret ikke er der
                    using (StreamWriter writer = new StreamWriter(DBFile, true))
                    {
                        writer.WriteLine($"{phone},{name},{adresse}");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tak for din tilmelding! Du vil modtage nyhedsbreve efter eget valg.");
                    Console.ReadKey();
                }
            }
        }

            // Metode til at læse og udskrive alle personer.
            static void ReadAll()
            {
                using (StreamReader reader = new StreamReader(DBFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }

            // Metode til at søge efter personer, der matcher søgetermet.
            static void Read()
            {
                Console.WriteLine("Indtast hvad du søger efter");
                Console.Write("Søg: ");
                string search = Console.ReadLine();
                using (StreamReader reader = new StreamReader(DBFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        foreach (string field in fields)
                        {
                            if (field.Contains(search))
                            {
                                Console.WriteLine(line);
                            }
                        }
                    }
                }
            }

            // Metode til at opdatere informationer om en person.
            static void Update()
            {
                List<string> lines = new List<string>();
                Console.WriteLine("Indtast telefonnummer på den du vil opdatere.");
                Console.Write("Telefonnummer: ");
                string phone = Console.ReadLine();
                Console.WriteLine("Indtast personens nye fulde navn.");
                Console.Write("Navn: ");
                string name = Console.ReadLine();
                Console.WriteLine("Indtast personens adresse.");
                Console.Write("Adresse: ");
                string adresse = Console.ReadLine();
                using (StreamReader reader = new StreamReader(DBFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var fields = line.Split(',');
                        if (fields[0] == phone)
                        {
                            lines.Add($"{phone},{name},{adresse}");
                        }
                        else
                        {
                            lines.Add(line);
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(DBFile, false))
                {
                    foreach (var l in lines)
                    {
                        writer.WriteLine(l);
                    }
                }
                Console.WriteLine("Bruger opdateret!");
            }

            // Metode til at slette en person.
            static void Delete()
            {
                List<string> lines = new List<string>();
                Console.WriteLine("Indtast telefonnummer på den du vil slette.");
                Console.Write("Telefonnummer: ");
                string phone = Console.ReadLine();
                using (StreamReader reader = new StreamReader(DBFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var fields = line.Split(',');
                        if (fields[0] != phone)
                        {
                            lines.Add(line);
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(DBFile, false))
                {
                    foreach (var l in lines)
                    {
                        writer.WriteLine(l);
                    }
                }
                Console.WriteLine("Bruger fjernet");
            }
        }
    }

