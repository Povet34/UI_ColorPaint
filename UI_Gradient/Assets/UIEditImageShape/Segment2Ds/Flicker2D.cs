using UnityEngine;

public class Flicker2D : BasicSegment2D
{
    public override void UpdateGradient(Data data)
    {
        base.UpdateGradient(data);

        if (timer > data.changeTime)
        {
            startImage.color = new Color(Random.value, Random.value, Random.value);
            endImage.color = Color.black;
            timer = 0;
        }

        render.material.SetColor("_Color", startImage.color);
        render.material.SetFloat("_ExtenedTime", data.speed);

        CalcTime();
    }

    protected override void CalcTime()
    {
        base.CalcTime();
    }
}
