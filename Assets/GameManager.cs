using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float missileSpeed;
    public float missileSpawnPeriod_sec;
    public float missileSpawnRadius;
    public Transform missileSpawnOrigin;
    public bool MSpawnerActive;   
    public Missile missilePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine("missileSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator missileSpawner()
    {
        while (true)
        {
            //spawn
            if (MSpawnerActive)
            {
                Missile m = Instantiate<Missile>(missilePrefab);
                //move location
                m.transform.position = missileSpawnOrigin.position +
                    Random.Range(-1.0f, 1.0f) * missileSpawnRadius * missileSpawnOrigin.right +
                    Random.Range(-1.0f, 1.0f) * missileSpawnRadius * missileSpawnOrigin.forward;
                yield return new WaitForSeconds(missileSpawnPeriod_sec);
            }

            yield return null;  // wait for next frame
         }        
        
    }
}
