using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemy : MonoBehaviour
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

    public float lifeTime = 4f;

    public ENEMY_TYPE enemyType;

    // Use this for initialization
    void Start()
    {
        this.Fly();
        initPos = this.transform.position;
        Destroy(this.gameObject, lifeTime);
    }

    public void init()
    {
        this.transform.position = initPos;
        this.Fly();
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
        
        float y = 0;
        if(this.enemyType == ENEMY_TYPE.SWING_ENEMY){
             y = Mathf.Sin(Time.timeSinceLevelLoad)*3f;
        }
        this.transform.position = new Vector3(this.transform.position.x-Time.deltaTime * speed, y);

        this.Fire();

    }

    public void Fire()
    {
        if (fireTimer > 1 / fireRate)
        {
            GameObject go = Instantiate(bulletTemlate);
            go.transform.position = this.transform.position;
            go.GetComponent<Element>().direction = -1;
            fireTimer = 0f;
        }


    }

    public void Death()
    {
        this.death = true;
        this.ani.SetTrigger("die");
        if (this.onDeath != null)
        {
            this.onDeath();
        }
        Destroy(this.gameObject,0.2f);
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
        Debug.Log("enemy:onTrigger");
        if (bullet.side == SIDE.PLAYER)
        {
            this.Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //this.Death();
    }
}
