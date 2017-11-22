using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{


    public Transform[] spawnLocations;
    public GameObject[] whatToSpawnPrefab;
    public GameObject[] whatToSpawnClone;



   public void SpawnRowOne()
    {
        whatToSpawnClone[0] = Instantiate(whatToSpawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[1] = Instantiate(whatToSpawnPrefab[0], spawnLocations[1].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[2] = Instantiate(whatToSpawnPrefab[0], spawnLocations[2].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[3] = Instantiate(whatToSpawnPrefab[0], spawnLocations[3].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[4] = Instantiate(whatToSpawnPrefab[0], spawnLocations[4].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    public void SpawnRowTwo()
    {
        whatToSpawnClone[5] = Instantiate(whatToSpawnPrefab[0], spawnLocations[5].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[6] = Instantiate(whatToSpawnPrefab[0], spawnLocations[6].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[7] = Instantiate(whatToSpawnPrefab[0], spawnLocations[7].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[8] = Instantiate(whatToSpawnPrefab[0], spawnLocations[8].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[9] = Instantiate(whatToSpawnPrefab[0], spawnLocations[9].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        
    }

    public void SpawnRowThree()
    {
        whatToSpawnClone[10] = Instantiate(whatToSpawnPrefab[0], spawnLocations[10].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[11] = Instantiate(whatToSpawnPrefab[0], spawnLocations[11].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[12] = Instantiate(whatToSpawnPrefab[0], spawnLocations[12].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[13] = Instantiate(whatToSpawnPrefab[0], spawnLocations[13].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[14] = Instantiate(whatToSpawnPrefab[0], spawnLocations[14].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    public void SpawnRowFour()
    {
        whatToSpawnClone[15] = Instantiate(whatToSpawnPrefab[0], spawnLocations[15].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[16] = Instantiate(whatToSpawnPrefab[0], spawnLocations[16].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[17] = Instantiate(whatToSpawnPrefab[0], spawnLocations[17].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[18] = Instantiate(whatToSpawnPrefab[0], spawnLocations[18].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[19] = Instantiate(whatToSpawnPrefab[0], spawnLocations[19].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }
    public void PlayerFireFirstRow()
    {
        whatToSpawnClone[20] = Instantiate(whatToSpawnPrefab[1], spawnLocations[20].transform.position, Quaternion.Euler(0, -40, 0)) as GameObject;
        whatToSpawnClone[21] = Instantiate(whatToSpawnPrefab[1], spawnLocations[20].transform.position, Quaternion.Euler(0, -25, 0)) as GameObject;
        whatToSpawnClone[22] = Instantiate(whatToSpawnPrefab[1], spawnLocations[20].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        whatToSpawnClone[23] = Instantiate(whatToSpawnPrefab[1], spawnLocations[20].transform.position, Quaternion.Euler(0, 25, 0)) as GameObject;
        whatToSpawnClone[24] = Instantiate(whatToSpawnPrefab[1], spawnLocations[20].transform.position, Quaternion.Euler(0, 40, 0)) as GameObject;
    }
    public void EnemyFire()
    {
        whatToSpawnClone[25] = Instantiate(whatToSpawnPrefab[2], spawnLocations[0].transform.position, Quaternion.Euler(0, -180, 0)) as GameObject;
        whatToSpawnClone[26] = Instantiate(whatToSpawnPrefab[2], spawnLocations[1].transform.position, Quaternion.Euler(0, -180, 0)) as GameObject;
        whatToSpawnClone[27] = Instantiate(whatToSpawnPrefab[2], spawnLocations[2].transform.position, Quaternion.Euler(0, -180, 0)) as GameObject;
        whatToSpawnClone[28] = Instantiate(whatToSpawnPrefab[2], spawnLocations[3].transform.position, Quaternion.Euler(0, -180, 0)) as GameObject;
        whatToSpawnClone[29] = Instantiate(whatToSpawnPrefab[2], spawnLocations[4].transform.position, Quaternion.Euler(0, -180, 0)) as GameObject;
    }
}   
    