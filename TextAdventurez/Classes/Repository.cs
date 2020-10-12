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
        public static List<Item> GetAllItems()
        {
            return new List<Item>
            {
                new Item(Items.banjo, Items_description.banjo),
                new Item(Items.mask, Items_description.mask),
                new Item(Items.bottle, Items_description.bottle),
                new Item(Items.cork_screw, Items_description.cork_screw),
                new Item(Items.bottle_opened, Items_description.bottle_opened),
                new Key(Items.silver_key, Items_description.silver_key, 1)
            };
        }
        public static List<Recipe> GetAllRecipes()
        {
            return new List<Recipe>
            {
                new Recipe
                {
                    By = GetAllItems().Single(x => x.Name == Items.cork_screw),
                    On = GetAllItems().Single(x => x.Name == Items.bottle),
                    Result = GetAllItems().Single(x => x.Name == Items.bottle_opened),
                },
            };
        }

        public static Location Start()
        {
            return new Location(Locations.field, Locations_description.field)
            { 
                Items = GetAllItems().Where(x => new[] { Items.bottle }.Contains(x.Name)).ToList(),

                Exits = new List<Exit>
                {
                    new Exit(Exits.entrance_door, Exits_description.entrance_door, Direction.east, 2)
                    {
                        NextLocation = new Location(Locations.entrance, Locations_description.entrance)
                        {
                            Items = GetAllItems().Where(x => new[] { Items.mask }.Contains(x.Name)).ToList(),

                            Exits = new List<Exit>
                            {
                                new Exit(Exits.hallway_door, Exits_description.hallway_door, Direction.east, 3)
                                {
                                    NextLocation = new Location(Locations.hallway, Locations_description.hallway)
                                    {
                                        Items = GetAllItems().Where(x => new[] { Items.banjo }.Contains(x.Name)).ToList(),

                                        Exits = new List<Exit>
                                        {
                                            new Exit(Exits.kitchen_door, Exits_description.kitchen_door, Direction.north, 4)
                                            {
                                                NextLocation = new Location(Locations.kitchen, Locations_description.kitchen)
                                                {
                                                    Items = GetAllItems().Where(x => new[] { Items.cork_screw }.Contains(x.Name)).ToList()
                                                }
                                            },
                                            new Exit(Exits.bedroom_door, Exits_description.bedroom_door, Direction.south, 5)
                                            {
                                                NextLocation = new Location (Locations.bedroom, Locations_description.bedroom)
                                                {
                                                    Items = GetAllItems().Where(x => new[] { Items.silver_key }.Contains(x.Name)).ToList()
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new Exit(Exits.barn_door, Exits_description.barn_door, Direction.north, 1, true)
                    {
                        NextLocation = new Location(Locations.barn, Locations_description.barn, true)
                    },
                }

            };
        }
    }
}

        //public static Location Start2()
        //{
        //    return new Location(GetAllLocations().Single(x => x.Name == Locations.field))
        //    {
        //        Exits = new List<Exit>
        //        {
        //            new Exit(GetAllExits().Single(x => x.Name == Exits.entrance_door))
        //            {
        //                NextLocation = new Location(GetAllLocations().Single(x => x.Name == Locations.entrance))
        //                {
        //                    Exits = new List<Exit>
        //                    {
        //                        new Exit(GetAllExits().Single(x => x.Name == Exits.hallway_door))
        //                        {
        //                            NextLocation = new Location(GetAllLocations().Single(x => x.Name == Locations.hallway))
        //                            {
        //                                Exits = new List<Exit>
        //                                {
        //                                    new Exit(GetAllExits().Single(x => x.Name == Exits.kitchen_door))
        //                                    {
        //                                        NextLocation = new Location(GetAllLocations().Single(x => x.Name == Locations.kitchen))
        //                                    },
        //                                    new Exit(GetAllExits().Single(x => x.Name == Exits.bedroom_door))
        //                                    {
        //                                        NextLocation = new Location(GetAllLocations().Single(x => x.Name == Locations.bedroom))
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            },
        //            new Exit(GetAllExits().Single(x => x.Name == Exits.barn_door))
        //            {
        //                NextLocation = new Location(GetAllLocations().Single(x => x.Name == Locations.barn))
        //            },
        //        }
        //    };
        //}






















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