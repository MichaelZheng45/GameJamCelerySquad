using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    public List<GameObject> obstaclePrefab;
    public float obstacleSpawnRate;
    float obstacleTimer;

    public GameObject partPrefab;
    public float partSpawnRate;
    float partTimer;

    public Vector2 xBounds;
    public Vector2 yBounds;

    Transform spawnerTransform;

	// Use this for initialization
	void Start () {
        spawnerTransform = gameObject.transform;
        obstacleTimer = 0;
        //partTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {

        partSpawn();
        obstacleSpawn();
	}

    void partSpawn()
    {
        partTimer += Time.deltaTime;
        if(partTimer > partSpawnRate)
        {
            partTimer = 0;
            spawnObj(partPrefab);
        }
    }

    void obstacleSpawn()
    {
        obstacleTimer += Time.deltaTime;
        if(obstacleTimer > obstacleSpawnRate)
        {
            obstacleTimer = 0;
            spawnObj(obstaclePrefab[Random.Range(0,obstaclePrefab.Count)]);
        }
    }

    void spawnObj(GameObject prefab)
    {
        float xBound = Random.Range(xBounds.x, xBounds.y);
        float yBound = Random.Range(yBounds.x, yBounds.y);

        Vector3 newP = new Vector3(xBound, yBound + spawnerTransform.position.y, 0);
        GameObject newObj = Instantiate(prefab, newP, spawnerTransform.rotation);
    }
}
