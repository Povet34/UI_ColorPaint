using System.Collections.Generic;
using UnityEngine;

public class Palette : MonoBehaviour
{
    readonly Color[] colors = new Color[]
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.cyan,
        Color.magenta,
        Color.black,
        Color.white,
        Color.gray
    };

    [SerializeField] PaletteColor paletteColorPrefab;

    List<PaletteColor> paletteColors = new List<PaletteColor>();
 
    private void Start()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            PaletteColor paletteColor = Instantiate(paletteColorPrefab, transform);
            paletteColor.SetColor(colors[i]);

            paletteColors.Add(paletteColor);
        }
    }
}
