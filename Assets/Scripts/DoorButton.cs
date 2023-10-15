using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] GameObject wall;
    [SerializeField] GameObject button;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        wall.SetActive(false);
        button.transform.localScale = new Vector3(.9f,.9f,transform.localScale.z);
    }

    public void Reset()
    {
        wall.SetActive(true);
        button.transform.localScale = new Vector3(1f, 1f, transform.localScale.z);
        Debug.Log("BOP!");
    }
}
