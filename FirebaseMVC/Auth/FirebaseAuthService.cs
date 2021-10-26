using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Configuration;
using GoodCompanyMVC.Auth.Models;

namespace GoodCompanyMVC.Auth
    //handles all interactions with firebase, is injected in services in Startup so it can be injected as dependency here
{
    public class FirebaseAuthService : IFirebaseAuthService
    {
        private const string FIREBASE_SIGN_IN_BASE_URL =
            "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=";
        private const string FIREBASE_SIGN_UP_BASE_URL =
            "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=";

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _firebaseApiKey;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
 //constructor httpClientFactory makes clients for making http requests (comes with  System.Net.Http library)
        public FirebaseAuthService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _firebaseApiKey = configuration.GetValue<string>("FirebaseApiKey");
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        // See firebase documentation for more information, note definition of login URL for use in signup/signin
        //  https://firebase.google.com/docs/reference/rest/auth/#section-sign-in-email-password
        public async Task<FirebaseUser> Login(Credentials credentials)
        {
            var url = FIREBASE_SIGN_IN_BASE_URL + _firebaseApiKey;
            return await SignUpOrSignIn(credentials.Email, credentials.Password, url);
        }

        public async Task<FirebaseUser> Register(Registration registration)
        {
            var url = FIREBASE_SIGN_UP_BASE_URL + _firebaseApiKey;
            return await SignUpOrSignIn(registration.Email, registration.Password, url);
        }
//Task can only be called - everything here strongly typed from http lib
//await is like .then in function call
        private async Task<FirebaseUser> SignUpOrSignIn(string email, string password, string url)
        {
            //make new instance of fbreq
            var firebaseRequest = new FirebaseRequest(email, password);
            //make new instance of httpreq
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            //serialize into json
            request.Content = new StringContent(
                JsonSerializer.Serialize(firebaseRequest, _jsonSerializerOptions),
                Encoding.UTF8,
                "application/json");

            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            var firebaseResponse =
                JsonSerializer.Deserialize<FirebaseResponse>(content, _jsonSerializerOptions);
//if no localId, add new user (using constructor in model)
            return firebaseResponse.LocalId != null
                ? new FirebaseUser(firebaseResponse.Email, firebaseResponse.LocalId)
                : null;
        }
    }
}
