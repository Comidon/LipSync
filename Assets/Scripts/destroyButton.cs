using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyButton : MonoBehaviour
{
    private GameObject destroyInstruct;
    // Start is called before the first frame update
    void Start()
    {
        destroyInstruct = GameObject.Find("Instructions");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyButton()
    {
        Destroy(gameObject);
        Destroy(GameObject.Find("Instructions"));
    }
}
