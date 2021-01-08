using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerMovement>().hp != 60)
            {
                collision.gameObject.GetComponent<PlayerMovement>().heal(20);
                Destroy(gameObject);
            }
        }

    }

    private void Update()
    {
        Destroy(gameObject, 2f);
    }
}
