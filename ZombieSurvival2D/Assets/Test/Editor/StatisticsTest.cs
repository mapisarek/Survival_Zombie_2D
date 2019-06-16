using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StatisticsTest
{
    IStatistics statistics;
    StatisticsInitalizer statisticsInitalizer;

    [SetUp]
    public void InitStats()
    {
        statistics = Substitute.For<IStatistics>();
        statisticsInitalizer = new StatisticsInitalizer();
    }

    [Test]
    [TestCase(101, 100)]
    [TestCase(100, 100)]
    [TestCase(10000, 100)]
    public void InitMaxStatValue_StatsAreNotNull(int current, int max)
    {
        statisticsInitalizer.Initalize(current, max, statistics);
        Assert.IsNotNull(statistics);
        Assert.AreEqual(100, statistics.CurrentValue);
    }

    [Test]
    [TestCase(-50,100)]
    [TestCase(0, 100)]
    [TestCase(-1000,0)]
    public void InitMinStatsValue_StatsAreNotNull(int current, int max)
    {
        statisticsInitalizer.Initalize(current, max, statistics);
        Assert.IsNotNull(statistics);
        Assert.AreEqual(0, statistics.CurrentValue);        
    }
}

