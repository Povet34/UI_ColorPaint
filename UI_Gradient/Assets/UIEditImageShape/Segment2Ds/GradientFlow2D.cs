using UnityEngine;

public class GradientFlow2D : BasicSegment2D
{
    public override void UpdateGradient(Data data)
    {
        base.UpdateGradient(data);

        render.material.SetFloat("_FlowSpeed", data.speed);
    }
}
