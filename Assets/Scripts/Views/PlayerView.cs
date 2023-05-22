using Memory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Memory.Views
{
    public class PlayerView : ViewBaseClass<PlayerModel>
    {
        [SerializeField] private CanvasGroup _playerText;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _ElapsedTime;

        public PlayerView()
        {


        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(Model.IsActive)))
            {
                if (_playerText.alpha == 0.5f)
                {
                    _playerText.alpha = 1f;
                }
                else
                {
                    _playerText.alpha = 0.5f;
                }
            }
            if (e.PropertyName.Equals(nameof(Model.Score)))
            {
                _scoreText.text = Model.Score.ToString();
            }
            if (e.PropertyName.Equals(nameof(Model.Elapsed)))
            {
                _ElapsedTime.text = Model.Elapsed.ToString();
            }
        }

        private void Update()
        {
            if (Model.IsActive)
                Model.Elapsed += Time.deltaTime;

        }

    }
}
