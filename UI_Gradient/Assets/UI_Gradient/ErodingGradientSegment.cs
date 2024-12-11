using UnityEngine;
using UnityEngine.UI;

public class ErodingGradientSegment : MonoBehaviour
{
    [SerializeField] RawImage startImage;
    [SerializeField] RawImage endImage;
    [SerializeField] RawImage gradientArea;

    [SerializeField] float changeTime;
    [SerializeField] float erodingTime = 5;

    float timer;
    float erodingTimer;

    private void Update()
    {
        UpdateGrdient();
    }

    private void UpdateGrdient()
    {
        if (timer > changeTime)
        {
            startImage.color = new Color(Random.value, Random.value, Random.value);
            endImage.color = new Color(Random.value, Random.value, Random.value);
            timer = 0;
            erodingTimer = 0;
        }

        Vector2 start = startImage.rectTransform.anchoredPosition;
        Vector2 end = endImage.rectTransform.anchoredPosition;

        Vector2 dir = end - start;

        gradientArea.rectTransform.anchoredPosition = start;

        gradientArea.rectTransform.sizeDelta = new Vector2(dir.magnitude, startImage.rectTransform.sizeDelta.y);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gradientArea.rectTransform.rotation = Quaternion.Euler(0, 0, angle);

        gradientArea.material.SetColor("_StartColor", startImage.color);
        gradientArea.material.SetColor("_EndColor", endImage.color);

        float erodingUV = CalcErodingUV();
        gradientArea.material.SetFloat("_ErodingTime", erodingUV);

        timer += Time.deltaTime;
        erodingTimer += Time.deltaTime;
    }

    private float CalcErodingUV()
    {
        float uv = Mathf.Clamp01(erodingTimer / erodingTime);
        Debug.Log(uv);
        return uv;
    }
}
