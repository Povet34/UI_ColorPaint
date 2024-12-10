using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PaintArea : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum ViewUpdateMode{ RegionPaint, AllPaint }

    [SerializeField] ViewUpdateMode viewUpdateMode;
    [SerializeField] int totalCount;
    [SerializeField] FrameNode frameNodePrefab;
    [SerializeField] GraphicRaycaster graphicRaycaster;
    [SerializeField] SummationView summationView;

    List<FrameNode> frameNodes = new List<FrameNode>();
    Brush brush;
    PointerEventData pointerEventData;
    EventSystem eventSystem;

    int startIndex;
    int endIndex;

    public void OnBeginDrag(PointerEventData eventData)
    {
        pointerEventData.position = eventData.position;
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, results);

        if (results.Count > 0)
        {
            startIndex = results[0].gameObject.GetComponent<FrameNode>().index;
        }
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
        pointerEventData.position = eventData.position;
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, results);

        if (results.Count > 0)
        {
            endIndex = results[0].gameObject.GetComponent<FrameNode>().index;
        }

        switch (viewUpdateMode)
        {
            case ViewUpdateMode.AllPaint:
                UpdateAllPaints();
                break;
            case ViewUpdateMode.RegionPaint:
                UpdateRegionPaints();
                break;
        }
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

        UpdateAllPaints();
    }

    private void UpdateAllPaints()
    {
        SummationView.AllColor data = new SummationView.AllColor
        {
            colors = frameNodes.Select(node => node.Color).ToList()
        };

        summationView.UpdateView(data);
    }

    private void UpdateRegionPaints()
    {
        int start = Mathf.Min(startIndex, endIndex);
        int end = Mathf.Max(startIndex, endIndex);

        SummationView.RegionPaint data = new SummationView.RegionPaint
        {
            startIndex = start,
            endIndex = end,
            color = brush.GetColor()
        };

        summationView.UpdateView(data);
    }
}