using Memory.Models; // Import the Memory.Models namespace
using Memory.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Memory.Views
{
    public class MemoryBoardView : ViewBaseClass<MemoryBoard>
    {
        [SerializeField] private float _tileSpacing = 0.2f; // The spacing between tiles
        [SerializeField] private float sizeX = 1; // The size of the tiles along the X-axis
        [SerializeField] private float sizey = 1; // The size of the tiles along the Y-axis

        public MemoryBoardView()
        {
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public void SetUpMemoryBoardView(MemoryBoard model, GameObject Tileprefab, Material[] mats, PlayerView player1View, PlayerView player2View)
        {
            // Set up the view for the memory board

            for (int i = 0; i < model.Tiles.Count; i++)
            {
                // Calculate the position of the tile based on its row and column

                var offsetX = -((model.Tiles[i].Column / 2f - 0.5f) + _tileSpacing) * sizeX; // Calculate the X-offset
                var offsety = -((model.Tiles[i].Row / 2f - 0.5f) + _tileSpacing) * sizey; // Calculate the Y-offset

                // Instantiate a tile prefab at the calculated position
                var tile = Instantiate(Tileprefab, new Vector3(offsetX, sizeX / 4f, offsety), Tileprefab.transform.rotation, this.gameObject.transform);

                tile.GetComponent<TileView>().Model = model.Tiles[i]; // Set the model of the tile view

                tile.transform.GetChild(0).GetComponent<MeshRenderer>().material = mats[model.Tiles[i].MemoryCardId]; // Assign the material to the tile
            }

            // Set the models of the player views
            player1View.Model = model.Playermodel1;
            player2View.Model = model.Playermodel2;
        }
    }
}
