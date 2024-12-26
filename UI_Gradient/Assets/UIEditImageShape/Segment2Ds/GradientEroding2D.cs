using UnityEngine;

public class GradientEroding2D : BasicSegment2D
{
    public override bool UpdateGradient(Data data)
    {
        bool isDone = base.UpdateGradient(data);

        float lerp = CalcLerp();
        render.material.SetFloat("_ErodingTime", lerp);

        return isDone;
    }

    private float CalcLerp()
    {
        float uv = Mathf.Clamp01(timer / data.changeTime) * 2 - 1;
        return uv;
    }
}
