using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class RewardedVideoBtn : MonoBehaviour, IUnityAdsListener
{


    private string googleStoreID = "3433505";
    private string appleStoreID = "3433504";

    [SerializeField] bool isPlayStore = true;
    [SerializeField] bool isTestAd = true;

    
    [SerializeField] string myPlacementId = "rewardedVideo";

    [SerializeField] Manager manager;

 
    void Start()
    {
        

        // Set interactivity to be dependent on the Placement’s status:
        

        // Map the ShowRewardedVideo function to the button’s click listener:
        

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        InitializeMon();
    }

    private void InitializeMon()
    {
        if (isPlayStore)
        {
            Advertisement.Initialize(googleStoreID, isTestAd);
            return;
        }
        Advertisement.Initialize(appleStoreID, isTestAd);
    }

    // Implement a function for showing a rewarded video ad:
    public void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    

    void IUnityAdsListener.OnUnityAdsReady(string placementId)
    {
       
    }

   

    void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            manager.AddStars(10);
        }
    }

   void IUnityAdsListener.OnUnityAdsDidStart(string placementId)
   {

   }

    void IUnityAdsListener.OnUnityAdsDidError(string message)
    {

    }

    


}
