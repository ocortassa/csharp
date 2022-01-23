class Program {
    static void Main(string[] args) {

        Occhiali occhiali1 = new Occhiali();
        occhiali1.MarcaMontatura = "RayBan";
        occhiali1.Costo = 100.00;
        occhiali1.Sconto = 10;
        Console.WriteLine(occhiali1);
        Console.WriteLine(occhiali1.VisualizzaOcchiale());
        Console.WriteLine("Prezzo: " + occhiali1.CalcolaPrezzo().ToString("F2") + "€");
        
        Occhiali occhiali2 = new Occhiali("Oakley", 120.00, 5);
        Console.WriteLine(occhiali2.VisualizzaOcchiale());
        Console.WriteLine("Prezzo: " + occhiali2.CalcolaPrezzo().ToString("F2") + "€");
        Console.WriteLine("----");

        OcchialiDaVista occhialiDaVista1 = new OcchialiDaVista();
        occhialiDaVista1.CorrezioneLenteDx = 5;
        occhialiDaVista1.CorrezioneLenteSx = 5;
        occhialiDaVista1.CostoLenti = 30.00;
        Console.WriteLine( occhialiDaVista1.VisualizzaOcchiale() );
        Console.WriteLine("Prezzo: " + occhialiDaVista1.CalcolaPrezzo().ToString() + "€");
        
        OcchialiDaVista occhialiDaVista2 = new OcchialiDaVista("Oakley", 125.00, 3, 2, 2, 60);
        Console.WriteLine( occhialiDaVista2.VisualizzaOcchiale() );
        Console.WriteLine( occhialiDaVista2.CalcolaPrezzo().ToString("F2") );
        Console.WriteLine("----");

        OcchialiDaSole occhialiDaSole1 = new OcchialiDaSole();
        occhialiDaSole1.AntiRiflesso = true;
        Console.WriteLine( occhialiDaSole1.VisualizzaOcchiale() );
        Console.WriteLine("Prezzo: " + occhialiDaSole1.CalcolaPrezzo().ToString() + "€");

        OcchialiDaSole occhialiDaSole2 = new OcchialiDaSole("Safilo", 200.00, 0, true);
        Console.WriteLine( occhialiDaSole2.VisualizzaOcchiale() );
        Console.WriteLine("Prezzo: " + occhialiDaSole2.CalcolaPrezzo().ToString() + "€");

        OcchialiDaSole occhialiDaSole3 = new OcchialiDaSole("Luxottica", 210.00, 5, false);
        Console.WriteLine( occhialiDaSole3.VisualizzaOcchiale() );
        Console.WriteLine("Prezzo: " + occhialiDaSole3.CalcolaPrezzo().ToString() + "€");

    }
}