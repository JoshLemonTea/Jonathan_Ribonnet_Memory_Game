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
            get
            {
                return _elapsed;
            }

            set
            {
                if (_elapsed == value) return;
                _elapsed = value;
                OnPropertyChanged();
            }
        }

        private float _mm;
        public float Mm
        {
            get
            {
                return (int) (Elapsed / 60);
            }

            set
            {
                if (_mm == value) return;
                _mm = value;
                OnPropertyChanged();
            }
        }

        private float _ss;
        public float Ss
        {
            get
            {
                return (int)(Elapsed % 60);
            }

            set
            {
                if (_ss == value) return;
                _ss = value;
                OnPropertyChanged();
            }
        }

        private float _ms;
        public float Ms
        {
            get
            {
                return (int)((Elapsed % 1) * 1000);
            }

            set
            {
                if (_ms == value) return;
                _ms = value;
                OnPropertyChanged();
            }
        }

        public PlayerModel(string name, bool isactive)
        {
            Name = name;
            Score = 0;
            IsActive = isactive;

        }

    }


}

