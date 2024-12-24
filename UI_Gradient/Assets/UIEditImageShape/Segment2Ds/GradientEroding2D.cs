using UnityEngine;

public class GradientEroding2D : BasicSegment2D
{
    public override void UpdateGradient(Data data)
    {
        base.UpdateGradient(data);

        if (timer > data.changeTime)
        {
            startImage.color = new Color(Random.value, Random.value, Random.value);
            endImage.color = new Color(Random.value, Random.value, Random.value);
            timer = 0;
            render.material.SetFloat("_ErodingTime", 0);
        }

        render.material.SetColor("_StartColor", startImage.color);
        render.material.SetColor("_EndColor", endImage.color);

        float lerp = CalcLerp();
        render.material.SetFloat("_ErodingTime", lerp);
        
        CalcTime();
    }

    private float CalcLerp()
    {
        float uv = Mathf.Clamp01(timer / data.changeTime) * 2 - 1;
        return uv;
    }
}
