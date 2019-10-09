using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipScript : MonoBehaviour
{
    Vector3 latestPos;
    public Vector3   speed;

    

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0,0.5f,0);
        speed = ((transform.position - latestPos) / Time.deltaTime);
        latestPos = transform.position;
    }
}
