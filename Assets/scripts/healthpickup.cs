using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class healthpickup : MonoBehaviour
{
    public GameObject helth;
    public GameObject ded;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerMovement>().hp != 60)
            {
                
                collision.gameObject.GetComponent<PlayerMovement>().heal(20);
                Destroy(gameObject, 0.01f);
                Instantiate(ded, transform.position, transform.rotation);
            }
        }
        if (collision.gameObject.tag == "Ground")
        {

            helth = (GameObject)Instantiate(helth, transform.position, transform.rotation);
            
           ded=(GameObject) Instantiate(ded, transform.position, transform.rotation);
            Destroy(gameObject, 0.1f);
            Destroy(helth, 0.6f);
        }
    }

    private void Update()
    {
        Destroy(gameObject, 1.5f);
    }
}
