using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private float missileSpeed = 1.0f;
    private float missileSpawnPeriod_sec = 30;
    private float missileSpawnRadius = 1.8f;
    public Transform missileSpawnOrigin;
    public Transform bulletSpawnOrigin;
    public Missile missilePrefab;
    public bullet bullet;
    private int level_gap = 6;
    private int numRounds = 10;
    private int count;
    private bool gameActive = true;
    private Text levelText;
    
    // Start is called before the first frame update
    void Start() {
        count = 0;
        StartCoroutine("missileSpawner");
        LevelTextInit(1);
    }

    // Update is called once per frame
    void Update() {
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) ) {
            Debug.Log("Left Trigger Pulled");
            shoot();
        }


    }
    IEnumerator missileSpawner() {
        while (count < numRounds) {
           

           

            float Leveltime = Time.time + missileSpawnPeriod_sec;
            //spawn
            while (Time.time < Leveltime) {
                Missile m = Instantiate<Missile>(missilePrefab);
                //move location
                m.transform.position = missileSpawnOrigin.position +
                    Random.Range(-1.0f, 1.0f) * missileSpawnRadius * missileSpawnOrigin.right +
                    Random.Range(-1.0f, 1.0f) * missileSpawnRadius * missileSpawnOrigin.forward;
                yield return new WaitForSeconds(missileSpeed); // adjust speed rate by reducing missile spawn intervals
            }

            //level management
            count++; //increase round
            newLevel(count, level_gap);
            
        }
        
    }

    private void shoot() {
        Debug.Log("We shot");

        float dist = bulletSpawnOrigin.transform.position.magnitude;
        bullet b = Instantiate<bullet>(bullet);
        b.transform.position = bulletSpawnOrigin.position;
        Rigidbody rbb = b.GetComponent<Rigidbody>();
        //b.transform.position = transform.position + bulletSpawnOrigin.transform.forward * 2;
        rbb.velocity = bulletSpawnOrigin.transform.forward * 40;
        
        Wait1Sec();
    }

    private static float boostSpeed(float speed) {
        speed -= 0.2f;
        return speed;
    }

    private static float increasePeriod(float period) {
        period += 5.0f;
        return period;
    }

    public  void setInactive() {
        gameActive = false;
    }

    
    public IEnumerable Wait1Sec() {
        yield return new WaitForSeconds(1);
    }

    public IEnumerable LevelTextInit(int level) {
        
        levelText.gameObject.SetActive(true);

        for (int sec = 5; sec >= 0; sec--) {
            levelText.text = "Level " + level + "starting in... " + sec;
            Wait1Sec();
        }

        levelText.gameObject.SetActive(false);

        yield return null;

    }

    public IEnumerable newLevel(int level, int time) {
        levelText.gameObject.SetActive(true);

        for (int sec = time; sec >= 0; sec--) {
            levelText.text = "Level " + level + "starting in... " + sec;
            yield return new WaitForSeconds(1);
        }

        levelText.gameObject.SetActive(true);
        //increase difficulty
        boostSpeed(missileSpeed);
        increasePeriod(missileSpawnPeriod_sec);
    }
    public IEnumerable fire() {
        Debug.Log("Fired");
        shoot();
        yield return new WaitForSeconds(.5f);

    }
}
