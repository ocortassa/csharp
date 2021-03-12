/*=================================================
* @Autore: DEMICHELIS ANDREA
* @Numerazione: ESERCIZIO 17
* @Titolo: Ricerche Sequenziali :
*            - Caso1 pag.91 (Vettore Disgiunto e non ordinato);
*            - Caso2 pag.92 (Vettore con Ripetizioni e non ordinato);
*            - Caso3 pag.93 (Vettore Disgiunto e Ordinato);
*            - Caso4 pag.94 (Vettore con Ripetizioni e Ordinato);
*
* @Classe: 3A INF
* @Data: 19/01/2021 
*===================================================*/

using System;
/*
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/

namespace Esercizio17
{
    class Program
    {

        static Random rnd = new Random();
        const int Max = 100;

        static void Main(string[] args)
        {

            int[] vNum = new int[1];
            int lunVet = 0;
            string scelta = string.Empty;

            bool car1OK = false, car2OK = false, car3OK = false, car4OK = false;

            do
            {

                // Visualizza le singole Voci del Menù
                disegnaMenu();

                // Acquisisco la Scelta dell' Utente
                scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        // Chiede in Input la Lunghezza del Vettore
                        lunVet = gesInputLunVet();
                        // Definisco la lunghezza del Vettore
                        vNum = new int[lunVet];
                        car1OK = false;
                        car2OK = false;
                        car3OK = false;
                        car4OK = false;
                        break;

                    case "2":
                        // Carico Vettore Disgiunto e NON ordinato [car1OK]
                        if (lunVet != 0)
                        {
                            caricaVetDisgiunto(vNum, lunVet, Max + 50);
                            car1OK = true;
                            Console.WriteLine("");
                            Console.WriteLine("Caricamento Vettore Disgiunto e NON ordinato effettuato con successo.");
                        }
                        else
                            Console.WriteLine("Lunghezza del Vettore non inserita.");
                        break;

                    case "3":
                        // Carico Vettore con Ripetizioni e NON ordinato [car2OK]
                        if (lunVet != 0)
                        {
                            caricaVetRipetizioni(vNum, lunVet);
                            car2OK = true;
                            Console.WriteLine("");
                            Console.WriteLine("Caricamento Vettore con Ripetizioni e NON ordinato effettuato con successo.");
                        }
                        else
                            Console.WriteLine("Lunghezza del Vettore non inserita.");
                        break;

                    case "4":
                        // Carico Vettore Disgiunto e Ordinato [car3OK]
                        if (lunVet != 0)
                        {
                            caricaVetDisgiuntoOrd(vNum, lunVet);
                            car3OK = true;
                            Console.WriteLine("");
                            Console.WriteLine("Caricamento Vettore Disgiunto e Ordinato effettuato con successo.");
                        }
                        else
                            Console.WriteLine("Lunghezza del Vettore non inserita.");
                        break;

                    case "5":
                        // Carico Vettore con Ripetizioni e Ordinato [car4OK]
                        if (lunVet != 0)
                        {
                            caricaVetRipetizioniOrd(vNum, lunVet);
                            car4OK = true;
                            Console.WriteLine("");
                            Console.WriteLine("Caricamento Vettore con Ripetizioni e Ordinato effettuato con successo.");
                        }
                        else
                            Console.WriteLine("Lunghezza del Vettore non inserita.");
                        break;

                    case "6":
                        //Visualizza Vettore
                        if (lunVet != 0)
                        {
                            if (car1OK || car2OK || car3OK || car4OK)
                            {
                                Console.Clear();
                                Console.WriteLine("Vettore:");
                                Console.WriteLine("");
                                visualizzaVettore(vNum, lunVet);
                            }
                            else
                                Console.WriteLine("Vettore non caricato.");
                        }
                        else
                            Console.WriteLine("Lunghezza del Vettore non inserita.");
                        break;

                    case "7":
                        // Ricerca su Vettore Disgiunto e NON ordinato
                        if (lunVet != 0)
                        {
                            if (car1OK)
                            {
                                ricercaVetDisgiunto(vNum, lunVet);
                            }
                            else
                                Console.WriteLine("Vettore non caricato.");
                        }
                        else
                            Console.WriteLine("Lunghezza del Vettore non inserita.");
                        break;


                    case "8":
                        // Ricerca su Vettore con Ripetizioni e NON ordinato
                        if (lunVet != 0)
                        {
                            if (car2OK)
                            {
                                ricercaVetRipetizioni(vNum, lunVet);
                            }
                            else
                                Console.WriteLine("Vettore non caricato.");
                        }
                        else
                            Console.WriteLine("Lunghezza del Vettore non inserita.");
                        break;

                    case "9":
                        break;

                    case "10":
                        break;

                    case "0":
                        break;

                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Scelta non valida.");
                        break;
                }

                // Attesa Utente
                if (scelta != "0")
                    attesa();

            }
            while (scelta != "0");

        }

        /****************/
        /* Disegna Menù */
        /****************/
        static void disegnaMenu()
        {
            //Console.Clear();
            Console.WriteLine("Ricerche Sequenziali");

            Console.WriteLine("");
            Console.WriteLine("1 - Inserimento Lunghezza Vettore");
            Console.WriteLine("2 - Carico Vettore Disgiunto e NON ordinato");
            Console.WriteLine("3 - Carico Vettore con Ripetizioni e NON ordinato");
            Console.WriteLine("4 - Carico Vettore Disgiunto e Ordinato");
            Console.WriteLine("5 - Carico Vettore con Ripetizioni e Ordinato");
            Console.WriteLine("6 - Visualizza Vettore");
            Console.WriteLine("");
            Console.WriteLine("7 - CASO 1 - Ricerca su Vettore Disgiunto e NON ordinato");
            Console.WriteLine("8 - CASO 2 - Ricerca su Vettore con Ripetizioni e NON ordinato");
            Console.WriteLine("9 - CASO 3 - Ricerca su Vettore Disgiunto e Ordinato");
            Console.WriteLine("10 - CASO 4 - Ricerca su Vettore con Ripetizioni e Ordinato");
            Console.WriteLine("");
            Console.WriteLine("0 - Uscire");
            Console.WriteLine("");
            Console.Write("Scelta ==> ");
        }

        /******************/
        /* Attesa Utentre */
        /******************/
        static void attesa()
        {
            Console.WriteLine();
            Console.WriteLine("Premi un tasto per continuare ...");
            Console.ReadKey();
        }

        /***************************/
        /* Input Lunghezza Vettore */
        /***************************/
        static int gesInputLunVet()
        {
            int lunghezza = 0;
            bool errore;

            do
            {
                errore = false;

                Console.Write("Inserisci la Lunghezza del Vettore (1.." + Max + ") ==> ");
                try
                {
                    lunghezza = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lunghezza del Vettore non valida. Errore (" + ex.Message + ")");
                    errore = true;
                }

                if (!errore)
                {
                    if (lunghezza <= 0 || lunghezza > Max)
                    {
                        Console.WriteLine("Lunghezza del Vettore non valida.");
                        errore = true;
                    }
                }
            }
            while (errore);

            // Restuisco la Lunghezza inserita
            return lunghezza;
        }

        /***************************/
        /* Input Numero da Ricerca */
        /***************************/
        static int gesInputNumero()
        {
            int Numero = 0;
            bool errore;

            do
            {
                errore = false;

                Console.Write("Inserisci il Numero da Ricercare (1.." + (Max + 50) + ") ==> ");
                try
                {
                    Numero = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Numero da Ricercare non valido. Errore (" + ex.Message + ")");
                    errore = true;
                }

                if (!errore)
                {
                    if (Numero <= 0 || Numero > (Max + 50))
                    {
                        Console.WriteLine("Numero da Ricercare non valido.");
                        errore = true;
                    }
                }
            }
            while (errore);

            return Numero;
        }

        /****************************************************/
        /* Caricamento del Vettore Disgiunto e NON ordinato */
        /****************************************************/
        static void caricaVetDisgiunto(int[] V, int lun, int NumMax)
        {
            int I, num;

            for (I = 0; I < lun; I++)
            {
                do
                {
                    num = rnd.Next(1, NumMax);
                }
                while (esiste(V, I, num));
                V[I] = num;
            }
        }

        /*******************************************/
        /* Controlla duplicazione Numero  generato */
        /*******************************************/
        static bool esiste(int[] V, int lun, int x)
        {
            bool trovato = false;
            int I = 0;

            while ((I < lun) && !(trovato))
            {
                if (V[I] == x)
                    trovato = true;
                I++;
            }

            // Versione per chi non vuole usare il WHILE
            /*
            for (I = 0; I < lun; I++)
            {
                if (V[I] == x)
                    trovato = true;
            }
            */

            return trovato;
        }

        /*************************************************/
        /* Carico Vettore con Ripetizioni e NON ordinato */
        /*************************************************/
        static void caricaVetRipetizioni(int[] V, int lun)
        {
            int I;

            for (I = 0; I < lun; I++)
                V[I] = rnd.Next(1, (Max + 50));
        }

        /***************************************/
        /* Carico Vettore Disgiunto e Ordinato */
        /***************************************/
        static void caricaVetDisgiuntoOrd(int[] V, int lun)
        {
            int I, valPrec = 1;

            for (I = 0; I < lun; I++)
            {
                V[I] = valPrec + rnd.Next(1, 3);
                valPrec = V[I];
            }
        }

        /*********************************************/
        /* Carico Vettore con Ripetizioni e Ordinato */
        /*********************************************/
        static void caricaVetRipetizioniOrd(int[] V, int lun)
        {
            int I, valPrec = 1;

            for (I = 0; I < lun; I++)
            {
                V[I] = valPrec + rnd.Next(0, 3);
                valPrec = V[I];
            }
        }

        /******************************/
        /* Visulizzazione del Vettore */
        /******************************/
        static void visualizzaVettore(int[] V, int lun)
        {
            int I;

            for (I = 0; I < lun; I++)
                Console.Write(V[I] + " | ");

            Console.WriteLine();
            Console.WriteLine();
        }

        /********************************************************/
        /* CASO 1 - Ricerca su Vettore Disgiunto e NON ordinato */
        /********************************************************/
        static void ricercaVetDisgiunto(int[] V, int lun)
        {
            int x;
            int I = 0;

            Console.Clear();
            x = gesInputNumero();

            while (!((V[I] == x) || (I == lun - 1)))
            {
                I++;
            }

            Console.WriteLine("");

            if (V[I] == x)
                Console.WriteLine(
                    "Numero " + x +
                    " trovato in posizione " + (I + 1) + ".");
            else
                Console.WriteLine("Numero " + x + " non trovato.");

            Console.WriteLine("");

        }

        /**************************************************************/
        /* CASO 2 - Ricerca su Vettore con Ripetizioni e NON ordinato */
        /**************************************************************/
        static void ricercaVetRipetizioni(int[] V, int lun)
        {
            int x, I;
            bool trovato = false;

            Console.Clear();
            Console.WriteLine("");
            x = gesInputNumero();

            Console.WriteLine("");

            for (I = 0; I < lun; I++)
            {
                if (V[I] == x)
                {
                    Console.WriteLine(
                    "Numero " + x +
                    " trovato in posizione " + (I + 1) + ".");
                    trovato = true;
                }
            }

            if (!trovato)
                Console.WriteLine("Numero " + x + " non trovato.");

            Console.WriteLine("");

        }

    }
}
