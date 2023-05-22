using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Models.States
{
    class BoardNoPreviewState : BoardStateBaseClass
    {
        public BoardNoPreviewState(MemoryBoard board) : base(board)
        {
            board.Playermodel1.IsActive = !board.Playermodel1.IsActive;
            board.Playermodel2.IsActive = !board.Playermodel2.IsActive;
        }

        public override BoardStates State => BoardStates.NoPreview;

        

        public override void AddPreview(Tile tile)
        {
            if (tile.State.State != TileStates.Hidden)
                return;
            tile.State = new TilePreviewState(tile);
            Board.PreviewingTiles.Add(tile);

            Board.State = new BoardOnePreviewState(Board);
        }

        public override void TileAnimationEnd(Tile tile)
        {
           
        }
    }
}
