using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Models.States
{
    public interface IBoardState
    {

        public BoardStates State { get; }

        public MemoryBoard Board { get; }

        public void AddPreview(Tile tile);

        public void TileAnimationEnd(Tile tile);
    }
}
