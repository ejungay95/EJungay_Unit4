using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  private float spawnRange = 8.5f;
  public GameObject enemyPrefab;
  // Start is called before the first frame update
  void Start()
  {
    Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
  }

  // Update is called once per frame
  void Update()
  {
    
  }

  Vector3 GenerateSpawnPosition()
  {
    float xPos = Random.Range(-spawnRange, spawnRange);
    float zPos = Random.Range(-spawnRange, spawnRange);
    Vector3 randSpawnPos = new Vector3(xPos, enemyPrefab.transform.position.y, zPos);
    return randSpawnPos;
  }
}
