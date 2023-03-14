using UnityEngine;

public class BlueCollisionHandler : MonoBehaviour, ISphereCollisionHandler
{
    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void HandleSphereCollision()
    {
        Debug.Log(transform.name + " was triggered by something blue");
    }
}
