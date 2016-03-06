using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {
	
	bool allowed=true;
	GameObject camera;
	
	void Start(){
		camera=GameObject.Find("Camera");
		Changepos();
	}
	
	void Changepos(){
		while(true){
			if(camera.transform.position!=new Vector3(0,1,0)){
				camera.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,1,0), 2 * Time.deltaTime);
			}
			else{
				return;
			}
		}
	}

	  void OnTriggerEnter(Collider col)
    {
      
        if (col.gameObject.name == "BorderScene")
        {
			Debug.Log("not ALLOWED");
            allowed =false;
        }
      
    }
	
	  void OnTriggerExit(Collider col)
    {
      
        if (col.gameObject.name == "BorderScene")
        {
			Debug.Log("ALLOWED");
            allowed =true;
        }
      
    }
	
	public bool GetAllowed(){
		return allowed;
	}
	
	
	
}
