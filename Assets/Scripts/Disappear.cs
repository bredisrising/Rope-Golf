using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    [SerializeField] float sec;
    [SerializeField] bool activeFirst;

    LineRenderer line;
    EdgeCollider2D collideR;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        collideR = GetComponent<EdgeCollider2D>();

        if (activeFirst)
        {
            StartCoroutine(SetActive(sec));
        }
        else
        {
            StartCoroutine(SetNotActive(sec));
        }
        
    }







    IEnumerator SetActive(float sec)
    {

        yield return new WaitForSeconds(sec);

        line.enabled = true;
        collideR.enabled = true;
        StartCoroutine(SetNotActive(sec));

        //Do Function here...
    }

    IEnumerator SetNotActive(float sec)
    {

        yield return new WaitForSeconds(sec);

        line.enabled = false;
        collideR.enabled = false;
        StartCoroutine(SetActive(sec));
        //Do Function here...
    }

}
