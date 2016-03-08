using UnityEngine;
using System.Collections;

public class killer : MonoBehaviour {
	GameObject plane;
	Building b;
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

        {
           //Destroy(col.gameObject);
			b.AddGold(100);
			b.AddScore (200);

        }


    }
}
