using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Memory.Data
{
    public class ImageRepository : Singleton<ImageRepository>
    {
        private string urlMemoryImages = "http://www.pd4memorygame.edu/memoryWebService/api/image";

        public void ProcessImageIds(Action<List<int>> processIds)
        {
            StartCoroutine(GetImageIds(processIds));
        }

        private IEnumerator GetImageIds(Action<List<int>> processIds)
        {
            UnityWebRequest uwrids = UnityWebRequest.Get(urlMemoryImages);
            yield return uwrids.SendWebRequest();

            if (uwrids.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("ImageRepository.GetImageIds: " + uwrids.error);
            }
            else
            {
                string json = uwrids.downloadHandler.text;
                List<DBImage> images = JsonConvert.DeserializeObject<List<DBImage>>(json);
                images = images.Where(i => !i.IsBack).ToList();
                List<int> imagedbids = images.Select(i => i.Id).ToList();
                processIds(imagedbids);
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
