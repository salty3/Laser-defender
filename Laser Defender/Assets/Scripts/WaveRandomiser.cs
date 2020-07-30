using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveRandomiser : MonoBehaviour
{
    [SerializeField] private string easySpawnConfig;
    [SerializeField] private string mediumSpawnConfig;
    [SerializeField] private string hardSpawnConfig;

    [Header("Enemies")]
    [SerializeField] private GameObject[] easyEnemies;
    [SerializeField] private GameObject[] mediumEnemies;
    [SerializeField] private GameObject[] hardEnemies;

    [Header("Paths")]
    [SerializeField] private GameObject[] easyPaths;
    [SerializeField] private GameObject[] mediumPaths;
    [SerializeField] private GameObject[] hardPaths;

    [Header("Move Speed")]
    [SerializeField] [Range(0, 25)] private float minEasySpeed;
    [SerializeField] [Range(0, 25)] private float maxEasySpeed;
    [SerializeField] [Range(0, 25)] private float minMediumSpeed;
    [SerializeField] [Range(0, 25)] private float maxMediumSpeed;
    [SerializeField] [Range(0, 25)] private float minHardSpeed;
    [SerializeField] [Range(0, 25)] private float maxHardSpeed;

    [Header("Spawn Time")]
    [SerializeField] [Range(0, 10)] private float minEasyTime;
    [SerializeField] [Range(0, 10)] private float maxEasyTime;
    [SerializeField] [Range(0, 10)] private float minMediumTime;
    [SerializeField] [Range(0, 10)] private float maxMediumTime;
    [SerializeField] [Range(0, 10)] private float minHardTime;
    [SerializeField] [Range(0, 10)] private float maxHardTime;

    [Header("Number of Enemies")]
    [SerializeField] [Range(1, 100)] private int minEasyEnemies;
    [SerializeField] [Range(1, 100)] private int maxEasyEnemies;
    [SerializeField] [Range(1, 100)] private int minMediumEnemies;
    [SerializeField] [Range(1, 100)] private int maxMediumEnemies;
    [SerializeField] [Range(1, 100)] private int minHardEnemies;
    [SerializeField] [Range(1, 100)] private int maxHardEnemies;

    private string spawnConfig;

    public void SetSpawnConfig(string difficult)
    {
        switch (difficult)
        {
            case "Easy":
                spawnConfig = easySpawnConfig;
                break;
            case "Medium":
                spawnConfig = mediumSpawnConfig;
                break;
            case "Hard":
                spawnConfig = hardSpawnConfig;
                break;
        }
    }

    public List<WaveConfig> GenerateWaves()
    {
        List<WaveConfig> waveConfigs = new List<WaveConfig>();
        foreach (char difficult in spawnConfig.ToCharArray())
        {
            switch (difficult)
            {
                case ('E'):
                    waveConfigs.Add(new WaveConfig(
                        easyEnemies[Random.Range(0, easyEnemies.Length)],
                        easyPaths[Random.Range(0, easyPaths.Length)],
                        minEasyTime, maxEasyTime,
                        minEasySpeed, maxEasySpeed,
                        minEasyEnemies, maxEasyEnemies));
                    break;
                case ('M'):
                    waveConfigs.Add(new WaveConfig(
                        mediumEnemies[Random.Range(0, mediumEnemies.Length)],
                        mediumPaths[Random.Range(0, mediumPaths.Length)],
                        minMediumTime, maxMediumTime,
                        minMediumSpeed, maxMediumSpeed,
                        minMediumEnemies, maxMediumEnemies));
                    break;
                case ('H'):
                    waveConfigs.Add(new WaveConfig(
                        hardEnemies[Random.Range(0, hardEnemies.Length)],
                        hardPaths[Random.Range(0, hardPaths.Length)],
                        minHardTime, maxHardTime,
                        minHardSpeed, maxHardSpeed,
                        minHardEnemies, maxHardEnemies));
                    break;
                default:
                    continue;
            }
        }
        return waveConfigs;
    }
}
