using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class OneMoreChanceGUI : MonoBehaviour {



    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Activate()
    {
        gameObject.SetActive(true);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

     public void OnOneMoreChanceButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();

		if (Advertisement.IsReady ()) {
			UnityRewardAds.instance.ShowRewardedAd (HandleShowResult);
			GameManager.instance.gameState = GameManager.GameState.game;
			GameManager.instance.oneMoreChanceUsed = true;
			GameManager.instance.StartGame (false, false);  
			Deactivate();
		} else {
			MobileNativeMessage msg = new MobileNativeMessage("Error", "To use this feature please enable your internet connection");
		}
    }

    public void OnGameOverButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();

        Deactivate();
        GameManager.instance.oneMoreChanceUsed = true;
        GameManager.instance.GameOver(0);
    }


    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:

                
                GameManager.instance.gameState = GameManager.GameState.game;
                GameManager.instance.oneMoreChanceUsed = true;
                GameManager.instance.StartGame(false,false);

                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                
                   GameManager.instance.gameState = GameManager.GameState.game;
                   GameManager.instance.oneMoreChanceUsed = true;
                   GameManager.instance.StartGame(false, false);
                   
                break;
            case ShowResult.Failed:
                
                      GameManager.instance.gameState = GameManager.GameState.game;
                      GameManager.instance.oneMoreChanceUsed = true;
                      GameManager.instance.StartGame(false, false);
                      
                break;
        }
    }

}
