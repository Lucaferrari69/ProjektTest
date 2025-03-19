﻿namespace ProjektTest
{
    internal class Program /********HUSK AT OMDØBE PROGRAM**********/
    {
        /*Denne kode er skrevet ae*/

        //string-variablen "databaseFil" - definerer/indeholder lokal sti til Database.txt
        static string databaseFil = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Database.txt");
        //variabel databaseFil = KOMBINER STI (INDSÆT DENNE STI(STI), FIL)

        /*  DETALJERET FORKLARING:
         

         static string databaseFil - klassespecifik variabel: static gør at variablen tilhører program(altså CMISinfostander)-klassen,
                                     så den kan tilgås/arbejdes med uden at eksistere inden.
         
          Path.Combine() - STIEN: metode fra System.IO-namespace til at kombinere flere stier til korrekt formateret sti,
                                  uanset hvilket operativsystem, programmet køres på.
        sti 1:
          (Environment.GetFolderPath())  - metode, der returnerer/"indsætter" stien til en lokal systemmappe på computeren

        kombineres med
        
        sti 2:
          (Environment.SpecialFolder.MyDocuments) - sti til "Dokumenter"-systemmappen.
                                                    feks for windows C:\Users\Gruppe5\Documents.

          "Database.txt" - FILEN
        
        altså: Path.Combine(HENT DENNE STI(HVOR), "HVAD")         
         */

        static void Main(string[] args)
        {
            //deklarerer og initialiserer variabler
            string menuValg, brugerNavn, adgangsKode, systemBruger = "CMIS", systemKode = "PASSWORD";

            //boolean(true/false) - værdi, der styrer om menuen skal fortsætte eller ej
            bool fortsætMenu = true; //true: fortsæt menuen

            //if-betingelse: hvis filen ikke eksisterer køres koden i curly-brackets
            if (!File.Exists(databaseFil))
            {
                //opret filen og luk den igen efter oprettelse
                File.Create(databaseFil).Dispose();

                /*FORKLARING:
                 
                 File.Create() for sig selv holder filen åben til at læse og skrive i.
                
                 .Dispose() lukker den og frigiver de systemressourcer, der ellers bliver brugt til
                            at holde den åben - vi tager altså "fingrene ud af kagedåsen" og undgår
                            at filen bliver lukket forkert eller tilgået flere steder fra samtidigt*/
            }
            bool programKører = true; //

            do //starter do-while løkke 1, som styrer hele programmet
            {
                Console.BackgroundColor = ConsoleColor.White; //indstiller baggrundsfarve på skærm
                Console.ForegroundColor = ConsoleColor.Black; //indstiller tekstfarve
                Console.Clear();

                //titel på konsolvinduet
                Console.Title = "CMIS - Informationsstander";

                //udskriver menu til skærm, laver linjeskift
                Console.Write("\nVelkommen til CMIS.\nHer kan du tilmelde dig til vores nyhedsbrev! \n" +
                    "────────── [ MENU ] ────────── \n" +
                    "Indtast en af de nedstående typer. (f.eks. 1, 2, 3 eller 4)\n\n" +
                    "[1] ■ Tilmeld nyhedsbrev - hver måned.\n\n" +
                    "[2] ■ Tilmeld nyhedsbrev - hver tredje måned.\n\n" +
                    "[3] ■ Tilmeld nyhedsbrev - hvert år.\n\n");

                Console.ForegroundColor = ConsoleColor.Gray; //indstiller tekstfarve

                Console.Write("[4] ■ Login - Admin");

                Console.ForegroundColor = ConsoleColor.Black; //indstiller tekstfarve

                Console.Write("\n\n──────────────────────────────\n\n" +
                    "Valg: ");

                //læser indtastning, tildeler værdi til variabel
                menuValg = Console.ReadLine();

                Console.WriteLine(" ");

                //starter switch-case til indtastning (værdi i variablen menuValg)
                switch (menuValg)
                {
                    case "1": //betingelse: hvis indtastning er menu-valg 1, kør case-kode
                        Console.Write("Du har valgt at få nyhedsbrevet tilsendt månedligt\n");
                        Create(); //kalder på metoden Create
                        break; //afslutter case

                    case "2":
                        Console.WriteLine("Du har valgt at få nyhedsbrevet tilsendt hver tredje måned\n");
                        Create();
                        break;

                    case "3":
                        Console.WriteLine("Du har valgt at få nyhedsbrevet tilsendt årligt");
                        Console.WriteLine(" ");
                        Create();
                        break;

                    case "4":
                        Console.Title = "LOGIN"; //indstiller titel på konsol-vindue
                        fortsætMenu = false; //afslutter menuen
                        Console.Clear(); //renser skærmen

                        //udskriver til skærm, lavindsætter linjeskift
                        Console.Write("\nLogin - Admin\n\n" +
                            "[USERNAME] : \n\n" +
                            "[PASSWORD] : ");

                        //flytter curseren
                        Console.SetCursorPosition(13, 3);
                        //tildeler værdi til variabler, konverterer til uppercase
                        brugerNavn = Console.ReadLine().ToUpper();
                        Console.SetCursorPosition(13, 5);
                        adgangsKode = Console.ReadLine().ToUpper();

                        //if-statement: betingelse tjekker om indtastning stemmer med systemets admin-loginoplysninger
                        if (adgangsKode == systemKode && brugerNavn == systemBruger)
                        {
                            //hvis login er rigtig, kør kode
                            System.Threading.Thread.Sleep(1000); //pauser program i 1 sekund
                            Console.Clear(); //renser skærm
                            Console.WriteLine("Logger ind.");
                            System.Threading.Thread.Sleep(500);
                            Console.Clear();
                            Console.WriteLine("Logger ind..");
                            System.Threading.Thread.Sleep(300);
                            Console.Clear();
                            Console.WriteLine("Logger ind...");
                            System.Threading.Thread.Sleep(800);
                            Console.Clear();

                            //starter do-while løkke 2, som styrer admin-panel
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Admin Panel\n");
                                Console.WriteLine("[1] Opret" +
                                    "\n[2] Se alle" +
                                    "\n[3] Søg" +
                                    "\n[4] Opdater" +
                                    "\n[5] Slet" +
                                    "\n[0] Log ud");
                                //læser indtastning, forsøger at konvertere til int, opretter & tildeler værdi til variabel
                                int.TryParse(Console.ReadLine(), out int adminPanel);

                                /*********************** HVIS KONVERTERING FEJLER = VIOLATION SKAL STYRES, SÅ DEN IKKE HOPPER TIL CASE 0*/

                                Console.Clear(); //renser skærm

                                //starter switch-case til admin-panel
                                switch (adminPanel)
                                {
                                    case 1: //hvis indtastning er 1
                                        Create(); //kalder metoden Create
                                        break; //afsnutter case

                                    case 2:
                                        //kalder metoden ReadAll
                                        ReadAll();
                                        break;

                                    case 3:
                                        //kalder metoden Read
                                        Read();
                                        break;

                                    case 4:
                                        //kalder metoden Opdater
                                        Opdater();
                                        break;

                                    case 5:
                                        //kalder metoden Delete
                                        Delete();
                                        break;

                                    case 0:
                                        Console.Write("Tryk på en tast for at vende tilbage til menuen\n");
                                        programKører = false; //ændrer bool til false, 
                                        fortsætMenu = true; //ændrer bool til true, hopper tilbage til menu
                                        break;

                                    default:
                                        Console.WriteLine("Fejl i indtastning.\n\n" +
                                            "Tryk på en tast for at vende tilbage");
                                        break;
                                }
                                Console.ReadKey();
                            } while (programKører); //slutter do-while løkke 2, som styrer admin-panel switch-case

                            /****************************************** TJEK OG RET BOOLS TIL RETVISENDE NAVNE *************************************/
                        }
                        else //hvis brugernavn og/eller password er forkert
                        {
                            Console.Clear();
                            Console.WriteLine("\nAdgang nægtet\n" +
                                "Vender tilbage til menuen om 3 sekunder");
                            System.Threading.Thread.Sleep(3000); //pauser programmet i 3sek
                            fortsætMenu = true; //hopper tilbage til menu-skærm
                            break;
                        }
                        break;
                }
            } while (fortsætMenu); // slutter do-while løkke 1, som styrer hele programmet.

            /****************************************** TJEK OG RET BOOLS TIL RETVISENDE NAVNE *************************************/

            // metode til at oprette en person i databasen
            static void Create() //void betyder, at metoden ikke returnerer en værdi
            {
                Console.Write("Indtast dit fulde navn\n" +
                    "Navn: ");
                //læser indtastning, opretter variabel og tildeler værdi
                string navn = Console.ReadLine();
                Console.Write("\nIndtast dit telefonnummer\n" +
                    "Telefonnummer: ");
                string tlf = Console.ReadLine();

                // int til at tjekke om telefonnummeret allerede findes i databasen
                int tjekNr = 0; //0: det findes ikke før det er bevist, at det findes

                if (File.Exists(databaseFil)) //hvis database-fil eksisterer, kør kode
                {
                    //opretter string-arrayet linjer, læser filens indhold og smider hver linje i filen ind i array som et element
                    string[] linjer = File.ReadAllLines(databaseFil);

                    //foreach løkke. for hvert element (variablen line) i linjer-array'et, dvs. hver linje i filen
                    foreach (string linje in linjer)
                    {
                        //opretter array'et dele til opdeling af hverenkelt linje i filen, så den bliver flere elementer
                        string[] dele = linje.Split(','); //opdel linjens indhold ved komma-tegn til separate elementer

                        /************FIND LØSNING TIL PROBLEM:
                         - ADRESSER MED KOMMA: FEKS "GULDBLOMMEVEJ 5, 3.TV" 
                        
                         - SKAL DET VÆRE ADRESSER ELLER EMAIL? OVERVEJ BÆREDYGTIGHED? 
                        
                         LØSNINGSFORSLAG: JEG HAR EN GAMMEL KODE TIL AT TESTE EMAIL-ADR
                                          MEN I SKAL TJEKKE OM DEN ER TIL AT FORSTÅ ELLER VI SKAL GØRE NOGET ANDET
                                          FEKS BEDE OM AT MAN IKKE SKRIVER KOMMAER I ADRESSEN OG BYTTE UD MED ????
                                          MEN SÅ SKAL VI OGSÅ KODE OS UD AF, HVIS MAN SKRIVER KOMMA ALLIGEVEL ***************/

                        //betingelse: arrayet har 1 eller flere elementer og første element er det samme som indtastning til tlfnr
                        if (dele.Length >= 1 && dele[0] == Convert.ToString(tlf))
                        {
                            //altså hvis tlf-nummeret allerede eksisterer i filen
                            tjekNr += 1; //lægger 1 til variablens værdi
                        }
                        else //altså hvis tlf-nummeret ikke findes
                        {
                            tjekNr += 0; //lægger 0 til variablens værdi
                        }

                    }
                }

                if (tjekNr > 0) //hvis nummer findes (tjekNr er mere end 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; //indstiller skriftfarve
                    Console.WriteLine("FEJL: Telefonnummeret findes allerede.");
                    Console.ForegroundColor = ConsoleColor.Black;

                    //venter på tastetryk
                    Console.ReadKey();
                }
                else //hvis nummer IKKE findes (tjekNr ikke er mere end 0)
                {
                    Console.Write("Indtast din adresse\n" +
                        "Adresse: ");
                    string adresse = Console.ReadLine();

                    //skriv til filen, hvis telefonnummeret ikke er der
                    using (StreamWriter Filskriver = new StreamWriter(databaseFil, true))
                    {
                        Filskriver.WriteLine($"{tlf},{navn},{adresse}");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tak for din tilmelding! Vi glæder os til at holde dig opdateret");
                    Console.ForegroundColor = ConsoleColor.Black;

                    //venter på tastetryk
                    Console.ReadKey();
                }
            }
        }

        //metode til at læse og udskrive indhold i database-fil
        static void ReadAll()
        {
            if (File.Exists(databaseFil)) //hvis fil eksisterer, kør kode
            {
                //string-array linjer - læser filens indhold og smider hver linje i filen ind i array som et element
                string[] linjer = File.ReadAllLines(databaseFil);

                //initialiserer variabler til matematisk funktion, hvor y er en funktion af x    -    f(x) = a * x 
                int a = 14, x = 0, y = a * x;
                /* a= antal linjer der skrives, x = "side", y= første linje pr side /element i array*/

                Console.WriteLine("Viser alle modtagere af nyhedsbrevet. Der vises 14 tilmeldte ad gangen");

                /*************************** TEST ET ANTAL DER GÅR OP I 14 *********************************/
                while (y < linjer.Length && linjer.Length > 12) //så længe der er linjer tilbage i filen
                {
                    //vis elementerne fra y til y + a, men ikke mere end linjer.Length
                    for (int i = y; i < y + a && i < linjer.Length; i++) // Tjekker, så vi ikke går ud over antallet af linjer i filen
                    {
                        Console.WriteLine(linjer[i]); //skriv element nr i til skærm
                    }

                    //skriver til skærm
                    Console.Write($"\n\nViser index {x + 1} til {y + a}\n" +
                        "Tryk på [Enter] for at vise flere");

                    Console.ReadKey(); //venter på tastetryk

                    x++; //øger x med 1
                    y = a * x; //beregner y(x) = a * x for at vise de næste linjer
                    Console.Clear();
                }

                Console.WriteLine("\nDer er ikke mere at vise");
                /*************************** TEST ET ANTAL DER GÅR OP I 14 *********************************/

                /* DETALJERET FORKLARING:
               
               a - konstant: 14. antallet af linjer, der skal skrives til skærmen ad gangen.
               x - uafhængig variabel. tæller allet af "hop" i visningen/hvor mange gange er der blevet vist 14 linjer.
               y - afhængig (af x) variabel. linjenummeret på den første linje, der skrives til skærmen i "hoppet"
               x initialiseres til 0, og derfor starter vi med linje 1 (element 0 i array), fordi:
               y(0) = 14 * 0 = 0 - derefter øges x med 1 (hver gang der er skrevet 14 linjer), så:
               y(1) = 14 * 1 = 14 - næste "side" starter med element 14 i array (line 15 i fil), derefter
               y(2) = 14 * 2 = 28 - element 28/linje 29     */

            }
        }

        //metode til at søge efter personer, der matcher søgeord.
        static void Read()
        {
            Console.WriteLine("Indtast hvad du søger efter");
            Console.Write("Søg: ");
            string søg = Console.ReadLine();
            using (StreamReader Fillæser = new StreamReader(databaseFil))
            {
                string linje;
                while ((linje = Fillæser.ReadLine()) != null) //så længe antallet af linjer i filen ikke er 0
                {
                    string[] felter = linje.Split(',');//array felter til at opdele hver linje i separate elementer  
                    foreach (string felt in felter)//for hvert felt i arrayet felter
                    {
                        if (felt.Contains(søg)) //hvis felt indeholder søgeord
                        {
                            Console.WriteLine(linje);
                        }
                    }
                }
            }
        }

        //metode til at opdatere informationer om en person i database-filen.
        static void Opdater()
        {
            List<string> linjer = new List<string>(); //liste - som array, men uden fordefineret antal elementer
            Console.WriteLine("Indtast telefonnummer på den du vil opdatere.");
            Console.Write("Telefonnummer: ");
            string tlf = Console.ReadLine();
            Console.WriteLine("Indtast personens nye fulde navn.");
            Console.Write("Navn: ");
            string navn = Console.ReadLine();
            Console.WriteLine("Indtast personens adresse.");
            Console.Write("Adresse: ");
            string adresse = Console.ReadLine();
            using (StreamReader Fillæser = new StreamReader(databaseFil))
            {
                string linje;
                while ((linje = Fillæser.ReadLine()) != null) //læser en linje i filen, så længe der er linjer
                {
                    var felter = linje.Split(','); //skiller linjen ved kommaer, lav til elementer i array
                    if (felter[0] == tlf) //hvis næste linjen starter med  intastet tlfnr
                    {
                        linjer.Add($"{tlf},{navn},{adresse}"); //opdater linjen med nye indtastninger
                    }
                    else //hvis det var sidste linje 
                    {
                        linjer.Add(linje); //lad linjen være som den er 
                    }
                }
            }

            using (StreamWriter Filskriver = new StreamWriter(databaseFil, false))
            {
                foreach (var l in linjer)
                {
                    Filskriver.WriteLine(l); //skriver de opdaterede linjer i filen
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
            string tlf = Console.ReadLine();
            using (StreamReader Fillæser = new StreamReader(databaseFil))
            {
                string line;
                while ((line = Fillæser.ReadLine()) != null)
                {
                    var felter = line.Split(',');
                    if (felter[0] != tlf)
                    {
                        lines.Add(line);
                    }
                }
            }

            using (StreamWriter Filskriver = new StreamWriter(databaseFil, false))
            {
                foreach (var l in lines)
                {
                    Filskriver.WriteLine(l);
                }
            }
            Console.WriteLine("Bruger fjernet");
        }
    }
}

