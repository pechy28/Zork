using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Zork
{
    public class Player
    {
        public World World { get; }

        [JsonIgnore]
        public Room Location { get; set; }

        [JsonIgnore]
        public string LocationName
        {
            get
            {
                return Location?.Name;
            }

            set
            {
                Location = World?.RoomsByName.GetValueOrDefault(value);
            }
        }

        public Player(World world, string startingLocation)
        {
            World = world;
            LocationName = startingLocation;
        }

        public bool Move(Directions direction)
        {
            bool isValidMove = Location.Neighbors.TryGetValue((Zork.Directions)direction, out Room destination);
            if (isValidMove)
            {
                Location = destination;
            }

            return isValidMove;
        }

        internal bool Move(Game.Directions direction)
        {
            throw new NotImplementedException();
        }

        public enum Directions
        { 
        
        }

    }
}
