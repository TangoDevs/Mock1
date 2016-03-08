using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Building : MonoBehaviour {

    bool building,allowed;
    GameObject prefab,plane,cam,border;
    Vector3 mousePosition, targetPosition,CheckPosition;	
   start s;
	GameObject scoreLabelObject,goldLabelObject;
	Text scoreTxt,goldTxt;
	int score=0,gold=1000;


    void Awake()
    {
        building = false;
        prefab = (GameObject)Resources.Load("Prefabs/WoodTower");
        plane = GameObject.Find("Plane");
		cam=GameObject.Find("camerarig");
		s=cam.GetComponent<start>();
		allowed=s.GetAllowed();
		SetScore ();
		SetGold ();
    }

    // Update is called once per frame
    void Update()
    {   
		scoreTxt.text = " " + score;
		goldTxt.text = " " + gold;
		if (gold >= 100) {
			allowed = s.GetAllowed ();
			if (allowed == false) {
				//If Left Button is clicked
				if (Input.GetMouseButtonDown (0)) {
					//To get the current mouse position
					mousePosition = Input.mousePosition;
					//Convert the mousePosition according to World position
					targetPosition = Camera.main.ScreenToWorldPoint (new Vector3 (mousePosition.x, mousePosition.y, 1));


					//Set the position of targetObject
					prefab.transform.position = targetPosition;

					targetPosition.y = plane.transform.position.y;
					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					RaycastHit rch;
					if (Physics.Raycast (ray, out rch)) {
						if (rch.transform.name == "Plane") {                   
							building = true;
							//create the instance of targetObject and place it at given position.
							Instantiate (prefab, targetPosition, prefab.transform.rotation);
							gold-=100;
						}
					}
				}
			}
		}
    }


    public bool GetBuilding()
    {
        return building;
    }

    public  void SetBuilding(bool newbuild)
    {
        building = newbuild;
    }

	public void AddScore(int addScore){
		score += addScore;
	}

	public void AddGold(int addGold){
		gold += addGold;
	}

	void SetGold (){
		goldLabelObject = GameObject.Find ("GoldCurrent");
		goldTxt = goldLabelObject.GetComponent<Text>();
	}

	void SetScore (){
		scoreLabelObject = GameObject.Find ("ScoreCurrent");
		scoreTxt = scoreLabelObject.GetComponent<Text>();
	}


}
