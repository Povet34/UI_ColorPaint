using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PaletteColor : MonoBehaviour, IPointerDownHandler
{
    Image paletteColor;
    Brush brush;

    private void Awake()
    {
        paletteColor = GetComponent<Image>();
        SetBrush();
    }

    public void SetColor(Color color)
    {
        paletteColor.color = color;
    }

    private void SetBrush()
    {
        if (!brush)
            brush = FindAnyObjectByType<Brush>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        brush.SetBrushColor(paletteColor.color);
    }
}
