using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    public static bool building;
    GameObject prefab,plane;
    Vector3 mousePosition, targetPosition,CheckPosition;
   

    void Start()
    {
        building = false;
        prefab = (GameObject)Resources.Load("Prefabs/Cube11");
        plane = GameObject.Find("Plane");
    }

    // Update is called once per frame
    void Update()
    {     
        //If Left Button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //To get the current mouse position
            mousePosition = Input.mousePosition;
            //Convert the mousePosition according to World position
            targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 1));
            //Set the position of targetObject
            prefab.transform.position = targetPosition;

            targetPosition.y = plane.transform.position.y;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rch;
            if (Physics.Raycast(ray, out rch))
            {
                if (rch.transform.name == "Plane")
                {                   
                    building = true;
                    //create the instance of targetObject and place it at given position.
                    Instantiate(prefab, targetPosition, prefab.transform.rotation);
                }
            }
        }
    }


    public static bool GetBuilding()
    {
        return building;
    }

    public static void SetBuilding(bool newbuild)
    {
        building = newbuild;
    }

  
}
