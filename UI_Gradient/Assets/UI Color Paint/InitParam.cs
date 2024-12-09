using UnityEngine;

public partial class FrameNode
{
    public struct InitParam
    {
        public int index;
        public Color color;

        public InitParam(int index, Color color)
        {
            this.index = index;
            this.color = color;
        }
    }
}
