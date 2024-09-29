using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Azure;
using MediatR;
using Newtonsoft.Json;
using OneSignalApi.Api;
using OneSignalApi.Client;
using OneSignalApi.Model;

namespace WebAPICHATest.Domain.AggregateModels.NotificationAggregate
{
    public class NotificationModel : Entity, IAggregateRoot
    {
        public static async Task SendNotificationAsync()
        {
            //// See https://aka.ms/new-console-template for more information
            //Console.WriteLine("Hello, World!");
            ////Console.ReadLine();
            //// Configure the OneSignal Library
            //Console.WriteLine("notification-0");
            //var appConfig = new Configuration();
            //appConfig.BasePath = "https://onesignal.com/api/v1";
            //appConfig.AccessToken = "N2UyMDI4ZjMtY2QxMS00YWIyLTg4NTMtZTE1Y2RjZGMyOWIy";
            //Console.WriteLine("notification-1");
            //var appInstance = new DefaultApi(appConfig);

            //// Create and send notification to all subscribed users
            //Console.WriteLine("notification-2");
            //var notification = new Notification(appId: "2247a758-2d57-4bff-98dd-6aba60f3f77b")
            //{
            //    Contents = new StringMap(en: "Hello World from .NET!"),
            //    IncludedSegments = new List<string> { "Subscribed Users" }

            //};
            //Console.WriteLine("notification-3");

            //notification.AndroidChannelId = "ef452f92-8dac-44e9-bb37-caeeaa3f6319";
            //Console.WriteLine($"notification.AndroidChannelId: {notification.AndroidChannelId}");
            //var response = await appInstance.CreateNotificationAsync(notification);

            //Console.WriteLine($"Notification created for {response.Recipients} recipients");
            //Console.WriteLine("20");

            Console.WriteLine("Hello, World!");
            using (var client = new HttpClient())
            {
                Console.WriteLine("notification-0");
                var url = new Uri("https://onesignal.com/api/v1/notifications");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "N2UyMDI4ZjMtY2QxMS00YWIyLTg4NTMtZTE1Y2RjZGMyOWIy");
                Console.WriteLine("notification-1");
                var obj = new
                {
                    app_id = "2247a758-2d57-4bff-98dd-6aba60f3f77b",
                    contents = new { en = "Đã có lịch làm việc mới, vui lòng vào kiểm tra!" },
                    included_segments = new string[] { "All" },
                    android_channel_id = "ef452f92-8dac-44e9-bb37-caeeaa3f6319",
                    ic_stat_onesignal_default = "z4413941533678_01041df75ddd576e542981f42fd6c8ab.jpg"
                };
                Console.WriteLine("notification-2");
                var json = JsonConvert.SerializeObject(obj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                Console.WriteLine("notification-3");
            }
        }
    }
}
