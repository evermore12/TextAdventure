using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventurez
{
    public static class Repository
    {
        public static Room Start()
        {
            return new Room
            {
                Name = "Field",
                Description = "You are in the field",
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "Bottles",
                        Count = 3,
                        Interactions = new List<Recipe>
                        {
                            new Recipe
                            {
                                Combine = new Item
                                {
                                    Name = "Cork screw",   
                                },
                                Result = new Item
                                {
                                    Name = "Opened bottles",
                                    Count = 3
                                }
                            }
                        }
                    },
                    new Key
                    {
                        Name = "Silver key"
                    }
                },
                Doors = new List<Door>
                {
                    new Door
                    {
                        Name = "Entrance door",
                        Orientation = Direction.east,
                        NextRoom = new Room
                        {
                            Name = "Entrance",
                            Description = "You are now at the entrance",
                            Doors = new List<Door>
                            {
                                new Door
                                {
                                    Name = "Hallway door",
                                    Orientation = Direction.east,                                    
                                    NextRoom = new Room
                                    {
                                        Name = "Hallway",
                                        Description = "You are now in the hallway",
                                        Doors = new List<Door>
                                        {
                                            new Door
                                            {
                                                Name = "Kitchen door",
                                                Orientation = Direction.north,
                                                NextRoom = new Room
                                                {
                                                    Name = "Kitchen",
                                                    Description = "You are now in the kitchen"
                                                }
                                            },
                                            new Door
                                            {
                                                Name = "Bedroom door",
                                                Orientation = Direction.south,
                                                NextRoom = new Room
                                                {
                                                    Name = "Bedroom",
                                                    Description = "You are now in the bedroom",
                                                    Items = new List<Item>
                                                    {
                                                        new Key
                                                        {
                                                            Name = "Golden key",
                                                            Id = 1
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new Door
                    {
                        Name = "Barn door",
                        Orientation = Direction.north,
                        Locked = true,
                        LockId = 1,
                        NextRoom = new Room
                        {
                            Name = "Barn",
                            EndPoint = true,
                        }
                    },
                }

            };
        }
    }
}
