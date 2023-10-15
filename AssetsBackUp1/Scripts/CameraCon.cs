using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    Camera cam;
    
    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;

    }

    public IEnumerator Zoom(float duration, float val)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {



            cam.orthographicSize += val; ;

            elapsed += Time.deltaTime;

            yield return null;
        }

        

    }

    private void Update()
    {
        
    }





}
