using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ItemDestroyer : MonoBehaviour {

    public static ItemDestroyer instance;


    void Awake() {
        instance = this;
    }

    public void ClearAllItems() {


        foreach (SpriteRenderer item in FollowIcons.instance.SpawnedMissile) {

            Destroy(item.transform.root.gameObject);
        }

        foreach (SpriteRenderer item in FollowIcons.instance.SpawnedBonus)
        {

            Destroy(item.transform.root.gameObject);
        }


        foreach (SpriteRenderer item in FollowIcons.instance.SpawnedPoint)
        {

            Destroy(item.transform.root.gameObject);
        }
        FollowIcons.instance.SpawnedPoint.Clear();
        FollowIcons.instance.SpawnedMissile.Clear();
        FollowIcons.instance.SpawnedBonus.Clear();


    }



}
