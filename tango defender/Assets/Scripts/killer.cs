using UnityEngine;
using System.Collections;

public class killer : MonoBehaviour {
	GameObject plane;
	Building b;
	float spawnDistance;

	// Use this for initialization
	void Start () {
		plane=GameObject.Find("Plane");
		b=plane.GetComponent<Building>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
		if (col.name == "Target") {
			col.GetComponentInChildren<HealthCastle> ().decreaseCastleHealth();
			Destroy (gameObject);
		}
    }
}
