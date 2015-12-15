using System;
using System.Collections.Generic;
using System.Drawing;
using WindowsFormsApplication1;
using BGServ.Exceptions;
using BulgarianReality.Buildings;

namespace BGServ
{
    public class Seeder
    {
        private Map map;

        public Seeder(Map map)
        {
            this.map = map;
        }
        public void AddBiuldings()
        {
            if (map.DummyBuildings.Count <= 0)
            {
                throw new NoBuildingsException("No buldings to populate");
            }

            Random rand = new Random();
            for (int i = 0; i < Config.GameConfig.Hospital; i++)
            {
                if (map.DummyBuildings.Count <= 0)
                {
                    throw new NoBuildingsException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, this.map.DummyBuildings.Count);
                Tile foundBuilding = map.DummyBuildings[randomLocation];
                Building hospital = new Hospital(i, new Bitmap(@"images\Hospital.png"), foundBuilding.Location);
                map.WorldMap[foundBuilding.Location.Y / 40][foundBuilding.Location.X / 40] = new Tile(hospital.Location,
                    foundBuilding.Player, hospital, true);
                map.DummyBuildings.RemoveAt(randomLocation);
            }
            for (int i = 0; i < Config.GameConfig.Police; i++)
            {
                if (map.DummyBuildings.Count <= 0)
                {
                    throw new NoBuildingsException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, this.map.DummyBuildings.Count);
                Tile foundBuilding = map.DummyBuildings[randomLocation];
                Building police = new PoliceStation(i, new Bitmap(@"images\Police.png"), foundBuilding.Location);
                map.WorldMap[foundBuilding.Location.Y / 40][foundBuilding.Location.X / 40] = new Tile(police.Location,
                    foundBuilding.Player, police, true);
                map.DummyBuildings.RemoveAt(randomLocation);

            }
            for (int i = 0; i < Config.GameConfig.Restaurant; i++)
            {
                if (map.DummyBuildings.Count <= 0)
                {
                    throw new NoBuildingsException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, this.map.DummyBuildings.Count);
                Tile foundBuilding = map.DummyBuildings[randomLocation];
                Building restaurant = new Restaurant(i, new Bitmap(@"images\Retaurant.png"), foundBuilding.Location);
                map.WorldMap[foundBuilding.Location.Y / 40][foundBuilding.Location.X / 40] = new Tile(restaurant.Location,
                    foundBuilding.Player, restaurant, true);
                map.DummyBuildings.RemoveAt(randomLocation);

            }
            for (int i = 0; i < Config.GameConfig.Office; i++)
            {
                if (map.DummyBuildings.Count <= 0)
                {
                    throw new NoBuildingsException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, this.map.DummyBuildings.Count);
                Tile foundBuilding = map.DummyBuildings[randomLocation];
                Building office = new Office(i, new Bitmap(@"images\Office.png"), foundBuilding.Location);
                map.WorldMap[foundBuilding.Location.Y / 40][foundBuilding.Location.X / 40] = new Tile(office.Location,
                    foundBuilding.Player, office, true);
                map.DummyBuildings.RemoveAt(randomLocation);

            }
            for (int i = 0; i < Config.GameConfig.Coffee; i++)
            {
                if (map.DummyBuildings.Count <= 0)
                {
                    throw new NoBuildingsException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, this.map.DummyBuildings.Count);
                Tile foundBuilding = map.DummyBuildings[randomLocation];
                Building office = new Coffee(i, new Bitmap(@"images\Coffee.png"), foundBuilding.Location);
                map.WorldMap[foundBuilding.Location.Y / 40][foundBuilding.Location.X / 40] = new Tile(office.Location,
                    foundBuilding.Player, office, true);
                map.DummyBuildings.RemoveAt(randomLocation);

            } 
            for (int i = 0; i < Config.GameConfig.Bank; i++)
            {
                if (map.DummyBuildings.Count <= 0)
                {
                    throw new NoBuildingsException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, this.map.DummyBuildings.Count);
                Tile foundBuilding = map.DummyBuildings[randomLocation];
                Building bank = new Bank(i, new Bitmap(@"images\Bank.png"), foundBuilding.Location);
                map.WorldMap[foundBuilding.Location.Y / 40][foundBuilding.Location.X / 40] = new Tile(bank.Location,
                    foundBuilding.Player, bank, true);
                map.DummyBuildings.RemoveAt(randomLocation);

            }

        }
    }
}