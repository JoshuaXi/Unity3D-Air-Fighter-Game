/*using UnityEngine;
using System.Collections;

public class TerrainsSpawner : MonoBehaviour {
    public GameObject[] terrainsList;
     int numberOfTerrainsToSpawnEachTime = 35000;
     float maxDistanceToSpawnNewTerrains = 500f;
     float terrainsSpawnRadius = 800f;
    GameObject[] lastSpawnedTerrainsCompound;
    
    // Use this for initialization
	void Start () {
       
        SpawnTerrains();
        StartCoroutine(TerrainSpawnerRoutine());
	}

    void SpawnTerrains() {

        GameObject[] spawnedTerrains = new GameObject[numberOfTerrainsToSpawnEachTime];
        for (int i = 0; i < spawnedTerrains.Length; i++) {
            GameObject newTerrain =(GameObject) Instantiate(terrainsList[Random.Range(0, terrainsList.Length)], Vector3.zero, Quaternion.identity);
         spawnedTerrains[i] = newTerrain;
        }
        MoveTerrainsInACircle(spawnedTerrains);
        lastSpawnedTerrainsCompound = spawnedTerrains;
    }

    void MoveTerrainsInACircle(GameObject[] terrains) {

        foreach (GameObject terrain in terrains) {
            Vector3 randomizedCircle = Random.insideUnitSphere * terrainsSpawnRadius;
            randomizedCircle.y = 0;
            Vector3 targetPosition = PlaneController.instance.transform.position + randomizedCircle;
            terrain.transform.position = targetPosition;
            terrain.transform.Rotate(90, 0, 0);
            terrain.transform.position += Vector3.up;
            terrain.transform.parent = this.transform;
        }

    }

    void MoveTerrainsCompound() {
        transform.position = PlaneController.instance.transform.position;


    }


    IEnumerator TerrainSpawnerRoutine() {

        Vector3 savedPlanePosition = PlaneController.instance.transform.position;
        while (true) {
            if (PlaneController.instance == null) yield break;
            Vector3 currentPlanePosition = PlaneController.instance.transform.position;

            if (Vector3.Distance(currentPlanePosition, savedPlanePosition) > maxDistanceToSpawnNewTerrains) {
                savedPlanePosition = currentPlanePosition;
                MoveTerrainsCompound();
            }





            yield return new WaitForEndOfFrame();


        }


    }


}
*/