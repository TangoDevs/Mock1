using UnityEngine;
using System.Collections;

public class Clicker : MonoBehaviour {

    GameObject target;
	// Use this for initialization
	void Awake () {
        target = GameObject.Find("target");
	}
    
    public GameObject GetTarget()
    {
        return target;
    }
}
