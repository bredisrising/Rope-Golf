using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdManager : MonoBehaviour
{
    private string googleStoreID = "3433505";
    private string appleStoreID = "3433504";
    
    

    //set to false if launching appstore
    [SerializeField] bool isPlayStore;

    //set to false when launching game
    [SerializeField] bool isTestAd;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Ads");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }



        DontDestroyOnLoad(this.gameObject);

    }


    private void Start()
    {
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

   

    public IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.IsReady())
        {
            yield return new WaitForSeconds(.5f);
        }

        Advertisement.Show();
        
        
    }

  


}
