using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	GameObject tards;
	Transform target;
	public float speed ;
	Vector3[] path;
	int targetIndex;
    bool recheck=false;
    int i=0;
    Clicker c;
    bool changer=false;
	GameObject plane,astar;
	Building b;
	Grid g;


    void Start()
    {
		plane=GameObject.Find("Plane");
		astar=GameObject.Find("A*");
		b=plane.GetComponent<Building>();
        c=GetComponentInParent<Clicker>();
		g=astar.GetComponent<Grid>();
        tards = c.GetTarget();
		target = tards.transform;
        PathRequestManager.RequestPath(transform.position, target.transform.position, OnPathFound);
    }
    void Update()
    {
        /*
        changer = b.GetBuilding();
        if (changer == true)
        {
            speed = 0f;
            b.SetBuilding(false);
            changed();
			
        }
        */
    }

    void OnTriggerEnter(Collider col)
    {
       // Debug.Log("hello");
        if (col.gameObject.name == "target")
        {
            Destroy(gameObject);
        }
      
    }
   // void changed()   
   /*

    {
        Debug.Log("hello changing");
        
       g.CreateGrid();
        PathRequestManager.RequestPath(transform.position, target.transform.position, OnPathFound);
    }
    */
    public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful) {
			path = newPath;
			StopCoroutine("FollowPath");
            speed = 0.05f;
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];

		while (true) {
           
            if (transform.position == currentWaypoint) {
				targetIndex ++;
                
                if (targetIndex >= path.Length) {
                   
					yield break;
				}
				currentWaypoint = path[targetIndex];

			}
			
			
         
                transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            
            
            yield return null;


			}
		}
	}

