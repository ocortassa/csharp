using System;

namespace Matrici
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Esercizi sulle matrici!");
            
            Console.WriteLine("Esercizio 31");
            Ex31();
            Console.ReadLine();

            Console.WriteLine("Esercizio 32");
            Ex32();
            Console.ReadLine();

            Console.WriteLine("Esercizio 34");
            Ex34();
            Console.ReadLine();

            Console.WriteLine("Esercizio 36");
            Ex36();
            Console.ReadLine();

            Console.WriteLine("Esercizio 38");
            Ex38();
            Console.ReadLine();

            Console.WriteLine("Esercizio 39");
            Ex39();
            Console.ReadLine();

            Console.WriteLine("Esercizio 42");
            Ex42();
            Console.ReadLine();

            Console.WriteLine("Esercizio 43");
            Ex43();
            Console.ReadLine();

            Console.WriteLine("Esercizio 44");
            Ex44();
            Console.ReadLine();

        }

        /*
            31) Calcolare la somma degli elementi appartenenti alla cornice 
            più esterna di una matrice di interi A di ordine (r x c).
        */
        static void Ex31() 
        {
            int righe = LeggiValoreIntero("r");
            int colonne = LeggiValoreIntero("c");
            Console.WriteLine("Matrice di {0} per {1} celle.", righe, colonne);
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
        static void Ex32()
        {
            int righe = LeggiValoreIntero("r");
            int colonne = LeggiValoreIntero("c");
            Console.WriteLine("Matrice di {0} per {1} celle.", righe, colonne);
            int [,] matrice = new int[righe, colonne];
            PopolaMatriceCasuale(ref matrice, 0, 5);
            StampaMatrice(matrice);
            int rigaDaStampare = LeggiValoreIntero("riga", 0, righe);
            int somma = 0;
            for (int c = 0; c < colonne; c++) 
            {
                somma += matrice[rigaDaStampare, c];
            }
            Console.WriteLine("La somma della riga {0} è {1}", rigaDaStampare, somma);
        }

        /*
            34) Contare il numero di volte in cui un valore X ricevuto in ingresso
            compare tra gli elementi di una matrice di interi A di ordine (r x c).
        */
        static void Ex34() 
        {
            int righe = LeggiValoreIntero("r");
            int colonne = LeggiValoreIntero("c");
            Console.WriteLine("Matrice di {0} per {1} celle.", righe, colonne);
            int [,] matrice = new int[righe, colonne];
            PopolaMatriceCasuale(ref matrice, 0, 5);
            StampaMatrice(matrice);
            int numeroDaCercare = LeggiValoreIntero("valore da cercare", 0, 5);
            int contatore = 0;
            for (int i = 0; i < righe; i++) 
            {
                for (int j = 0; j < colonne; j++) 
                {
                    if (matrice[i,j] == numeroDaCercare) {
                        contatore++;
                    }
                }
            }
            Console.WriteLine("Il valore {0} è presente {1} volte", numeroDaCercare, contatore);
        }

        /*
            36) Verificare la somma degli elementi sulla diagonale principale è uguale 
            a quella sulla diagonale secondaria in una matrice quadrata di interi A di ordine (r x r)
        */
        static void Ex36() 
        {
            int ordine = LeggiValoreIntero("ordine");
            Console.WriteLine("Matrice di {0} per {0} celle.", ordine);
            int [,] matrice = new int[ordine, ordine];
            PopolaMatriceCasuale(ref matrice, 0, 5);
            StampaMatrice(matrice);
            int sommaPrincipale = 0, sommaSecondaria = 0;
            for (int i = 0; i < ordine; i++) 
            {
                sommaPrincipale += matrice[i, i];
                sommaSecondaria += matrice[ordine-1-i, i];
            }
            Console.WriteLine("Somma principale {0}, somma secondaria {1}", sommaPrincipale, sommaSecondaria);
            string risultato = "";
            if (sommaPrincipale == sommaSecondaria) 
            {
                risultato = "Le somme coincidono";
            }
            else
            {
                risultato = "Le somme NON coincidono";
            }
            Console.WriteLine(risultato);
        }

        /*
            38) Verificare se una matrica quadrata di interi A di ordine (r x r) è unitaria.
            Una matrice è unitaria se gli elementi sulla diagonale principale sono tutti 
            uguali a 1 e i restanti sono tutti uguali a 0.
        */
        static void Ex38() 
        {
            int ordine = LeggiValoreIntero("ordine");
            Console.WriteLine("Matrice di {0} per {0} celle.", ordine);
            int [,] matrice = new int[ordine, ordine];
            PopolaMatriceCasuale(ref matrice, 0, 2);
            StampaMatrice(matrice);
            bool matriceUnitaria = true;            
            for (int i = 0; i < ordine && matriceUnitaria; i++) 
            {
                for (int j = 0; j < ordine && matriceUnitaria; j++) 
                {
                    if (i == j)
                    {
                        if (matrice[i,j] != 1) {
                            matriceUnitaria = false;
                        }
                    } 
                    else
                    {
                        if (matrice[i,j] != 0) {
                            matriceUnitaria = false;
                        }
                    }
                }
            }
            string risultato = "E'";
            if (!matriceUnitaria) {
                risultato = "NON E'";
            }
            Console.WriteLine("La matrice {0} unitaria", risultato);
        }

        /*
            39) Verificare se una matrice quadrata di interi A di ordine (r x r) 
            è diagonalmente dominante. Una matrice è diagonalmente dominante se la somma 
            dei valori assoluti degli elementi su ciascuna riga, escluso l'elemento 
            sulla diagonale principale, è minore del valore assoluto dell'elemento della stessa riga sulla diagonale principale. 
        */
        static void Ex39() 
        {
            int ordine = LeggiValoreIntero("ordine");
            Console.WriteLine("Matrice di {0} per {0} celle.", ordine);
            int [,] matrice = new int[ordine, ordine];
            PopolaMatriceCasuale(ref matrice, 0, 10);
            StampaMatrice(matrice);
            int sommaRigaSenzaDiagonale = 0;
            bool diagonaleDominante = true;            
            for (int i = 0; i < ordine && diagonaleDominante; i++) 
            {
                for (int j = 0; j < ordine && diagonaleDominante; j++) 
                {
                    if (i != j) 
                    {
                        sommaRigaSenzaDiagonale += matrice[i,j];
                    }
                }
                if (matrice[i,i] <= sommaRigaSenzaDiagonale) 
                {
                    diagonaleDominante = false;
                }
                sommaRigaSenzaDiagonale = 0;
            }
            string risultato = "NON E'";
            if (diagonaleDominante) {
                risultato = "E'";
            }
            Console.WriteLine("La matrice {0} diagonale dominante", risultato);
        }

        /*
            42) Caricare una matrice quadrata di interi A di ordine (r x r) a spirale 
            partendo con il valore 1 in posizione 0,0. 
        */
        static void Ex42() 
        {
            int ordine = LeggiValoreIntero("ordine");
            Console.WriteLine("Matrice di {0} per {0} celle.", ordine);
            int [,] matrice = new int[ordine, ordine];
            int valoreCella = 1;
            int latoNord = 0;
            int latoEst = ordine - 1;
            int latoSud = ordine - 1;
            int latoOvest = 0;
            while (latoNord <= latoSud && latoOvest <= latoEst) 
            {
                // Lato Nord
                for (int i = latoOvest; i <= latoEst; i++)
                {
                    matrice[latoNord, i] = valoreCella++;
                }
                latoNord++;
                // Lato Est
                for (int i = latoNord; i <= latoSud; i++)
                {
                    matrice[i, latoEst] = valoreCella++;
                }
                latoEst--;
                // Lato Sud
                for (int i = latoEst; i >= latoOvest; i--)
                {
                    matrice[latoSud, i] = valoreCella++;
                }
                latoSud--;
                // Lato Ovest
                for (int i = latoSud; i >= latoNord; i--)
                {
                    matrice[i, latoOvest] = valoreCella++;
                }
                latoOvest++;
            }
            StampaMatrice(matrice);
        }

        /*
            43) Caricare una matrice quadrata di interi A di ordine (r x r) mettendo 
            tutti 1 nella cornice più esterna, tutti 2 nella seconda cornice, tutti 3 nella terza, ecc
        */
        static void Ex43() 
        {
            int ordine = LeggiValoreIntero("ordine");
            Console.WriteLine("Matrice di {0} per {0} celle.", ordine);
            int [,] matrice = new int[ordine, ordine];
            int valoreCella = 1;
            int latoNord = 0;
            int latoEst = ordine - 1;
            int latoSud = ordine - 1;
            int latoOvest = 0;
            while (latoNord <= latoSud && latoOvest <= latoEst) 
            {
                // Lato Nord
                for (int i = latoOvest; i <= latoEst; i++)
                {
                    matrice[latoNord, i] = valoreCella;
                }
                latoNord++;
                // Lato Est
                for (int i = latoNord; i <= latoSud; i++)
                {
                    matrice[i, latoEst] = valoreCella;
                }
                latoEst--;
                // Lato Sud
                for (int i = latoEst; i >= latoOvest; i--)
                {
                    matrice[latoSud, i] = valoreCella;
                }
                latoSud--;
                // Lato Ovest
                for (int i = latoSud; i >= latoNord; i--)
                {
                    matrice[i, latoOvest] = valoreCella;
                }
                latoOvest++;
                valoreCella++;
            }
            StampaMatrice(matrice);
        }

        /*
            44) Verificare che tutti gli elementi di una matrice di interi A di 
            ordine (r x c) sono ordinati in ordine crescente.
        */
        static void Ex44() 
        {
            int righe = LeggiValoreIntero("r");
            int colonne = LeggiValoreIntero("c");
            Console.WriteLine("Matrice di {0} per {1} celle.", righe, colonne);
            int [,] matrice = new int[righe, colonne];
            PopolaMatriceCasuale(ref matrice, 0, 10);
            StampaMatrice(matrice);
            int valorePrecedente = -1;
            bool matriceOrdinata = true;
            for (int i = 0; i < righe && matriceOrdinata; i++)
            {
                for (int j = 0; i < colonne && matriceOrdinata; j++) 
                {
                    matriceOrdinata = matrice[i,j] > valorePrecedente;
                }
            }
            string risultato = "NON E'";
            if (matriceOrdinata) {
                risultato = "E'";
            }
            Console.WriteLine("La matrice {0} ordinata", risultato);
        
        }

       static int LeggiValoreIntero(string etichetta) {
            if (etichetta != null) {
                Console.Write("{0}: ", etichetta);
            }
            return Convert.ToInt32(Console.ReadLine());
        }
       static int LeggiValoreIntero(string etichetta, int min, int max) {
            if (etichetta != null) {
                Console.Write("{0} [compreso tra {1} e {2}]: ", etichetta, min, max-1);
            }
            int valore;
            do 
            {
                valore = Convert.ToInt32(Console.ReadLine());
            } while (valore < min || valore > max);
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
                    Console.Write(string.Format("{0, 3}", mat[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        static void StampaCoord(int r, int c) 
        {
            Console.Write("[{0},{1}] ", r, c);
        }

        static void PopolaMatriceCasuale(ref int[,] mat, int min, int max) {
            int numRighe = mat.GetLength(0);
            int numColonne = mat.GetLength(1);
            for (int i = 0; i < numRighe; i++)
            {
                for (int j = 0; j < numColonne; j++)
                {
                    mat[i, j] = GeneraNumeroCasuale(min, max);
                }
            }             
        }
    
        static int GeneraNumeroCasuale(int min, int max) {
            System.Random random = new System.Random();
            int numeroCasuale = 0;
            if (min == 0 && max == 0) {
                numeroCasuale = random.Next();
            } 
            else{
                numeroCasuale = random.Next(min, max);
            }
            return numeroCasuale;
        }
    }

}
