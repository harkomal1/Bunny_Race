using System;

namespace Bunny_Race
{
    public static class Factory
    {
        private static Random Random = new Random();
        private static int newNumber;
        public static int BunnyCount { get; set; } = 0;
        public static int RaceTrackLength { get; set; }
        public static int Location { get; set; } = 0;

        public static int Number()
        {
            return newNumber = Random.Next(1, 50);
        }


        // decides which class to instantiate
        public static Punter GetAPunter(int id)
        {
            switch (id)
            {
                case 0:
                    return new Punter01();
                case 1:
                    return new Punter02();
                case 2:
                    return new Punter03();

                default:
                    return new Punter01();
            }
        }

        public static Bunny GetABunny(int id)
        {
            switch (id)
            {
                case 0:
                    return new Bunny01();
                case 1:
                    return new Bunny02();
                case 2:
                    return new Bunny03();
                case 3:
                    return new Bunny04();

                default:
                    return new Bunny01();
            }
        }
    }
}
