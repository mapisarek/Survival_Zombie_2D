internal class weapon
{
    private double rel_time;
    private double fast_shot;
    private double mag_cap;
    private double num_mag;
    private double damage;
    private double fast_bulest;
    private double canShot;
    private double canAmo;
    private double amo;
    private double magazin;

    public weapon(double rel_time, double fast_shot, double mag_cap, double num_mag, double damage, double fast_bulest, double canShot, double canAmo, double amo, double magazin)
    {
        this.rel_time = rel_time;
        this.fast_shot = fast_shot;
        this.mag_cap = mag_cap;
        this.num_mag = num_mag;
        this.damage = damage;
        this.fast_bulest = fast_bulest;
        this.canShot = canShot;
        this.canAmo = canAmo;
        this.amo = amo;
        this.magazin = magazin;
    }
}