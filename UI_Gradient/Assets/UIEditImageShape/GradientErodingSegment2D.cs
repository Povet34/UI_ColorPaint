using UnityEngine;

public class GradientErodingSegment2D : GradientBasicSegment2D
{
    [SerializeField] float erodingTime = 1;
    float erodingTimer;

    protected override void UpdateGradient()
    {
        base.UpdateGradient();

        if (erodingTimer > erodingTime)
        {
            erodingTimer = 0;
            gradientLine.material.SetFloat("_ErodingTime", 0);
        }

        gradientLine.material.SetColor("_StartColor", startImage.color);
        gradientLine.material.SetColor("_EndColor", endImage.color);

        float lerp = CalcLerp();
        gradientLine.material.SetFloat("_ErodingTime", lerp);

        erodingTimer += Time.deltaTime;
    }

    private float CalcLerp()
    {
        float uv = Mathf.Clamp01(erodingTimer / erodingTime) * 2 - 1;
        return uv;
    }
}
