using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("spawning")]
    [Min(1)] [SerializeField] private int spawnAmount;
    [Min(1)] [SerializeField] private int spawnRadius;

    [Header("Timers")]
    [Min(1)] [SerializeField] private int spawnTimer;
    [Min(1)] [SerializeField] private int initSpawnTime;

    [Header("Layermask")]
    public LayerMask surfaceToSpawnOn;

    public GameObject[] prefabs;
    private Dictionary<string, int> currentItems;

    private void Start()
    {
        currentItems = new Dictionary<string, int>();
        for(int i = 0; i < prefabs.Length; i++)
        {
            currentItems.Add(prefabs[i].name, 0);
        }

        InvokeRepeating(nameof(spawn), initSpawnTime, spawnTimer);

        ScrapMaterial.OnScrapDestroyed += scrapDestroyed;
    }

    private void OnDestroy() {
        ScrapMaterial.OnScrapDestroyed -= scrapDestroyed;
    }

    private void spawn()
    {
        foreach(var entry in currentItems)
        {
            for (int i = entry.Value; i < spawnAmount; i++)
            {
                int arrayIndex = Random.Range(0, prefabs.Length - 1);
                GameObject prefab = prefabs[arrayIndex];

                int randomRangeX = Random.Range(-spawnRadius, spawnRadius);
                int randomRangeZ = Random.Range(-spawnRadius, spawnRadius);
                Vector3 position = new Vector3(randomRangeX, 0, randomRangeZ) + transform.position;

                RaycastHit hit;
                if (Physics.Raycast(position, Vector3.down, out hit, 20, surfaceToSpawnOn))
                {
                    float offset = prefab.transform.localScale.y;
                    GameObject newObject = Instantiate(prefab, hit.point + (Vector3.up * offset), Quaternion.identity, transform);
                    newObject.name = prefab.name;
                }
            }
        }

        for(int i = 0; i < prefabs.Length; i++)
        {
            currentItems[prefabs[i].name] = spawnAmount;
        }
    }

    private void scrapDestroyed(string name)
    {
        print($"{name} was destroyed");
        currentItems[name] -= 1;
    }
}
