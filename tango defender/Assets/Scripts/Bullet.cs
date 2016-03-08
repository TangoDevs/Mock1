using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    // Speed
    public float speed = 0.0001f;

    // Target (set by Tower)
    public Transform target;

    void FixedUpdate()
    {
        // Still has a Target?
        if (target)
        {
            // Fly towards the target        
            Vector3 dir = target.position - transform.position;
            GetComponent<Rigidbody>().velocity = dir.normalized * speed;
        }
        else
        {
            // Otherwise destroy self
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider co)
    {
		HealthUnit health = co.GetComponentInChildren<HealthUnit>();
        if (health)
        {
            health.decreaseUnitHealth();
        }
    }
}
