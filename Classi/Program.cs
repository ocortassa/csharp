class Program {
    static void Main(string[] args) {
        Occhiali occhiali = new Occhiali();
        occhiali.setMarcaMontatura("RayBan");
        occhiali.setCosto(100.00);
        occhiali.setSconto(0);

        Console.WriteLine(occhiali);
    }
}