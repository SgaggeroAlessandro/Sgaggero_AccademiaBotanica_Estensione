using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sgaggero_AccademiaBotanica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CHabitat> habitatPresenti = new List<CHabitat>();
            int scelta;
            do
            {
                do
                {
                    Console.WriteLine("Inserisci il numero relativo alla funzione che si vuole richiamare, tra quelli proposte:");
                    Console.WriteLine("\t1.Creare un habitat, inserendo il nome e i valori ambientali adatti\n" +
                        "\t2.Selezionare un habitat\n" +
                        "\t3.Eseguire il controllo generale\n" +
                        "\t4.Terminare il programma");
                    Console.Write("Numero scelto: ");
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 4);

                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("E' stato scelto di creare un habitat");
                        CreaHabitat(habitatPresenti);
                        break;
                    case 2:
                        Console.WriteLine("E' stato scelto di selezionare un habitat");
                        SelezionaHabitat(habitatPresenti);
                        break;
                    case 3:
                        Console.WriteLine("E' stato scelto di fare il controllo generale");
                        ControlloGenerale(habitatPresenti);
                        break;
                    case 4:
                        Console.WriteLine("E' stato scelto di terminare il programma");
                        break;

                }
            } while (scelta != 4);



        }

        public static void CreaHabitat(List<CHabitat> habitat)
        {
            string nome;
            int mese;
            int temperatura;
            int umidita;
            int luminosita;
            bool nomeValido;

            do
            {
                do
                {
                    Console.WriteLine("Inserire il nuovo nome dell'habitat");
                    nome = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(nome));

                nomeValido = true;

                foreach (CHabitat ch in habitat)
                {

                    if (nome.ToLower() == ch.Nome.ToLower())
                    {
                        Console.WriteLine("E' già presente un habitat con questo nome, scrivi un altro nome");
                        nomeValido = false;
                        break;
                    }
                }
            } while (!nomeValido);
           

           
            do
            {
                Console.WriteLine("Inserisci il mese attuale");
            } while (!int.TryParse(Console.ReadLine(), out mese) || mese < 1 || mese > 12);

            do
            {
                Console.WriteLine("Inserisci la temperatura iniziale registrata");
            } while (!int.TryParse(Console.ReadLine(), out temperatura));
            do
            {
                Console.WriteLine("Inserisci l'umidità registrata");
            } while (!int.TryParse(Console.ReadLine(), out umidita));
            do
            {
                Console.WriteLine("Inserisci la luminosità registrata inizialmente");
            } while (!int.TryParse(Console.ReadLine(), out luminosita));

            try
            {
                CStatoAmbientale StatoAttuale = new CStatoAmbientale(mese, temperatura, umidita, luminosita);
                CHabitat NuovoHabitat = new CHabitat(nome, StatoAttuale);
                habitat.Add(NuovoHabitat);
                Console.WriteLine("Habitat aggiunto con successo");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public static void AggiungiPianta(CHabitat habitatScelto)
        {
            int tipo;
            do
            {
                Console.WriteLine("Inserisci il numero relativo al tipo di pianta che si vuole aggiungere: \n 1. Tropicale \t 2. Temperata \t 3. Mediterranea");
            } while (!int.TryParse(Console.ReadLine(), out tipo) || tipo < 1 || tipo > 3);
            string nome;
            switch (tipo)
            {
                case 1:
                    Console.WriteLine("E' stata scelta la pianta tropicale");
                    break;
                case 2:
                    Console.WriteLine("E' stata scelta la pianta temperata");
                    break;
                case 3:
                    Console.WriteLine("E' stata scelta la pianta mediterranea");
                    break;
            }
            do
            {
                Console.WriteLine("Inserisci il nome della nuova pianta");
                nome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nome));

            int eta;
            do
            {
                Console.WriteLine("Inserisci l'età della pianta");
            } while (!int.TryParse(Console.ReadLine(), out eta) || eta < 0);
            string foglieString = "";
            bool foglie;
            do
            {
                Console.WriteLine("La pianta in questo momento ha le foglie?");
                foglieString = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(foglieString) || (foglieString.ToLower() != "sì" && foglieString.ToLower() != "no" && foglieString.ToLower() != "si"));

            if (foglieString.ToLower() != "no")
            {
                foglie = true;
            }
            else
            {
                foglie = false;
            }

            string specie;
            do
            {
                Console.WriteLine("Inserisci la specie della pianta");
                specie = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(specie));
           
            if (tipo == 1)
            {
                int umidita;

                do
                {
                    Console.WriteLine("Inserisci l'umidità minima della pianta");
                } while (!int.TryParse(Console.ReadLine(), out umidita));
                try
                {
                    CTropicali tropicale = new CTropicali(nome, specie, eta, foglie, umidita);
                    if(habitatScelto.AggiungiPianta(tropicale) == true)
                    {
                        Console.WriteLine("Pianta tropicale aggiunta con successo");
                    }
                    else
                    {
                        Console.WriteLine("C'è già un'altra pianta con questi dati");
                       
                    }

                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            else if (tipo == 2)
            {
                int temperatura;

                do
                {
                    Console.WriteLine("Inserisci la temperatura ideale della pianta");
                } while (!int.TryParse(Console.ReadLine(), out temperatura));
                try
                {
                    CTemperata temperata = new CTemperata(nome, specie, eta, foglie, temperatura);
                    if (habitatScelto.AggiungiPianta(temperata) == true)
                    {
                        Console.WriteLine("Pianta temperata aggiunta con successo");
                    }
                    else
                    {
                        Console.WriteLine("C'è già un'altra pianta con questi dati");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            else
            {
                int luminosita;

                do
                {
                    Console.WriteLine("Inserisci la luminosità minima della pianta");
                } while (!int.TryParse(Console.ReadLine(), out luminosita));
                try
                {
                    CMediterranea mediterranea = new CMediterranea(nome, specie, eta, foglie, luminosita);
                    if (habitatScelto.AggiungiPianta(mediterranea) == true)
                    {
                        Console.WriteLine("Pianta mediterranea aggiunta con successo");
                    }
                    else
                    {
                        Console.WriteLine("C'è già un'altra pianta con questi dati");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public static void VisualizzaPianteHabitat(CHabitat habitatScelto)
        {
            habitatScelto.piantePerHabitat.Sort();
            foreach (CPianta p in habitatScelto.piantePerHabitat)
            {
                Console.WriteLine(p.Descrizione());
            }

        }

        public static void ModificaValori(CHabitat habitatScelto)
        {
            int scelta;

            do
            {
                Console.WriteLine("Inserisci il numero del valore che si vuole modificare, tra i seguenti");
                Console.WriteLine("\t1.Temperatura\n" +
                    "\t2.Umidità\n" +
                    "\t3.Luminosità\n" +
                    "\t4.Mese");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 4);

            switch (scelta)
            {
                case 1:

                    int nuovaTemperatura;
                    do
                    {
                        Console.WriteLine("Inserisci il nuovo valore della temperatura");
                    } while (!int.TryParse(Console.ReadLine(), out nuovaTemperatura));

                    try
                    {
                        CStatoAmbientale nuovoStato = new CStatoAmbientale(habitatScelto.StatoAttuale.Mese, nuovaTemperatura, habitatScelto.StatoAttuale.Umidita, habitatScelto.StatoAttuale.Luminosita);
                        if (nuovoStato.Equals(habitatScelto.StatoAttuale))
                        {
                            Console.WriteLine("Nessuna variazione delle condizioni ambientali");
                        }
                        else
                        {
                            habitatScelto.StatoAttuale = nuovoStato;
                            Console.WriteLine("Valore aggiornato con successo");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }

                    break;
                case 2:

                    int umidita;

                    do
                    {
                        Console.WriteLine("Inserisci il nuovo valore dell'umidità");
                    } while (!int.TryParse(Console.ReadLine(), out umidita));

                    try
                    {
                        CStatoAmbientale nuovoStato = new CStatoAmbientale(habitatScelto.StatoAttuale.Mese, habitatScelto.StatoAttuale.Temperatura, umidita, habitatScelto.StatoAttuale.Luminosita);
                        if (nuovoStato.Equals(habitatScelto.StatoAttuale))
                        {
                            Console.WriteLine("Nessuna variazione delle condizioni ambientali");
                        }
                        else
                        {
                            habitatScelto.StatoAttuale = nuovoStato;
                            Console.WriteLine("Valore aggiornato con successo");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }

                    break;
                case 3:
                    int luminosita;

                    do
                    {
                        Console.WriteLine("Inserisci il nuovo valore della luminosita");
                    } while (!int.TryParse(Console.ReadLine(), out luminosita));

                    try
                    {
                        CStatoAmbientale nuovoStato = new CStatoAmbientale(habitatScelto.StatoAttuale.Mese, habitatScelto.StatoAttuale.Temperatura, habitatScelto.StatoAttuale.Umidita, luminosita);
                        if (nuovoStato.Equals(habitatScelto.StatoAttuale))
                        {
                            Console.WriteLine("Nessuna variazione delle condizioni ambientali");
                        }
                        else
                        {
                            habitatScelto.StatoAttuale = nuovoStato;
                            Console.WriteLine("Valore aggiornato con successo");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                    break;
                case 4:
                    int mese;

                    do
                    {
                        Console.WriteLine("Inserisci il nuovo mese");
                    } while (!int.TryParse(Console.ReadLine(), out mese) || mese < 1 || mese > 12);

                    try
                    {
                        CStatoAmbientale nuovoStato = new CStatoAmbientale(mese, habitatScelto.StatoAttuale.Temperatura, habitatScelto.StatoAttuale.Umidita, habitatScelto.StatoAttuale.Luminosita);
                        if (nuovoStato.Equals(habitatScelto.StatoAttuale))
                        {
                            Console.WriteLine("Nessuna variazione delle condizioni ambientali");
                        }
                        else
                        {
                            habitatScelto.StatoAttuale = nuovoStato;
                            Console.WriteLine("Valore aggiornato con successo");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                    break;
            }
        }

        public static void ControlloGenerale(List<CHabitat> habitat)
        {
            if (habitat.Count == 0)
            {
                Console.WriteLine("Non ci sono habitat salvati in questo momento, di conseguenza nemmeno piante");
                return;
            }

            foreach (CHabitat h in habitat)
            {
                if (h.piantePerHabitat.Count == 0)
                {
                    Console.WriteLine($"Non ci sono piante per l'habitat: {h.Nome}");
                    continue;
                }
                int nAdeguate = 0;
                int nMediterranee = 0;
                int nTemperate = 0;
                int nTropicali = 0;
                int nPiante = 0;
                h.piantePerHabitat.Sort();
                CPianta primaPianta = h.piantePerHabitat[0];
                CPianta ultimaPianta = h.piantePerHabitat[h.piantePerHabitat.Count - 1];

                foreach (CPianta p in h.piantePerHabitat)
                {
                   
                    Console.WriteLine(p.Descrizione());
                    nPiante++;

                    if (p is CMediterranea)
                    {
                        Console.WriteLine("Pianta mediterranea, perde le foglie a luglio e agosto");
                        nMediterranee++;

                    }
                    else if (p is CTemperata)
                    {
                        Console.WriteLine("Pianta temperata, perde le foglie da novembre a febbraio");
                        nTemperate++;
                    }
                    else
                    {
                        Console.WriteLine("Pianta tropicale");
                        nTropicali++;
                    }


                    if (p.Foglie == true)
                    {
                        Console.WriteLine("Ha le foglie");
                    }
                    else
                    {
                        Console.WriteLine("Non ha le foglie");
                    }


                    bool adeguata = p.Adeguata(h.StatoAttuale);

                    if (adeguata == true)
                    {
                        Console.WriteLine("La pianta è adatta per questo habitat");
                        nAdeguate++;
                    }
                    else
                    {
                        Console.WriteLine("La pianta non è adatta per questo habitat");
                    }
                    

                }
                
                Console.WriteLine("Numero di piante adeguate per questo habitat: " + nAdeguate);
                Console.WriteLine($"Piante mediterranee: {nMediterranee} \n Piante tropicali: {nTropicali}\n Piante temperate: {nTemperate}\n Piante totali: {nPiante}");

                Console.WriteLine($"Prima pianta della lista: {primaPianta.Descrizione()}");
                Console.WriteLine($"Ultima pianta della lista: {ultimaPianta.Descrizione()}");
            }
        }

        public static void SelezionaHabitat(List<CHabitat> habitat)
        {
            if (habitat.Count == 0)
            {
                Console.WriteLine("Non ci sono habitat salvati in questo momento");
                return;
            }
            habitat.Sort();
            foreach(CHabitat c in habitat)
            {
                Console.WriteLine("Nome habitat: " + c.Nome);
            }
            string nome;
            do
            {
                Console.WriteLine("Inserisci il nome dell'habitat da selezionare");
                nome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nome));
            CHabitat habitatTrovato = null;
            bool trovato = false;
            foreach (CHabitat h in habitat)
            {
                if (h.Nome.ToLower() == nome.ToLower())
                {
                    Console.WriteLine("Habitat trovato con successo");
                    trovato = true;
                    habitatTrovato = h;
                    break;
                }
            }

            if (trovato == false)
            {
                Console.WriteLine("Non è stato trovato alcun habitat con questo nome");

            }
            else
            {
                int scelta;
                do
                {
                    Console.WriteLine("Inserisci il numero relativo alla funzione che si vuole richimare, tra quelle proposte:");
                    Console.WriteLine("\t1.Aggiungi una pianta\n" +
                        "\t2.Rimuovi una pianta\n" +
                        "\t3.Visualizza le piante presenti\n" +
                        "\t4.Modificare i valori dell'habitat\n" +
                        "\t5.Cercare una pianta nell'habitat\n");
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 5);
                switch (scelta)
                {
                    case 1:
                        AggiungiPianta(habitatTrovato);
                        break;
                    case 2:
                        RimuoviPianta(habitatTrovato);
                        break;
                    case 3:
                        VisualizzaPianteHabitat(habitatTrovato);
                        break;
                    case 4:
                        ModificaValori(habitatTrovato);
                        break;
                    case 5:
                        CercaPianta(habitatTrovato);
                        break;
                }
            }
        }

        public static void RimuoviPianta(CHabitat habitatScelto)
        {
            string nome;
            string specie;

            do
            {
                Console.WriteLine("Scrivi il nome della pianta da rimuovere dall'habitat");
                nome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nome));

            do
            {
                Console.WriteLine("Scrivi la specie della pianta da rimuovere dall'habitat");
                specie = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(specie));


            bool trovato = false;
            CPianta piantaRimossa = null;
            foreach (CPianta p in habitatScelto.piantePerHabitat)
            {
                if (nome.ToLower() == p.Nome.ToLower() && specie.ToLower() == p.Specie.ToLower())
                {
                    trovato = true;
                    piantaRimossa = p;
                    break;
                }
            }

            if (trovato == true)
            {
                Console.WriteLine($"Pianta trovata: {piantaRimossa.Descrizione()}");
                habitatScelto.piantePerHabitat.Remove(piantaRimossa);
                Console.WriteLine("Pianta rimossa con successo");
            }
            else
            {
                Console.WriteLine("Nessuna pianta trovata con questi dati");
            }
        }

        public static void CercaPianta(CHabitat habitatScelto)
        {
            string nome;
            string specie;
            do
            {
                Console.WriteLine("Inserisci il nome della pianta da cercare");
                nome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nome));

            do
            {
                Console.WriteLine("Inserisci la specie della pianta da cercare");
                specie = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(specie));


            bool trovato = false;
            CPianta piantaTrovata = null;
            foreach(CPianta p in habitatScelto.piantePerHabitat)
            {
                if(nome.ToLower().Equals(p.Nome.ToLower()) && specie.ToLower().Equals(p.Specie.ToLower())){
                    trovato = true;
                    piantaTrovata = p;
                    break;
                }
            }

            if(trovato == true)
            {
                Console.WriteLine($"Pianta trovata con successo\n Descrizione: {piantaTrovata.Descrizione()}");
            }
            else
            {
                Console.WriteLine("Nessuna pianta trovata con questo nome e questa specie");
            }
        }
    }
}
