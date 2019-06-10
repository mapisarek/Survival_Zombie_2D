

using NUnit.Framework;

public class WeaponTest
{
    [Test]
    [TestCase(10, 10, 50, 10, 10, 50, 10, 10, 50, 10)]
    [TestCase(102, 120, 520, 120, 120, 250, 102, 120, 520, 102)]
    public void WeaponStatsNotMinu(double rel_time, double fast_shot, double mag_cap, double num_mag, 
        double damage, double fast_bulest, double canShot, double canAmo, double amo, double magazin)
    {
        var n = new weapon(rel_time, fast_shot, mag_cap, num_mag,
           damage,  fast_bulest,  canShot,  canAmo,  amo,  magazin);
        Assert.GreaterOrEqual(rel_time, 0);
        Assert.GreaterOrEqual(fast_shot, 0);
        Assert.GreaterOrEqual(mag_cap, 0);
        Assert.GreaterOrEqual(num_mag, 0);
        Assert.GreaterOrEqual(damage, 0);
        Assert.GreaterOrEqual(fast_bulest, 0);
        Assert.GreaterOrEqual(canShot, 0);
        Assert.GreaterOrEqual(canAmo, 0);
        Assert.GreaterOrEqual(amo, 0);
        Assert.GreaterOrEqual(magazin, 0);


    }


}
