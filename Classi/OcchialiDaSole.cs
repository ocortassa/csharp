class OcchialiDaSole : Occhiali {
    public bool AntiRiflesso { get; set; }

    public OcchialiDaSole() : base() {

    }

    public OcchialiDaSole(string marca, double costo, int sconto, bool antiRiflesso) : base(marca, costo, sconto) {
        this.AntiRiflesso = antiRiflesso;
    }
    public OcchialiDaSole(bool antiRiflesso) : base() {
        this.AntiRiflesso = antiRiflesso;
    } 

    public override double CalcolaPrezzo() {
        if (AntiRiflesso) {
            Sconto = -20;
        }
        return base.CalcolaPrezzo();
    }
    public override string VisualizzaOcchiale() {
        return base.VisualizzaOcchiale() + 
            ", AntiRiflesso " + (AntiRiflesso ? "si!" : "no!"); 
    }

}