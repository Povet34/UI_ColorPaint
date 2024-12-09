using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public partial class FrameNode : MonoBehaviour, IPaintable, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    [SerializeField] TextMeshProUGUI indexText;
    Image paintImage;

    Brush brush;

    public Color Color { get; set; }
    private int index;

    private void Awake()
    {
        paintImage = GetComponent<Image>();
    }

    public void Paint(Color color)
    {
        paintImage.color = color;
        Color = color;
    }

    public void Init(InitParam initParam)
    {
        Color = initParam.color;
        index = initParam.index;

        Paint(Color);
        SetIndexText(index);

        name = $"FrameNode_{index}";
    }

    private void SetIndexText(int index)
    {
        indexText.text = index.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SetBrush();

        brush.brushOn = true;
        Paint(brush.GetColor());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SetBrush();

        brush.brushOn = false;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        SetBrush();

        if (brush.brushOn)
        {
            Paint(brush.GetColor());
        }
    }

    private void SetBrush()
    {
        if (!brush)
            brush = FindAnyObjectByType<Brush>();
    }
}
