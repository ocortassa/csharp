class Occhiali {
    public string MarcaMontatura { get; set; } = "";
    public double Costo { get; set; } = 0.0;
    public int Sconto { get; set; } = 0;

    public Occhiali() { }

    public Occhiali (string MarcaMontatura, double Costo, int Sconto) {
        this.MarcaMontatura = MarcaMontatura;
        this.Costo = Costo;
        this.Sconto = Sconto;
    }

    public virtual double CalcolaPrezzo() {
        return Costo * (1 - (Sconto / 100.0));
    }

    public virtual string VisualizzaOcchiale() {
        return MarcaMontatura + ", " + 
                Costo.ToString("F2") + "€, " + 
                Sconto + "%";
    } 

    /*
    public string getMarcaMontatura() {
        return marcaMontatura;
    }

    public void setMarcaMontatura(string marcaMontatura) {
        this.marcaMontatura = marcaMontatura;
    }

    public double getCosto() {
        return costo;
    }
    
    public void setCosto(double costo) {
        this.costo = costo;
    } 

    public int getSconto() {
        return sconto;
    }

    public void setSconto(int sconto) {
        if (sconto < 0 || sconto > 100) {
            throw new ArgumentException("Valore sconto non ammesso");
        }
        this.sconto = sconto;
    }
    */

    public override string ToString() {
        return VisualizzaOcchiale();
    }
}