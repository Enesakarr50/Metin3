using UnityEngine;
using RestSharp;
using System;
using System.Threading.Tasks;

public class API_GetItem : MonoBehaviour
{
    private RestClient client;
    public API_Register apiR;
    private string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJrZXkiOiI2YzIxMDQxNy0wYWE5LTQ2OGMtYjM4Yy1lMmU1YTQ5ZjhmY2UiLCJzdWIiOiIxMTk0YmUzNS01NzQyLTQ5MjQtYjQ4NS05Njk0NDBjYjdiZWEiLCJpYXQiOjE3MjAxNzU2MTd9.f8BUQs7misWIM24AQW2wEIiADHkaCKRs4nWC3WSorcA";
    private string baseUrl = "https://api.gameshift.dev/nx/users";

    void Start()
    {
        // Initialize the RestClient with base URL
        client = new RestClient(baseUrl);
    }

    public async Task GetItemData(string referenceId, string itemId)
    {
        // Construct the full request URL with dynamic referenceId and itemId
        string requestUrl = $"{baseUrl}/{referenceId}/items/{itemId}";

        // Create a new RestRequest with the constructed URL
        var request = new RestRequest(requestUrl, Method.Get);

        // Add headers
        request.AddHeader("accept", "application/json");
        request.AddHeader("x-api-key", apiKey);

        try
        {
            // Execute the request asynchronously
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                Debug.Log($"Response Content: {response.Content}");
            }
            else
            {
                Debug.LogError($"Error: {response.ErrorMessage}\nStatus Code: {response.StatusCode}\nContent: {response.Content}");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Exception occurred: {ex.Message}");
        }
    }

    public void OnGetItemButtonClick()
    {
        // Example usage: Replace 'yourReferenceId' and 'yourItemId' with actual values
        string referenceId = apiR.name;
        string itemId = "yourItemId";

        // Call the GetItemData method with dynamic values
        GetItemData(referenceId, itemId).ConfigureAwait(false);
    }
}
