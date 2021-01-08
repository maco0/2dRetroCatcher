using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerabehaviour : MonoBehaviour
{
    public SpriteRenderer background;
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetratio = background.bounds.size.x / background.bounds.size.y;
        if (screenRatio >= targetratio)
        {
            Camera.main.orthographicSize = background.bounds.size.y / 2;
          
        }  else
            {
            float difference = targetratio / screenRatio;
            Camera.main.orthographicSize = background.bounds.size.y / 2 * difference;
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
