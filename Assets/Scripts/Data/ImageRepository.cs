using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Memory.Models; // Assuming 'DBImage' is defined in the 'Memory.Models' namespace


namespace Memory.Data
{
    class ImageRepository : Singleton<ImageRepository>
    {
        private MemoryContext dbContext; // Entity Framework DbContext

        public ImageRepository()
        {
            dbContext = new MemoryContext();
        }

        // Method for processing image IDs and invoking a callback action
        public void ProcessImageIds(Action<List<int>> processIds)
        {
            List<int> imageIds = dbContext.Images.Select(i => i.Id).ToList();
            processIds(imageIds);
        }

        // Method for retrieving and processing a texture based on an image ID
        public void GetProcessTexture(int imgdbid, Action<Texture2D> processTexture)
        {
            DBImage image = dbContext.Images.FirstOrDefault(i => i.Id == imgdbid);
            if (image != null)
            {
                StartCoroutine(GetTextureFromURL(image.MemoryImageUrl, processTexture));
            }
            else
            {
                Debug.Log("Image not found in the database.");
            }
        }

        // Coroutine for retrieving a texture from a URL and invoking a callback action
        private IEnumerator GetTextureFromURL(string url, Action<Texture2D> processTexture)
        {
            UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url);
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("ImageRepository.GetTextureFromURL: " + uwr.error);
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
