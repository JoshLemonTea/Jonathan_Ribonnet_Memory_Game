using Memory.Data;
using Memory.Models.States;
using Memory.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Memory.Models
{
    public class MemoryBoard : ModelBaseClass
    {
        // Fields for storing the number of rows and columns in the game board
        private int _rows;
        public int Rows
        {
            get { return _rows; }
            set
            {
                if (_rows == value) return;
                _rows = value;
                //OnPropertyChanged();
            }
        }

        private int _columns;
        public int Columns
        {
            get { return _columns; }
            set
            {
                if (_columns == value) return;
                _columns = value;
                //OnPropertyChanged();
            }
        }

        // List to store all the tiles on the game board
        private List<Tile> _tiles;
        public List<Tile> Tiles
        {
            get { return _tiles; }
            set
            {
                if (_tiles == value) return;
                _tiles = value;
                //OnPropertyChanged();
            }
        }

        // List to store the tiles that are currently being previewed
        private List<Tile> _previewingTiles;
        public List<Tile> PreviewingTiles
        {
            get { return _previewingTiles; }
            set
            {
                if (_previewingTiles == value) return;
                _previewingTiles = value;
                //OnPropertyChanged();
            }
        }

        // Flag indicating if a combination of two matching tiles has been found
        private bool _isCombinationFound;

        public bool IsCombinationFound
        {
            get
            {
                return _isCombinationFound;
                // If two tiles with the same image are found, return true
            }
        }

        // Current state of the game board
        private IBoardState _state;

        public IBoardState State
        {
            get { return _state; }
            set
            {
                if (_state == value) return;
                _state = value;
                OnPropertyChanged();
            }
        }

        // Player models representing the two players in the game
        private PlayerModel _playermodel1;
        public PlayerModel Playermodel1
        {
            get { return _playermodel1; }
            set
            {
                if (_playermodel1 == value) return;
                _playermodel1 = value;
                OnPropertyChanged();
            }
        }

        private PlayerModel _playermodel2;
        public PlayerModel Playermodel2
        {
            get { return _playermodel2; }
            set
            {
                if (_playermodel2 == value) return;
                _playermodel2 = value;
                OnPropertyChanged();
            }
        }

        // Constructor for creating a new MemoryBoard instance
        public MemoryBoard(int rows, int columns, PlayerModel player1, PlayerModel player2)
        {
            // Set the number of rows and columns
            Rows = rows;
            Columns = columns;

            // Set the player models and their initial properties
            Playermodel1 = player1;
            Playermodel2 = player2;
            Playermodel1.IsActive = true;
            Playermodel2.IsActive = false;
            Playermodel1.Score = 0;
            Playermodel2.Score = 0;
            Playermodel1.Elapsed = 0f;
            Playermodel2.Elapsed = 0f;

            // Create lists for storing the tiles
            Tiles = new List<Tile>();
            PreviewingTiles = new List<Tile>();

            // Create tiles for the game board
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Tiles.Add(new Tile(i, j, this));
                }
            }

            // Assign memory cards and their IDs to the tiles
            AssignMemoryCards();
            AssignMemoryCardIds();

            // Shuffle the tiles
            ExtensionMethods.Shuffle(Tiles);

            // Set the initial state of the game board to "No Preview"
            State = new BoardNoPreviewState(this);
        }

        // Assign unique memory card IDs to each tile
        private void AssignMemoryCardIds()
        {
            // Get the instance of the ImageRepository
            ImageRepository repo = ImageRepository.Instance;

            // Process the image IDs and assign them to the memory cards
            repo.ProcessImageIds(AssignMemoryCardIds);
        }

        // Assign unique memory card IDs to each tile based on the available memory card IDs
        private void AssignMemoryCardIds(List<int> memoryCardIds)
        {
            // Shuffle the memory card IDs
            memoryCardIds = memoryCardIds.Shuffle();

            // Shuffle the tiles
            List<Tile> shuffledTiles = Tiles.Shuffle();

            int memoryCardIndex = 0;
            bool first = true;

            foreach (Tile tile in shuffledTiles)
            {
                tile.MemoryCardId = memoryCardIds[memoryCardIndex];
                if (first)
                    first = false;
                else
                {
                    memoryCardIndex++;
                    first = true;
                }
            }
        }

        // Assign memory cards to each tile
        private void AssignMemoryCards()
        {
            for (int i = 0; i < Tiles.Count - 1; i++)
            {
                Tiles[i].MemoryCardId = i / 2;
            }
        }

        public override string ToString()
        {
            return $"MemoryBoard({Rows},{Columns})";
        }
    }
}
