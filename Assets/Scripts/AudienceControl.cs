using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceControl : MonoBehaviour
{
    private bool shaking = false;
    public static bool shakingN = false;
    public static float shakeAmt;
    private float tempShake = 100f;
    Animator animator;

    private void Start()
    {
       animator = GetComponent<Animator>();
    }
    

    private void Update()
    {
        if(PlayerManager.instance.GetPoints()>=70)
        {
            animator.SetTrigger("DoesWell");
        }
        if (PlayerManager.instance.GetPoints() >= 0)
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
            ShakeMe();
            /*Vector3 newPos = transform.position + Random.insideUnitSphere * (Time.deltaTime * (shakeAmt - tempShake)*50);
            newPos.x = transform.position.x;
            newPos.z = transform.position.z;
            transform.position = newPos;
            tempShake = shakeAmt;*/
          
        }
        if(shakingN)
        {
            Vector3 newPos = transform.position + Random.insideUnitSphere * (Time.deltaTime * (shakeAmt - tempShake) * 30);
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
        if(shakingN == false)
        {
            shakingN = true;
        }
        yield return new WaitForSeconds(0.25f);

        shakingN = false;
        transform.position = originalPos;
            
    }
        
}
