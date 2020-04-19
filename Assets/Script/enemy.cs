using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemy : Unit
{

    public event deathNotify onDeath;

    public float lifeTime = 4f;

    public ENEMY_TYPE enemyType;

    public float min;
    public float max;
    public float initY = 0;
    // Use this for initialization
    public override void OnStart()
    {
        this.Fly();
        Destroy(this.gameObject, lifeTime);

        initY = Random.Range(min, max);
        this.transform.localPosition = new Vector3(0, initY, 0);
    }



    
    // Update is called once per frame
    public override void OnUpdate()
    {

        
        float y = 0;
        if(this.enemyType == ENEMY_TYPE.SWING_ENEMY){
             y = Mathf.Sin(Time.timeSinceLevelLoad)*3f;
        }
        this.transform.position = new Vector3(this.transform.position.x-Time.deltaTime * speed, initY+y);

        this.Fire(-1);

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
