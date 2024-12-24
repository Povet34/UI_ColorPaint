using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class CompositeSegment2D : MonoBehaviour
{
    public enum Active { Eroding, Flow, Flicker }

    public Active active = Active.Eroding;

    [SerializeField] GradientEroding2D gradientEroding2D;
    [SerializeField] GradientFlow2D gradientFlow2D;
    [SerializeField] Flicker2D flicker2D;

    [SerializeField] LineRenderer gradientLine;
    [SerializeField] float changeTime;

    delegate void OnUpdateRender(BasicSegment2D.Data data);
    OnUpdateRender onUpdateRender;

    void Start()
    {
        ChangeSegment(active);
    }

    public void ChangeSegment(Active active)
    {
        if (this.active == active)
            return;

        switch (active)
        {
            case Active.Eroding:
                gradientEroding2D.enabled = true;
                gradientFlow2D.enabled = false;
                flicker2D.enabled = false;

                onUpdateRender = gradientEroding2D.UpdateGradient;

                break;
            case Active.Flow:
                gradientEroding2D.enabled = false;
                gradientFlow2D.enabled = true;
                flicker2D.enabled = false;

                onUpdateRender = gradientFlow2D.UpdateGradient;


                break;
            case Active.Flicker:
                gradientEroding2D.enabled = false;
                gradientFlow2D.enabled = false;
                flicker2D.enabled = true;

                onUpdateRender = flicker2D.UpdateGradient;

                break;
        }
    }

    private void Update()
    {
        BasicSegment2D.Data data = new BasicSegment2D.Data();
        data.changeTime = 3f;
        data.speed = 5f;

        onUpdateRender?.Invoke(data);
    }

    public void AddLine(Vector3 worldPosition)
    {
        int positionCount = gradientLine.positionCount;
        gradientLine.positionCount = positionCount + 1;
        gradientLine.SetPosition(positionCount, worldPosition);
    }
}
