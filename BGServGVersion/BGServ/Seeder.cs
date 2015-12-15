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
                throw new NoTilesException("No buldings to populate");
            }

            Random rand = new Random();
            for (int i = 0; i < Config.GameConfig.Hospital; i++)
            {
                if (map.DummyBuildings.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
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
                    throw new NoTilesException("No buldings to populate");
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
                    throw new NoTilesException("No buldings to populate");
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
                    throw new NoTilesException("No buldings to populate");
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
                    throw new NoTilesException("No buldings to populate");
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
                    throw new NoTilesException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, this.map.DummyBuildings.Count);
                Tile foundBuilding = map.DummyBuildings[randomLocation];
                Building bank = new Bank(i, new Bitmap(@"images\Bank.png"), foundBuilding.Location);
                map.WorldMap[foundBuilding.Location.Y / 40][foundBuilding.Location.X / 40] = new Tile(bank.Location,
                    foundBuilding.Player, bank, true);
                map.DummyBuildings.RemoveAt(randomLocation);

            }

        }

        public void AddPeople()
        {
            NameConfig name = new NameConfig();
            Random rand = new Random();
            for (int i = 0; i < Config.GameConfig.Policemans; i++)
            {
                if (map.WalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, this.map.WalkableTiles.Count);
                Tile foundCharacter = map.WalkableTiles[randomLocation];
                Gender gender = this.RandomGender();
                Human character = new Policeman(name.FirstName(gender) ,name.LastName(gender), rand.Next(1,101),gender, new Wallet(0),foundCharacter.Location, new Bitmap(@"images\Policeman.png") );
                map.WorldMap[foundCharacter.Location.Y / 40][foundCharacter.Location.X / 40] = new Tile(character.Location,
                    character, foundCharacter.Building, true);
                map.WalkableTiles.RemoveAt(randomLocation);
            }
            for (int i = 0; i < Config.GameConfig.Doctors; i++)
            {
                if (map.WalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, this.map.WalkableTiles.Count);
                Tile foundCharacter = map.WalkableTiles[randomLocation];
                Gender gender = this.RandomGender();
                Human character = new Doctor(name.FirstName(gender), name.LastName(gender), rand.Next(1, 101), gender, new Wallet(0), foundCharacter.Location, new Bitmap(@"images\Doctor.png"));
                map.WorldMap[foundCharacter.Location.Y / 40][foundCharacter.Location.X / 40] = new Tile(character.Location,
                    character, foundCharacter.Building, true);
                map.WalkableTiles.RemoveAt(randomLocation);
            }
            for (int i = 0; i < Config.GameConfig.Developer; i++)
            {
                if (map.WalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, this.map.WalkableTiles.Count);
                Tile foundCharacter = map.WalkableTiles[randomLocation];
                Gender gender = this.RandomGender();
                Human character = new Developer(name.FirstName(gender), name.LastName(gender), rand.Next(1, 101), gender, new Wallet(0), foundCharacter.Location, new Bitmap(@"images\Developer.png"));
                map.WorldMap[foundCharacter.Location.Y / 40][foundCharacter.Location.X / 40] = new Tile(character.Location,
                    character, foundCharacter.Building, true);
                map.WalkableTiles.RemoveAt(randomLocation);
            }
            for (int i = 0; i < Config.GameConfig.Mayors; i++)
            {
                if (map.WalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, this.map.WalkableTiles.Count);
                Tile foundCharacter = map.WalkableTiles[randomLocation];
                Gender gender = this.RandomGender();
                Human character = new Mayor(name.FirstName(gender), name.LastName(gender), rand.Next(1, 101), gender, new Wallet(0), foundCharacter.Location, new Bitmap(@"images\Mayor.png"));
                map.WorldMap[foundCharacter.Location.Y / 40][foundCharacter.Location.X / 40] = new Tile(character.Location,
                    character, foundCharacter.Building, true);
                map.WalkableTiles.RemoveAt(randomLocation);
            }
            for (int i = 0; i < Config.GameConfig.Thiefs; i++)
            {
                if (map.WalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, this.map.WalkableTiles.Count);
                Tile foundCharacter = map.WalkableTiles[randomLocation];
                Gender gender = this.RandomGender();
                Human character = new Thief(name.FirstName(gender), name.LastName(gender), rand.Next(1, 101), gender, new Wallet(0), foundCharacter.Location, new Bitmap(@"images\Thief.png"));
                map.WorldMap[foundCharacter.Location.Y / 40][foundCharacter.Location.X / 40] = new Tile(character.Location,
                    character, foundCharacter.Building, true);
                map.WalkableTiles.RemoveAt(randomLocation);
            }
            for (int i = 0; i < Config.GameConfig.MassMurders; i++)
            {
                if (map.WalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, this.map.WalkableTiles.Count);
                Tile foundCharacter = map.WalkableTiles[randomLocation];
                Gender gender = this.RandomGender();
                Human character = new MassMurderer(name.FirstName(gender), name.LastName(gender), rand.Next(1, 101), gender, new Wallet(0), foundCharacter.Location, new Bitmap(@"images\MassMurder.png"));
                map.WorldMap[foundCharacter.Location.Y / 40][foundCharacter.Location.X / 40] = new Tile(character.Location,
                    character, foundCharacter.Building, true);
                map.WalkableTiles.RemoveAt(randomLocation);
            }
            for (int i = 0; i < Config.GameConfig.Rapists; i++)
            {
                if (map.WalkableTiles.Count <= 0)
                {
                    throw new NoTilesException("No buldings to populate");
                }
                int randomLocation = rand.Next(0, this.map.WalkableTiles.Count);
                Tile foundCharacter = map.WalkableTiles[randomLocation];
                Gender gender = this.RandomGender();
                Human character = new Rapist(name.FirstName(gender), name.LastName(gender), rand.Next(1, 101), gender, new Wallet(0), foundCharacter.Location, new Bitmap(@"images\Rapist.png"));
                map.WorldMap[foundCharacter.Location.Y / 40][foundCharacter.Location.X / 40] = new Tile(character.Location,
                    character, foundCharacter.Building, true);
                map.WalkableTiles.RemoveAt(randomLocation);
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
    }
}