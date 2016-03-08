using UnityEngine;
using System.Collections;

public class HealthUnit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void decreaseUnitHealth(){
		Destroy (transform.parent.gameObject);
		//Destroy (gameObject);
		Debug.Log ("decreasing health");
	}
}
