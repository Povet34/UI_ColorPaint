using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChannelEditPanel : MonoBehaviour
{
    public static bool Test;

    [SerializeField] SummationView summationView;
    [SerializeField] PaintArea paintArea;
    [SerializeField] Palette palette;

    [SerializeField] Button saveButton;
    [SerializeField] Button cancelButton;

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
        List<Color> colors = summationView.GetColors();
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
    }

    public void StartEdit(int channelIndex, List<Color> colors)
    {
        gameObject.SetActive(true);
        this.channelIndex = channelIndex;
        paintArea.EditStart(colors);
    }
}
