using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuGUI : MonoBehaviour {

    public static MainMenuGUI instance;

    public Text highscoreText;
    public Text gamesPlayedText;

    string originalHighScoreText;
    string originalGamesPlayedText;
    void Awake()
    {

        instance = this;
        originalHighScoreText = highscoreText.text;
        originalGamesPlayedText = gamesPlayedText.text;
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        highscoreText.text = originalHighScoreText + ScoreHandler.instance.highScore;
        gamesPlayedText.text = originalGamesPlayedText + ScoreHandler.instance.numberOfGames;
    }

    public void OnShopButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();

        gameObject.SetActive(false);
        GUIManager.instance.ShowShopGUI();
    }

    public void OnPlayButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();
		AdNetworks.instance.HideBanner ();
        GameManager.instance.StartGame();
        gameObject.SetActive(false);
    }

    public void OnRateButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();

        RateManager.instance.rateGame();
    }

	void OnEnable(){

		AdNetworks.instance.ShowBanner();

	}

}
