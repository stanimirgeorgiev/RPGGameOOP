
namespace BGSurv.Config
{
    class GameConfig
    {
        public const int WindowSizeX = 960;
        public const int WindowSizeY = 640;
        public const int WindowStaticSizeX = WindowSizeX + 8;
        public const int WindowStaticSizeY = WindowSizeY + 27;

        public const int TileSize = 40;
        public const int GridX = WindowSizeX / TileSize;
        public const int GridY = WindowSizeY / TileSize;



    }
}
