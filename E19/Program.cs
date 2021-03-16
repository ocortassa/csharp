using System;

namespace Esercizio19
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

            int[,] matrice = new int[8, 8];

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            /*
            InizializzaMatrice(ref matrice);
            StampaMatrice(ref matrice);
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
            */

            // Crea Struttura
            Struttura();
            VisualizzaMatrice(ref matrice);

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
                            if (pedinaPiazzata == 0) {
                                continue;
                            }

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
                            VisualizzaMatrice(ref matrice);

                            ControllaChiVince(ref matrice);

                            break;

                        default:
                            break;

                    }
                    Pedina(posI, ref PosOLD, N, Turno);

                }

            }
            while (c != 81);


        }

        static void InizializzaMatrice(ref int[,] m) {
            for (int r = 0; r < 8; r++) {
                for (int c = 0; c < 8; c++) {
                    m[r, c] = 0;
                }
            }
        }

        static void StampaMatrice(ref int[,] m) {
            for (int r = 0; r < 8; r++) {
                for (int c = 0; c < 8; c++) {
                   Console.Write(m[r, c] + ",");
                }
                Console.WriteLine("");
            }            
        }

        static int ImpostaPedina(ref int[, ] mat, int col, int colore) {
            int cMatrice = (col - 7) / 4;
            // Verifica colonna piena
            if (mat[0, cMatrice] != 0) {
                // Colonna piena
                return 0;
            }
            // Indivia prima cella vuota
            int rMatrice = 7;
            for(; rMatrice >= 0; rMatrice--) {
                if (mat[rMatrice, cMatrice] == 0) {
                    break;
                }
            }
            mat[rMatrice, cMatrice] = colore;
            return 1;
        }

        static void VisualizzaMatrice(ref int[,] m)
        {
            int R, C;
            int ColI = 5;
            int ColY = ColI;

            for (R = 5; R < 21; R+=2)
            {
                for (C = 7; C < 38; C+=4)
                {
                    Console.SetCursorPosition(C, R);
                    int rMatrice = (R-5) / 2;
                    int cMatrice = (C-7) / 4;
                    if (m[rMatrice, cMatrice] == 0) {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (m[rMatrice, cMatrice] == 1) {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    if (m[rMatrice, cMatrice] == 2) {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                        Console.Write(" ");
                }
            }
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        
        }

        static void ControllaChiVince(ref int[,] mat) {
            // Controlla verticale
            int coloreVincente = ControllaVerticale(ref mat);
            if (coloreVincente != 0) {
                Console.WriteLine("Ha vinto il colore: " + DecodificaColore(coloreVincente) + " !!!!!!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            // Controlla orizzontale
            coloreVincente = ControllaOrizzontale(ref mat);
            if (coloreVincente != 0) {
                Console.WriteLine("Ha vinto il colore: " + DecodificaColore(coloreVincente) + " !!!!!!");
                Console.ReadKey();
                Environment.Exit(0);
            }

            coloreVincente = ControllaDiagonaleDx(ref mat);
            if (coloreVincente != 0) {
                Console.WriteLine("Ha vinto il colore: " + DecodificaColore(coloreVincente) + " !!!!!!");
                Console.ReadKey();
                Environment.Exit(0);
            }

            coloreVincente = ControllaDiagonaleSx(ref mat);
            if (coloreVincente != 0) {
                Console.WriteLine("Ha vinto il colore: " + DecodificaColore(coloreVincente) + " !!!!!!");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        static string DecodificaColore(int col) {
            return col == 1 ? "ROSSO" : "GIALLO";
        }

        static int ControllaVerticale(ref int[,] mat) {
            for (int colonna = 0; colonna < 8; colonna++) {
                int coloreDaControllare = mat[7, colonna];
                int contatore = 1;
                for(int riga = 6; riga >= 0; riga--) {
                    if (mat[riga, colonna] == coloreDaControllare && coloreDaControllare != 0) {
                        contatore++;
                    } else {
                        coloreDaControllare = mat[riga, colonna];
                        contatore = 1;
                    }
                    if (contatore == 4) {
                        return coloreDaControllare;
                    }
                }
            }
            return 0;
        }

        static int ControllaOrizzontale(ref int[,] mat) {
            for (int riga = 7; riga >= 0; riga--) {
                int coloreDaControllare = mat[riga, 0];
                int contatore = 1;
                for(int colonna = 1; colonna < 8; colonna++) {
                    if (mat[riga, colonna] == coloreDaControllare && coloreDaControllare != 0) {
                        contatore++;
                    } else {
                        coloreDaControllare = mat[riga, colonna];
                        contatore = 1;
                    }
                    if (contatore == 4) {
                        return coloreDaControllare;
                    }
                }
            }
            return 0;
        }

        static int ControllaDiagonaleDx(ref int[,] mat) {
            // TODO: to implement!
            return 0;
        }

        static int ControllaDiagonaleSx(ref int[,] mat) {
            // TODO: to implement!
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
