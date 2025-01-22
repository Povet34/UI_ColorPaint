using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChannelEditPanel : MonoBehaviour
{
    public struct Data
    {
        public int channelIndex;
        public List<Color32> colors;
        public Action<List<Color32>> repaintCallback;
    }


    public static bool Test;

    [SerializeField] SummationView summationView;
    [SerializeField] PaintArea paintArea;
    [SerializeField] Palette palette;

    [SerializeField] Button saveButton;
    [SerializeField] Button cancelButton;

    Action<List<Color32>> repaintCallback;

    int channelIndex;

    private void Awake()
    {
        saveButton.onClick.AddListener(SaveEdit);
        cancelButton.onClick.AddListener(CancelEdit);
    }

    private void CancelEdit()
    {
    }

    private void SaveEdit()
    {
        List<Color32> colors = summationView.GetColors();
        List<PaletteColor> paletteColors = palette.GetPaletteColors();

        SummationChannel.ChannelData channelData = new SummationChannel.ChannelData();
        channelData.channelIndex = channelIndex;
        channelData.colors = colors;
        channelData.paletteColors = paletteColors;

        string json = JsonUtility.ToJson(channelData);
        Debug.Log(json);

        string path = Application.persistentDataPath + "/channel" + channelIndex + ".json";
        System.IO.File.WriteAllText(path, json);

        paintArea.DestroyAll();
        gameObject.SetActive(false);

        repaintCallback?.Invoke(colors);
    }

    public void StartEdit(Data data)
    {
        gameObject.SetActive(true);
        channelIndex = data.channelIndex;
        paintArea.EditStart(data.colors);

        repaintCallback = data.repaintCallback;
    }
}
