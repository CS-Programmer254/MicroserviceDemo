using Notification.Microservice.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Notification.Microservice.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        public NotificationService (HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<bool> SendNotificationAsync(string fromPhoneNumber, string toPhoneNumber, string messageBody)
        {
            var requestBody = new
            {
                messages = new[]
                {
                    new
                    {
                        fromPhoneNumber,
                        destinations = new[]
                        {
                            new { toPhoneNumber }
                        },
                        messageBody
                    }
                }
            };

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/sms/2/text/advanced")
            {
                Headers =
                {
                    { "Authorization", $"App {_apiKey}" },
                    { "Content-Type", "application/json" }
                },
                Content = JsonContent.Create(requestBody)
            };

            var response = await _httpClient.SendAsync(requestMessage);
            return response.IsSuccessStatusCode;

        }

    }
    
}
