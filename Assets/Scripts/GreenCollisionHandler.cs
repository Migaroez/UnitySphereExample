using UnityEngine;

public class GreenCollisionHandler : MonoBehaviour, ISphereCollisionHandler
{
    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void HandleSphereCollision()
    {
        Debug.Log(transform.name + " was triggered by something green");
    }
}
