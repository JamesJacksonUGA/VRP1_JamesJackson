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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerStay(Collider c)
    {
        Rigidbody rb = c.attachedRigidbody;

        if(rb == null)
        {
            return;
        }

        PickupObject p = rb.GetComponent<PickupObject>();

        if(p == null)
        {
            return;
        }

        float triggerValue;
        if(myController == OVRInput.Controller.LTouch)
        {
            triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        }
        else
        {
            triggerValue = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        }

        //pickup 
        if(currentAttachment == null && triggerValue > pickupTriggerThreshold)
        {
            currentAttachment = p;
            currentAttachment.pickedUp(this.transform);
        }

        //release
        if (currentAttachment != null && triggerValue < releaseTriggerThreshold )
        {
            currentAttachment.released(this.transform);
            currentAttachment = null; 
        }

    }
}
