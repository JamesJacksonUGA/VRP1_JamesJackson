using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;   
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTime > .3f)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision) {

        if(collision.rigidbody == null) {
            return;
        }

        Rigidbody rb = collision.rigidbody;
        Missile m = rb.GetComponent<Missile>();
        if (m == null) {
            return;
        }
        else {
            Destroy(this.gameObject);
        }
        
    }
   
}
