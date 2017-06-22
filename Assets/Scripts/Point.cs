using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour
{

    // Use this for initialization


    void OnTriggerEnter(Collider obj)
    {
        if (obj.transform.tag == "Player")
        {
            PickUp();
        }
    }


    void PickUp()
    {

        DeleteItem();
        ScoreHandler.instance.increaseSpecialPoints(1);
        ScoreHandler.instance.increaseScore(10);
        SpawnerManager.instance.coinspawner.CallSpawnItem(SpawnerManager.instance.coinspawner.spawnSecondsOffset);
        SoundsManager.instance.PlayDiamondSound();

    }

    public void DeleteItem()
    {
        FollowIcons.instance.RemoveElement(SpawnInPlaneRadius.ObjectTypeSpawn.points, gameObject);
        Destroy(this.gameObject);

    }

}
