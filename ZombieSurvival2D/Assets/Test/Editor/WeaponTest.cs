

using NUnit.Framework;

public class WeaponTest
{
    [Test]
    public void WeaponStatsNotMinu(double rel_time, double fast_shot, double mag_cap, double num_mag, 
        double damage, double fast_bulest, double canShot, double canAmo, double amo, double magazin)
    {
        var n = new weapon(rel_time, fast_shot, mag_cap, num_mag
           damage,  fast_bulest,  canShot,  canAmo,  amo,  magazin);
    }


}
