using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int jointNum = 3;

    public int kawaraNum = 100;

    public GameObject kawara;

    public int breakNum = 0;

    public GameObject[] kawaraArray;
    public static GameManager instance = null;
    public IKManager ikManagerScript;
    public bool punchFlag = false;

    public float TimeCount = 0.1f;
    int Count = 0;
    int punchPower = 0;
    public Camera mainCam;
    public bool finishFlag = false;
    public Text scoreText;


    private void Awake()
    {
        /*
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        */


        kawaraArray = new GameObject[kawaraNum];
        ikManagerScript = GetComponent<IKManager>();
        InitGame();

        KawaraSetup();

    }


    void InitGame()
    {
        ikManagerScript.IKSetUp(jointNum);
    }

    void KawaraSetup()
    {
        for(int i = 0; i < kawaraNum; i++)
        {
            kawaraArray[i] = Instantiate(kawara, new Vector3(0f, i * (-0.5f), 0f), Quaternion.identity)as GameObject;
        }
    }



    private void Update()
    {
        if (!punchFlag && Input.GetKeyDown(KeyCode.Space))
        {
            punchFlag = true;
            punchPower = GetIKSpeed();
            if (punchPower <= 0)
            {
                punchFlag = false;
            }
        }
        if(punchFlag && punchPower > 0)
        {
            TimeCount -= Time.deltaTime;
            if (TimeCount <= 0)
            {
                KawaraBreak(punchPower);
                TimeCount = 0.1f;
            }
            mainCam.transform.position = Vector3.Lerp(new Vector3(kawaraArray[Count].transform.position.x,
                                                                  kawaraArray[Count].transform.position.y,
                                                                  -5f),
                                                      new Vector3(kawaraArray[Count+1].transform.position.x,
                                                                  kawaraArray[Count+1].transform.position.y,
                                                                  -5f),0.1f);
        }
        if (finishFlag)
        {
            scoreText.text = punchPower.ToString() + "枚！";
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Scenes/Title");
            }
        }
        

    }

    void KawaraBreak(int breakNum)
    {
        kawaraArray[Count].GetComponent<KawaraScript>().breakFlag = true;
        if (Count <= breakNum)
            Count += 1;
        else finishFlag = true;
    }

    int GetIKSpeed()
    {
        int speed = Mathf.FloorToInt(GetComponent<IKManager>().punchSpeed.y * -1);
        speed *= 2;
        return speed;
    }

}
