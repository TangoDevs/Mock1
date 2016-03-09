using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

     GameObject hazard;
    GameObject seeker;
     Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    void Start()
    {
        seeker = GameObject.Find("Seekers");
        spawnValues = seeker.transform.position;
		hazard = (GameObject)Resources.Load ("Prefabs/Enemies/Battering Ram/Seekers");
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = spawnValues;
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
