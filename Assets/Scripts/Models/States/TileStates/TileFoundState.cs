using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Models.States
{
    class TileFoundState : TileStateBaseClass
    {
        public TileFoundState(Tile tile) : base(tile)
        {
        }

        public override TileStates State => TileStates.Found;
    }
}
