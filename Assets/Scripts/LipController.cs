using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LipController : MonoBehaviour
{
    public GameObject[] Lips;

    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (Lips.Length > 1)
        {
            for(var i = 1; i < Lips.Length; i++)
            {
                Lips[i].GetComponent<Image>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextState()
    {
        if (index + 1 <= 3)
        {
            Lips[index].GetComponent<Image>().enabled = false;
            Lips[++index].GetComponent<Image>().enabled = true;
        }
        Update();
    }

    public void PreviousState()
    {
        if (index - 1 >= 0)
        {
            Lips[index].GetComponent<Image>().enabled = false;
            Lips[--index].GetComponent<Image>().enabled = true;
        }
        Update();
    }
}
