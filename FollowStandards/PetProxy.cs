using System.Net;

public class PetProxy
{
    const string baseUrl = "https://petstore.swagger.io/v2";
    static HttpClient client = new HttpClient();

    static public async Task<string> GetPet(int id) 
    { 
        string pet = string.Empty;
        // Call rest api to get the pet
        HttpResponseMessage response = await client.GetAsync( $"{baseUrl}/pet/{id}");
        //handle the response
        if (response.IsSuccessStatusCode)
        {
            pet = await response.Content.ReadAsStringAsync();
        }
        return pet;
    }
}