using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdmobHandler : MonoBehaviour {
	bool AlreadyInitialized;
	string Banner_AD_ID;
	string Interstitial_AD_ID;
	InterstitialAd interstitialADMOB;
	BannerView bannerView;
	AdPosition adpos;



	public void Initialize(string banner_id,string interstitial_id,bool useInterstitial){
		if (AlreadyInitialized) {
			return;
		}

		Banner_AD_ID = banner_id;
		Interstitial_AD_ID = interstitial_id;

		if (useInterstitial) {
		
			PrecacheNextInterstitial();
		
			AlreadyInitialized = true;
		
		}



	}


	public void ShowBanner(int position){
		if (position==1)
			adpos = AdPosition.Bottom;
		if (position==2)
			adpos = AdPosition.Top;
		if (position==3)
			adpos = AdPosition.BottomLeft;
		if (position==4)
			adpos = AdPosition.BottomRight;
		if (position==5)
			adpos = AdPosition.TopLeft;
		if (position==6)
			adpos = AdPosition.TopRight;
	

		string adUnitId = Banner_AD_ID;



		if (bannerView == null) {
			// Create a 320x50 banner at the top of the screen.
			bannerView = new BannerView (adUnitId, AdSize.SmartBanner, adpos);
			// Create an empty ad request.
			AdRequest request = new AdRequest.Builder ().Build ();
			// Load the banner with the request.
			bannerView.LoadAd (request);
		} else {
			bannerView.Show();}


	}


	public void HideBanner(){
        try {
            bannerView.Hide();
        }
        catch
        {
            
        }
        	}

	public void ShowInterstitial(){

		interstitialADMOB.Show ();

		PrecacheNextInterstitial ();
	}


	private void PrecacheNextInterstitial(){
		interstitialADMOB = new InterstitialAd (Interstitial_AD_ID);
		AdRequest request = new AdRequest.Builder ().Build ();
		interstitialADMOB.LoadAd (request);
	}




}
