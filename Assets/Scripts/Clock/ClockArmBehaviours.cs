﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockArmBehaviours : MonoBehaviour
{
    public float spinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, spinSpeed * Time.deltaTime,0));
    }
}
