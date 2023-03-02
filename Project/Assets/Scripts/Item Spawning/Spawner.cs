using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("spawning")]
    [Min(1)] [SerializeField] private int spawnAmount;
    [Min(1)] [SerializeField] private int spawnTimer;
    [SerializeField] private int initSpawnTime;
    [SerializeField] private int range;
    [SerializeField] private int maxOfItem;

    public GameObject[] prefabs;

    private string[] _ItemArray = { "Polymer", "Scrap Metal", "Bolts", "Wires" };
    private Dictionary<string, int> currentItems = new Dictionary<string, int>()
    {
        {"Polymer",0},
        {"Scrap Metal",0},
        {"Bolts",0},
        {"Wires", 0},
    };

    private void Start()
    {
        InvokeRepeating(nameof(spawn), initSpawnTime, spawnTimer);
    }

    private void spawn()
    {
        foreach(KeyValuePair<string,int> entry in currentItems)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                var arrayIndex = Random.Range(0, _ItemArray.Length - 1);
                var nameOfItem = _ItemArray[arrayIndex];

                MaterialStruct newItem = new MaterialStruct();
                newItem.Name = nameOfItem;
                newItem.Prefab = prefabs[arrayIndex];

                int randomRangeX = Random.Range(-range, range);
                int randomRangeZ = Random.Range(-range, range);
                Vector3 position = new Vector3(randomRangeX, 0, randomRangeZ) + transform.position;
                Instantiate(newItem.Prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
