using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour {
    public Rigidbody2D rigibodyBird;
    public float speed = 5f;
    public float fireRate = 5;

    public Animator ani;

    protected bool death = false;

    public delegate void deathNotify();

    public UnityAction<int> onScore;

    public GameObject bulletTemlate;

    protected Vector3 initPos;

    public float HP = 10f;
    public float MaxHP = 10f;

    protected float fireTimer = 0;

    // Use this for initialization
    void Start () {
        initPos = this.transform.position;
       OnStart();
    }

    public virtual void OnStart()
    {

    }
	
	// Update is called once per frame
	void Update () {
        if (this.death)
        {
            return;
        }

        fireTimer += Time.deltaTime;

        OnUpdate();
    }

    public virtual void OnUpdate()
    {

    }

    public void init()
    {
        this.transform.position = initPos;
        this.Fly();
        this.death = false;
        this.HP = this.MaxHP;

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

    public void Fire(int dir)
    {
        if (fireTimer > 1 / fireRate)
        {
            GameObject go = Instantiate(bulletTemlate);
            go.transform.position = this.transform.position;
            go.GetComponent<Element>().direction = dir;
            fireTimer = 0f;
        }
    }
}
