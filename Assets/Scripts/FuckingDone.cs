using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuckingDone : MonoBehaviour
{
    public GameObject ResultFPanel;
    public Text Line1;
    public Text Line2;

    private string Win = "Congratulations! You score is: ";
    private string Lose = "Haha, loser! Your score is: ";

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
            Line1.text = Win;
        }
        else
        {
            Line1.text = Lose;
        }

        Line2.text = Mathf.Round(point).ToString();

        ResultFPanel.SetActive(true);
    }
}
