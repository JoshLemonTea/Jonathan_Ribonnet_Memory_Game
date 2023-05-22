using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Models.States
{
    class BoardOnePreviewState : BoardStateBaseClass
    {
        public BoardOnePreviewState(MemoryBoard board) : base(board)
        {
        }

        public override BoardStates State => BoardStates.OnePreview;

        public override void AddPreview(Tile tile)
        {
            if (tile.State.State != TileStates.Hidden)
                return;

            Board.PreviewingTiles.Add(tile);

            if (Board.PreviewingTiles[0].MemoryCardId == Board.PreviewingTiles[1].MemoryCardId)
            {
                foreach (var item in Board.PreviewingTiles)
                {
                    item.State = new TileFoundState(item);
                }
                Board.State = new BoardTwoFoundState(Board);
            }
            else
            {
                Board.State = new BoardTwoPreviewState(Board);
                tile.State = new TilePreviewState(tile);
            }
        }

        public override void TileAnimationEnd(Tile tile)
        {
           
        }
    }
}
