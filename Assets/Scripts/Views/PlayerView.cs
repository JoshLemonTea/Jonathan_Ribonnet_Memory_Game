using Memory.Models; // Import the Memory.Models namespace
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
        [SerializeField] private CanvasGroup _playerText; // The canvas group for the player text
        [SerializeField] private Text _scoreText; // The text component for displaying the score
        [SerializeField] private Text _ElapsedTime; // The text component for displaying the elapsed time

        public PlayerView()
        {

        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Handle property changes in the player model

            if (e.PropertyName.Equals(nameof(Model.IsActive)))
            {
                // If the IsActive property changes, toggle the alpha value of the player text

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
                // If the Score property changes, update the score text

                _scoreText.text = Model.Score.ToString();
            }
            if (e.PropertyName.Equals(nameof(Model.Elapsed)))
            {
                // If the Elapsed property changes, update the elapsed time text

                _ElapsedTime.text = Model.Elapsed.ToString();
            }
            
        }

        private void Update()
        {
            // Update the elapsed time if the player is active

            if (Model.IsActive)
                Model.Elapsed += Time.deltaTime;
        }

    }
}
