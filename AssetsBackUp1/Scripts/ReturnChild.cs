using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnChild : MonoBehaviour
{

    private void Start()
    {
        Debug.Log(transform.childCount);
    }
    public List<GameObject> ReturnChildren()
    {
        List<GameObject> children = new List<GameObject>();
        for (int i = 0; i < transform.childCount-1; i++)
        {
            children.Add(transform.GetChild(i).gameObject);
        }
        Debug.Log("WHY THIS NO WORK!?");
        return children;
    }

}
