using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public float spawnMinX = -20;
    public float spawnMaxX = 20;
    public float spawnY = 30;


    public float dropIntervalSec = 0.5f;
    public List<GameObject> spawnPrefabs;

    float lastDropTime = 0;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spawnMinX = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        spawnMaxX = Camera.main.ViewportToWorldPoint(Vector3.right).x;
    }

    // Update is called once per frame
    void Update()
    {
		if(!gameManager.isPlaying) {
            return;
		}

        if(Time.time - lastDropTime > dropIntervalSec) {
            SpawnItem();
            lastDropTime = Time.time;

        }
        
    }

    void SpawnItem()
	{
        GameObject obj = Instantiate(spawnPrefabs[Random.Range(0,spawnPrefabs.Count)]);
        Vector3 pos = new Vector3(Random.Range(spawnMinX,spawnMaxX),spawnY,0);
        obj.transform.SetPositionAndRotation(pos, Quaternion.identity); 
	}
}
