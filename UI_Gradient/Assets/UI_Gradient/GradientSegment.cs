using UnityEngine;
using UnityEngine.UI;

public class GradientSegment : MonoBehaviour
{
    [SerializeField] RawImage startImage;
    [SerializeField] RawImage endImage;

    [SerializeField] RawImage gradientArea;
    [SerializeField] RawImage copyGradientArea;

    [SerializeField] float changeTime;

    float timer;

    private void Update()
    {
        UpdateGrdient();
    }

    private void UpdateGrdient()
    {
        if(timer > changeTime)
        {
            startImage.color = new Color(Random.value, Random.value, Random.value);
            endImage.color = new Color(Random.value, Random.value, Random.value);
            timer = 0;
        }

        Vector2 start = startImage.rectTransform.anchoredPosition;
        Vector2 end = endImage.rectTransform.anchoredPosition;

        Vector2 dir = end - start;

        gradientArea.rectTransform.anchoredPosition = start;
        copyGradientArea.rectTransform.anchoredPosition = start;

        gradientArea.rectTransform.sizeDelta = new Vector2(dir.magnitude, startImage.rectTransform.sizeDelta.y);
        copyGradientArea.rectTransform.sizeDelta = new Vector2(dir.magnitude, startImage.rectTransform.sizeDelta.y * 0.7f);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gradientArea.rectTransform.rotation = Quaternion.Euler(0, 0, angle);
        copyGradientArea.rectTransform.rotation = Quaternion.Euler(0, 0, angle);

        gradientArea.material.SetColor("_StartColor", startImage.color);
        copyGradientArea.material.SetColor("_StartColor", startImage.color);

        gradientArea.material.SetColor("_EndColor", endImage.color);
        copyGradientArea.material.SetColor("_EndColor", endImage.color);

        gradientArea.material.SetColor("_Emission", Color.white);
        copyGradientArea.material.SetColor("_Emission", new Color(0, 0, 0, 0));

        timer += Time.deltaTime;
    }
}
