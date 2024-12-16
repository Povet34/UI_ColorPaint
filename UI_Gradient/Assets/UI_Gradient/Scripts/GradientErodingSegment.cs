using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GradientErodingSegment : GradientBasicSegment
{
    [SerializeField] float erodingTime = 1;
    float erodingTimer;

    protected override void UpdateGrdient()
    {
        base.UpdateGrdient();

        if (erodingTimer > erodingTime)
        {
            erodingTimer = 0;
            gradientArea.material.SetFloat("_ErodingTime", 0);
        }

        gradientArea.material.SetColor("_StartColor", startImage.color);
        gradientArea.material.SetColor("_EndColor", endImage.color);

        float lerp = CalcLerp();
        gradientArea.material.SetFloat("_ErodingTime", lerp);

        erodingTimer += Time.deltaTime;
    }

    private float CalcLerp()
    {
        float uv = Mathf.Clamp01(erodingTimer / erodingTime) * 2 - 1;
        return uv;
    }
}
