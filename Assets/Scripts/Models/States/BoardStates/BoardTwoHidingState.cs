using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Models.States
{
    class BoardTwoHidingState : BoardStateBaseClass
    {
        public BoardTwoHidingState(MemoryBoard board) : base(board)
        {
        }

        public override BoardStates State => BoardStates.TwoHiding;

        public override void AddPreview(Tile tile)
        {

        }

        public override void TileAnimationEnd(Tile tile)
        {
            Board.PreviewingTiles.Remove(tile);

            if (Board.PreviewingTiles.Count == 0)
            {
                Board.State = new BoardNoPreviewState(Board);
            }
        }
    }
}

