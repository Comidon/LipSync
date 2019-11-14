using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlay : MonoBehaviour
{
    public GameObject upper;
    public GameObject lower;

    private bool on = false;
    public LipController controller;

    int currentState = 0;

    int prevState = 0;

    private float square_base = 0.8f;
    private float[] square_range = { 0f, 0.15f, 0.3f, 0.45f };

    public void Auto()
    {
        on = true;
    }

    private void Update()
    {
        float currentPos = SongDrawer.instance.GetOriginYPos();

        if (currentPos < 0.9)
        {
            upper.transform.localPosition = new Vector3(0, square_base + square_range[0], 0);
            lower.transform.localPosition = new Vector3(0, -square_base - square_range[0], 0);

            currentState = 0;
        }

        else if (currentPos < 1.05)
        {
            upper.transform.localPosition = new Vector3(0, square_base + square_range[1], 0);
            lower.transform.localPosition = new Vector3(0, -square_base - square_range[1], 0);

            currentState = 1;
        }

        else if (currentPos < 1.2)
        {
            upper.transform.localPosition = new Vector3(0, square_base + square_range[2], 0);
            lower.transform.localPosition = new Vector3(0, -square_base - square_range[2], 0);

            currentState = 2;
        }

        else
        {
            upper.transform.localPosition = new Vector3(0, square_base + square_range[3], 0);
            lower.transform.localPosition = new Vector3(0, -square_base - square_range[3], 0);

            currentState = 3;
        }

        if (prevState > currentState)
        {
            controller.PreviousState();
        }
        else if (prevState < currentState)
        {
            controller.NextState();
        }

        prevState = currentState;
    }
}
