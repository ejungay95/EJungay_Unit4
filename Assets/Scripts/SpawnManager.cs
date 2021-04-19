using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  private float spawnRange = 8.5f;
  private int enemyCount;
  private int waveNumber = 1;

  public GameObject enemyPrefab;
  public GameObject powerUpPrefab;
  // Start is called before the first frame update
  void Start()
  {
    SpawnWave(waveNumber);
  }

  // Update is called once per frame
  void Update()
  {
    enemyCount = FindObjectsOfType<Enemy>().Length;
    if(enemyCount == 0)
    {
      waveNumber++;
      SpawnWave(waveNumber);
    }
  }

  Vector3 GenerateSpawnPosition()
  {
    float xPos = Random.Range(-spawnRange, spawnRange);
    float zPos = Random.Range(-spawnRange, spawnRange);
    Vector3 randSpawnPos = new Vector3(xPos, enemyPrefab.transform.position.y, zPos);
    return randSpawnPos;
  }

  void SpawnWave(int enemyNum)
  {
    Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);

    for (int i = 0; i < enemyNum; i++) {
      Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }
  }
}
