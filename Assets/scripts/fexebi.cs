using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fexebi : MonoBehaviour
{
    PlayerMovement pleer;
    public int footHealth;
    public GameObject ded;
    public AudioSource legspwn;
    public GameObject legdeath;
    void Start()
    {
        legspwn.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
           // collision.GetComponent<healthBar>().minushealth(20);
            collision.GetComponent<PlayerMovement>().gotHit(20);
            ded = (GameObject)Instantiate(ded, transform.position, transform.rotation);
            Destroy(gameObject, 0.1f);
            
        }
        if (collision.gameObject.tag == "Ground")
        {
            legdeath = (GameObject)Instantiate(legdeath, transform.position, transform.rotation);
            ded = (GameObject)Instantiate(ded, transform.position, transform.rotation);

            Destroy(gameObject, 0.1f);
            Destroy(legdeath, 0.6f);
        }
    }

    public void foothurt(int dmg)
    {
        footHealth -= dmg;

        if (footHealth <= 0)
        {
            ded = (GameObject)Instantiate(ded, transform.position, transform.rotation);
            legdeath = (GameObject)Instantiate(legdeath, transform.position, transform.rotation);
            Destroy(gameObject,0.1f);
        }
    }

    private void Update()
    {
        Destroy(gameObject, 1.5f);
    }
}
