﻿using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	GameObject bulletPrefab;
	// Use this for initialization
	void Start () {
		bulletPrefab = (GameObject)Resources.Load("Prefabs/Bullet");
	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log ("TRIGGERED");
		if (col.GetComponent<killer> ()) {
			Debug.Log ("STARTING BULLET");
			GameObject g = (GameObject)Instantiate (bulletPrefab, transform.position, Quaternion.identity);
			g.GetComponent<Bullet> ().target = col.transform;
		}
	} 
}
