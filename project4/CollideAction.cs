using UnityEngine;
using UnityEngine.Events;

public class CollideAction : MonoBehaviour
{
    [Tooltip("The tag name of the object that is being collided with. (What this object is searching for)")]
    public string colliderTagName;

    [Tooltip("The action to take when this object collides with the object it's looking for.")]
    public UnityEvent onCollision;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(colliderTagName))
        {
            onCollision.Invoke();
        }
    }
}
