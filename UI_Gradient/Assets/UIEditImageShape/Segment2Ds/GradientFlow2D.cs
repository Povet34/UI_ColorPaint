using UnityEngine;

public class GradientFlow2D : BasicSegment2D
{
    public override void UpdateGradient(Data data)
    {
        base.UpdateGradient(data);

        if (timer > data.changeTime)
        {
            startImage.color = new Color(Random.value, Random.value, Random.value);
            endImage.color = new Color(Random.value, Random.value, Random.value);
            timer = 0;
        }

        render.material.SetColor("_StartColor", startImage.color);
        render.material.SetColor("_EndColor", endImage.color);
        render.material.SetFloat("_FlowSpeed", data.speed);

        CalcTime();
    }
}
