using UnityEngine;

public class Flicker2D : BasicSegment2D
{
    public override bool UpdateGradient(Data data)
    {
        bool isDone = base.UpdateGradient(data);
        render.material.SetFloat("_ExtenedTime", data.speed);

        return isDone;
    }
}
