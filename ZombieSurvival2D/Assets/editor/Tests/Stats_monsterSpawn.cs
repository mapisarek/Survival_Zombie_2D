namespace Tests
{
    internal class Stats_monsterSpawn
    {
        private int waitingForNextSpawn;
        private int theCountdown;
        private int animalAmount;
        private int monstersAmount;

        public Stats_monsterSpawn(int waitingForNextSpawn, int theCountdown, int animalAmount, int monstersAmount)
        {
            this.waitingForNextSpawn = waitingForNextSpawn;
            this.theCountdown = theCountdown;
            this.animalAmount = animalAmount;
            this.monstersAmount = monstersAmount;
        }
    }
}