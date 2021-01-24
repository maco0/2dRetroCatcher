using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pausingscript : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pausemenuUI;
    public Animator transishon;
    public static bool isloaded;
    void Start()
    {
       
        isPaused = false;

    }
    void Update()
    {
        if (isloaded)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {


               
                    pause();
                

            }
        }
    }
    public void resume()
    {


        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

       
    }

    public void pause()
    {

        pausemenuUI.SetActive(true);
        
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void quite()
    {
        Application.Quit();
    }
    public void mainmenu()
    {
        StartCoroutine(loadScene(0));
        Time.timeScale = 1f;
       
    }
    IEnumerator loadScene(int levelindex)
    {
        isloaded = false;
        transishon.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        isloaded = true;
        SceneManager.LoadScene(levelindex);

    }
}
