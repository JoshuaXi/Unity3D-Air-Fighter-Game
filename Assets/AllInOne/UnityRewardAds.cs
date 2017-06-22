using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityRewardAds : MonoBehaviour
{

    public int minCoinsToRewardOnVideoWatched = 3;
    public int maxCoinsToRewardOnVideoWatched = 3;

    public static UnityRewardAds instance;

    public string rewardVideoID;

    void Awake()
    {
        instance = this;
    }

	public void ShowRewardedAd (System.Action<ShowResult> callaBack)
	    {
       	 if (Advertisement.IsReady(rewardVideoID))
       	 {
            var options = new ShowOptions { resultCallback = callaBack };
            Advertisement.Show(rewardVideoID, options);
       	 }
   	 }



    public int GetCoinsToRewardOnVideoWatched()
    {
        return Random.Range(minCoinsToRewardOnVideoWatched, maxCoinsToRewardOnVideoWatched);
    }




}
