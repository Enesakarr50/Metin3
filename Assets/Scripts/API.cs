using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

public class API : MonoBehaviour
{
    
    void Start()
    {
        // A correct website page.
        StartCoroutine(GetRequest("https://dummy.restapiexample.com/api/v1/employee/1"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            Debug.Log( ":\nReceived:" + webRequest.downloadHandler.text);
        }
    }
}

    


