using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineManger : MonoBehaviour {

    public GameObject template;

    List<pipeline> pipelines = new List<pipeline>();

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    Coroutine coroutine = null;

    public void Init()
    {
        for (int i = 0;i < pipelines.Count; i++){
            Destroy (pipelines[i].gameObject);
        }
        pipelines.Clear();
    }

    public void StartRun()
    {
            coroutine = StartCoroutine(GeneratePipelines());
    }

    public void Stop()
    {
        StopCoroutine(coroutine);
        for(int i = 0; i < pipelines.Count; i++)
        {
            pipelines[i].enabled = false;
        }
    }

    IEnumerator GeneratePipelines()
    {
        for(int i = 0;i<3; i++)
        {
            if (pipelines.Count < 3)
            {
                GeneratePipeline();

            }
            else
            {
                pipelines[i].enabled = true;
                pipelines[i].Init();
            }
            yield return new WaitForSeconds(2f);
        }
    }



    void GeneratePipeline()
    {
        if(pipelines.Count < 3)
        {
            GameObject obj = Instantiate(this.template, this.transform);
            pipeline p = obj.GetComponent<pipeline>();
            pipelines.Add(p);
        }

    }

}
