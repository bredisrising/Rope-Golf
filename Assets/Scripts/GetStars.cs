using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetStars : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("stars"))
        {
            text.text = PlayerPrefs.GetInt("stars").ToString();
        }
        else
        {
            text.text = "0";
        }
        
    }


 
    
}
