using UnityEngine;

[System.Serializable]
public class PositionData
{
    public float X;
    public float Y;
    public float Z;

    public PositionData( Vector3 position)
    {
        X = position.x;
        Y = position.y;
        Z = position.z;
    }
}
