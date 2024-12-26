using System.Collections;
using UnityEngine;
using static CompositeSegment2D;

public class BasicSegment2D : MonoBehaviour
{
    public class Data
    {
        public Active active;
        public Color startColor;
        public Color endColor;

        public float changeTime;
        public float speed;
    }

    [SerializeField] protected Material material;

    protected Renderer render;
    protected float timer;
    protected Data data;

    protected virtual void OnEnable()
    {
        render = GetComponent<Renderer>();
        render.material = Instantiate(material);
        timer = 0;
    }

    protected virtual void OnDisable()
    {
    }

    public virtual bool UpdateGradient(Data data)
    {
        this.data = data;

        render.material.SetColor("_StartColor", data.startColor);
        render.material.SetColor("_EndColor", data.endColor);

        CalcTime();

        return timer > data.changeTime;
    }

    protected virtual void CalcTime()
    {
        timer += Time.deltaTime;
    }
}
