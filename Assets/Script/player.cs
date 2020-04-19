using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class player : Unit
{
    public event deathNotify onDeath;
    // Use this for initialization
    public override void OnStart()
    {
        this.Idle();
    }


    // Update is called once per frame
    public override void OnUpdate()
    {

        Vector2 pos = this.transform.position;

        pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        pos.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;

        this.transform.position = pos;

        if (Input.GetButton("Fire1"))
        {
            this.Fire(1);
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Element bullet = collision.gameObject.GetComponent<Element>();
        enemy enemy = collision.gameObject.GetComponent<enemy>();
        if (bullet == null && enemy ==null)
        {
            return;
        }
        Debug.Log("player:onTrigger");
        if (bullet!=null && bullet.side == SIDE.ENEMY)
        {
            this.HP = this.HP - bullet.power;
            if (this.HP <= 0)
            {
                this.Death();
            }

        }
        if(enemy!= null)
        {
            this.HP = 0;
            
             this.Death();
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //this.Death();
    }
}
