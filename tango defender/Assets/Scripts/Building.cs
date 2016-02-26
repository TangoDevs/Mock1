using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    bool building = false;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "Plane")
                building = true;
            Debug.Log("plane");

        }
    }


    public bool GetBuilding()
    {
        return building;
    }

    public void SetBuilding(bool newbuild)
    {
        building = newbuild;
    }
}
