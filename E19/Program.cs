using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_forza_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int pedG = 0, pedR = 0;
            char c = ' ';
            int posI = 7, PosOLD = 7;
            int N = 0;
            int Turno = 1;
            /*
                Turno = 1 ==> ROSSO
                Turno = 2 ==> GIALLO
            */

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            // Dichiarazione matrice
            int[,] matrice = new int[8, 8];


            // Crea Struttura
            Struttura();
            VisualizzaMatrice(matrice);

            // Gestisce Punteggio
            Punteggio(Turno, pedG, pedR);

            // Gestisce la possibilità di inserire la Pedina
            Pedina(posI, ref PosOLD, N, Turno);

            do
            {

                // Controlla pressione Carattere
                if (Console.KeyAvailable)
                {

                    c = Convert.ToChar(Console.ReadKey(false).Key);
                    N = Convert.ToInt32(c);

                    switch (N)
                    {
                        case 82:
                            // Reset - per resettare la partita premere 'r'
                            pedG = 0;
                            pedR = 0;
                            posI = 7;
                            PosOLD = 7;
                            N = 0;
                            ResettaMatrice(ref matrice);
                            Struttura();
                            VisualizzaMatrice(matrice);
                            Punteggio(Turno, pedG, pedR);
                            Pedina(posI, ref PosOLD, N, Turno);
                            break;
                        
                        case 37:
                            // Freccia SX
                            if (posI > 7)
                                posI -= 4;
                            break;

                        case 39:
                            // Freccia DX
                            if (posI < 35)
                                posI += 4;
                            break;

                        case 40:
                            // Freccia DOWN

                            // Imposta valore matrice
                            int pedinaPiazzata = ImpostaPedina(ref matrice, posI, Turno);
                            if (pedinaPiazzata != 0)
                            {

                                if (Turno == 1)
                                {
                                    pedR++;
                                    Turno++;
                                }
                                else
                                {
                                    pedG++;
                                    Turno--;
                                }

                                // Gestisce Punteggio
                                Punteggio(Turno, pedG, pedR);
                                VisualizzaMatrice(matrice);

                                ControllaChiVince(matrice, pedR, pedG);

                            }
                            break;

                        default:
                            break;

                    }
                    Pedina(posI, ref PosOLD, N, Turno);

                }

            }
            while (c != 81);    // Per uscire premere 'q'

        }

        static void ResettaMatrice(ref int[,] m)
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    m[r, c] = 0;
                }
            }
        }

        static void StampaMatrice(int[,] matrice)
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Console.Write(matrice[r, c] + ",");
                }
                Console.WriteLine("");
            }
        }

        static int ImpostaPedina(ref int[,] mat, int col, int colore)
        {
            int cMatrice = (col - 7) / 4;
            // Verifica colonna piena
            if (mat[0, cMatrice] != 0)
            {
                // Colonna già piena
                return 0;
            }
            // Individua prima cella vuota
            int rMatrice = 7;
            bool trovato = false;
            while (rMatrice >= 0 && trovato == false)
            {
                if (mat[rMatrice, cMatrice] == 0)
                {
                    trovato = true;
                } 
                else
                {
                    rMatrice--;
                }
            }

            mat[rMatrice, cMatrice] = colore;
            return 1;
        }

        static void VisualizzaMatrice(int[,] m)
        {
            int R, C;
            int ColI = 5;
            int ColY = ColI;

            for (R = 5; R < 21; R += 2)
            {
                for (C = 7; C < 38; C += 4)
                {
                    Console.SetCursorPosition(C, R);
                    int rMatrice = (R - 5) / 2;
                    int cMatrice = (C - 7) / 4;
                    if (m[rMatrice, cMatrice] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (m[rMatrice, cMatrice] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    if (m[rMatrice, cMatrice] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void VisualizzaVittoria(int[] righe, int[] colonne, int coloreVincente)
        {
            for (int i = 0; i < 4; i++) {
                int rCursore = (righe[i] * 2) + 5;
                int cCursore = (colonne[i] * 4) + 6;
                Console.SetCursorPosition(cCursore, rCursore);
                Console.BackgroundColor = DecodificaColore(coloreVincente);
                Console.Write("   ");
            }
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ControllaChiVince(int[,] mat, int contaRosso, int contaGiallo)
        {

            if (contaRosso < 4 ) 
            {
                // Con meno di 4 celle rosse (il primo a partire) non vince nessuno
                return;
            }

            // Controlla verticale
            int coloreVincente = ControllaVerticale(mat);
            if (coloreVincente != 0)
            {
                VisualizzaVincitore(coloreVincente);
            }

            // Controlla orizzontale
            coloreVincente = ControllaOrizzontale(mat);
            if (coloreVincente != 0)
            {
                VisualizzaVincitore(coloreVincente);
            }

            // Diagonale Discendente: da 0,0 a 7,7 
            coloreVincente = ControllaSopraDiagonaleDisc(mat);
            if (coloreVincente != 0)
            {
                VisualizzaVincitore(coloreVincente);
            }
            coloreVincente = ControllaSottoDiagonaleDisc(mat);
            if (coloreVincente != 0)
            {
                VisualizzaVincitore(coloreVincente);
            }

            // Diagonale Ascendente: da 7,0 a 0,7 
            coloreVincente = ControllaSopraDiagonaleAsc(mat);
            if (coloreVincente != 0)
            {
                VisualizzaVincitore(coloreVincente);
            }
            coloreVincente = ControllaSottoDiagonaleAsc(mat);
            if (coloreVincente != 0)
            {
                VisualizzaVincitore(coloreVincente);
            }

        }
        static ConsoleColor DecodificaColore(int col)
        {
            if (col == 1)
            {
                return ConsoleColor.Red;
            } 
            return ConsoleColor.Yellow;
        }

        static string DecodificaNomeColore(int col)
        {
            //return col == 1 ? "ROSSO" : "GIALLO";
            if (col == 1)
            {
                return "ROSSO";
            } 
            return "GIALLO";
        }

        static void VisualizzaVincitore(int coloreVincente) 
        {
                Console.SetCursorPosition(5, 23);
                Console.WriteLine("Ha vinto il " + DecodificaNomeColore(coloreVincente) + " !!!!!!");
                Console.ReadKey();
                Environment.Exit(0);
        }

        static int ControllaVerticale(int[,] mat)
        {
            int[] righe = new int[4];
            int[] colonne = new int[4];
            for (int colonna = 0; colonna < 8; colonna++)
            {
                // Prima riga in basso
                int coloreDaControllare = mat[7, colonna];
                righe[0] = 7;
                colonne[0] = colonna;
                int contatore = 1;
                // Elaborazione dalla seconda riga verso l'alto
                for (int riga = 6; riga >= 0; riga--)
                {
                    if (mat[riga, colonna] == coloreDaControllare && coloreDaControllare != 0)
                    {
                        righe[contatore] = riga;
                        colonne[contatore] = colonna;
                        contatore++;
                    }
                    else
                    {
                        coloreDaControllare = mat[riga, colonna];
                        contatore = 1;
                        righe = new int[4];
                        colonne = new int[4];
                        righe[0] = riga;
                        colonne[0] = colonna;
                    }
                    if (contatore == 4)
                    {
                        VisualizzaVittoria(righe, colonne, coloreDaControllare);
                        return coloreDaControllare;
                    }
                }
            }
            return 0;
        }

        static int ControllaOrizzontale(int[,] mat)
        {
            int[] righe = new int[4];
            int[] colonne = new int[4];
            for (int riga = 7; riga >= 0; riga--)
            {
                // Prima colonna a sinistra
                int coloreDaControllare = mat[riga, 0];
                righe[0] = riga;
                colonne[0] = 0;
                int contatore = 1;
                // Elaborazione dalla seconda colonna verso destra
                for (int colonna = 1; colonna < 8; colonna++)
                {
                    if (mat[riga, colonna] == coloreDaControllare && coloreDaControllare != 0)
                    {
                        righe[contatore] = riga;
                        colonne[contatore] = colonna;
                        contatore++;
                    }
                    else
                    {
                        coloreDaControllare = mat[riga, colonna];
                        contatore = 1;
                        righe = new int[4];
                        colonne = new int[4];
                        righe[0] = riga;
                        colonne[0] = colonna;
                    }
                    if (contatore == 4)
                    {
                        VisualizzaVittoria(righe, colonne, coloreDaControllare);
                        return coloreDaControllare;
                    }
                }
            }
            return 0;
        }

        static int ControllaSopraDiagonaleAsc(int[,] mat)
        {
            int[] righe = new int[4];
            int[] colonne = new int[4];
            // Si parte dalla prima diagonale lunga 4 celle
            for(int diagonale = 3; diagonale < 8; diagonale++)
            {
                int coloreDaControllare = mat[diagonale, 0];
                righe[0] = diagonale;
                colonne[0] = 0;
                int contatore = 0;
                for (int riga = diagonale; riga >= 0; riga--)
                {
                    int colonna = diagonale - riga;
                    if (mat[riga, colonna] == coloreDaControllare && coloreDaControllare != 0)
                    {
                        righe[contatore] = riga;
                        colonne[contatore] = colonna;
                        contatore++;
                    }
                    else
                    {
                        coloreDaControllare = mat[riga, colonna];
                        contatore = 1;
                        righe = new int[4];
                        colonne = new int[4];
                        righe[0] = riga;
                        colonne[0] = colonna;
                    }
                    if (contatore == 4)
                    {
                        VisualizzaVittoria(righe, colonne, coloreDaControllare);
                        return coloreDaControllare;
                    }
                }                
            }
            return 0;
        }

        static int ControllaSottoDiagonaleAsc(int[,] mat)
        {
            int[] righe = new int[4];
            int[] colonne = new int[4];
            // Si parte dalla prima diagonale lunga 4 celle
            for (int diagonale = 3; diagonale < 8; diagonale++)
            {
                int coloreDaControllare = mat[7, 7 - diagonale];
                righe[0] = 7;
                colonne[0] = 7 - diagonale;
                int contatore = 0;
                for (int j = 0; j <= diagonale; j++)
                {
                    int riga = 7 - j;
                    int colonna = 7 - diagonale + j;
                    // Scarto diagonale più lunga perchè già elaborata
                    if (colonna > 0)
                    {
                        if (mat[riga, colonna] == coloreDaControllare && coloreDaControllare != 0)
                        {
                            righe[contatore] = riga;
                            colonne[contatore] = colonna;
                            contatore++;
                        }
                        else
                        {
                            coloreDaControllare = mat[riga, colonna];
                            contatore = 1;
                            righe = new int[4];
                            colonne = new int[4];
                            righe[0] = riga;
                            colonne[0] = colonna;
                        }
                        if (contatore == 4)
                        {
                            VisualizzaVittoria(righe, colonne, coloreDaControllare);
                            return coloreDaControllare;
                        }
                    }
                }

            }
            return 0;
        }

        static int ControllaSottoDiagonaleDisc(int[,] mat)
        {
            int[] righe = new int[4];
            int[] colonne = new int[4];
            // Si parte dalla prima diagonale lunga 4 celle
            for (int diagonale = 4; diagonale <= 8; diagonale++)
            {
                int coloreDaControllare = mat[8 - diagonale, 0];
                righe[0] = diagonale - 8;
                colonne[0] = 0;
                int contatore = 0;
                for (int riga = 8 - diagonale; riga < 8; riga++)
                {
                    int colonna = riga - (8 - diagonale);
                    //Console.Write("[" + riga + "," + colonna + "],");
                    
                    if (mat[riga, colonna] == coloreDaControllare && coloreDaControllare != 0)
                    {
                        righe[contatore] = riga;
                        colonne[contatore] = colonna;
                        contatore++;
                    }
                    else
                    {
                        coloreDaControllare = mat[riga, colonna];
                        contatore = 1;
                        righe = new int[4];
                        colonne = new int[4];
                        righe[0] = riga;
                        colonne[0] = colonna;
                    }
                    if (contatore == 4)
                    {
                        VisualizzaVittoria(righe, colonne, coloreDaControllare);
                        return coloreDaControllare;
                    }
                }
                //Console.WriteLine("");
            }
            return 0;
        }

        static int ControllaSopraDiagonaleDisc(int[,] mat)
        {
            int[] righe = new int[4];
            int[] colonne = new int[4];
            // Si parte dalla prima diagonale lunga 4 celle
            for (int diagonale = 4; diagonale <= 8; diagonale++)
            {
                int coloreDaControllare = mat[8 - diagonale, 0];
                righe[0] = 8 - diagonale;
                colonne[0] = 0;
                int contatore = 0;
                for (int j = 8 - diagonale; j < 8; j++)
                {
                    int riga = j - (8 - diagonale);
                    int colonna = j;
                    // Scarto diagonale più liunga perchè già elaborata 
                    if (colonna > 0) 
                    {
                        //Console.Write("[" + riga + "," + colonna + "],");
                        if (mat[riga, colonna] == coloreDaControllare && coloreDaControllare != 0)
                        {
                            righe[contatore] = riga;
                            colonne[contatore] = colonna;
                            contatore++;
                        }
                        else
                        {
                            coloreDaControllare = mat[riga, colonna];
                            contatore = 1;
                            righe = new int[4];
                            colonne = new int[4];
                            righe[0] = riga;
                            colonne[0] = colonna;
                        }
                        if (contatore == 4)
                        {
                            VisualizzaVittoria(righe, colonne, coloreDaControllare);
                            return coloreDaControllare;
                        }
                    }
                }
                //Console.WriteLine("");
            }
            return 0;
        }

        // ------------------------------------------------------------------------------------------------

        static void Struttura()
        {
            int R, C;
            int ColI = 5;
            int ColY = ColI;

            Console.Clear();

            for (C = ColI; C < 65; C++)
            {
                Console.SetCursorPosition(C, 2);
                Console.Write("-");
            }

            for (R = 4; R < 21; R++)
            {
                for (C = ColI; C < 38; C++)
                {

                    Console.SetCursorPosition(C, R);
                    if (C == ColY)
                    {
                        Console.Write("|");
                        ColY = ColY + 4;
                    }
                    else
                    {
                        if (R % 2 == 0)
                            Console.Write("=");
                        else
                            Console.Write(" ");
                    }

                }
                ColY = ColI;
            }
            Console.SetCursorPosition(0, 0);

        }

        static void Punteggio(int p, int PG, int PR)
        {
            Console.SetCursorPosition(45, 4);
            Console.Write("Turno");

            Console.SetCursorPosition(52, 4);
            Console.ForegroundColor = ConsoleColor.Black;
            if (p == 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("  ROSSO  ");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(" GIALLO  ");
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(45, 6);
            Console.Write("Pedine ROSSO: " + PR);
            Console.SetCursorPosition(45, 7);
            Console.Write("Pedine GIALLO: " + PG);
        }

        static void Pedina(int newPOS, ref int oldPOS, int nChar, int p)
        {
            // Pulisce la vecchia posizione
            Console.SetCursorPosition(oldPOS, 1);
            Console.Write("     ");

            Console.SetCursorPosition(newPOS, 1);
            Console.ForegroundColor = ConsoleColor.Black;

            if (p == 1)
                Console.BackgroundColor = ConsoleColor.Red;
            else
                Console.BackgroundColor = ConsoleColor.Yellow;

            Console.Write("#");

            // Mi sposto o verso DX o verso SX
            if (nChar == 37 && oldPOS > 7)
                oldPOS -= 4;
            if (nChar == 39 && oldPOS < 35)
                oldPOS += 4;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
