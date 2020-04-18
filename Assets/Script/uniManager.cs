using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uniManager : MonoBehaviour
{

    public GameObject enemyTemplate;
    public GameObject enemyTemplate2;
    public GameObject enemyTemplate3;
    public float speed1 = 2;
    public float speed2 = 3;
    public float speed3 = 5;
    public List<enemy> enemies = new List<enemy>();

    public float min;
    public float max;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    Coroutine coroutine = null;

    public void Begin()
    {
        coroutine = StartCoroutine(GenerateEnemies());
    }

    public void Stop()
    {
        StopCoroutine(coroutine);

        enemies.Clear();
    }

    int timer1 = 0;
    int timer2 = 0;
    int timer3 = 0;

    IEnumerator GenerateEnemies()
    {
        while (true)
        {
            if (timer1 > speed1)
            {
                GenerateEnemy(enemyTemplate);
                timer1 = 0;
            }
            if (timer2 > speed2)
            {
                GenerateEnemy(enemyTemplate2);
                timer2 = 0;
            }
            if (timer3 > speed3)
            {
                GenerateEnemy(enemyTemplate3);
                timer3 = 0;
            }
            timer1++;
            timer2++;
            timer3++;

            yield return new WaitForSeconds(1f);

        }



    }


    void GenerateEnemy(GameObject templates)
    {
        if (templates == null)
            return;

        GameObject obj = Instantiate(templates, this.transform);
        enemy p = obj.GetComponent<enemy>();
        this.enemies.Add(p);

        float y = Random.Range(min, max);
        obj.transform.localPosition = new Vector3(0, y, 0);


    }
}
