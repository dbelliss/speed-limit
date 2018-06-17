using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public Transform spawnPoint;
    public GameObject[] list;
    public float spawnChanceGood;
    public float minSpawnTime;
    public float maxSpawnTime;
    public float startTime;
    public Camera cam;
	// Use this for initialization
	void Start () {
        StartCoroutine(Spawn());
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(startTime);
        while (true)
        {
            Vector3 spawnPosition = new Vector3(spawnPoint.position.x, Random.Range(-6, 6), 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            float randomNumber = Random.Range(0.0f, 1.0f);
            if (randomNumber <= spawnChanceGood)
            {
                Instantiate(list[0], spawnPosition, spawnRotation);
            }
            else
                Instantiate(list[Random.Range(1,3)], spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
    }
}
