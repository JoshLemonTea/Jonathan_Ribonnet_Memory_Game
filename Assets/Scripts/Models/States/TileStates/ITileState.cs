using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Models.States
{
    public interface ITileState
    {
        public TileStates State { get; }

        public Tile Tile { get; }

    }
}
