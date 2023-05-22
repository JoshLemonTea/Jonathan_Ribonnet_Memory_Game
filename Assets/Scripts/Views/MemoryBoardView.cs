using Memory.Models;
using Memory.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Memory.Views
{

    public class MemoryBoardView : ViewBaseClass<MemoryBoard>
    {
        [SerializeField] private float _tileSpacing = 0.2f;
        [SerializeField] private float sizeX = 1;
        [SerializeField] private float sizey = 1;

        public MemoryBoardView()
        {
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public void SetUpMemoryBoardView(MemoryBoard model, GameObject Tileprefab, /*Material[] mats*/ PlayerView player1View, PlayerView player2View)
        {
            for (int i = 0; i < model.Tiles.Count; i++)
            {
                var offsetX = -((model.Tiles[i].Column / 2f - 0.5f) + _tileSpacing) * sizeX;
                var offsety = -((model.Tiles[i].Row / 2f - 0.5f) + _tileSpacing) * sizey;

                var tile = Instantiate(Tileprefab, new Vector3(/*model.Tiles[i].Row */ offsetX, sizeX/4f,/* model.Tiles[i].Column*/  offsety), Tileprefab.transform.rotation, this.gameObject.transform);
                                

                tile.GetComponent<TileView>().Model = model.Tiles[i];

                //tile.transform.GetChild(0).GetComponent<MeshRenderer>().material = mats[model.Tiles[i].MemoryCardId];
            }

            player1View.Model = model.Playermodel1;
            player2View.Model = model.Playermodel2;



        }
    }
}
