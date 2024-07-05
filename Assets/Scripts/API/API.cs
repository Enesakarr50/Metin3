using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class API : MonoBehaviour
{
    private string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJrZXkiOiI2YzIxMDQxNy0wYWE5LTQ2OGMtYjM4Yy1lMmU1YTQ5ZjhmY2UiLCJzdWIiOiIxMTk0YmUzNS01NzQyLTQ5MjQtYjQ4NS05Njk0NDBjYjdiZWEiLCJpYXQiOjE3MjAxNzU2MTd9.f8BUQs7misWIM24AQW2wEIiADHkaCKRs4nWC3WSorcA";
    private string baseUrl = "https://api.gameshift.io/";

    // �rnek GET iste�i
    public IEnumerator GetPlayerData(string playerId)
    {
        string url = $"{baseUrl}players/{playerId}";
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("Authorization", $"Bearer {apiKey}");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            // JSON verisini parse edin ve kullan�n
        }
    }

    // �rnek POST iste�i
    public IEnumerator PostPlayerScore(string playerId, int score)
    {
        string url = $"{baseUrl}players/{playerId}/score";
        WWWForm form = new WWWForm();
        form.AddField("score", score);

        UnityWebRequest request = UnityWebRequest.Post(url, form);
        request.SetRequestHeader("Authorization", $"Bearer {apiKey}");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            // Yan�t verisini i�leyin
        }
    }
    void Start()
    {
        StartCoroutine(GetPlayerData("player123"));
    }
    void UpdateScore()
    {
        StartCoroutine(PostPlayerScore("player123", 100));
    }

}