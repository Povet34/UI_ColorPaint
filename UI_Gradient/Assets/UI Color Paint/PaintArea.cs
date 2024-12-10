using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PaintArea : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] int totalCount;
    [SerializeField] FrameNode frameNodePrefab;
    [SerializeField] GraphicRaycaster graphicRaycaster;

    List<FrameNode> frameNodes = new List<FrameNode>();
    Brush brush;
    PointerEventData pointerEventData;
    EventSystem eventSystem;

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        pointerEventData.position = eventData.position;
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, results);

        foreach (RaycastResult result in results)
        {
            IPaintable paintable = result.gameObject.GetComponent<IPaintable>();
            if (paintable != null)
            {
                paintable.Paint(brush.GetColor());
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    private void Start()
    {
        brush = FindAnyObjectByType<Brush>();
        eventSystem = GetComponent<EventSystem>();
        pointerEventData = new PointerEventData(eventSystem);

        for (int i = 0; i < totalCount; i++)
        {
            FrameNode node = Instantiate(frameNodePrefab, transform);
            node.Init(new FrameNode.InitParam(i, Color.white));

            frameNodes.Add(node);
        }

        GridLayoutGroup layout = GetComponent<GridLayoutGroup>();

        if (layout)
        {
            float cellSizeX = layout.cellSize.x;
            RectOffset padding = layout.padding;

            GetComponent<RectTransform>().sizeDelta = new Vector2((cellSizeX + padding.left + padding.right) * totalCount, 315f);
        }
    }
}