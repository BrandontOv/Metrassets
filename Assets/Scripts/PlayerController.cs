
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour

{

    [SerializeField] int Ammo = 30;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator anim;

    [SerializeField] int live = 4;

    [SerializeField] GameObject shot;

    [SerializeField] int Item = 0;

    [SerializeField] float Timer = 180;

    [SerializeField] TMP_Text Txtlives, Txtitems, TxtTimer;

    [SerializeField] GameObject TxtWin, TxtLose;

    [SerializeField] AudioClip sndJump, sndItem, sndShoot, sndDamage;

    [SerializeField] GameObject PauseM;

    [SerializeField] GameObject PlataAdios;

    public static bool right = true;
    private Rigidbody2D rb;
    public int speed = 4;
    public int jump = 5;
    public int vulnera = 5;

    bool FinishGame = false;



    AudioSource audioSrc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        GameManager.invulnerable = false;
        rb = GetComponent<Rigidbody2D>();
        // rb.AddForce(Vector2.up*20, ForceMode2D.Impulse);

        Txtlives.text = "lives:" + live;

        Txtitems.text = "Items:" + Item;

        TxtTimer.text = Timer.ToString(); //El To String pasa de numero a texto con x.0 es el numero de decimales que se veria si fueran x.00 serian 2 decimales

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!FinishGame)
        {



            float inputX = Input.GetAxis("Horizontal");
            rb.linearVelocity = new Vector2(inputX * speed, rb.linearVelocity.y); // Recibiendo el input horizontal y añadiendolo en el Vector dos toma el valor de la variable (Siendo el primer espacio el eje X y Añadiendole la velocidad que habia recibido y puesta en "rb (que es el Riggidbody). linearVelocity en el eje Y, en el apapartado Y)

            if (inputX > 0)
            {
                sprite.flipX = false;
                right = true;
            }
            else if (inputX < 0)
            {
                sprite.flipX = true;
                right = false;
            }

            if (Input.GetKeyDown(KeyCode.Space) && grounded() == true)
            {
                rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse); // Añadiendo fuerza vertical para saltar
                audioSrc.PlayOneShot(sndJump);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {

                anim.SetBool("isRunning", true);
            }

            else
            {
                anim.SetBool("isRunning", false);

            }

            if (grounded() == false)
            {

                anim.SetBool("isJump", true);

            }
            else
            {
                anim.SetBool("isJump", false);
            }

            // if (rb.position.y < -5) // Si el jugador sale de la pantalla, se teletransporta a la parte superior
            // {
            //     rb.position = new Vector2(0, 5);
            // }

            // if (rb.position.x > 10) // Si el jugador sale de la pantalla, se teletransporta a la parte izquierda
            // {
            //     rb.position = new Vector2(-10, rb.position.y);
            // }

            if (Input.GetKeyDown(KeyCode.E)&& Ammo>=0)
            {
                Invoke ("cadencia", 0.3f);
                

            }



            Timer = Timer - Time.deltaTime;

            if (Timer < 0)
            {
                Timer = 0;
                TxtLose.SetActive(true);
                FinishGame = true;
                Invoke("GogoMenu", 3); //El Invoke permite llamar un metodo pero añadiendole tiempo antes de ser llamada
            }


            float min, sec;
            min = Mathf.Floor(Timer / 60);
            sec = Mathf.Floor(Timer % 60);
            TxtTimer.text = min.ToString("00") + ":" + sec.ToString("00");



        }

        else
        {

            Invoke("pause", 0);
            Invoke("GogoCredits", 0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            PauseM.SetActive(true);
            Time.timeScale = 0;

        }



    }


    //  void OnCollisionEnter2D(Collider2D other){

    //  }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Acid")
        {

            rb.position = new Vector2(15, -15);
            live --;
        }

        if (other.gameObject.tag == "PowerUp")
        {
            Destroy(other.gameObject);
            sprite.color = Color.green;
            GameManager.invulnerable = true;
            Invoke("vunerable", vulnera);
        }

        if (other.gameObject.tag == "Item")
        {

            Destroy(other.gameObject);
            Item++;
            Txtitems.text = "Item:" + Item;
            audioSrc.PlayOneShot(sndItem);

            if (Item == 1)
            {

                TxtWin.SetActive(true);
                FinishGame = true;
                Invoke("GogoCredits", 3);
            }
        }


    }




    bool grounded()
    {
        RaycastHit2D touch = Physics2D.Raycast(transform.position, Vector2.down, 0.2f);

        if (touch.collider == null)
        {

            return false;
        }
        else
        {
            return true;
        }
    }

    void vunerable()
    {
        sprite.color = Color.white;
        GameManager.invulnerable = false;
    }

    public void damage()
    {
        live--;
        sprite.color = Color.red;
        GameManager.invulnerable = true;
        Invoke("vunerable", vulnera);
        audioSrc.PlayOneShot(sndDamage);

        if (live < 0)
        {

            live = 0;
            TxtLose.SetActive(true);
            FinishGame = true;
            Invoke("GogoMenu", 3);


        }

        Txtlives.text = "lives:" + live;
    }

   

    void GogoMenu()
    {
        SceneManager.LoadScene("Menu");


    }
    void GogoCredits()
    {
        SceneManager.LoadScene("Credits");

    }

    void pause()
    {
        Time.timeScale = 0;
    }

void cadencia(){
    Ammo--;
    Instantiate(shot, new Vector3(transform.position.x, transform.position.y + 1.7f, 0), Quaternion.identity);
                anim.SetBool("isShooting", true);
                audioSrc.PlayOneShot(sndShoot);


}

}

