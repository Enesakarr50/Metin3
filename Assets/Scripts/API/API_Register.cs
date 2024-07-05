using UnityEngine;
using RestSharp;
using System.Threading.Tasks;
using TMPro;

public class API_Register : MonoBehaviour
{
    private RestClient client;
    public TextMeshProUGUI NameInp;
    public TextMeshProUGUI MailInp;
    private string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJrZXkiOiI2YzIxMDQxNy0wYWE5LTQ2OGMtYjM4Yy1lMmU1YTQ5ZjhmY2UiLCJzdWIiOiIxMTk0YmUzNS01NzQyLTQ5MjQtYjQ4NS05Njk0NDBjYjdiZWEiLCJpYXQiOjE3MjAxNzU2MTd9.f8BUQs7misWIM24AQW2wEIiADHkaCKRs4nWC3WSorcA";
    private string url = "https://api.gameshift.dev/nx/users";

    void Start()
    {
        var options = new RestClientOptions(url);
        client = new RestClient(options);
    }

    public async Task PostUserData(string referenceId, string email)
    {
        var request = new RestRequest("", Method.Post);
        request.AddHeader("accept", "application/json");
        request.AddHeader("x-api-key", apiKey);

        var body = new { referenceId = referenceId, email = email };
        request.AddJsonBody(body);

        var response = await client.ExecuteAsync(request);

        if (response.IsSuccessful)
        {
            Debug.Log("Success: " + response.Content);
        }
        else
        {
            Debug.LogError($"Error: {response.ErrorMessage}\nStatus Code: {response.StatusCode}\nContent: {response.Content}");
        }
    }

    public void OnSendButtonClick()
    {
        // Giriþ alanlarýndan verileri al
        string _name = NameInp.text;
        string _mail = MailInp.text;

        // PostUserData metodunu çaðýr
        PostUserData(_name, _mail).ConfigureAwait(false);
    }
}
