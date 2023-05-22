using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Models.States
{
    class TilePreviewState : TileStateBaseClass
    {
        public TilePreviewState(Tile tile) : base(tile)
        {
        }

        public override TileStates State => TileStates.Preview;
    }
}
