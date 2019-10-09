using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointScript : MonoBehaviour
{
    public float rotin = 0;
    public float rotSum;
    public int myJointNum;

    public void Update()
	{
        rotSum += rotin* 1.5f;
        //rotSum += rot;
        if (Mathf.Abs(rotSum) > 360) rotSum -= 360f;
        transform.localRotation = Quaternion.Euler(0, 0, rotSum);
	}
}
