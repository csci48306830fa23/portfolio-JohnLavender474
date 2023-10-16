using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using VelUtils.VRInteraction;

public class CanKnockdown : MonoBehaviour
{
    [SerializeField]
    GameObject[] cans;
    int knockdownCount = 0;
    [SerializeField]
    TMP_Text infoText;

    [SerializeField]
    Transform Pedestal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int tempCount = 0;
        for(int i = 0; i < cans.Length; i++) 
        {
            Vector3 canUp = cans[i].transform.up;
            float upAngle = Vector3.Angle(canUp, Vector3.up);
            Vector3 canPos = cans[i].transform.position;
            Vector3 pedTopPos = Pedestal.position;
            Vector3 canToPed = canPos - pedTopPos; //vector from pedestal center/top to can origin
            if(upAngle > 20 || canToPed.y < 0)
            {
                tempCount++;
            }
        }
        //this is where we can detect change
        knockdownCount = tempCount;
        infoText.text = "Cans Knocked: " + knockdownCount;
        if(knockdownCount == cans.Length)
        {
            //game over
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Ball ball = other.attachedRigidbody?.GetComponent<Ball>();
    //    if (ball != null)
    //    {
    //        VRMoveable moveable = ball.GetComponent<VRMoveable>();
   //         if (moveable.GrabbedBy != null)
   //         {
   //             //this is being held
   //             moveable.GrabbedBy.Release();
   //             GameObject.Destroy(moveable.gameObject);
   //         }   
  //      }
 //   }
  
}
