class OcchialiDaVista : Occhiali {
    public int CorrezioneLenteDx { get; set; }
    public int CorrezioneLenteSx { get; set; }
    public double CostoLenti { get; set; }    

    public OcchialiDaVista() : base() {

    }

    public OcchialiDaVista(string marca, double costo, int sconto, int corrDx, int corrSx, double costoLenti) : base(marca, costo, sconto) {
        this.CorrezioneLenteDx = corrDx;
        this.CorrezioneLenteSx = corrSx;
        this.CostoLenti = costoLenti;
    }
    public OcchialiDaVista(int corrDx, int corrSx, double costoLenti) : base() {
        this.CorrezioneLenteDx = corrDx;
        this.CorrezioneLenteSx = corrSx;
        this.CostoLenti = costoLenti;
    } 
    public override double CalcolaPrezzo() {
        return base.CalcolaPrezzo() + CostoLenti;
    }
    public override string VisualizzaOcchiale() {
        return base.VisualizzaOcchiale() + 
            ", Correzione dx " + CorrezioneLenteDx + "/ sx " + CorrezioneLenteSx +
            ", Costo lenti: " + CostoLenti.ToString("F2") + "€"; 
    }

    /*
    public int getCorrezioneLenteDx() {
        return correzioneLenteDx;
    }

    public void setCorrezioneLenteDx(int correzioneLenteDx) {
        this.correzioneLenteDx = correzioneLenteDx;
    }

    public int getCorrezioneLenteSx() {
        return correzioneLenteSx;
    }

    public void setCorrezioneLenteSx(int correzioneLenteSx) {
        this.correzioneLenteSx = correzioneLenteSx;
    }

    public double getCostoLenti() {
        return costoLenti;
    }

    public void setCostoLenti(double costoLenti) {
        this.costoLenti = costoLenti;
    }
    */
}