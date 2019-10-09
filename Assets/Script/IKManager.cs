using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : MonoBehaviour
{
    //ジョイント格納用可変リスト
    public List<GameObject> joints;
    public GameObject jointPrefab;
    public List<JointScript> jointScripts;

    public Vector3 punchSpeed;

    public Vector3 childPosition = new Vector3(0f, 0.5f, 0);

    public GameObject checkMark;
    public GameObject tip;

    public int selectJointNum = 0;
    public GameObject selectJoint;
    public JointScript selectJointScript;
    public GameManager gameManager;
    public TipScript tipScript;
    public SliderScript sliderScript;
    GameObject slider;
    public Vector3 firstJointPoint;

    public int test;

    // Start is called before the first frame update
    public void IKSetUp(int jointSum)
    {
        gameManager = GetComponent<GameManager>();
        joints = new List<GameObject>();
        jointScripts = new List<JointScript>();
        slider = GameObject.Find("Slider");
        sliderScript = slider.GetComponent<SliderScript>();

        for (int i=0;i<jointSum; i++)
        {
            AddJoint(i);
        }
        if (joints.Count <= 0) return;
        tip.transform.parent = joints[jointSum - 1].transform;
        tipScript = tip.GetComponent<TipScript>();

        joints[0].transform.position = firstJointPoint;

    }

    private void Start()
    {
        SelectJoint(selectJointNum);
        test = 0;
    }
    private void Update()
    {
        punchSpeed = tipScript.speed;
        IKInput();
    }

    public void IKInput()
    {
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            selectJointNum++;
            SelectJoint((selectJointNum-1) % gameManager.jointNum);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selectJointNum--;
            SelectJoint((selectJointNum-1) % gameManager.jointNum);
        }
        */
        JointRotation(sliderScript.nowInput);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Speed:" + punchSpeed);
        }
    }
   

    public void OnClickNext()
    {
        selectJointNum++;
        SelectJoint((selectJointNum) % gameManager.jointNum);
        test = 5;
    }

    

    


    void AddJoint(int myJoinNum)
    {
        GameObject obj = (GameObject)Instantiate(jointPrefab, transform.position, Quaternion.identity);
        obj.name = "Joint" + myJoinNum;
        if (myJoinNum > 0)
        {
            obj.transform.parent = joints[myJoinNum - 1].transform;
            obj.transform.localPosition = childPosition;
        }
        joints.Add(obj);
    }

    void SelectJoint(int jointNum)
    {
        selectJoint = joints[jointNum];
        selectJointScript = selectJoint.GetComponent<JointScript>();
        checkMark.transform.parent = selectJoint.transform;
        sliderScript.SetRotSlider(selectJointScript.rotin);
    }

    void JointRotation(float rot)
    {
        if (Mathf.Abs(rot) > 1) return;
        selectJointScript.rotin = rot;
    }

    
}
