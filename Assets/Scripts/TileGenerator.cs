using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private List<GameObject> activeTiles = new List<GameObject>();
    private float spawnPos = 0;
    private float tileLeght = 100;
    [SerializeField] private Transform player;
    private int startTiles = 6;

    void Start()
    {
       for (int i = 0; i < startTiles; i++)
        {
            SpawnTile(Random.Range(0,tilePrefabs.Length));
        }
        
    }


    void Update()
    {
        if (player.position.z -60 > spawnPos - (startTiles * tileLeght))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }

    }

    // генерація платформ
    private void SpawnTile(int tileIndex)
    {
       GameObject nextTile = Instantiate(tilePrefabs[tileIndex], transform.forward * spawnPos, transform.rotation);
        activeTiles.Add(nextTile);
        spawnPos += tileLeght;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
