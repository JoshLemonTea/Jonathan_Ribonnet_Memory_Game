using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Models.States
{
    class BoardTwoFoundState : BoardStateBaseClass
    {
        public BoardTwoFoundState(MemoryBoard board) : base(board)
        {
            // Increase the score of the active player when two tiles are found
            if (board.Playermodel1.IsActive)
            {
                board.Playermodel1.Score++;
            }
            else
            {
                board.Playermodel2.Score++;
            }
        }

        public override BoardStates State => BoardStates.TwoFound;

        public override void AddPreview(Tile tile)
        {

        }

        public override void TileAnimationEnd(Tile tile)
        {
            Board.PreviewingTiles.Remove(tile);
            Board.PreviewingTiles.RemoveAt(0);

            if (Board.PreviewingTiles.Count == 0)
            {
                if (Board.Tiles.Where(t => t.State.State == TileStates.Hidden).Count() < 2)
                {
                    Board.State = new BoardFinishedState(Board);
                }
                else
                {
                    // Switch the active player here
                    Board.Playermodel1.IsActive = !Board.Playermodel1.IsActive;
                    Board.Playermodel2.IsActive = !Board.Playermodel2.IsActive;

                    Board.State = new BoardNoPreviewState(Board);
                }
            }
        }
    }
}
