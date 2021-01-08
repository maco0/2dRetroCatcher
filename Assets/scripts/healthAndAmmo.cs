using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthAndAmmo : MonoBehaviour
{
    public GameObject ammo;
    public GameObject health;
    public float Xbounds, Ybounds;
    float  ammoTime=0, healthTime=0;
    public float ammodelay, healthdelay;
    public AudioSource spawn;
   
  

    // Update is called once per frame
    void Update()
    {
        ammoTime += Time.deltaTime;
        healthTime += Time.deltaTime;
        if (ammoTime > ammodelay)
        {
            if (!PlayerMovement.hasMaxAmmo)
            {
                spawn.Play();
                Instantiate(ammo, new Vector2(Random.Range(-Xbounds, Xbounds), Ybounds), Quaternion.identity);
                ammoTime = 0;
            }
        }
        if (healthTime > healthdelay)
        {
            spawn.Play();
            Instantiate(health, new Vector2(Random.Range(-Xbounds, Xbounds), Ybounds), Quaternion.identity);
            healthTime = 0;
        }
    }
    
}
