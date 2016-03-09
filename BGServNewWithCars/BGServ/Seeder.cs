using System;
using System.Collections.Generic;
using System.Drawing;
using WindowsFormsApplication1;
using BGServ.Config;
using BGServ.Exceptions;
using BulgarianReality.Buildings;
using BulgarianReality.Enums;
using BulgarianReality.Humans;
using BulgarianReality.Humans.Criminals;
using BulgarianReality.Humans.Workers;
using BulgarianReality.Items.Belongings;
using BulgarianReality.Transportation;

namespace BGServ
{
    public class Seeder
    {

        public void AddBiuldings()
        {
            if (Map.Instance.DummyBuildings.Count <= 0)
            {
                throw new NoTilesException("No buldings to populate");
            }

            Random rand = new Random();
            for (int i = 0; i < Config.GameConfig.Hospital; i++)
            {
                if (Map.Instance.DummyBuildings.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, Map.Instance.DummyBuildings.Count);
                Tile foundBuilding = Map.Instance.DummyBuildings[randomLocation];
                MapTile hospital = new Hospital(i, new Bitmap(@"images\Hospital.png"), foundBuilding.Location);
                Map.Instance.WorldMap[foundBuilding.Location.Y / Config.GameConfig.TileSize][foundBuilding.Location.X / Config.GameConfig.TileSize] = new Tile(hospital.Location,
                    foundBuilding.PlayerId, hospital, true,false);

                Map.Instance.DummyBuildings.RemoveAt(randomLocation);
            }
            for (int i = 0; i < Config.GameConfig.Police; i++)
            {
                if (Map.Instance.DummyBuildings.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, Map.Instance.DummyBuildings.Count);
                Tile foundBuilding = Map.Instance.DummyBuildings[randomLocation];
                MapTile police = new PoliceStation(i, new Bitmap(@"images\Police.png"), foundBuilding.Location);
                Map.Instance.WorldMap[foundBuilding.Location.Y / Config.GameConfig.TileSize][foundBuilding.Location.X / Config.GameConfig.TileSize] = new Tile(police.Location,
                    foundBuilding.PlayerId, police, true, false);
                Map.Instance.DummyBuildings.RemoveAt(randomLocation);

            }
            for (int i = 0; i < Config.GameConfig.Restaurant; i++)
            {
                if (Map.Instance.DummyBuildings.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, Map.Instance.DummyBuildings.Count);
                Tile foundBuilding = Map.Instance.DummyBuildings[randomLocation];
                MapTile restaurant = new Restaurant(i, new Bitmap(@"images\Retaurant.png"), foundBuilding.Location);
                Map.Instance.WorldMap[foundBuilding.Location.Y / Config.GameConfig.TileSize][foundBuilding.Location.X / Config.GameConfig.TileSize] = new Tile(restaurant.Location,
                    foundBuilding.PlayerId, restaurant, true, false);
                Map.Instance.DummyBuildings.RemoveAt(randomLocation);

            }
            for (int i = 0; i < Config.GameConfig.Office; i++)
            {
                if (Map.Instance.DummyBuildings.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, Map.Instance.DummyBuildings.Count);
                Tile foundBuilding = Map.Instance.DummyBuildings[randomLocation];
                MapTile office = new Office(i, new Bitmap(@"images\Office.png"), foundBuilding.Location);
                Map.Instance.WorldMap[foundBuilding.Location.Y / Config.GameConfig.TileSize][foundBuilding.Location.X / Config.GameConfig.TileSize] = new Tile(office.Location,
                    foundBuilding.PlayerId, office, true, false);
                Map.Instance.DummyBuildings.RemoveAt(randomLocation);

            }
            for (int i = 0; i < Config.GameConfig.Coffee; i++)
            {
                if (Map.Instance.DummyBuildings.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, Map.Instance.DummyBuildings.Count);
                Tile foundBuilding = Map.Instance.DummyBuildings[randomLocation];
                MapTile office = new Coffee(i, new Bitmap(@"images\Coffee.png"), foundBuilding.Location);
                Map.Instance.WorldMap[foundBuilding.Location.Y / Config.GameConfig.TileSize][foundBuilding.Location.X / Config.GameConfig.TileSize] = new Tile(office.Location,
                    foundBuilding.PlayerId, office, true, false);
                Map.Instance.DummyBuildings.RemoveAt(randomLocation);

            } 
            for (int i = 0; i < Config.GameConfig.Bank; i++)
            {
                if (Map.Instance.DummyBuildings.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, Map.Instance.DummyBuildings.Count);
                Tile foundBuilding = Map.Instance.DummyBuildings[randomLocation];
                MapTile bank = new Bank(i, new Bitmap(@"images\Bank.png"), foundBuilding.Location);
                Map.Instance.WorldMap[foundBuilding.Location.Y / Config.GameConfig.TileSize][foundBuilding.Location.X / Config.GameConfig.TileSize] = new Tile(bank.Location,
                    foundBuilding.PlayerId, bank, true, false);
                Map.Instance.DummyBuildings.RemoveAt(randomLocation);

            }

        }

        public void AddPeople()
        {
            int Id = 1;
            Game.Instance.Bots = new HashSet<Human>();
            NameConfig name = new NameConfig();
            Random rand = new Random();
            for (int i = 0; i < Config.GameConfig.Policemans; i++)
            {
                if (Map.Instance.WalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                Image[] directionImage =
                {
                    new Bitmap(@"images\pol-0.png"),
                    new Bitmap(@"images\pol-1.png"),
                    new Bitmap(@"images\pol-2.png"),
                    new Bitmap(@"images\pol-3.png"),
                };
                int randomLocation = rand.Next(0, Map.Instance.WalkableTiles.Count);
                Tile foundCharacter = Map.Instance.WalkableTiles[randomLocation];
                Gender gender = this.RandomGender();
                Human character = new Policeman(Game.Instance.Id(),name.FirstName(gender) ,name.LastName(gender), rand.Next(1,101),gender, new Wallet(0),foundCharacter.Location, directionImage);
                Map.Instance.WorldMap[foundCharacter.Location.Y / Config.GameConfig.TileSize][foundCharacter.Location.X / Config.GameConfig.TileSize].PlayerId = character.Id;
                Map.Instance.WalkableTiles.RemoveAt(randomLocation);
                character.Direction = rand.Next(0, 3);
                character.Image = directionImage[character.Direction];
                Game.Instance.Bots.Add(character);
            }
            for (int i = 0; i < Config.GameConfig.Doctors; i++)
            {
                if (Map.Instance.WalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                                Image[] directionImage =
                {
                    new Bitmap(@"images\doc-0.png"),
                    new Bitmap(@"images\doc-1.png"),
                    new Bitmap(@"images\doc-2.png"),
                    new Bitmap(@"images\doc-3.png"),
                };
                int randomLocation = rand.Next(0, Map.Instance.WalkableTiles.Count);
                Tile foundCharacter = Map.Instance.WalkableTiles[randomLocation];
                Gender gender = this.RandomGender();
                Human character = new Doctor(Game.Instance.Id(),name.FirstName(gender), name.LastName(gender), rand.Next(1, 101), gender, new Wallet(0), foundCharacter.Location, directionImage);
                Map.Instance.WorldMap[foundCharacter.Location.Y / Config.GameConfig.TileSize][foundCharacter.Location.X / Config.GameConfig.TileSize].PlayerId = character.Id;
                Map.Instance.WalkableTiles.RemoveAt(randomLocation);
                character.Direction = rand.Next(0, 3);
                character.Image = directionImage[character.Direction];
                Game.Instance.Bots.Add(character);
            }
            for (int i = 0; i < Config.GameConfig.Developer; i++)
            {
                if (Map.Instance.WalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                Image[] directionImage =
                {
                    new Bitmap(@"images\dev-0.png"),
                    new Bitmap(@"images\dev-1.png"),
                    new Bitmap(@"images\dev-2.png"),
                    new Bitmap(@"images\dev-3.png"),
                };
                int randomLocation = rand.Next(0, Map.Instance.WalkableTiles.Count);
                Tile foundCharacter = Map.Instance.WalkableTiles[randomLocation];
                Gender gender = this.RandomGender();
                Human character = new Developer(Game.Instance.Id(), name.FirstName(gender), name.LastName(gender), rand.Next(1, 101), gender, new Wallet(0), foundCharacter.Location, directionImage);
                Map.Instance.WorldMap[foundCharacter.Location.Y / Config.GameConfig.TileSize][foundCharacter.Location.X / Config.GameConfig.TileSize].PlayerId = character.Id;
                Map.Instance.WalkableTiles.RemoveAt(randomLocation);
                character.Direction = rand.Next(0, 3);
                character.Image = directionImage[character.Direction];
                Game.Instance.Bots.Add(character);
            }
            for (int i = 0; i < Config.GameConfig.Mayors; i++)
            {
                if (Map.Instance.WalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                                Image[] directionImage =
                {
                    new Bitmap(@"images\mayor-0.png"),
                    new Bitmap(@"images\mayor-1.png"),
                    new Bitmap(@"images\mayor-2.png"),
                    new Bitmap(@"images\mayor-3.png"),
                };
                int randomLocation = rand.Next(0, Map.Instance.WalkableTiles.Count);
                Tile foundCharacter = Map.Instance.WalkableTiles[randomLocation];
                Gender gender = this.RandomGender();
                Human character = new Mayor(Game.Instance.Id(),name.FirstName(gender), name.LastName(gender), rand.Next(1, 101), gender, new Wallet(0), foundCharacter.Location,directionImage);
                Map.Instance.WorldMap[foundCharacter.Location.Y / Config.GameConfig.TileSize][foundCharacter.Location.X / Config.GameConfig.TileSize].PlayerId = character.Id;
                Map.Instance.WalkableTiles.RemoveAt(randomLocation);
                character.Direction = rand.Next(0, 3);
                character.Image = directionImage[character.Direction];
                Game.Instance.Bots.Add(character);
            }
            for (int i = 0; i < Config.GameConfig.Thiefs; i++)
            {
                if (Map.Instance.WalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                                Image[] directionImage =
                {
                    new Bitmap(@"images\thief-0.png"),
                    new Bitmap(@"images\thief-1.png"),
                    new Bitmap(@"images\thief-2.png"),
                    new Bitmap(@"images\thief-3.png"),
                };
                int randomLocation = rand.Next(0, Map.Instance.WalkableTiles.Count);
                Tile foundCharacter = Map.Instance.WalkableTiles[randomLocation];
                Gender gender = this.RandomGender();
                Human character = new Thief(Game.Instance.Id(),name.FirstName(gender), name.LastName(gender), rand.Next(1, 101), gender, new Wallet(0), foundCharacter.Location, directionImage);
                Map.Instance.WorldMap[foundCharacter.Location.Y / Config.GameConfig.TileSize][foundCharacter.Location.X / Config.GameConfig.TileSize].PlayerId = character.Id;
                Map.Instance.WalkableTiles.RemoveAt(randomLocation);
                character.Direction = rand.Next(0, 3);
                character.Image = directionImage[character.Direction];
                Game.Instance.Bots.Add(character);
            }
            for (int i = 0; i < Config.GameConfig.MassMurders; i++)
            {
                if (Map.Instance.WalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                                Image[] directionImage =
                {
                    new Bitmap(@"images\mass-0.png"),
                    new Bitmap(@"images\mass-1.png"),
                    new Bitmap(@"images\mass-2.png"),
                    new Bitmap(@"images\mass-3.png"),
                };
                int randomLocation = rand.Next(0, Map.Instance.WalkableTiles.Count);
                Tile foundCharacter = Map.Instance.WalkableTiles[randomLocation];
                Gender gender = this.RandomGender();
                Human character = new MassMurderer(Game.Instance.Id(),name.FirstName(gender), name.LastName(gender), rand.Next(1, 101), gender, new Wallet(0), foundCharacter.Location, directionImage);
                Map.Instance.WorldMap[foundCharacter.Location.Y / Config.GameConfig.TileSize][foundCharacter.Location.X / Config.GameConfig.TileSize].PlayerId = character.Id;
                Map.Instance.WalkableTiles.RemoveAt(randomLocation);
                character.Direction = rand.Next(0, 3);
                character.Image = directionImage[character.Direction];
                Game.Instance.Bots.Add(character);
            }
            for (int i = 0; i < Config.GameConfig.Rapists; i++)
            {
                if (Map.Instance.WalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                                Image[] directionImage =
                {
                    new Bitmap(@"images\rapist-0.png"),
                    new Bitmap(@"images\rapist-1.png"),
                    new Bitmap(@"images\rapist-2.png"),
                    new Bitmap(@"images\rapist-3.png"),
                };
                int randomLocation = rand.Next(0, Map.Instance.WalkableTiles.Count);
                Tile foundCharacter = Map.Instance.WalkableTiles[randomLocation];
                Gender gender = this.RandomGender();
                Human character = new Rapist(Game.Instance.Id(),name.FirstName(gender), name.LastName(gender), rand.Next(1, 101), gender, new Wallet(0), foundCharacter.Location, directionImage);
                Map.Instance.WorldMap[foundCharacter.Location.Y / Config.GameConfig.TileSize][foundCharacter.Location.X / Config.GameConfig.TileSize].PlayerId = character.Id;
                Map.Instance.WalkableTiles.RemoveAt(randomLocation);
                character.Direction = rand.Next(0, 3);
                character.Image = directionImage[character.Direction];
                Game.Instance.Bots.Add(character);
            }
            
        }

        private Gender RandomGender()
        {
            Random rand = new Random();
            int gender = rand.Next(0, 2);
            if (gender == 0)
            {
                return Gender.Male;
            }
            if (gender == 1)
            {
                return Gender.Female;
            }
            if (gender == 2)
            {
                return Gender.Other;
            }

            return Gender.Other;
        }

        public void AddCars()
        {
            Game.Instance.Cars = new HashSet<Transport>();
            Random rand = new Random();
            for (int i = 0; i < Config.GameConfig.Cars; i++)
            {
                if (Map.Instance.NonWalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No cars to populate");
                }
                Image[] directionImage =
                {
                    new Bitmap(@"images\pol1-0.png"),
                    new Bitmap(@"images\pol1-1.png"),
                    new Bitmap(@"images\pol1-2.png"),
                    new Bitmap(@"images\pol1-3.png"),
                };
                int randomLocation = rand.Next(0, Map.Instance.NonWalkableTiles.Count);
                Tile foundCar = Map.Instance.NonWalkableTiles[randomLocation];
                Transport car = new Car(Game.Instance.Id(), foundCar.Location, directionImage);

                //Map.Instance.NonWalkableTiles.RemoveAt(randomLocation);
                Game.Instance.Cars.Add(car);
                //car.Direction = rand.Next(0, 4);
                car.Direction = 0;
            }
            for (int i = 0; i < Config.GameConfig.Cars; i++)
            {
                if (Map.Instance.NonWalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No cars to populate");
                }
                Image[] directionImage =
                {
                    new Bitmap(@"images\car1-0.png"),
                    new Bitmap(@"images\car1-1.png"),
                    new Bitmap(@"images\car1-2.png"),
                    new Bitmap(@"images\car1-3.png"),
                };
                int randomLocation = rand.Next(0, Map.Instance.NonWalkableTiles.Count);
                Tile foundCar = Map.Instance.NonWalkableTiles[randomLocation];
                Transport car = new Car(Game.Instance.Id(), foundCar.Location, directionImage);

                //Map.Instance.NonWalkableTiles.RemoveAt(randomLocation);
                Game.Instance.Cars.Add(car);
                car.Direction = 0;
            }
            for (int i = 0; i < Config.GameConfig.Cars; i++)
            {
                if (Map.Instance.NonWalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No cars to populate");
                }
                Image[] directionImage =
                {
                    new Bitmap(@"images\car2-0.png"),
                    new Bitmap(@"images\car2-1.png"),
                    new Bitmap(@"images\car2-2.png"),
                    new Bitmap(@"images\car2-3.png"),
                };
                int randomLocation = rand.Next(0, Map.Instance.NonWalkableTiles.Count);
                Tile foundCar = Map.Instance.NonWalkableTiles[randomLocation];
                Transport car = new Car(Game.Instance.Id(), foundCar.Location, directionImage);

                //Map.Instance.NonWalkableTiles.RemoveAt(randomLocation);
                Game.Instance.Cars.Add(car);
                car.Direction = 0;
            }

        }

    }
}