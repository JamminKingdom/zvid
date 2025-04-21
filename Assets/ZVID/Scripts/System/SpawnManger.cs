using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }
    
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap obstacleTilemap;
    
    [SerializeField] private GameObject enemyPrefab;
    
    [SerializeField] private float initialSpawnTime = 5f;
    [SerializeField] private float minSpawnTime = 0.01f;
    [SerializeField] private float accelerationDuration = 120f;

    private List<Vector3Int> _validCells = new List<Vector3Int>();

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
        StartCoroutine(SpawnProcess());
    }

    private IEnumerator SpawnProcess()
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

    public void SpawnRandomEnemy()
    {
        if (_validCells.Count == 0) return;

        var cell = _validCells[Random.Range(0, _validCells.Count)];
        var worldPos = groundTilemap.CellToWorld(cell) + groundTilemap.cellSize * 0.5f;

        Instantiate(enemyPrefab, worldPos, Quaternion.identity);
    }
}
