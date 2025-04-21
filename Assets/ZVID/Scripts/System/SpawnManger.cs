using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }
    public ItemManager itemManager;
    
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap obstacleTilemap;
    
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject itemPrefab;
    
    [SerializeField] private float initialSpawnTime = 5f;
    [SerializeField] private float minSpawnTime = 0.01f;
    [SerializeField] private float accelerationDuration = 120f;

    private List<Vector3Int> _validCells = new List<Vector3Int>();
    
    private float TotalWeight
    {
        get
        {
            float sum = 0;
            
            foreach (var it in itemManager.itemData)
                sum += it.weight;
            
            return sum;
        }
    }
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        var bounds = groundTilemap.cellBounds;
        foreach (var pos in bounds.allPositionsWithin)
        {
            if (groundTilemap.HasTile(pos) && !obstacleTilemap.HasTile(pos))
                _validCells.Add(pos);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemyProcess());
    }

    private IEnumerator SpawnEnemyProcess()
    {
        while (true)
        {
            float gameTime = TimeManager.Instance.ElapsedTime;

            float t = Mathf.Clamp01(gameTime / accelerationDuration);
            float spawnInterval = Mathf.Lerp(initialSpawnTime, minSpawnTime, t);

            SpawnRandomEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnRandomEnemy()
    {
        if (_validCells.Count == 0) return;

        var cell = _validCells[Random.Range(0, _validCells.Count)];
        var worldPos = groundTilemap.CellToWorld(cell) + groundTilemap.cellSize * 0.5f;

        GameObject go = Instantiate(enemyPrefab, worldPos, Quaternion.identity);

        go.GetComponent<EnemyData>().target = Player.Instance.transform;
    }

    public void SpawnRandomItem(Transform spawnPoint)
    {
        var item = GetRandomItem();

        if (item == null) return;
        
        GameObject go = Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
        
        ItemObject itemObject = go.GetComponent<ItemObject>();
        itemObject?.Init(item);
    }
    
    private ItemData GetRandomItem()
    {
        float total = TotalWeight;

        float rnd = Random.Range(0f, total);
        float accum = 0f;

        foreach (var data in itemManager.itemData)
        {
            accum += data.weight;
            if (rnd <= accum)
                return data;
        }
        
        return null;
    }
}
