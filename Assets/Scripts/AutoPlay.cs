using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlay : MonoBehaviour
{
    GameObject upper;
    GameObject lower;

    private bool on = false;
    public LipController controller;

    private void Update()
    {
        //Upper.transform.localPosition = new Vector3(0, square_base + square_range[new_index - 1], 0);
        //Lower.transform.localPosition = new Vector3(0, -square_base - square_range[new_index - 1], 0);
    }
}
