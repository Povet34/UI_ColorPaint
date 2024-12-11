using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class GradientBasicSegment : MonoBehaviour
{
    [SerializeField] protected RawImage startImage;
    [SerializeField] protected RawImage endImage;
    [SerializeField] protected RawImage gradientArea;

    [SerializeField] protected float changeTime;

    protected float timer;

    protected virtual void Update()
    {
        UpdateUIs();
        UpdateGrdient();
    }

    protected virtual void UpdateUIs()
    {
        Vector2 start = startImage.rectTransform.anchoredPosition;
        Vector2 end = endImage.rectTransform.anchoredPosition;

        Vector2 dir = end - start;

        gradientArea.rectTransform.anchoredPosition = start;

        gradientArea.rectTransform.sizeDelta = new Vector2(dir.magnitude, startImage.rectTransform.sizeDelta.y);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gradientArea.rectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }

    protected virtual void UpdateGrdient()
    {
        if(timer > changeTime)
        {
            startImage.color = new Color(Random.value, Random.value, Random.value);
            endImage.color = new Color(Random.value, Random.value, Random.value);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
