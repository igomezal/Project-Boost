using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] private float period = 2f;
    [SerializeField] private Vector3 movementVector;
    
    private Vector3 startingPosition;
    const float Tau = Mathf.PI * 2f;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) return;
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(cycles * Tau); // Goes from -1 to 1
        var movementFactor = rawSinWave / 2f + 0.5f; // Goes from 0 to 1
        
        var offset = movementFactor * movementVector;
        transform.position = startingPosition + offset;
    }
}
