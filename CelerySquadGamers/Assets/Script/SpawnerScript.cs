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

    public GameObject metroPrefab;
    public float metroSpawnRate;
    float metroTimer;

    float updateTimeCount;

    public Vector2 xBounds;
    public Vector2 yBounds;

    Transform spawnerTransform;

    public GameObject Despawner;
    private Despawner despawnerScr;

	// Use this for initialization
	void Start () {
        spawnerTransform = gameObject.transform;
        obstacleTimer = 0;
        despawnerScr = Despawner.GetComponent<Despawner>();
        //partTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {

        partSpawn();
        obstacleSpawn();
        metroSpawn();
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

    void metroSpawn()
    {
        metroTimer += Time.deltaTime;
        if (metroTimer > metroSpawnRate)
        {
            metroTimer = 0;
            spawnObj(metroPrefab, 20);
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

        updateTimeCount += Time.deltaTime;
        if(updateTimeCount > 20)
        {
            updateTimeCount = 0;
            obstacleSpawnRate -= .1f;
            if(obstacleSpawnRate < .5f)
            {
                obstacleSpawnRate = .5f;
            }
        }
    }

    void spawnObj(GameObject prefab, int addY = 0)
    {
        float xBound = Random.Range(xBounds.x, xBounds.y);
        float yBound = Random.Range(yBounds.x, yBounds.y);

        Vector3 newP = new Vector3(xBound, yBound + spawnerTransform.position.y + addY, 0);
        GameObject newObj = Instantiate(prefab, newP, spawnerTransform.rotation);

        despawnerScr.addToActive(newObj);
    }
}
