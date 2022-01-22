class Occhiali {
    private string marcaMontatura;

    private double costo;
    private int sconto = 0;

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
        this.sconto = sconto;
    }

    public override string ToString() {
        return getMarcaMontatura() + "," + getCosto + " €, " + getSconto + "%";
    } 

}