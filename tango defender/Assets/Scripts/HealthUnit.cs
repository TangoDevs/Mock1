using UnityEngine;
using System.Collections;

public class HealthUnit : MonoBehaviour {

	float MaxHealth=100f,currHealth=0f;
	GameObject HealthBar;

	// Use this for initialization
	void Start () {
		currHealth = MaxHealth;
		HealthBar = GameObject.FindGameObjectWithTag ("unit");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void decreaseUnitHealth(){
		currHealth -= 34;
		if (currHealth <= 0) {
			Destroy (transform.parent.gameObject);
			//Destroy (gameObject);
			Debug.Log ("decreasing health");
		} else {
			float myhealth = currHealth / MaxHealth;
			SetHealthBar (myhealth);
		}
	}


	void SetHealthBar (float myhealth){
		HealthBar.transform.localScale = new Vector3 (myhealth, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
	}

}
