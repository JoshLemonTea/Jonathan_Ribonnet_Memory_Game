using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Models.States
{
    abstract class TileStateBaseClass : ITileState
    {
             

        public abstract TileStates State { get; }

        private Tile _tile;
        public Tile Tile => _tile;

        protected TileStateBaseClass(Tile tile)
        {
            _tile = tile;
        }
    }
}
