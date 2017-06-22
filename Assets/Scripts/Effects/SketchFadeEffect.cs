using UnityEngine;
using System.Collections;

public class SketchFadeEffect : MonoBehaviour {

    public SpriteRenderer sprite;
   public  float fadeTimer = 5;
    void Start() {
        if (transform.root.name.Contains("Missile")) return;
        transform.parent.transform.parent = SketchLinesContainer.instance.transform;
        sprite.color = Color.white;
        StartCoroutine(spriteEffect());

    }


    IEnumerator spriteEffect() {

        yield return new WaitForSeconds(fadeTimer);

        float lerper = 0;
        float lerpTime = 1;
        Color targetColor = sprite.color;
        Color startColor = sprite.color;
        targetColor.a = 0;

        while (lerper < 1) {


            lerper += Time.deltaTime / lerpTime;
            sprite.color = Color.Lerp(startColor, targetColor, lerper);
            yield return new WaitForEndOfFrame();

        }



        Destroy(transform.parent.gameObject);

    }


}
