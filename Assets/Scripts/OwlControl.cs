﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlControl : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("Who",Random.RandomRange(1,8));
    }
}
