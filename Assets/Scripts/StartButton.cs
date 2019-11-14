using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button Text;
    public Animator ani;
   



    void Start()
    {
        Text = Text.GetComponent<Button>();
        ani.enabled = false;
        
    }


    public void Press()

    {
        Text.enabled = true;
        ani.enabled = true;


    }
}
