using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LineControlPanel : MonoBehaviour
{
    [SerializeField] Button createLineButton;
    [SerializeField] Button offAddLinePositionModeButton;
    [SerializeField] Button onAddLinePositionModeButton;
    
    [SerializeField] Button interval1Button;
    [SerializeField] Button interval2Button;
    [SerializeField] Button interval5Button;

    [SerializeField] TMP_Dropdown changeShaderDropdown;

    [SerializeField] CompositeSegment2D composite2DPrefab;

    private CompositeSegment2D curComposite2D;
    private bool isAddLinePositionModeOn = false;

    private float timer;
    private float intervalTime = 0.1f;

    private void Awake()
    {
        intervalTime = 0.1f;

        createLineButton.onClick.AddListener(CreateLine);
        offAddLinePositionModeButton.onClick.AddListener(OffAddLinePositionMode);
        onAddLinePositionModeButton.onClick.AddListener(OnAddLinePositionMode);

        interval1Button.onClick.AddListener(() => { SetInterval(0.1f); });
        interval2Button.onClick.AddListener(() => { SetInterval(0.2f); });
        interval5Button.onClick.AddListener(() => { SetInterval(0.5f); });

        changeShaderDropdown.ClearOptions();
        changeShaderDropdown.AddOptions(new List<TMP_Dropdown.OptionData>() 
        {
            new TMP_Dropdown.OptionData("Eroding"),
            new TMP_Dropdown.OptionData("Flow"),
            new TMP_Dropdown.OptionData("Flick"),
            new TMP_Dropdown.OptionData("Maintain"),
        });

        changeShaderDropdown.onValueChanged.AddListener(ChangeSegment);
    }
        
    private void Update()
    {
        if (CanAdd())
        {
            timer += Time.deltaTime;
            if (timer > intervalTime)
            {
                AddLinePosition();
                timer = 0f;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            OffAddLinePositionMode();
            CreateLine();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isAddLinePositionModeOn = !isAddLinePositionModeOn;
        }
    }

    private void SetInterval(float time)
    {
        intervalTime = time;
    }

    private bool CanAdd()
    {
        bool isUIClick = false;
        if (Input.GetMouseButtonDown(0))
        {
            // UI 영역 클릭 여부 확인
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.GetComponent<GraphicRaycaster>() != null)
                {
                    isUIClick = true;
                    break;
                }
            }
        }

        return isAddLinePositionModeOn && !isUIClick;
    }

    private void CreateLine()
    {
        curComposite2D = Instantiate(composite2DPrefab);
        curComposite2D.transform.SetParent(transform, false);
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
        if (curComposite2D == null)
        {
            Debug.LogWarning("No line segment created to add position to.");
            return;
        }

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform as RectTransform,
            Input.mousePosition,
            Camera.main,
            out localPoint
        );

        Vector3 worldPosition = transform.TransformPoint(localPoint);
        curComposite2D.AddLine(worldPosition);
    }

    private void ChangeSegment(int active)
    {
        curComposite2D.ChangeSegment((CompositeSegment2D.Active)active);
    }
}