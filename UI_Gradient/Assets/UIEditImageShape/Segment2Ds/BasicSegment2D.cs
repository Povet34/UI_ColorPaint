using UnityEngine;
using UnityEngine.UI;

public class BasicSegment2D : MonoBehaviour
{
    public class Data
    {
        public float changeTime;
        public float speed;
    }

    [SerializeField] protected SpriteRenderer startImage;
    [SerializeField] protected SpriteRenderer endImage;
    [SerializeField] protected Material material;

    protected Renderer render;
    protected float timer;
    protected Data data;

    protected virtual void OnEnable()
    {
        render = GetComponent<Renderer>();
        render.material = Instantiate(material);
    }

    protected virtual void OnDisable()
    {
    }

    public virtual void UpdateGradient(Data data)
    {
        this.data = data;
    }

    protected virtual void CalcTime()
    {
        timer += Time.deltaTime;
    }
}
