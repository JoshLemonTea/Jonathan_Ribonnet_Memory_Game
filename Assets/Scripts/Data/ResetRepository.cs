using UnityEngine;
using UnityEngine.UI;
using Memory.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class ResetRepository : MonoBehaviour
{
    private string urlMemoryReset = "http://www.pd4memorygame.edu/memoryWebService/api/memoryreset"; // Update with the correct URL

    private void Start()
    {
        // Attach the button click event
        Button button = GetComponent<Button>();
        button.onClick.AddListener(RequestReset);
    }

    private void RequestReset()
    {
        // Get the current date in the yyyy-MM-dd format
        string currentDate = System.DateTime.Now.ToString("yyyy-MM-dd");

        // Convert the current date to JSON format
        string json = JsonConvert.SerializeObject(currentDate);

        // Send a POST request to the MemoryReset API
        StartCoroutine(SendResetRequest(json));
    }

    private IEnumerator SendResetRequest(string json)
    {
        var www = new UnityEngine.Networking.UnityWebRequest(urlMemoryReset, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        www.uploadHandler = new UnityEngine.Networking.UploadHandlerRaw(jsonToSend);
        www.downloadHandler = new UnityEngine.Networking.DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result != UnityEngine.Networking.UnityWebRequest.Result.Success)
        {
            Debug.Log("ResetButton.SendResetRequest: " + www.error);
        }
        else
        {
            Debug.Log("Reset request successful!");
        }
    }
}
