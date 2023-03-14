using UnityEngine;

public class RedCollisionHandler : MonoBehaviour, ISphereCollisionHandler
{
    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void HandleSphereCollision()
    {
        Debug.Log(transform.name + " was triggered by something red");
    }
}
