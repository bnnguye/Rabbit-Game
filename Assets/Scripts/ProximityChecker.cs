using UnityEngine;

public class ProximityChecker : MonoBehaviour
{
    public string targetTag;

    public Collider[] nearbyObjects = null;

    public float radius = 5;

    void Update() {
        GetNearbyObjects();
    }

    private Collider[] GetNearbyObjects()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        if (colliders.Length > 0) {
            nearbyObjects = colliders;
        }
        return null;
    }


}
