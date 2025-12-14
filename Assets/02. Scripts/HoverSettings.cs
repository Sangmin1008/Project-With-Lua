using UnityEngine;

[CreateAssetMenu(fileName = "HoverSettings", menuName = "Scriptable Objects/Hover Settings", order = 1)]
public class HoverSettings : ScriptableObject
{
    public float HoverHeight = 1.0f;
    public float HoverTime = 1.0f;
    
    private Vector3 _startPosition;
    private Vector3 _startOffset;

    public Vector3 StartPosition
    {
        get => _startPosition;
        set => _startPosition = value;
    }
    
    public Vector3 StartOffset
    {
        get => _startOffset;
        set => _startOffset = value;
    }

    public Vector3 CalculateHover(float time)
    {
        return StartPosition + Vector3.up *
               (Mathf.Sin(StartOffset.x + Time.realtimeSinceStartup * HoverTime) * HoverHeight);
    }
}
