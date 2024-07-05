using UnityEngine;
using RestSharp;
using System.Threading.Tasks;

public class API_AddUniqueAsset : MonoBehaviour
{
    private RestClient client;
    private string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJrZXkiOiI2YzIxMDQxNy0wYWE5LTQ2OGMtYjM4Yy1lMmU1YTQ5ZjhmY2UiLCJzdWIiOiIxMTk0YmUzNS01NzQyLTQ5MjQtYjQ4NS05Njk0NDBjYjdiZWEiLCJpYXQiOjE3MjAxNzU2MTd9.f8BUQs7misWIM24AQW2wEIiADHkaCKRs4nWC3WSorcA"; // Replace with your actual API key
    private string baseUrl = "https://api.gameshift.dev/nx/unique-assets"; // Endpoint for adding unique assets
    public API_Register apr;

    void Start()
    {
        client = new RestClient(baseUrl);
    }

    public async Task AddUniqueAsset(string destinationUserReferenceId)
    {
        var request = new RestRequest("", Method.Post);
        request.AddHeader("accept", "application/json");
        request.AddHeader("x-api-key", apiKey);

        // Example JSON body with destination user reference ID
        var body = new
        {
            destinationUserReferenceId = destinationUserReferenceId
        };
        request.AddJsonBody(body);

        try
        {
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                Debug.Log($"Asset added successfully: {response.Content}");
            }
            else
            {
                Debug.LogError($"Error: {response.ErrorMessage}\nStatus Code: {response.StatusCode}\nContent: {response.Content}");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Exception occurred: {ex.Message}");
        }
    }

    public void OnAddAssetClick()
    {
        // Example usage: Replace '1' with actual destination user reference ID
        string destinationUserReferenceId = apr.name;

        AddUniqueAsset(destinationUserReferenceId).ConfigureAwait(false);
    }
}