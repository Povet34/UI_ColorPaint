using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummationView : MonoBehaviour
{
    public struct RegionPaint
    {
        public int startIndex;
        public int endIndex;
        public Color color;
    }

    public struct AllColor
    {
        public List<Color> colors;
    }


    RawImage viewImage;
    List<Color> colors;

    private void Start()
    {
        viewImage = GetComponent<RawImage>();
    }

    public void SetupColors(AllColor colors)
    {
        UpdateView(colors);
    }

    public void UpdateView(RegionPaint data)
    {
        if (colors == null || colors.Count == 0)
        {
            Debug.LogWarning("Colors list is not initialized or empty.");
            return;
        }

        for (int i = data.startIndex; i <= data.endIndex; i++)
        {
            if (i >= 0 && i < colors.Count)
            {
                colors[i] = data.color;
            }
        }

        viewImage.texture = CreateColorArrayTexture(colors);
    }

    public void UpdateView(AllColor data)
    {
        colors = data.colors;
        viewImage.texture = CreateColorArrayTexture(colors);
    }

    Texture2D CreateColorArrayTexture(List<Color> colors)
    {
        int length = colors.Count;
        Texture2D texture = new Texture2D(length, 1, TextureFormat.RGBA32, false);
        for (int i = 0; i < colors.Count; i++)
        {
            texture.SetPixel(i, 0, colors[i]);
        }
        texture.Apply();
        return texture;
    }
}
