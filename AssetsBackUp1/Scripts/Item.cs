using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int cost;
    [SerializeField] ShopManager shopManager;
    public int itemNum;

    public bool hasBeenBought;
    public bool isEquiped = false;


    private void Awake()
    {
        if (PlayerPrefs.HasKey("bought" + itemNum))
        {
            if (PlayerPrefs.GetInt("bought" + itemNum) == 1)
            {
                hasBeenBought = true;
            }
            else
            {
                hasBeenBought = false;
            }
        }
        else
        {
            hasBeenBought = false;
        }
    }



    public void DoStuff()
    {

        if (hasBeenBought)
        {
            shopManager.Equip(this.gameObject);
            
        }

        else if (!hasBeenBought)
        {
            shopManager.Buy(this.gameObject);
            
        }

    }
}
