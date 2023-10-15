using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    [SerializeField] Manager manager;

    [SerializeField] GameObject[] items;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("equip"))
        {
            items[PlayerPrefs.GetInt("equip")-1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        
    }

    public void Equip(GameObject skin)
    {
        
        

        

        PlayerPrefs.SetInt("equip", skin.GetComponent<Item>().itemNum);
        

        foreach (GameObject item in items){
            item.GetComponent<Image>().color = new Color32(255,255,255,130);
        }

        

        skin.GetComponent<Image>().color = new Color32(255,255,255,255);
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


            foreach (GameObject item in items)
            {
                
                item.GetComponent<Image>().color = new Color32(255, 255, 255,130);
            }




            skin.GetComponent<Image>().color = new Color32(255, 255, 255,255);

        }
    }




}
