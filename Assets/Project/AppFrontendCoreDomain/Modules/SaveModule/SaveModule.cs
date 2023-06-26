using UnityEngine;

namespace Project.AppFrontendCoreDomain.Modules
{
    public class SaveModule : ISaveModule
    {
        public bool TryGet<T>(string key, out T data)
        {
            data = default(T);
            var dataStr = PlayerPrefs.GetString(key);
            if (dataStr != null)
            {
                data = JsonUtility.FromJson<T>(dataStr);
                return data != null;
            }

            return false;
        }

        public void Set<T>(string key, T data)
        {
            PlayerPrefs.SetString(key, JsonUtility.ToJson(data));
            PlayerPrefs.Save();
        }
    }
}