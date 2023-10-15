using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    [SerializeField] Manager manager;

    
    public void Equip(GameObject skin)
    {
        
        

        

        PlayerPrefs.SetInt("equip", skin.GetComponent<Item>().itemNum);
    }

    public void Buy(GameObject skin)
    {
        Item skinItem = skin.GetComponent<Item>();


        if (manager.numStars >= skinItem.cost)
        {
            manager.LoseStars(skin.GetComponent<Item>().cost);
            

            

            PlayerPrefs.SetInt("equip", skinItem.itemNum);

            skinItem.hasBeenBought = true;

            PlayerPrefs.SetInt("bought" + skinItem.itemNum, 1);

        }
    }




}
