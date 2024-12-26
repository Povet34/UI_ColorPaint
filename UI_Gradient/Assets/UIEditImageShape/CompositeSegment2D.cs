using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeSegment2D : MonoBehaviour
{
    public class Sequence
    {
        public List<BasicSegment2D.Data> datas;
        public static Sequence Create()
        {
            Sequence sequence = new Sequence();
            sequence.datas = new List<BasicSegment2D.Data>();

            return sequence;
        }

        public BasicSegment2D.Data this[int index]
        {
            get
            {
                if (index < GetDatasCount())
                    return datas[index];
                else
                    return null;
            }
            set
            {
                if (index < GetDatasCount())
                    datas[index] = value;
            }
        }

        public int GetDatasCount()
        {
            return datas.Count;
        }

        public void NewData(BasicSegment2D.Data data)
        {
            datas.Add(data);
        }
    }

    public enum Active { Eroding, Flow, Flicker }

    [Header("Composition")]
    [SerializeField] GradientEroding2D gradientEroding2D;
    [SerializeField] GradientFlow2D gradientFlow2D;
    [SerializeField] Flicker2D flicker2D;
    [Header("Renderer"),SerializeField] LineRenderer gradientLine;

    delegate void OnUpdateRender(BasicSegment2D.Data data);
    OnUpdateRender onUpdateRender;

    Sequence sequence;

    public void Start()
    {
        sequence = TestDatas();
        StartCoroutine(UpdateSequence(sequence));
    }

    public void ChangeSegment(Active active)
    {
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

    public void AddLine(Vector3 worldPosition)
    {
        int positionCount = gradientLine.positionCount;
        gradientLine.positionCount = positionCount + 1;
        gradientLine.SetPosition(positionCount, worldPosition);
    }

    public IEnumerator UpdateSequence(Sequence sequence)
    {
        float timer = 0;
        for (int i = 0; i < sequence.GetDatasCount(); i++)
        {
            ChangeSegment(sequence[i].active);

            while (timer < sequence[i].changeTime)
            {
                onUpdateRender(sequence[i]);
                timer += Time.deltaTime;
                yield return null;
            }

            timer = 0f;
        }
    }

    private Sequence TestDatas()
    {
        Sequence sequence = Sequence.Create();
        sequence.NewData(new BasicSegment2D.Data 
        { 
            active = Active.Eroding, 
            startColor = Color.red, 
            endColor = Color.blue, 
            changeTime = 3f, 
        });

        sequence.NewData(new BasicSegment2D.Data
        {
            active = Active.Flow,
            startColor = Color.gray,
            endColor = Color.green,
            speed = 5f,
            changeTime = 3f,
        });

        sequence.NewData(new BasicSegment2D.Data
        {
            active = Active.Flicker,
            startColor = Color.red,
            endColor = Color.black,
            speed = 3f,
            changeTime = 3f,
        });

        sequence.NewData(new BasicSegment2D.Data
        {
            active = Active.Eroding,
            startColor = Color.blue,
            endColor = Color.red,
            changeTime = 5f,
        });


        return sequence;
    }
}
