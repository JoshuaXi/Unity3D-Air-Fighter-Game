using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
  
    public enum GameState {menu,game,gameover,shop}
    public GameState gameState;
    public bool oneMoreChanceUsed = false;



    void Awake()
    {
        Application.targetFrameRate = 60;
        instance = this;
    }
	// Use this for initialization
	void Start () {
            
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator GameOverCoroutine(float delay)
    {

        yield return new WaitForSeconds(delay);
        SoundsManager.instance.PlayGameOverSound();
        AdNetworks.instance.HideBanner();
        gameState = GameState.gameover;
        if (oneMoreChanceUsed)
        {
            AdNetworks.instance.ShowInterstitial();

            ScoreHandler.instance.increaseScore((int)Timer.instance.timer);
            Leaderboard.instance.reportScore(ScoreHandler.instance.score);
            GUIManager.instance.ShowGameOverGUI();
            InGameGUI.instance.gameObject.SetActive(false);
        }
        else
        {
            GUIManager.instance.ShowOneMoreChanceGUI();
        }
    }


    public void GameOver(float delay)
    {
        StartCoroutine(GameOverCoroutine(delay));
    }

   public void StartGame(bool resetScore = true, bool resetOneMoreChance = true)
    {
        ResetGame(resetScore,resetOneMoreChance);

        SpawnerManager.instance.coinspawner.CallSpawnItem(0);

        ScoreHandler.instance.incrementNumberOfGames();
        GUIManager.instance.ShowInGameGUI();
       // GUIManager.instance.tutorialGUI.ShowIfNeverAppeared();
        gameState = GameState.game;
    }

    public void ResetGame(bool resetScore = true,bool resetOneMoreChance = true)
    {

        if (Plane.instance == null)
        {
            PlayerManager.instance.SpawnNewPlane();
        }

        ItemDestroyer.instance.ClearAllItems();

        if (resetOneMoreChance)
        {
            oneMoreChanceUsed = false;
        }

        if (resetScore)
        {
            ScoreHandler.instance.reset();
            Timer.instance.ResetTimer();
        }
    }


}
