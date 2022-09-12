using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectSpawner : MonoBehaviour
{
    public Transform target;
    public Transform mapObjectParent; // Para que la escena se vea mas limpia

    public MapObjectSO[] mapObjects;
    public GameObject coinPf;
    private MapObjectSO.YPosition lastCoinYPos;
    [Range(0f, 100f)]
    public float coinProbability = 50;
    private float lastMapObjectXPos;
    public float cooldownToSpawnMapObject;
    public float minCooldownToSpawnMapObject;
    public float cooldownReductionPerSecond;
    private float timer;

    [Space]
    private MapObjectProbabilityController[] mapObjectProbabilities;
    private Queue<MapObjectSO> mapObjectsQueue = new Queue<MapObjectSO>();
    public int maxMapObjectsInQueue;

    public int xPositionToSpawn;

    private void Start()
    {
        mapObjectProbabilities = new MapObjectProbabilityController[mapObjects.Length];
        for(int i = 0; i < mapObjects.Length; i++)
        {
            mapObjectProbabilities[i] = new MapObjectProbabilityController(mapObjects[i]);
        }

        //Populate map object queue
        while(mapObjectsQueue.Count < maxMapObjectsInQueue)
        {
            AddMapObjectToQueue();
        }
    }

    private void Update()
    {
        if (GameManager.gameOver) return;
        if (minCooldownToSpawnMapObject < cooldownToSpawnMapObject)
        {
            cooldownToSpawnMapObject -= Time.deltaTime * cooldownReductionPerSecond;
        }

        timer += Time.deltaTime;

        if(timer > cooldownToSpawnMapObject)
        {
            SpawnTwoMapObject();
            timer = 0;
        }
    }

    private void AddMapObjectToQueue()
    {
        bool obstacleSelected = false;
        while (!obstacleSelected)
        {
            foreach (var mapObject in mapObjectProbabilities)
            {
                if (mapObject.actualProbability > Random.Range(0, 100))
                {
                    mapObjectsQueue.Enqueue(mapObject.mapObjectData);
                    mapObject.RemoveProbability();
                    foreach (var m in mapObjectProbabilities)
                    {
                        if (!m.Equals(mapObject))
                        {
                            m.AddProbability();
                        }
                    }
                    obstacleSelected = true;

                    break;
                }
            }
        }
    }

    private void SpawnTwoMapObject()
    {
        MapObjectSO mapObject = mapObjectsQueue.Dequeue();
        GameObject mapObjectGO = Instantiate(mapObject.mapObjectPf, new Vector3(target.position.x + xPositionToSpawn + 0.5f, (int)mapObject.yPosition + 0.5f, 0), Quaternion.identity);


        //Spawning Coin
        if(coinProbability > Random.Range(0, 100))
        {
            if(lastCoinYPos != mapObject.yPositionCoin && lastMapObjectXPos != 0)
            {
                float middleX = (target.position.x + xPositionToSpawn + 0.5f + lastMapObjectXPos) / 2;
                Instantiate(coinPf, new Vector3(middleX, (int)MapObjectSO.YPosition.Middle, 0), Quaternion.identity, mapObjectParent);
            }

            Instantiate(coinPf, new Vector3(target.position.x + xPositionToSpawn + 0.5f, (int)mapObject.yPositionCoin + 0.5f, 0), Quaternion.identity, mapObjectParent);
        }
        lastCoinYPos = mapObject.yPositionCoin;
        lastMapObjectXPos = mapObjectGO.transform.position.x;

        AddMapObjectToQueue();
    }
}
