using UnityEngine;

public class SphereColissionEmitter : MonoBehaviour
{
    [SerializeField] private LayerMask _collisionLayers;
    [SerializeField] private float _radius = 1000f;
    [SerializeField] private int _maxNumberOfHits = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log(transform.name + " clicked");

        // this does not trigger a collision nor does it return what objects where inside the sphere
        //Physics.CheckSphere(transform.position, _radius, _collisionLayers);

        // This will return all the colliders (and thus there objects) found inside the sphere
        // This call is slightly optimized as it will ignore all objects that are not in the given layer
        //var collidersInTheSphere = Physics.OverlapSphere(transform.position, _radius, _collisionLayers);

        // This is the most optimized version as it both filters out objects we do not want trough the use of a layermask
        // and it limits the amount of objects returned to _maxNumberOfHits
        // this is important because the way the detection goes, the system has to allocate a new array every it finds a new cluster of hits
        // which increases memory consumption and overhead because of garbage cleanup. Remember small memory optimizations have huge consequences especially when they run during update (every frame) or fixedupdate (50 times/s)
        var collidersInTheSphere = new Collider[_maxNumberOfHits];
        var numberOfHits = Physics.OverlapSphereNonAlloc(transform.position, _radius, collidersInTheSphere, _collisionLayers);

        // loop over all the colliders, get all their script
        // we use an interface (contract) to get all the possible scripts that want to interact with spheres, the requirement is that they have a HandleSphereCollision method
        // This is not all necessary but might give you some ideas on how to proceed.
        for (int i = 0; i < numberOfHits; i++)
        {
            var otherScript = collidersInTheSphere[i].GetComponent<ISphereCollisionHandler>();
            // if an object in the sphere does not contain any matching scripts, skip it
            if (otherScript == null ) continue;

            otherScript.HandleSphereCollision();
        }
    }
}
