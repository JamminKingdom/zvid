using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[Serializable]
public class RankEntry
{
    public int   killCount;
    public float clearTime;

    public RankEntry(int kills, float time)
    {
        killCount = kills;
        clearTime = time;
    }
}

[Serializable]
public class RankListData
{
    public List<RankEntry> entries = new List<RankEntry>();
}

public class RankingManager : MonoBehaviour
{
    public static RankingManager Instance { get; private set; }

    [SerializeField] private Transform  contentParent;
    [SerializeField] private  CanvasGroup rangkingCanvas;
    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private int maxEntries = 5;

    private List<RankEntry> rankList = new List<RankEntry>();
    private const string PrefKey = "Rankings";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadRecords();
        RefreshUI();
    }

    public void AddRecord(int kills, float time)
    {
        rangkingCanvas.alpha = 1f;
        rangkingCanvas.interactable = rangkingCanvas.blocksRaycasts = true;

        rankList.Add(new RankEntry(kills, time));
        SortRankings();
        SaveRecords();
        RefreshUI();
    }

    private void SortRankings()
    {
        rankList.Sort((a, b) =>
        {
            int cmp = b.clearTime.CompareTo(a.clearTime);
            
            if (cmp != 0) return cmp;
            
            return b.killCount.CompareTo(a.killCount);
        });
    }

    private void SaveRecords()
    {
        var data = new RankListData { entries = rankList };
        string json = JsonUtility.ToJson(data);
        
        PlayerPrefs.SetString(PrefKey, json);
        PlayerPrefs.Save();
    }

    private void LoadRecords()
    {
        if (!PlayerPrefs.HasKey(PrefKey))
            return;

        string json = PlayerPrefs.GetString(PrefKey);
        var data = JsonUtility.FromJson<RankListData>(json);
        
        rankList = data.entries ?? new List<RankEntry>();
    }

    private void RefreshUI()
    {
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);
        
        int count = Mathf.Min(rankList.Count, maxEntries);
        
        for (int i = 0; i < count; i++)
        {
            RankEntry entry = rankList[i];
            GameObject row   = Instantiate(rowPrefab, contentParent);

            float clearTime = entry.clearTime;
            int min = Mathf.FloorToInt(clearTime / 60f);
            int sec = Mathf.FloorToInt(clearTime % 60f);
            
            row.transform.Find("Rank").GetComponent<TextMeshProUGUI>().text = $"{i + 1}";
            row.transform.Find("Time").GetComponent<TextMeshProUGUI>().text = $"{min:00}:{sec:00}";
            row.transform.Find("Kill").GetComponent<TextMeshProUGUI>().text = entry.killCount.ToString();
        }
    }
}
