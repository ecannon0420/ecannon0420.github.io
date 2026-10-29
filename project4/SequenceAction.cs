using UnityEngine;
using UnityEngine.Events;

public class SequenceAction : MonoBehaviour
{
    [Tooltip("The actions that you want to occur.")]
    public UnityEvent[] steps;

    [Tooltip("The amount of time before a step fires. If this list is shorter than the number of steps, each step without a delay will have an assumed delay of 0, and fire automatically.")]
    public float[] stepDelays;

    private int currentStep = 0;
    private int currentDelay = 0;
    private float elapsedTime = 0.0f;
    private bool sequencing = false;
    private bool listSizeDifference = false;


    void Start()
    {
        StartSequence();
    }

    void StartSequence()
    {
        sequencing = true;
        elapsedTime = 0.0f;
    }

    void StopSequence()
    {
        sequencing = false;
    }

    void Update()
    {
        if (sequencing)
        {
            elapsedTime += Time.deltaTime;

            if (stepDelays.Length < steps.Length)
            {
                listSizeDifference = true;
            } else 
            {
                listSizeDifference = false;
            }

            if (listSizeDifference && currentDelay >= stepDelays.Length) // CASE FOR IF THE DELAY IS SHORTER AND "GOES OUT OF BOUNDS"
            {
                steps[currentDelay].Invoke();
                currentStep += 1;
            } else 
            {
                if (elapsedTime >= stepDelays[currentDelay])
                {
                    steps[currentDelay].Invoke();
                    StartSequence();
                    currentStep += 1;
                    currentDelay += 1;
                }
            }

            if (currentStep >= steps.Length)
            {
                StopSequence();
            }
        }
    }
}
