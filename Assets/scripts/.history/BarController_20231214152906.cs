using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BarController : MonoBehaviour
{
    public GameObject centerObject;
    public GameObject manipulatorTip;
    public GameObject[] guidingPoints;
    public List<string> guidingPointNames;
    public GameObject currentCheckPoint; // set to the first one
    public string currentCheckPointName; 
    public GameObject targ;

    public float barWidth = 39.5f;
    public float thredshold = 0.5f;



    // Start is called before the first frame update
    void Start()
    {
        var Points = GameObject.Find("Guiding Points").GetComponentsInChildren<Transform>();
        guidingPoints = Points.Skip(1).Select(p => p.gameObject).ToArray();
        guidingPointNames = guidingPoints.Select(g => g.name).ToList();
        currentCheckPoint = guidingPoints[0];
        currentCheckPointName = guidingPointNames[0];
    }

    float Find_err(string pValue)
    {
        manipulatorTip = GameObject.FindGameObjectWithTag("Right_Controller");
        targ = GameObject.Find(pValue);
        Vector3 targ_pos = targ.transform.position;
        Vector3 tool_pos = manipulatorTip.transform.position;
        Vector3 div = targ_pos - tool_pos;
        centerObject = GameObject.Find("gun base");
        Vector3 div_vec = centerObject.transform.InverseTransformDirection(div);
        float err = div_vec[0];
        print("err is" + err);
        return err;
    }

    // Update is called once per frame
    void Update()
    {
        float err = Find_err(currentCheckPointName);
        // render to error UI

        Vector3 tool_pos = manipulatorTip.transform.position;
        Vector3 targ_pos = currentCheckPoint.transform.position;
        float distance = Vector3.Distance(tool_pos, targ_pos);

        if (distance < thredshold)
        {
            if (currentCheckPointName == guidingPointNames.Last())
            {
                IndicateSuccess();
            }
            else
            {
                int currentIndex = guidingPointNames.IndexOf(currentCheckPointName);
                currentIndex = currentIndex + 1;

                if(currentIndex < guidingPointNames.Count)
                {
                    currentCheckPoint = guidingPoints[currentIndex];
                    currentCheckPointName = guidingPointNames[currentIndex];
                }
            }
        }

        
        // err = Find_err(cur_targ)
  
        // 
        // 1. check the tool tip dist to cur targ
        //      2.2 if dist < thresh // zhao dao le
        //          {
        //              if cur_targ == p9
        //                  success
        //              else
        //                  current_check = list + 1
        //           }
        //          
        //
    }

    void IndicateSuccess()
    {
        Debug.Log("Success!");
    }
}
