using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineManger : MonoBehaviour {

    public GameObject template;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    Coroutine coroutine = null;

    public void StartRun()
    {
        coroutine = StartCoroutine(GeneratePipelines());
    }

    public void Stop()
    {
        StopCoroutine(coroutine);
    }

    IEnumerator GeneratePipelines()
    {
        while (true)
        {
            GeneratePipeline();
            yield return new WaitForSeconds(2f);
        }
    }

    void GeneratePipeline()
    {
        Instantiate(this.template, this.transform);
    }

}
