using UnityEngine;
using System.Collections;

public class ImmortalityBonus : MonoBehaviour {




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
        Plane.instance.TriggerInvulnerability();
        SoundsManager.instance.PlayPerfectLandingSound();

    }

    public void DeleteItem() {
        FollowIcons.instance.RemoveElement(SpawnInPlaneRadius.ObjectTypeSpawn.bonus, gameObject);
        Destroy(this.gameObject);


    }
}
