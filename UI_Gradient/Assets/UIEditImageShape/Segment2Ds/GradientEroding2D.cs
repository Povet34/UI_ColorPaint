using UnityEngine;

public class GradientEroding2D : BasicSegment2D
{
    public override void UpdateGradient(Data data)
    {
        base.UpdateGradient(data);

        float lerp = CalcLerp();
        render.material.SetFloat("_ErodingTime", lerp);
    }

    private float CalcLerp()
    {
        float uv = Mathf.Clamp01(timer / data.changeTime) * 2 - 1;
        return uv;
    }
}
