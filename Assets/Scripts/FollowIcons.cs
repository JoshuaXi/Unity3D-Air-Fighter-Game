using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class FollowIcons : MonoBehaviour {
    public List<SpriteRenderer> SpawnedPoint;
    public List<SpriteRenderer> SpawnedMissile;
    public List<SpriteRenderer> SpawnedBonus;
    // Use this for initialization

    public SpriteRenderer missileIcon;
    public SpriteRenderer pointIcon;
    public SpriteRenderer bonusIcon;

    Transform planeTransform;
    float screenW;
    float screenH;
    public static FollowIcons instance;

    void Awake() {
        instance = this;
    }


    void Start() {
        planeTransform = PlaneController.instance.transform;
        screenW = Screen.width;

        screenH = Screen.height;


    }

    public void AssignLastPoint(GameObject item) {
        SpawnedPoint.Add(item.GetComponentInChildren<SpriteRenderer>());
    }
    public void AssignLastMissile(GameObject item) {
        SpawnedMissile.Add(item.GetComponentInChildren<SpriteRenderer>());

    }

    public void AssignLastBonus(GameObject item)
    {
        SpawnedBonus.Add(item.GetComponentInChildren<SpriteRenderer>());

    }

    public void RemoveElement(SpawnInPlaneRadius.ObjectTypeSpawn  objectType, GameObject item)
    {

        if (objectType == SpawnInPlaneRadius.ObjectTypeSpawn.missiles)
        {
            SpawnedMissile.Remove(item.GetComponentInChildren<SpriteRenderer>());
        }

        if (objectType == SpawnInPlaneRadius.ObjectTypeSpawn.points)
        {
            SpawnedPoint.Remove(item.GetComponentInChildren<SpriteRenderer>());

        }

        if (objectType == SpawnInPlaneRadius.ObjectTypeSpawn.bonus)
        {
            SpawnedBonus.Remove(item.GetComponentInChildren<SpriteRenderer>());

        }

    }

        void LateUpdate() {

        if (SpawnedMissile != null)
        {
            if (SpawnedMissile.Count > 0)
            {
                FollowItem(SpawnedMissile[0], missileIcon);
            }
            else
            {
                missileIcon.enabled = false;
            }

        }
        else {
            missileIcon.enabled = false;

        }

        if (SpawnedPoint != null)
        {
            if (SpawnedPoint.Count > 0)
            {
                FollowItem(SpawnedPoint[0], pointIcon);
            }
            else
            {
                pointIcon.enabled = false;
            }
        }
        else {
            pointIcon.enabled = false;

        }

        if (SpawnedBonus != null)
        {
            if (SpawnedBonus.Count > 0)
            {
                FollowItem(SpawnedBonus[0], bonusIcon);
            }
            else
            {
                bonusIcon.enabled = false;
            }
        }
        else {
            bonusIcon.enabled = false;

        }

        if (GameManager.instance.gameState != GameManager.GameState.game) {
            bonusIcon.enabled = false;
            missileIcon.enabled = false;
            pointIcon.enabled = false;
        }



    }


    void FollowItem(SpriteRenderer target, SpriteRenderer icon) {


        if (target.isVisible == false)
        {

            icon.enabled = true;

            Vector3 targetVector = Camera.main.WorldToScreenPoint(target.transform.position);

            float BoundOffset = 10; // The offset in pixel to define the bounds (icon will stay internally the bounds+offset)
            targetVector.x = Mathf.Clamp(targetVector.x, 0+ BoundOffset, screenW- BoundOffset);
            targetVector.y = Mathf.Clamp(targetVector.y, 0+ BoundOffset, screenH- BoundOffset);
            icon.transform.parent.position = Camera.main.ScreenToWorldPoint(targetVector);
            icon.transform.parent.LookAt(target.transform.position);

        }
        else
        {
          icon.enabled = false;

        }
    }


}
