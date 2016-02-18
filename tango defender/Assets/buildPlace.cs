using UnityEngine;
using System.Collections;

public class buildPlace : MonoBehaviour {

    // The Tower that should be built
    public GameObject towerPrefab;

    void OnMouseUpAsButton()
    {
        // Build Tower above Buildplace
        GameObject g = (GameObject)Instantiate(towerPrefab);
        g.transform.position = transform.position + Vector3.up;
    }
}
