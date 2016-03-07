using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {
	
	bool allowed=false;
	GameObject cameran;
	
	void Start(){
		cameran=GameObject.Find("Camera");
		Changepos();
	}
	
	void Changepos(){
		while(true){
			if(cameran.transform.position!=new Vector3(0,1,0)){
				cameran.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,1,0), 2 * Time.deltaTime);
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
