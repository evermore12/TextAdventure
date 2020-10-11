using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using TextAdventurez.Resource_Files.Exits;
using TextAdventurez.Resource_Files.Items;
using TextAdventurez.Resource_Files.Locations;

namespace TextAdventurez
{
    public static class Repository
    {
        public static List<Recipe> GetAllRecipes()
        {
            return new List<Recipe>
            {
                new Recipe
                {
                    By = Items.cork_screw,
                    On = Items.bottle,
                    Result = new Item
                    {
                        Name = Items.bottle_opened,
                        Description = Items_description.bottle_opened,
                    },
                },
            };
        }
        public static List<Item> GetAllItems()
        {
            return new List<Item>
            {
                new Item
                {
                    Name = Items.banjo,
                    Description = Items_description.banjo,
                    Interactions = Repository.GetAllRecipes().Where(x => x.By == Items.banjo).ToList()
                },
                new Item
                {
                    Name = Items.mask,
                    Description = Items.mask,
                    Interactions = Repository.GetAllRecipes().Where(x => x.By == Items.mask).ToList()
                },
                new Item
                {
                    Name = Items.bottle,
                    Description = Items_description.bottle,
                    Interactions = Repository.GetAllRecipes().Where(x => x.By == Items.bottle).ToList()
                },
                new Item
                {
                    Name = Items.cork_screw,
                    Description = Items_description.cork_screw,
                    Interactions = Repository.GetAllRecipes().Where(x => x.By == Items.cork_screw).ToList()
                },
                new Key
                {
                    Name = Items.silver_key,
                    Description = Items.silver_key,
                    Id = 1
                }
            };
        }

        public static List<Exit> GetAllExits()
        {
            return new List<Exit>
            {
                new Exit
                {
                    Name = Exits.barn_door,
                    Description = Exits_description.barn_door,
                    Orientation = Direction.north,
                    Locked = true,
                    LockId = 1
                },
                new Exit
                {
                    Name = Exits.entrance_door,
                    Description = Exits_description.entrance_door,
                    Orientation = Direction.east,
                },
                new Exit
                {
                    Name = Exits.hallway_door,
                    Description = Exits_description.hallway_door,
                    Orientation = Direction.east,
                },
                new Exit
                {
                    Name = Exits.kitchen_door,
                    Description = Exits_description.kitchen_door,
                    Orientation = Direction.north,
                },
                new Exit
                {
                    Name = Exits.bedroom_door,
                    Description = Exits_description.bedroom_door,
                    Orientation = Direction.south,
                }
            };
        }

        public static List<Location> GetAllLocations()
        {
            return new List<Location>
            {
                new Location()
                {
                    Name = Locations.field,
                    Description = Locations_description.field,
                    Items = GetAllItems().Where(x => new[] {Items.bottle, Items.cork_screw}.Contains(x.Name)).ToList(),
                },
                new Location()
                {
                    Name = Locations.barn,
                    Description = Locations_description.barn,
                    Items = GetAllItems().Where(x => new[] {""}.Contains(x.Name)).ToList(),
                },
                new Location
                {
                    Name = Locations.entrance,
                    Description = Locations_description.entrance,
                    Items = GetAllItems().Where(x => new[] {""}.Contains(x.Name)).ToList(),
                },
                new Location
                {
                    Name = Locations.hallway,
                    Description = Locations_description.hallway,
                    Items = GetAllItems().Where(x => new[] {""}.Contains(x.Name)).ToList(),
                },
                new Location
                {
                    Name = Locations.kitchen,
                    Description = Locations_description.kitchen,
                    Items = GetAllItems().Where(x => new[] {""}.Contains(x.Name)).ToList(),
                },
                new Location
                {
                    Name = Locations.bedroom,
                    Description = Locations_description.kitchen,
                    Items = GetAllItems().Where(x => new[] {Items.silver_key}.Contains(x.Name)).ToList(),
                },
            };
        }

        public static Location Start()
        {
            return new Location(GetAllLocations().Single(x => x.Name == Locations.field))
            {
                Exits = new List<Exit>
                {
                    new Exit(GetAllExits().Single(x => x.Name == Exits.entrance_door))
                    {
                        NextLocation = new Location(GetAllLocations().Single(x => x.Name == Locations.entrance))
                        {
                            Exits = new List<Exit>
                            {
                                new Exit(GetAllExits().Single(x => x.Name == Exits.hallway_door))
                                {
                                    NextLocation = new Location(GetAllLocations().Single(x => x.Name == Locations.hallway))
                                    {
                                        Exits = new List<Exit>
                                        {
                                            new Exit(GetAllExits().Single(x => x.Name == Exits.kitchen_door))
                                            {
                                                NextLocation = new Location(GetAllLocations().Single(x => x.Name == Locations.kitchen))
                                            },
                                            new Exit(GetAllExits().Single(x => x.Name == Exits.bedroom_door))
                                            {
                                                NextLocation = new Location(GetAllLocations().Single(x => x.Name == Locations.bedroom))
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new Exit(GetAllExits().Single(x => x.Name == Exits.barn_door))
                    {
                        NextLocation = new Location(GetAllLocations().Single(x => x.Name == Locations.barn))
                    },
                }
            };
        }
    }
}
























//Name = Locations.field,
//       Description = Locations_description.field,
//       Items = GetAllItems().Where(x => new[] { "" }.Contains(x.Name)).ToList(),
//       Exits = new List<Exit>
//       {
//           new Exit
//           {
//               Name = Exits.barn_door,
//               Description = Exits.barn_door,
//               NextRoom = GetAllLocations().Single(x => x.Name == Locations.entrance)
//               .Exits.Single(x => x.Name == )
//           }
//       }




////Exits -----------------------------------------------------------

//Exit barnDoor = GetAllExits().Single(x => x.Name == Exits.barn_door);

//Exit entranceDoor = GetAllExits().Single(x => x.Name == Exits.entrance_door);

//Exit hallwayDoor = GetAllExits().Single(x => x.Name == Exits.hallway_door);

//Exit kitchenDoor = GetAllExits().Single(x => x.Name == Exits.kitchen_door);

//Exit bedroomDoor = GetAllExits().Single(x => x.Name == Exits.bedroom_door);

////-------------------------------------------------------------------


////Locations ---------------------------------------------------------
//Location field = GetAllLocations().Single(x => x.Name == Locations.field);

//Location barn = GetAllLocations().Single(x => x.Name == Locations.barn);

//Location entrance = GetAllLocations().Single(x => x.Name == Locations.entrance);

//Location hallway = GetAllLocations().Single(x => x.Name == Locations.hallway);

//Location kitchen = GetAllLocations().Single(x => x.Name == Locations.kitchen);

//Location bedroom = GetAllLocations().Single(x => x.Name == Locations.bedroom);
////--------------------------------------------------------------------



////Syihop dem baserat på NextRoom propertyn hos dörrarna

//barnDoor.NextRoom = barn;

//entranceDoor.NextRoom = entrance;

//hallwayDoor.NextRoom = hallway;

//kitchenDoor.NextRoom = kitchen;

//bedroomDoor.NextRoom = bedroom;




//Locations-------------------------------------------------------- -
//Location field = GetAllLocations().Single(x => x.Name == Locations.field);

//Location barn = GetAllLocations().Single(x => x.Name == Locations.barn);

//Location entrance = GetAllLocations().Single(x => x.Name == Locations.entrance);

//Location hallway = GetAllLocations().Single(x => x.Name == Locations.hallway);

//Location kitchen = GetAllLocations().Single(x => x.Name == Locations.kitchen);

//Location bedroom = GetAllLocations().Single(x => x.Name == Locations.bedroom);
//--------------------------------------------------------------------

//Exits---------------------------------------------------------- -

//Exit barnDoor = GetAllExits().Single(x => x.Name == Exits.barn_door);

//Exit entranceDoor = GetAllExits().Single(x => x.Name == Exits.entrance_door);

//Exit hallwayDoor = GetAllExits().Single(x => x.Name == Exits.hallway_door);

//Exit kitchenDoor = GetAllExits().Single(x => x.Name == Exits.kitchen_door);

//Exit bedroomDoor = GetAllExits().Single(x => x.Name == Exits.bedroom_door);

//---------------------------------------

//Syihop dem baserat på NextRoom propertyn hos dörrarna

//barnDoor.NextRoom = barn;

//entranceDoor.NextRoom = entrance;

//hallwayDoor.NextRoom = hallway;

//kitchenDoor.NextRoom = kitchen;

//bedroomDoor.NextRoom = bedroom;

//---------------------------------------

//field.Exits = new List<Exit>
//            {
//                barnDoor,
//                entranceDoor,
//            };