using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeControl : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShakeThisObject(GameObject skeObject)
    {
        skeObject.GetComponent<AudienceControl>().ShakeMe();
    }
}
