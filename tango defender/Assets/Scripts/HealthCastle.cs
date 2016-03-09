using UnityEngine;
using System.Collections;

public class HealthCastle : MonoBehaviour {
	public float MaxHealth=100f,currHealth=0f;
	GameObject HealthBar;

	// Use this for initialization
	void Start () {
		currHealth = MaxHealth;
		HealthBar = GameObject.FindGameObjectWithTag ("target");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void decreaseCastleHealth (){
		currHealth -= 10;
		if (currHealth < 1) {
			Destroy (gameObject);
		} else {
			float myhealth = currHealth / MaxHealth;
			SetHealthBar (myhealth);
		}
	}

	void SetHealthBar (float myhealth){
		HealthBar.transform.localScale = new Vector3 (myhealth, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
	}

}
