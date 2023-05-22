using Memory.Data;
using Memory.Models.States;
using Memory.Scripts.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Memory.Models
{
    public class MemoryBoard : ModelBaseClass
    {

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

        private bool _isCombinationFound;

        public bool IsCombinationFound
        {
            get
            {
                return _isCombinationFound;
                //if 2 tiles with same image found return true;
            }

        }

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

        public MemoryBoard(int rows, int columns, PlayerModel player1, PlayerModel player2)
        {
            Rows = rows;
            Columns = columns;
            Playermodel1 = player1;
            Playermodel2 = player2;

            Playermodel1.IsActive = true;
            Playermodel2.IsActive = false;

            Playermodel1.Score = 0;
            Playermodel2.Score = 0;

            Playermodel1.Elapsed = 0f;
            Playermodel2.Elapsed = 0f;


            Tiles = new List<Tile>();
            PreviewingTiles = new List<Tile>();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Tiles.Add(new Tile(i, j, this));
                }
            }

            //AssignMemoryCards();
            AssignMemoryCardIds();

            //ExtensionMethods.Shuffle(Tiles);

            State = new BoardNoPreviewState(this);
        }

        private void AssignMemoryCardIds()
        {
            ImageRepository repo = ImageRepository.Instance;

            repo.ProcessImageIds(AssignMemoryCardIds);
        }

        private void AssignMemoryCardIds(List<int> memoryCardIds)
        {
            // List<int> memoryCardIds = Enumerable.Range(0, (Tiles.Count + 1) / 2).ToList().Shuffle();

            memoryCardIds = memoryCardIds.Shuffle();
            List<Tile> shuffledTiles = Tiles.Shuffle();
            int memoryCardIndex = 0;
            Boolean first = true;

            foreach(Tile tile in shuffledTiles)
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


