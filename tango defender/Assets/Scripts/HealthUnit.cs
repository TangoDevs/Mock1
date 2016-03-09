using UnityEngine;
using System.Collections;

public class HealthUnit : MonoBehaviour {

	float MaxHealth=100f,currHealth=0f;
	GameObject HealthBar;
	GameObject plane,astar;
	Building b;


	// Use this for initialization
	void Start () {
		currHealth = MaxHealth;
		HealthBar = GameObject.FindGameObjectWithTag ("unit");
		plane=GameObject.Find("Plane");
		b=plane.GetComponent<Building>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void decreaseUnitHealth(){
		currHealth -= 33;
		if (currHealth <= 0) {
			//score++
			b.AddScore(100);
			//gold++
			b.AddGold(50);
			Destroy (gameObject);

		} else {
			float myhealth = currHealth / MaxHealth;
			HealthBar.transform.localScale = new Vector3 (myhealth, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
		}
	}

}
