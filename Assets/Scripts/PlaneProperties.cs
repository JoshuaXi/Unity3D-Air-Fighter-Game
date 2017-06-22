using UnityEngine;
using System.Collections;

public class PlaneProperties : MonoBehaviour {
    public Plane plane;
    public PlaneController planeController;
    public SpriteRenderer planeSprite;
    ShopItem savedShopItem;
    // Use this for initialization

    void Update() {
       
            if (savedShopItem != ShopHandler.instance.shopItemToUse) {
            StartCoroutine(takeShopItem());
                
                    }
    }

    IEnumerator takeShopItem() {

        ShopItem current = null;

        while (current == null)
        {
            current = ShopHandler.instance.shopItemToUse;
            yield return new WaitForEndOfFrame();
        }

        ShopItemProperties currentProperties = current.gameObject.GetComponent<ShopItemProperties>();


        planeController.SpeedMultiplier = currentProperties.SpeedMultiplier;

        planeController.steeringPower = currentProperties.steeringPower;

        planeSprite.sprite = currentProperties.spriteImage;
        savedShopItem = current;

    }


}
