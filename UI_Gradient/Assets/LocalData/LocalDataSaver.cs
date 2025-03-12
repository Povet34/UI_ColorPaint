using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalDataSaver : MonoBehaviour
{
    [SerializeField] Button saveButton;
    [SerializeField] Button loadButton;

    [SerializeField] Text log;

    private Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();

    public class Data
    {
        public string id;
        public List<string> values;
    }

    private void Start()
    {
        saveButton.onClick.AddListener(SaveData);
        loadButton.onClick.AddListener(LoadData);
    }

    private void SaveData()
    {
        List<Data> datas = new List<Data>();
        for (int i = 0; i < 100; i++)
        {
            var data = new Data();
            data.id = i.ToString();
            data.values = new List<string>();
            for (int j = 0; j < 1000; j++)
            {
                data.values.Add(j.ToString() + "Value");
            }

            datas.Add(data);
        }


        var json = JsonConvert.SerializeObject(datas);

        PlayerPrefs.SetString("data", json);
    }

    private void LoadData()
    {
        if(PlayerPrefs.HasKey("data"))
        {
            var json = PlayerPrefs.GetString("data");
            var data = JsonConvert.DeserializeObject<List<Data>>(json);
            System.IO.File.WriteAllText("log.txt", JsonConvert.SerializeObject(data, Formatting.Indented));
        }
    }
}
