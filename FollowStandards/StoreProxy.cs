using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

public class StoreProxy
{
    const string baseUrl = "https://petstore.swagger.io/v2";
    static HttpClient client = new HttpClient();

    static public async Task<string> GetOrder(int id)
    {
        string order = string.Empty;

        // Call rest api to get the user based on name
        HttpResponseMessage response = await client.GetAsync( $"{baseUrl}/store/order/{id}");
        //Handle response
        if (response.StatusCode != HttpStatusCode.OK)
        {
            string errorMessage = $"Bad news :-( There was an error trying to the the user with id {id}. The status code returned was: {response.StatusCode}";
            Console.WriteLine(errorMessage);
            throw new Exception(errorMessage);
        }

        order = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Found and returned the user with id {id}");
        return order;
    }
}
    







    


    
    