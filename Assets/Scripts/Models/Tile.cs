using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models
{
    public class Tile : ModelBaseClass
    {
        private int _row;
        public int Row
        {
            get { return _row; }
            set
            {
                if (_row == value) return;
                _row = value;
                OnPropertyChanged();
            }
        }

        private int _column;
        public int Column
        {
            get { return _column; }
            set
            {
                if (_column == value) return;
                _column = value;
                OnPropertyChanged();
            }
        }

        private int _memoryCardId;
        public int MemoryCardId
        {
            get { return _memoryCardId; }
            set
            {
                if (_memoryCardId == value) return;
                _memoryCardId = value;
                OnPropertyChanged();
            }
        }

        private MemoryBoard _memoryBoard;
        public MemoryBoard MemoryBoard
        {
            get { return _memoryBoard; }
            set
            {
                if (_memoryBoard == value) return;
                _memoryBoard = value;
                OnPropertyChanged();
            }
        }

        private ITileState _state;
        public ITileState State
        {
            get { return _state; }
            set
            {
                if (_state == value) return;
                _state = value;
                OnPropertyChanged();
            }
        }

        public Tile(int row, int column, MemoryBoard memoryBoard)
        {
            Row = row;
            Column = column;
            MemoryBoard = memoryBoard;
            State = new TileHiddenState(this);
        }

        public override string ToString()
        {
            return $"Tile({Row},{Column})";
        }
    }
}
