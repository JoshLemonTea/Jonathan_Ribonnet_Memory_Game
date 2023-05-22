using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Memory.Data
{
    class ImageRepository : Singleton<ImageRepository>
    {
        //uses project WSGetImages
        string urlMemoryImages = "https://localhost:44314/api/Memory";

        public void ProcessImageIds(Action<List<int>> processIds)
        {
            StartCoroutine(GetImageIDs(processIds));
        }

        private IEnumerator GetImageIDs(Action<List<int>> processIds)
        {
            //system.Random rnd - new System.Random();

            UnityWebRequest uwrids = UnityWebRequest.Get(urlMemoryImages);
            yield return uwrids.SendWebRequest();
            if (uwrids.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("imageRepository.GetImageIDs : " + uwrids.error);
            }
            else
            {
                string json = uwrids.downloadHandler.text;
                List<DBImage> images = JsonConvert.DeserializeObject<List<DBImage>>(json);
                images.ToList();

                List<int> imagebids = images.Select(i => i.Id).ToList();
                processIds(imagebids);
            }
        }

        public void GetProcessTexture(int imgdbid, Action<Texture2D> processTexture)
        {
            StartCoroutine(GetTextures(imgdbid, processTexture));
        }

        private IEnumerator GetTextures(int imgdbid, Action<Texture2D> processTexture)
        {
            UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(urlMemoryImages + "/" + imgdbid);
            yield return uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("ImageRepository.GetProcessMaterials: " + uwr.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(uwr);
                processTexture(texture);
            }
        }
    }
}
