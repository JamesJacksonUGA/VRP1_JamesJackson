using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public OVRInput.Controller myController; 
    PickupObject currentAttachment = null;
    public float pickupTriggerThreshold;
    public float releaseTriggerThreshold;
    
    // Start is called before the first frame update
    void Start() { 


        
    }
    float triggerValue;
    // Update is called once per frame
    void Update()
    {
    
    triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        
    Debug.Log("Left value is  " + triggerValue);
}

    //private void OnTriggerEnter(Collider other) {
    //    Debug.Log("Trigger Enetered");
    //}
    void OnTriggerStay(Collider c)
    {
        
        Rigidbody rb = c.attachedRigidbody;


        if (rb == null)
            return;


        if (rb == null) {
            return;
        }

        PickupObject p = rb.GetComponent<PickupObject>();

        if (p == null) {
            return;
        }

        //float triggerValue;


        if (myController == OVRInput.Controller.LTouch) {
            triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
            Debug.Log("Left value is  " + triggerValue);
        }
        else {
            triggerValue = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
            //Debug.Log("Right value is  " + triggerValue);
        }

        //pickup 
        if (currentAttachment == null && triggerValue > pickupTriggerThreshold) {
            currentAttachment = p;
            rb.isKinematic = true;
            currentAttachment.transform.parent = this.transform;
            //currentAttachment.pickedUp(this.transform);
        }

        //release
        if (currentAttachment != null && triggerValue < releaseTriggerThreshold) {
            rb.isKinematic = false;
            currentAttachment.transform.parent = null;
           // currentAttachment.released(this.transform);
            currentAttachment = null;
        }

    }
}
