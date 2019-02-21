using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public AudioSource audio1;
    public AudioSource SmallExplosion;
    // Start is called before the first frame update
    void Start()
    {
        SmallExplosion = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        SmallExplosion.Play();

        
        Destroy(this.gameObject);
    }
}
