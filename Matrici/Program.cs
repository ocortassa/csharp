using System;

namespace Matrici
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Esercizi sulle matrici!");
            
            /*
            Console.WriteLine("Esercizio 31");
            Ex31();
            Console.ReadLine();
            */

            Console.WriteLine("Esercizio 32");
            Ex32();
            Console.ReadLine();



        }

        /*
            31) Calcolare la somma degli elementi appartenenti alla cornice 
            più esterna di una matrice di interi A di ordine (r x c).
        */
        static void Ex31() {
            int righe = LeggiValoreIntero("r");
            int colonne = LeggiValoreIntero("c");
            Console.WriteLine("Matrice di {0} per {0} celle.", righe, colonne);
            int [,] matrice = new int[righe, colonne];
            PopolaMatriceCasuale(ref matrice, 0, 5);
            StampaMatrice(matrice);
            int somma = 0;
            for (int c = 0; c < colonne; c++) 
            {
                somma += matrice[0, c] + matrice[righe - 1, c];
            }
            for (int r = 1; r < righe - 1; r++) 
            {
                somma += matrice[r, 0] + matrice[r, colonne - 1];
            }
            Console.WriteLine("La somma della matrice è {0}", somma);

        }

        /*
            32) Calcolare la somma degli elementi appartenenti alla riga i (con 0 <= i <= r-1) 
            di una matrice di interi A di ordine (r x c)
        */
        static void Ex32() {
            int righe = LeggiValoreIntero("r");
            int colonne = LeggiValoreIntero("c");
            Console.WriteLine("Matrice di {0} per {0} celle.", righe, colonne);
            int [,] matrice = new int[righe, colonne];
            PopolaMatriceCasuale(ref matrice, 0, 5);
            StampaMatrice(matrice);
            int rigaDaStampare = LeggiValoreIntero("riga", 0, righe);
            int somma = 0;
            for (int c = 0; c < colonne; c++) 
            {
                somma += matrice[rigaDaStampare, c];
            }
            Console.WriteLine("La somma della riga {0} è {0}", rigaDaStampare, somma);
        }

        /*
        34) Contare il numero di volte in cui un valore di X ricevuto in ingresso compare tra gli elementi di una matrice di interi A di ordine (r x c).
        */

       static int LeggiValoreIntero(string etichetta) {
            if (etichetta != null) {
                Console.Write(etichetta + ": ");
            }
            return Convert.ToInt32(Console.ReadLine());
        }
       static int LeggiValoreIntero(string etichetta, int min, int max) {
            if (etichetta != null) {
                Console.Write(etichetta + " [compreso tra {0} e {0}]: ", min, max);
            }
            int valore;
            do 
            {
                valore = Convert.ToInt32(Console.ReadLine());
            } while (valore >= min && valore < max);
            return valore;
        }

        static void StampaMatrice(int[,] mat) {
            Console.WriteLine("");
            int numRighe = mat.GetLength(0);
            int numColonne = mat.GetLength(1);
            for (int i = 0; i < numRighe; i++)
            {
                for (int j = 0; j < numColonne; j++)
                {
                    Console.Write(string.Format("{0} ", mat[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        static void PopolaMatriceCasuale(ref int[,] mat, int min, int max) {
            int numRighe = mat.GetLength(0);
            int numColonne = mat.GetLength(1);
            for (int i = 0; i < numRighe; i++)
            {
                for (int j = 0; j < numColonne; j++)
                {
                    System.Random random = new System.Random();
                    int numeroCasuale = 0;
                    if (min == 0 && max == 0) {
                        numeroCasuale = random.Next();
                    } 
                    else{
                        numeroCasuale = random.Next(min, max);
                    }
                    mat[i, j] = numeroCasuale;
                }
            }             
        }
    
    }

}
