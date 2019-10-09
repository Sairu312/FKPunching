using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KawaraScript : MonoBehaviour
{

    SpriteRenderer kawara;
    public Sprite kawaraOrigin;
    public Sprite kawaraBreak;


    public bool breakFlag;
   

    // Start is called before the first frame update
    void Start()
    {
        kawara = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (breakFlag)
        {
            kawara.sprite = kawaraBreak;
        }
        else
        {
            kawara.sprite = kawaraOrigin;
        }

    }
}
