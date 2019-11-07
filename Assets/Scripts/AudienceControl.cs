using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceControl : MonoBehaviour
{
    private bool shaking = true;
    private float shakeAmt = 5f;
   

    private void Update()
    {
        
        if (shaking)
        {
            Vector3 newPos = transform.position + Random.insideUnitSphere * (Time.deltaTime * shakeAmt);
            newPos.z = transform.position.z;
            transform.position = newPos;
          
        }
    }
    public void ShakeMe()
    {
        StartCoroutine("ShakeNow");
    }

    IEnumerator ShakeNow()
    {
        Vector3 originalPos = transform.position;
        if(shaking == false)
        {
            shaking = true;
        }
        yield return new WaitForSeconds(2.5f);

        shaking = false;
        transform.position = originalPos;
            
    }
        
}
