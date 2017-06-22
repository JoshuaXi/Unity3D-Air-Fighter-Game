using UnityEngine;
using System.Collections;

public class ShopItemProperties : MonoBehaviour {

    public SpriteRenderer sprite;
    public float SpeedMultiplier = 2;
    public float steeringPower = 180;
    [HideInInspector]
    public Sprite spriteImage;
    void Awake()
    {
        spriteImage = sprite.sprite;

    }





}
