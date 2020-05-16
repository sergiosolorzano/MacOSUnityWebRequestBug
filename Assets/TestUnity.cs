using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestUnity : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(UserEnteredLoginCredentials());
    }

    IEnumerator UserEnteredLoginCredentials()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();

        formData.Add(new MultipartFormDataSection("thisUserHere", "Hello There!", "text/plain"));

        UnityWebRequest www = UnityWebRequest.Post("https://artfunctionlogin.azurewebsites.net/api/TestUnityBug?code=ay3zm2VpeCLeE2PqPUtthdaLNrIY48qSpoWIA5Al4eG9Wr1o70k39w==", formData);
        {
            www.downloadHandler = new DownloadHandlerBuffer();

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                www.Abort();
                www.Dispose();
                Debug.Log("Http Error Request !!");
                yield break;
            }
            else
            {
                string queryResult = www.downloadHandler.text;
                Debug.Log(queryResult);
            }
        }
    }
}

