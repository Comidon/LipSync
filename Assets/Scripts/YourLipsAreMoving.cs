using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourLipsAreMoving : MonoBehaviour
{
    public GameObject Upper;
    public GameObject Lower;

    float UpperYDelta, LowerYDelta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch firstTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);

            float yDelta0 = firstTouch.deltaPosition.y;
            float yDelta1 = secondTouch.deltaPosition.y;

            if ((yDelta0 < 0 && yDelta1 > 0) || (yDelta0 > 0 && yDelta1 < 0))
            {
                float yCur0 = firstTouch.position.y;
                float yCur1 = secondTouch.position.y;
                if (yCur0>yCur1)
                {
                    UpperYDelta = yDelta0;
                    LowerYDelta = yDelta1;
                }
                else
                {
                    UpperYDelta = yDelta1;
                    LowerYDelta = yDelta0;
                }
                ButYouLieLieLie();
            }
        }
    }

    //Your lips are moving
    private void ButYouLieLieLie()
    {
        Vector3 UpperDelta = new Vector3(0, UpperYDelta,0);
        Vector3 LowerDelta = new Vector3(0, LowerYDelta,0);

        Upper.transform.localPosition -= UpperDelta / 10;
        Lower.transform.localPosition -= LowerDelta / 10;

    }
}
