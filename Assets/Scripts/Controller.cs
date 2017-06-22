using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public GameObject MainController;
    public static Controller instance;

    public Transform center, stick;

    void Awake()
    {
        instance = this;

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(MainController.activeInHierarchy && GameManager.instance.gameState != GameManager.GameState.game)
        {
            MainController.SetActive(false);
        }
        else if(!MainController.activeInHierarchy && GameManager.instance.gameState == GameManager.GameState.game)
        {
            MainController.SetActive(true);
        }


	}
}
