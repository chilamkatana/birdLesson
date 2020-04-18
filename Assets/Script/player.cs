using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class player : MonoBehaviour
{

    public Rigidbody2D rigibodyBird;

    public float speed = 5f;
    public float fireRate = 5;

    public Animator ani;

    public bool death = false;

    public delegate void deathNotify();

    public event deathNotify onDeath;

    public UnityAction<int> onScore;

    public GameObject bulletTemlate;

    private Vector3 initPos;

    public float HP = 10;

    // Use this for initialization
    void Start()
    {
        this.Idle();
        initPos = this.transform.position;
    }

    public void init()
    {
        this.transform.position = initPos;
        this.Idle();
        this.death = false;
    }

    float fireTimer = 0;
    // Update is called once per frame
    void Update()
    {
        if (this.death)
        {
            return;
        }


        fireTimer += Time.deltaTime;
        Vector2 pos = this.transform.position;

        pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        pos.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;

        this.transform.position = pos;

        if (Input.GetButton("Fire1"))
        {
            this.Fire();
        }
    }

    public void Fire()
    {
        if (fireTimer > 1 / fireRate)
        {
            GameObject go = Instantiate(bulletTemlate);
            go.transform.position = this.transform.position;

            fireTimer = 0f;
        }


    }

    public void Death()
    {
        this.death = true;
        if (this.onDeath != null)
        {
            this.onDeath();
        }
    }

    public void Idle()
    {
        this.rigibodyBird.simulated = false;
        this.ani.SetTrigger("idle");
        this.death = false;
    }

    public void Fly()
    {
        this.rigibodyBird.simulated = true;
        this.ani.SetTrigger("fly");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name.Equals("scoreArea"))
        {

        }
        // else
        //this.Death();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Element bullet = collision.gameObject.GetComponent<Element>();
        if (bullet == null)
        {
            return;
        }
        Debug.Log("player:onTrigger");
        if (bullet.side == SIDE.ENEMY)
        {
            this.HP = this.HP - bullet.power;
            if (this.HP <= 0)
            {
                this.Death();
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //this.Death();
    }
}
