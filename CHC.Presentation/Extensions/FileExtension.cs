using Newtonsoft.Json;
using NuGet.Packaging;

namespace CHC.Presentation.Extensions
{
    public static class FileExtension<T> where T : class
    {
        public static List<T> LoadJson(string path, string f)
        {
            List<T> list = new List<T>();
            using (StreamReader r = new StreamReader(path + f))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(json)!;
            }
        }
    }
}
