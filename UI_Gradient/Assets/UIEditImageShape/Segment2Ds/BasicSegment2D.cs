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

    public virtual void UpdateGradient(Data data)
    {
        this.data = data;

        if (timer > data.changeTime)
        {
            timer = 0;
        }

        render.material.SetColor("_StartColor", data.startColor);
        render.material.SetColor("_EndColor", data.endColor);

        CalcTime();
    }

    protected virtual void CalcTime()
    {
        timer += Time.deltaTime;
    }
}
