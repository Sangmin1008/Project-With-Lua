using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] private HoverSettings hover;
    
    private Vector3 _startPosition;
    private Vector3 _startOffset;
    
    void Start()
    {
        Reset();
    }

    void Update()
    {
        transform.localPosition = hover.CalculateHover(Time.time);
    }

    public void Reset()
    {
        hover.StartPosition = transform.localPosition;
        hover.StartOffset = transform.position;
    }
}
