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
        // URL for retrieving memory images from the web service
        string urlMemoryImages = "https://localhost:44314/api/Memory";

        // Method for processing image IDs and invoking a callback action
        public void ProcessImageIds(Action<List<int>> processIds)
        {
            StartCoroutine(GetImageIDs(processIds));
        }

        // Coroutine for retrieving image IDs from the web service
        private IEnumerator GetImageIDs(Action<List<int>> processIds)
        {
            UnityWebRequest uwrids = UnityWebRequest.Get(urlMemoryImages);
            yield return uwrids.SendWebRequest();

            if (uwrids.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("imageRepository.GetImageIDs : " + uwrids.error);
            }
            else
            {
                // Retrieve the response JSON and deserialize it into a list of DBImage objects
                string json = uwrids.downloadHandler.text;
                List<DBImage> images = JsonConvert.DeserializeObject<List<DBImage>>(json);

                // Convert the list of DBImage objects into a list of image IDs
                List<int> imageIds = images.Select(i => i.Id).ToList();

                // Invoke the callback action with the processed image IDs
                processIds(imageIds);
            }
        }

        // Method for retrieving and processing a texture based on an image ID
        public void GetProcessTexture(int imgdbid, Action<Texture2D> processTexture)
        {
            StartCoroutine(GetTextures(imgdbid, processTexture));
        }

        // Coroutine for retrieving a texture from the web service and invoking a callback action
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
                // Retrieve the downloaded texture
                Texture2D texture = DownloadHandlerTexture.GetContent(uwr);

                // Invoke the callback action with the processed texture
                processTexture(texture);
            }
        }
    }
}
