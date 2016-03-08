using UnityEngine;
using System.Collections;

public class LookToCamera : MonoBehaviour {

     GameObject cameran;


    void Start()
    {
        cameran =GameObject.Find("Camera");
    }


    // Update is called once per frame
    void Update () {
        transform.LookAt (transform.position + cameran.transform.rotation* Vector3.back,
                                cameran.transform.rotation * Vector3.up);
	}
}
