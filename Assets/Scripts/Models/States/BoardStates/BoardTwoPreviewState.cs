using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Models.States
{
    class BoardTwoPreviewState : BoardStateBaseClass
    {
        public BoardTwoPreviewState(MemoryBoard board) : base(board)
        {
        }

        public override BoardStates State => BoardStates.TwoPreview;

        public override void AddPreview(Tile tile)
        {

        }

        public override void TileAnimationEnd(Tile tile)
        {
            if (Board.PreviewingTiles[1] == tile)
            {
                Board.State = new BoardTwoHidingState(Board);

                foreach (var item in Board.PreviewingTiles)
                {
                    item.State = new TileHiddenState(item);
                }
            }

        }
    }
}

