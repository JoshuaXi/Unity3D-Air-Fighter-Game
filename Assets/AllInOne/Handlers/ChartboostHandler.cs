using UnityEngine;
using System.Collections;
using ChartboostSDK;


public class ChartboostHandler : MonoBehaviour {
	string app_ID;
	string app_Signature;

	// Use this for initialization
	public void Initialize(string appId, string appSignature, GameObject mainController){
		app_ID = appId;
		app_Signature = appSignature;
		CBSettings settings = new CBSettings ();


		#if UNITY_ANDROID
			settings.SetAndroidAppId (app_ID);
			settings.SetAndroidAppSecret (app_Signature);

		#endif

		#if UNITY_IOS
			settings.SetIOSAppId (app_ID);
			settings.SetIOSAppSecret (app_Signature);
		#endif



	

		mainController.AddComponent<Chartboost> ();

		Chartboost.cacheInterstitial (CBLocation.Default);

	}

	public void ShowInterstitial(){
		Chartboost.showInterstitial (CBLocation.Default);
		// caching is useless because Chartboost.setAutoCacheAds (); is true by default

	}


}
