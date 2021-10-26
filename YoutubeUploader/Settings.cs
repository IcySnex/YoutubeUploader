using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace YoutubeUploader
{
    class Settings
    {
        public static j_settings value = Load();
        public static j_settings Load() { return File.Exists("settings.json") ? JsonConvert.DeserializeObject<j_settings>(File.ReadAllText("settings.json")) : new j_settings(); }
        public static void Save() => File.WriteAllTextAsync("settings.json", JsonConvert.SerializeObject(value));
    }

    public class j_settings
    {
        public string user = "Default";
        public List<string> users = new List<string>();
        public bool fluentqueue = false;
        public j_detials details = new j_detials();
    }

    public class j_detials
    {
        public string title = "";
        public string description = "";
        public string tags = "";
        public int privacy = 0;
        public string thumbnail = "";
        public string playlist = "";
        public List<j_stropt> stropt_title = new List<j_stropt>();
        public List<j_stropt> stropt_description = new List<j_stropt>();
        public List<j_stropt> stropt_tags = new List<j_stropt>();
        public List<j_stropt> stropt_thumbnail = new List<j_stropt>();
    }

    public class j_stropt
    {
        public string replacement = "{replacement}";
        public string start = "0";
        public string lenght = "1";
    }
}
