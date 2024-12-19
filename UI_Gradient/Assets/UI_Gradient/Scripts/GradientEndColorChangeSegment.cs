using UnityEngine;

public class GradientEndColorChangeSegment : GradientBasicSegment
{
    [SerializeField] float endColorChangeTime = 1;
    float endColorChangeTimer;

    protected override void UpdateGradient()
    {
        base.UpdateGradient();

        if (endColorChangeTimer > endColorChangeTime)
        {
            endColorChangeTimer = 0;
        }

        gradientArea.material.SetColor("_StartColor", startImage.color);
        gradientArea.material.SetColor("_EndColor", endImage.color);

        endColorChangeTimer += Time.deltaTime;

        float lerp = CalcLerp();
        gradientArea.material.SetFloat("_ErodingTime", lerp);
    }

    private float CalcLerp()
    {
        float uv = Mathf.Clamp01(endColorChangeTimer / endColorChangeTime);
        return uv;
    }
}
