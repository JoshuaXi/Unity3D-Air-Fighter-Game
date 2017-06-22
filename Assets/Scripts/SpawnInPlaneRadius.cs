
using UnityEngine;
using System.Collections;

public class SpawnInPlaneRadius : MonoBehaviour
{
    Transform planeTransform;
    public GameObject[] missiles;
    public GameObject[] points;
    public GameObject[] bonus;
    public float spawnSecondsOffset = 2;
    public float spawnRadius = 15;
    public float secondsToSpawn = 5;
    public ObjectTypeSpawn objectTypeSpawn;
    public bool spawnWhenTaken;
    public bool spawnAtStart = true;
    public enum ObjectTypeSpawn

    {
        missiles, points, bonus
    }
    // Use this for initialization
    void Start()
    {
        planeTransform = PlaneController.instance.transform;
        if (spawnWhenTaken == false)
        {
            StartCoroutine(spawnItemRoutine());
        }

        if (spawnAtStart)
            CallSpawnItem(0);

    }

    IEnumerator spawnItemRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsToSpawn);
            if (GameManager.instance.gameState == GameManager.GameState.game)
            {
                CallSpawnItem(spawnSecondsOffset);
            }
        }
    }

    public void CallSpawnItem(float offset)
    {
            StartCoroutine(SpawnItem(offset));
    }

    IEnumerator SpawnItem(float offsetTime)
    {

        while(GameManager.instance.gameState != GameManager.GameState.game)
        {
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(offsetTime);
        Vector3 radius = Random.onUnitSphere;
        radius.y = 0;
        radius = radius.normalized * spawnRadius;
        if (PlaneController.instance == null) yield break;

        Vector3 target = PlaneController.instance.transform.position + radius;

        GameObject spawningItem = null;
        if (objectTypeSpawn == ObjectTypeSpawn.missiles)
        {
            spawningItem = missiles[Random.Range(0, missiles.Length)];
        }

        if (objectTypeSpawn == ObjectTypeSpawn.points)
        {
            spawningItem = points[Random.Range(0, missiles.Length)];

        }

        if (objectTypeSpawn == ObjectTypeSpawn.bonus)
        {
            spawningItem = bonus[Random.Range(0, missiles.Length)];

        }

        GameObject newItem = (GameObject)Instantiate(spawningItem, target, Quaternion.identity);


        if (objectTypeSpawn == ObjectTypeSpawn.missiles)
        {
            FollowIcons.instance.AssignLastMissile(newItem);
        }

        if (objectTypeSpawn == ObjectTypeSpawn.points)
        {
            FollowIcons.instance.AssignLastPoint(newItem);

        }
        if (objectTypeSpawn == ObjectTypeSpawn.bonus)
        {
            FollowIcons.instance.AssignLastBonus(newItem);

        }
    }




}





