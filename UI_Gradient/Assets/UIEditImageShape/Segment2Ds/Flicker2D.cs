using UnityEngine;

public class Flicker2D : BasicSegment2D
{
    public override void UpdateGradient(Data data)
    {
        base.UpdateGradient(data);
        render.material.SetFloat("_ExtenedTime", data.speed);
    }
}
