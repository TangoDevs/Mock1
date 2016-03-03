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
    Building b;

    void Start()
    {
        c=GetComponentInParent<Clicker>();
        b = GetComponentInParent<Building>();
		tards = c.GetTarget();
		target = tards.transform;
        PathRequestManager.RequestPath(transform.position, target.transform.position, OnPathFound);
    }
    void Update()
    {
        changer = b.GetBuilding();
        if (changer == true)
        {
            b.SetBuilding(false);
            changed();
        }

    }

    void OnTriggerEnter(Collider col)
    {
       // Debug.Log("hello");
        if (col.gameObject.name == "target")
        {
            Destroy(gameObject);
        }
      
    }

    void changed()
    {
           
        StopCoroutine("FollowPath");
       
        PathRequestManager.RequestPath(transform.position, target.transform.position, OnPathFound);
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful) {
			path = newPath;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];

		while (true) {
            if (changer == true)
            {
                continue;
            }
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

