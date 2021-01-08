using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammopickup : MonoBehaviour
{
    public AudioSource ammo;
    public int givinammo=5;
    public GameObject ded;
    public int maxammo = 25;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<PlayerMovement>().ammo < collision.GetComponent<PlayerMovement>().moemaxammo)
            {
                ammo.Play();
                collision.GetComponent<PlayerMovement>().ammoui(givinammo);
                Destroy(gameObject,0.01f);
                Instantiate(ded, transform.position, transform.rotation);
                if (collision.GetComponent<PlayerMovement>().ammo > collision.GetComponent<PlayerMovement>().moemaxammo)
                {
                    collision.GetComponent<PlayerMovement>().ammo = collision.GetComponent<PlayerMovement>().moemaxammo;
                  
                }
              
            }
            
        }
        if (collision.gameObject.tag == "Ground")
        {
            ammo.Play();
           ded=(GameObject) Instantiate(ded, transform.position, transform.rotation);
           
            Destroy(gameObject, 0.1f);
        }

       
    }

    private void Update()
    {
        Destroy(gameObject, 1.5f);
        
    }
}
