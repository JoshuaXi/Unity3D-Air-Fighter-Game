using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseGUI : MonoBehaviour {

    public Button soundButton;
    public Sprite soundEnabledImage;
    public Sprite soundDisabledImage;

    public void OnCloseButtonClick()
    {
        Deactivate();
    }

    public void Activate()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void onHomeButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();

        GUIManager.instance.ShowMainMenuGUI();
        GameManager.instance.StopAllCoroutines();
        InGameGUI.instance.gameObject.SetActive(false);
        Deactivate();
    }

    public void OnSoundButtonClick()
    {
        if (AudioListener.volume == 0)
        {
            soundButton.image.sprite = soundEnabledImage;
            AudioListener.volume = 1;
        }
        else
        {
            soundButton.image.sprite = soundDisabledImage;
            AudioListener.volume = 0;
        }
    }


}
