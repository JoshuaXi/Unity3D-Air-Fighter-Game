using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Plus10Text : MonoBehaviour {

    public static Plus10Text instance;
    Text text;
    Color originalColor;

    void Awake()
    {
        instance = this;
        text = GetComponent<Text>();
        originalColor = text.color;
        text.enabled = false;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void Show(string value)
    {
        text.enabled = true;
        text.text = "+" + value;
        text.color = originalColor;
        StartCoroutine(FadeOut());
    }


    public IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1);
        Color targetColor = originalColor;
        targetColor.a = 0;
        float lerper = 0;
        float lerpTime = 1;
        while(lerper<1)            
        {
            lerper += Time.deltaTime / lerpTime;

            text.color = Color.Lerp(originalColor, targetColor, lerper);
            yield return new WaitForEndOfFrame();
        }

        text.enabled = false;
    }



}
