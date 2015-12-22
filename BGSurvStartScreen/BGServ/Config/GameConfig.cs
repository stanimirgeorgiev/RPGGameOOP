namespace BGServ.Config
{
    public class GameConfig
    {
        public const int WindowSizeX = 760;
        public const int WindowSizeY = 640;
        public const int WindowStaticSizeX = WindowSizeX + 8;
        public const int WindowStaticSizeY = WindowSizeY + 27;

        public static readonly int TileSize = 40;
        public const int GridX = 19;
        public const int GridY = 16;

        public const int GridMapX = 95;
        public const int GridMapY = 80;

        public const int PlayerStartX = 120;
        public const int PlayerStartY = 120;

        //Workers
        public const int Doctors = 25;
        public const int Mayors = 1;
        public const int Policemans = 20;
        public const int Workers = 35;
        public const int Developer = 35;
        //Criminals
        public const int Criminals = 12;
        public const int Thiefs = 40;
        public const int Rapists = 21;
        public const int MassMurders = 15;

        //Buildings

        public const int Hospital = 15;
        public const int Office = 130;
        public const int Bank = 120;
        public const int BusStation = 135;
        public const int Home = 11;
        public const int Police = 110;
        public const int Port = 11;
        public const int Restaurant = 130;
        public const int Coffee = 130;
        public const int Supermarket = 130;
        public const int TrainStation = 11;

        //Timer
        public const int TimerTick = 500;
        public const int RealTick = 230;

        public const int Cars = 40;

    }
}