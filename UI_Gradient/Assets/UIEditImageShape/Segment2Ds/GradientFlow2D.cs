using UnityEngine;

public class GradientFlow2D : BasicSegment2D
{
    public override bool UpdateGradient(Data data)
    {
        bool isDone = base.UpdateGradient(data);
        render.material.SetFloat("_FlowSpeed", data.speed);

        return isDone;
    }
}
