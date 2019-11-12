using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceControl : MonoBehaviour
{
    private bool shaking = false;
    public static float shakeAmt;
    private float tempShake = 100f;

    private void Update()
    {
        if(PlayerManager.instance.GetPoints()>=0)
        {
            //shaking = true;
            shakeAmt = PlayerManager.instance.GetPoints();
        }
        else if(PlayerManager.instance.GetPoints() < 0)
        {
            //shaking = false;
            shakeAmt = 0;
        }
        if(tempShake<shakeAmt)
        {
            shaking = true;
            //tempShake = shakeAmt;
        }
        else if(tempShake>=shakeAmt)
        {
            shaking = false;
            tempShake = shakeAmt;
        }
        if (shaking)
        {
            Vector3 newPos = transform.position + Random.insideUnitSphere * (Time.deltaTime * (shakeAmt - tempShake)*70);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;
            transform.position = newPos;
            tempShake = shakeAmt;
          
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
