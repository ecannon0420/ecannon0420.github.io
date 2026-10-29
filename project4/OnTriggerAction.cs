using UnityEngine;
using UnityEngine.Events;

public class OnTriggerAction : MonoBehaviour
{
    [Tooltip("The tag name of the object that will be detected by this object's trigger.")]
    public string triggerTagName = "MainCamera"; 
    
    [Tooltip("The action to take when the trigger is entered.")]
    public UnityEvent onEnter;
    
    [Tooltip("The action to take when the trigger is exited.")]
    public UnityEvent onExit;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTagName))
        {
            onEnter.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggerTagName))
        {
            onExit.Invoke();
        }
    }
}
