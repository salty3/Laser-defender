using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private float minTimeBetweenSpawns = 0.5f;
    [SerializeField] private float maxTimeBetweenSpawns = 0.1f;
    [SerializeField] private float minMoveSpeed = 2f;
    [SerializeField] private float maxMoveSpeed = 4f;
    [SerializeField] private int minNumberOfEnemies = 5;
    [SerializeField] private int maxNumberOfEnemies = 10;



    public WaveConfig(
        GameObject enemyPrefab, GameObject pathPrefab,
        float minTimeBetweenSpawns, float maxTimeBetweenSpawns,
        float minMoveSpeed, float maxMoveSpeed,
        int minNumberOfEnemies, int maxNumberOfEnemies)
    {
        this.enemyPrefab = enemyPrefab;
        this.pathPrefab = pathPrefab;
        this.minTimeBetweenSpawns = minTimeBetweenSpawns;
        this.maxTimeBetweenSpawns = maxTimeBetweenSpawns;
        this.minMoveSpeed = minMoveSpeed;
        this.maxMoveSpeed = maxMoveSpeed;
        this.minNumberOfEnemies = minNumberOfEnemies;
        this.maxNumberOfEnemies = maxNumberOfEnemies;
    }


    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }
    public float GetTimeBetweenSpawns() 
    {
        return Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
    }
    public int GetNumberOfEnemies() 
    { 
        return Random.Range(minNumberOfEnemies, maxNumberOfEnemies + 1);
    }
    public float GetMoveSpeed() 
    {
        return Random.Range(minMoveSpeed, maxMoveSpeed);
    }
}
