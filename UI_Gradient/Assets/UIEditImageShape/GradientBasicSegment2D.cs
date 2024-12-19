using UnityEngine;
using UnityEngine.UI;

public class GradientBasicSegment2D : MonoBehaviour
{

    [SerializeField] protected SpriteRenderer startImage;
    [SerializeField] protected SpriteRenderer endImage;
    [SerializeField] public LineRenderer gradientLine;

    [SerializeField] protected float changeTime;

    protected float timer;

    protected virtual void Start()
    {
        gradientLine.material = Instantiate(gradientLine.material);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        UpdateGradient();
    }

    protected virtual void UpdateGradient()
    {
        if (timer > changeTime)
        {
            startImage.color = new Color(Random.value, Random.value, Random.value);
            endImage.color = new Color(Random.value, Random.value, Random.value);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
