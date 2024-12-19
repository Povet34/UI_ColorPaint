using UnityEngine;
using UnityEngine.UI;

public class LineControlPanel : MonoBehaviour
{
    [SerializeField] Button createLineButton;
    [SerializeField] Button offAddLinePositionModeButton;
    [SerializeField] Button onAddLinePositionModeButton;

    [SerializeField] GradientErodingSegment2D gradientErodingSegment2DPrefab;

    private GradientErodingSegment2D currentLineSegment;
    private bool isAddLinePositionModeOn = false;

    private void Awake()
    {
        createLineButton.onClick.AddListener(CreateLine);
        offAddLinePositionModeButton.onClick.AddListener(OffAddLinePositionMode);
        onAddLinePositionModeButton.onClick.AddListener(OnAddLinePositionMode);
    }

    private void Update()
    {
        if (isAddLinePositionModeOn && Input.GetMouseButtonDown(0))
        {
            AddLinePosition();
        }
    }

    private void CreateLine()
    {
        currentLineSegment = Instantiate(gradientErodingSegment2DPrefab);
        currentLineSegment.transform.SetParent(transform, false);
    }

    private void OffAddLinePositionMode()
    {
        isAddLinePositionModeOn = false;
    }

    private void OnAddLinePositionMode()
    {
        isAddLinePositionModeOn = true;
    }

    private void AddLinePosition()
    {
        if (currentLineSegment != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane; // 또는 원하는 z 값 설정
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0;

            LineRenderer lineRenderer = currentLineSegment.gradientLine;
            int positionCount = lineRenderer.positionCount;
            lineRenderer.positionCount = positionCount + 1;
            lineRenderer.SetPosition(positionCount, mousePosition);
        }
    }
}