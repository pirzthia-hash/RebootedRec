using System;
using System.IO;
using System.Net.Http;
using System.Threading;

namespace start
{
    class Setup
    {
        public static bool firsttime = false;
        private static readonly HttpClient client = new HttpClient();

        public static void setup()
        {
            Console.WriteLine("Setting up... Validating directory layout.");

            // Standard storage setup
            Directory.CreateDirectory("SaveData\\App\\");
            Directory.CreateDirectory("SaveData\\Profile\\");
            Directory.CreateDirectory("SaveData\\Images\\");
            Directory.CreateDirectory("SaveData\\Rooms\\Downloaded\\");

            if (!File.Exists("SaveData\\App\\firsttime.txt"))
            {
                File.WriteAllText("SaveData\\App\\firsttime.txt", "Initialization verified.");
                firsttime = true;
            }

            // High-priority text asset retrieval
            DownloadTextIfMissing("SaveData\\avatar.txt", "https://githubusercontent.com", checkEmpty: true);
            DownloadTextIfMissing("SaveData\\avataritems.txt", "https://githubusercontent.com");
            DownloadTextIfMissing("SaveData\\avataritems2.txt", "https://githubusercontent.com");
            DownloadTextIfMissing("SaveData\\equipment.txt", "https://githubusercontent.com");
            DownloadTextIfMissing("SaveData\\consumables.txt", "https://githubusercontent.com");
            DownloadTextIfMissing("SaveData\\gameconfigs.txt", "https://githubusercontent.com");
            DownloadTextIfMissing("SaveData\\storefronts2.txt", "https://githubusercontent.com");
            DownloadTextIfMissing("SaveData\\baserooms.txt", "https://githubusercontent.com");
            DownloadTextIfMissing("SaveData\\App\\facefeaturesadd.txt", "https://githubusercontent.com");
            DownloadBytesIfMissing("SaveData\\profileimage.png", "https://github.com");

            // Profile creation
            if (!File.Exists("SaveData\\Profile\\username.txt"))
            {
                File.WriteAllText("SaveData\\Profile\\username.txt", $"OpenRec User#{Random.Shared.Next(0, 1000000)}");
            }
            if (!File.Exists("SaveData\\Profile\\level.txt"))
            {
                File.WriteAllText("SaveData\\Profile\\level.txt", "10");
            }
            if (!File.Exists("SaveData\\Profile\\userid.txt"))
            {
                File.WriteAllText("SaveData\\Profile\\userid.txt", "10000000");
            }

            // Defaults config fallbacks
            if (!File.Exists("SaveData\\myrooms.txt"))
            {
                File.WriteAllText("SaveData\\myrooms.txt", "[]");
            }
            if (!File.Exists("SaveData\\settings.txt"))
            {
                string configData = Newtonsoft.Json.JsonConvert.SerializeObject(api.Settings.CreateDefaultSettings());
                File.WriteAllText("SaveData\\settings.txt", configData);
            }
            if (!File.Exists("SaveData\\App\\privaterooms.txt"))
            {
                File.WriteAllText("SaveData\\App\\privaterooms.txt", "Disabled");
            }
            if (!File.Exists("SaveData\\App\\showopenrecinfo.txt"))
            {
                File.WriteAllText("SaveData\\App\\showopenrecinfo.txt", "Enabled");
            }

            // Custom rooms handshake loop
            int customRoomAttempts = 0;
            while (!File.Exists("SaveData\\Rooms\\Downloaded\\roomname.txt"))
            {
                customRoomAttempts++;
                Console.WriteLine($"[API Checking] Matching custom configuration index (Pass: {customRoomAttempts})...");
                try
                {
                    api.CustomRooms.RoomGet("gogo9");
                    break;
                }
                catch
                {
                    if (customRoomAttempts >= 3)
                    {
                        Console.WriteLine("[Skip] Local custom configuration index unavailable.");
                        break;
                    }
                    Thread.Sleep(2000);
                }
            }

            Console.WriteLine("Done! Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        private static void DownloadTextIfMissing(string path, string url, bool checkEmpty = false)
        {
            if (!File.Exists(path) || (checkEmpty && new FileInfo(path).Length == 0))
            {
                Console.WriteLine($"[Downloading] -> {Path.GetFileName(path)}");
                try
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                    {
                        // Explicit message header generation blocks GitHub 403 safety triggers
                        request.Headers.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                        
                        using (var response = client.Send(request))
                        {
                            response.EnsureSuccessStatusCode();
                            string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                            File.WriteAllText(path, data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error] Could not save {Path.GetFileName(path)}: {ex.Message}");
                }
            }
        }

        private static void DownloadBytesIfMissing(string path, string url)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"[Downloading Image] -> {Path.GetFileName(path)}");
                try
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                    {
                        request.Headers.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                        
                        using (var response = client.Send(request))
                        {
                            response.EnsureSuccessStatusCode();
                            byte[] data = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                            File.WriteAllBytes(path, data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error] Could not save {Path.GetFileName(path)}: {ex.Message}");
                }
            }
        }
    }
}