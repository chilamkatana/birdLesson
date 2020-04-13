using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeline : MonoBehaviour {

    public float speed;
    public float min;
    public float max;

	// Use this for initialization
	void Start () {
        float y = Random.Range(min, max);
        this.transform.localPosition = new Vector3(0, y, 0);

        Destroy(this.gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(-speed, 0) * Time.deltaTime;
	}
}
