using UnityEngine;
using UnityEngine.Events;

public class TimedAction : MonoBehaviour
{
    [Tooltip("The duration of the timer.")]
    public float duration;

    [Tooltip("The timer starts as soon as the scene loads.")]
    public bool startOnAwake;

    [Tooltip("Determines if the action will repeat when the timer expires.")]
    public bool repeat;

    [Tooltip("The number of times an action will repeat. The value of 0 means the action will repeat forever.")]
    public int repeatCount;

    [Tooltip("The action that will occur when the timer expires.")]
    public UnityEvent onTimerComplete;
    
    private float elapsedTime = 0.0f;
    private bool counting = false;
    private bool repeatForever = false;

    void Start()
    {
        if (repeatCount == 0)
        {
            repeatForever = true;
        }

        if (startOnAwake)
        {
            StartTimer();
        }
    }

    void StartTimer()
    {
        counting = true;
        elapsedTime = 0.0f;
    }

    void StopTimer()
    {
        counting = false;
    }

    void Update()
    {
        if (counting) 
        {
            elapsedTime += Time.deltaTime;
        }

        if (elapsedTime >= duration) {
            onTimerComplete.Invoke();
            elapsedTime = 0.0f;

            if (!repeat)
            {
                StopTimer();
            } else {
                if (!repeatForever)
                {
                    repeatCount -= 1;
                    if (repeatCount > 0) {
                        StartTimer();
                    } else {
                        StopTimer();
                    }
                }
            }
        }
    }
}
