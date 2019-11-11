using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YourLipsAreMoving : MonoBehaviour, IPerformanceArtist
{
    public GameObject Upper;
    public GameObject Lower;

    public GameObject LipAnimation;

    float UpperYDelta;

    private LipController controller;

    private int previous_index = 0;
    private float[] range = {0, 3, 6, 9, 12 };
    private float square_base = 0.8f;
    private float[] square_range = { 0f, 0.15f, 0.3f, 0.45f };

    // Start is called before the first frame update
    void Start()
    {
        controller = LipAnimation.GetComponent<LipController>();
        square_base = Upper.transform.localPosition.y;
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
                //print(UpperYDelta);
                float yCur0 = firstTouch.position.y;
                float yCur1 = secondTouch.position.y;
                if (yCur0>yCur1)
                {
                    UpperYDelta += yDelta0;
                }
                else
                {
                    UpperYDelta += yDelta1;
                }
                ButYouLieLieLie();
            }
        }
    }

    //Your lips are moving
    private void ButYouLieLieLie()
    {
        int new_index = 1;
        for(; new_index < 4; new_index++)
        {
            if (UpperYDelta < range[new_index])
            {
                break;
            }
        }

        if (new_index > previous_index)
        {
            if (UpperYDelta > range[range.Length-1])
            {
                UpperYDelta = range[range.Length-1];
            }
            for(var i = previous_index; i < new_index; i++)
            {
                controller.NextState();
                Upper.transform.localPosition = new Vector3(0, square_base + square_range[i], 0);
            }
        }else if (new_index < previous_index)
        {
            if (UpperYDelta < range[0])
            {
                UpperYDelta = range[0];
            }
            for (var i = previous_index-1; i >= new_index; i--)
            {
                controller.PreviousState();
                Upper.transform.localPosition = new Vector3(0, square_base + square_range[i], 0);
            }
        }

        previous_index = new_index;

        //print(new_index);
        Upper.transform.localPosition = new Vector3(0, square_base + square_range[new_index - 1], 0);
        Lower.transform.localPosition = new Vector3(0, -square_base - square_range[new_index - 1], 0);
    }

    public Vector3 GetLipsPosition()
    {
        return Upper.transform.localPosition;
    }
}
