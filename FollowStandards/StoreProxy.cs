using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
public interface IStoreProxy
{
    Task<string> GetOrder(int id);
}

public class StoreProxy : IStoreProxy
{
    const string baseUrl = "https://petstore.swagger.io/v2";
    static HttpClient client = new HttpClient();

    public async Task<string> GetOrder(int id)
    {
        string order = string.Empty;

        // Call rest api to get the user based on name
        HttpResponseMessage response = await client.GetAsync($"{baseUrl}/store/order/{id}");

        // Check if the response is successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content
            order = await response.Content.ReadAsStringAsync();
        }

        return order;
    }
}
    







    


    
    