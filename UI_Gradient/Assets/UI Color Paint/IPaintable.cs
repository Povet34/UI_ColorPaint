using UnityEngine;

public interface IPaintable
{
    Color Color { get; set; }
    void Paint(Color color);
}
