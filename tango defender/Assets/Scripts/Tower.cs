using UnityEngine;
using System.Collections;
using System.Diagnostics;


public class Tower : MonoBehaviour {
	GameObject bulletPrefab;
	int i=0;

	// Use this for initialization
	void Start () {
		bulletPrefab = (GameObject)Resources.Load("Prefabs/Bullet");
	}

	void OnTriggerEnter(Collider col)
	{
		

		if (col.GetComponent<killer> ()) {
			
			GameObject g = (GameObject)Instantiate (bulletPrefab, transform.position, Quaternion.identity);
			g.GetComponent<Bullet> ().target = col.transform;
		}


	} 
	void OnTriggerStay(Collider col)
	{
	} 
	void OnTriggerExit(Collider col)
	{


		if (col.GetComponent<killer> ()) {

			GameObject g = (GameObject)Instantiate (bulletPrefab, transform.position, Quaternion.identity);
			g.GetComponent<Bullet> ().target = col.transform;
		}


	} 



}
