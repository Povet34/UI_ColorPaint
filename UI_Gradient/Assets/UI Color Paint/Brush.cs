using UnityEngine;

public class Brush : MonoBehaviour
{
    public bool brushOn;

    Color currentColor;

    private void Awake()
    {
        currentColor = Color.black;
    }

    public Color GetColor()
    {
        return currentColor;
    }

    public void SetBrushColor(Color color)
    {
        currentColor = color;
    }
}
