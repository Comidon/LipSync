using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceControl : MonoBehaviour
{
    private bool shaking = true;
    public static float shakeAmt;
    private float tempShake = 100f;

    private void Update()
    {
        if(PlayerManager.instance.GetPoints()>=0)
        {
            shakeAmt = PlayerManager.instance.GetPoints()/10;
        }
        else if(PlayerManager.instance.GetPoints() < 0)
        {
            shakeAmt = 0;
        }
        /*if(tempShake<shakeAmt)
        {
            shaking = true;
            tempShake = shakeAmt;
        }
        else if(tempShake>=shakeAmt)
        {
            shaking = false;
            tempShake = shakeAmt;
        }*/
        if (shaking)
        {
            Vector3 newPos = transform.position + Random.insideUnitSphere * (Time.deltaTime * (shakeAmt));
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
