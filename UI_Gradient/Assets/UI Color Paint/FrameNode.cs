using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public partial class FrameNode : MonoBehaviour, IPaintable
{
    [SerializeField] TextMeshProUGUI indexText;
    Image paintImage;


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
}
