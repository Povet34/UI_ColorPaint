using System.Collections.Generic;
using UnityEngine;

public class Palette : MonoBehaviour
{
    public readonly Color[] Colors = new Color[]
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
        for (int i = 0; i < Colors.Length; i++)
        {
            PaletteColor paletteColor = Instantiate(paletteColorPrefab, transform);
            paletteColor.SetColor(Colors[i]);

            paletteColors.Add(paletteColor);
        }
    }
}
