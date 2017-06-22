using UnityEngine;
using System.Collections;

public class SoundsManager : MonoBehaviour
{
    public AudioSource FootStepsAudioSource;
    public AudioSource RopeDropAudioSource;
    public AudioSource LandAudioSource;
    public AudioSource PerfectLandAudioSource;
    public AudioSource DiamondAudioSource;
    public AudioSource DeathAudioSource;
    public AudioSource GameOverAudioSource;
    public AudioSource MenuButtonAudioSource;





    public static SoundsManager instance;

    bool cannotExecuteSound;
    float timeToBePaused = 0.1f;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlayAudioSource(AudioSource audioSource)
    {

        audioSource.Play();

    }

    IEnumerator CanExecuteCountDown()
    {
        cannotExecuteSound = true;
        yield return new WaitForSeconds(timeToBePaused);
        cannotExecuteSound = false;
    }


    public void PlayWalkSound()
    {
        if (!FootStepsAudioSource.isPlaying)
        {
            FootStepsAudioSource.Play();
        }
    }

    public void PauseWalkSound()
    {
        if (FootStepsAudioSource.isPlaying)
        {
            FootStepsAudioSource.Pause();
        }
    }

    public void PlayRopeDropSound()
    {
        RopeDropAudioSource.Play();
    }

    public void PlayLandingSound()
    {
        LandAudioSource.Play();
    }

    public void PlayPerfectLandingSound()
    {
        PerfectLandAudioSource.Play();
    }

    public void PlayDeathSound()
    {
        DeathAudioSource.Play();
    }

    public void PlayGameOverSound()
    {
        GameOverAudioSource.Play();
    }

    public void PlayDiamondSound()
    {
        DiamondAudioSource.Play();
    }

    public void PlayMenuButtonSound()
    {
        MenuButtonAudioSource.Play();
    }

}
