using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintArea : MonoBehaviour
{
    [SerializeField] int totalCount;
    [SerializeField] FrameNode frameNodePrefab;

    List<FrameNode> frameNodes = new List<FrameNode>();

    private void Start()
    {
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
