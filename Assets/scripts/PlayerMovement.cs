using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D tani;
    public float speed;
    public  float xBound= 10;
    public static int pointebi=0;
    public float sprtintspeed;
    public float sprintreminder=60;
    public float sprintmaxdur=60;
    
  //  public float health;
   // public Joystick joystick;
    public Animator left;
    public Animator right;
    public Animator hurt;
    public Animator shoot;
    public Animator uiHUrt;
    public Animator transishon;
    //partiyle
   
    public ParticleSystem laser;
    public GameObject bullets;
    public Transform titi;
    public int ammo=20;
    public Text ammotext;
    public Text pointText;
    public ParticleSystem sprintright;
    public ParticleSystem sprintleft;
    //
    public Image healthbar;
    public Image fadingEffect;
    public Image sprint;
    public float hp;
    public float maxhp;
    public float hurtspeed = 0.5f;

    //shooting
    bool canShoot = true;
   public float rateshoot = 0.5f;

    //audio
    public AudioSource sprintwoosh;
    public AudioSource shootsound;
    public AudioSource hurtsound;
    public AudioSource health;
    public AudioSource foodpoint;
    public AudioSource ammopoint;
    //ammo
    public static bool hasMaxAmmo = false;
    public int moemaxammo;

    void Start()
    {
        tani = GetComponent<Rigidbody2D>();
        ammotext.text = ammo.ToString();
        hp = maxhp;
        pointText.text = pointebi.ToString();
        sprint.fillAmount = sprintreminder;
    }


     void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
      //  float h = joystick.Horizontal;
        if (h > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift)&&sprintreminder>0)
            {
                if (!sprintwoosh.isPlaying)
                {
                    sprintwoosh.Play();
                }
                tani.velocity = Vector2.right *sprtintspeed;
                sprintreminder -= 1;
                sprint.fillAmount -= 0.01f;
                sprintright.Play();
            }
            else
            {
                sprintwoosh.Stop();
                tani.velocity = Vector2.right * speed;
            }
            right.SetBool("right", true);
            left.SetBool("left", false);
           
        }
        else if (h < 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) && sprintreminder>0)
            {
                if (!sprintwoosh.isPlaying)
                {
                    sprintwoosh.Play();
                }
                tani.velocity = Vector2.left * sprtintspeed;
                sprintreminder -= 1;
                sprint.fillAmount -= 0.01f;
                sprintleft.Play();
            }
            else
            {
               sprintwoosh.Stop();
                tani.velocity = Vector2.left * speed;
            }

            right.SetBool("right", false);
            left.SetBool("left", true);
            
           
        }
        else
        {
            //sprintwoosh.Stop();
            right.SetBool("right", false);
            left.SetBool("left", false);
            tani.velocity = Vector2.zero;
        }

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -xBound, xBound),transform.position.y);
    }
     void Update()
    {

        if (ammo > 0)
        {
            if (!pausingscript.isPaused)
            {
                if (Input.GetButtonDown("Fire1") && canShoot)
                {
                    StartCoroutine(FireRate());

                    if (ammo == moemaxammo)
                    {
                        hasMaxAmmo = false;
                    }
                    ammo--;
                }

                ammotext.text = ammo.ToString();
            }
        }
        //healtheffect hurt
        healthbar.fillAmount = hp / maxhp;
        if (fadingEffect.fillAmount > healthbar.fillAmount)
        {
            fadingEffect.fillAmount -= hurtspeed;
        }
        else
        {
            fadingEffect.fillAmount = healthbar.fillAmount;
        }
        {
            fadingEffect.fillAmount = healthbar.fillAmount;
        }
        //healtheffect heal
        if (fadingEffect.fillAmount < healthbar.fillAmount)
        {
            fadingEffect.fillAmount += hurtspeed;
        }

    }
   public  void gotHit(int helth)
    {
        hp -= helth;
        if (hp <= 0)
        {
            StartCoroutine(loadScene(2));
        }
        hurtsound.Play();
        hurt.SetTrigger("hurt");
        uiHUrt.SetTrigger("uiHurt");
    }


    public void ammoui(int amo)
    {
        ammopoint.Play();
        ammo += amo;
        if (ammo >= moemaxammo)
        {
            hasMaxAmmo = true;
        }
        ammotext.text = ammo.ToString();
    }


    public void heal(float x)
    {
        if (hp != maxhp)
        {
            hp += x;
            health.Play();
        }
    }


    public void pointDag(int p)
    {
        foodpoint.Play();
        pointebi += p;
        pointText.text = pointebi.ToString();

    }

    
   
    public void plussprint(float s) {
        
        sprintreminder += s;
        sprint.fillAmount += (s/100f);
        if (sprintreminder > sprintmaxdur)
        {
            sprintreminder = sprintmaxdur;
            sprint.fillAmount = 1f;
        }
    }


    IEnumerator FireRate()
    {
        canShoot = false;
        shootsound.Play();
        Instantiate(bullets, titi.position, titi.rotation);
        
        laser.Play();
        shoot.SetTrigger("shoot");
        yield return new WaitForSeconds(rateshoot);
        canShoot = true;
    }


    IEnumerator loadScene(int levelindex)
    {
        transishon.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelindex);
      

    }

    
}
