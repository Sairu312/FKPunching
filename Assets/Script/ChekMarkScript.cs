﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekMarkScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
