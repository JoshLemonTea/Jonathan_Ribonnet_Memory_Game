using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Models.States
{
    abstract class BoardStateBaseClass : IBoardState
    {
        public abstract BoardStates State { get; }

        private MemoryBoard _board;
        public MemoryBoard Board => _board;

        protected BoardStateBaseClass(MemoryBoard board)
        {
            _board = board;
        }

        public abstract void AddPreview(Tile tile);
        public abstract void TileAnimationEnd(Tile tile);
     
    }
}
