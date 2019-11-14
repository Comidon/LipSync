using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuckingDone : MonoBehaviour
{
    public GameObject ResultFPanel;
    public Text Line1;
    public Text Line2;

    private string Win = "Congratulations! Your score is: ";
    private string Lose = "Haha, loser! Your score is: ";
    private string YouAreA = ".\nYou are a: ";

    // Start is called before the first frame update
    void Start()
    {
        ResultFPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowFResult()
    {
        float point = PlayerManager.instance.GetPoints();
        if (point > 80)
        {
            Line1.text = Win+ Mathf.Round(point).ToString();
            Line2.text = "Super Star";
        }
        else if (point > 60 && point <= 80)
        {
            Line1.text = Lose+ Mathf.Round(point).ToString();
            Line2.text = "Amateur";
        }
        else
        {
            Line1.text = Lose+ Mathf.Round(point).ToString();
            Line2.text = "Fraud";
        }

        Line1.text += YouAreA;

        ResultFPanel.SetActive(true);
    }
}
