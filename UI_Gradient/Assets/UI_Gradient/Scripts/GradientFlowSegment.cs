using UnityEngine;

public class GradientFlowSegment : GradientBasicSegment
{
    [SerializeField] float flowSpeed = 5;
    private Material gradientMaterialInstance;

    protected override void UpdateGradient()
    {
        base.UpdateGradient();

        gradientArea.material.SetColor("_StartColor", startImage.color);
        gradientArea.material.SetColor("_EndColor", endImage.color);
        gradientArea.material.SetFloat("_FlowSpeed", flowSpeed);
    }
}
