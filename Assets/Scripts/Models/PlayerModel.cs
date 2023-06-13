using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models
{
    public class PlayerModel : ModelBaseClass
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        private int _score;
        public int Score
        {
            get { return _score; }
            set
            {
                if (_score == value) return;
                _score = value;
                OnPropertyChanged();
            }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive == value) return;
                _isActive = value;
                OnPropertyChanged();
            }
        }

        private float _elapsed;
        public float Elapsed
        {
            get { return _elapsed; }
            set
            {
                if (_elapsed == value) return;
                _elapsed = value;
                OnPropertyChanged();
            }
        }

        public PlayerModel(string name, bool isActive)
        {
            Name = name;
            Score = 0;
            IsActive = isActive;
            Elapsed = 0f;
        }
    }

}

