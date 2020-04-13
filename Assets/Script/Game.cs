using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public enum GAME_STATUS
    {
        Ready,
        InGame,
        GameOver
    }

    private GAME_STATUS status;

    public GameObject panelReady;
    public GameObject panelIngame;
    public GameObject GameOver;

    public PipelineManger pipelineManger;

	// Use this for initialization
	void Start () {
        this.panelReady.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        this.status = GAME_STATUS.InGame;
        UpdateUI();
        pipelineManger.StartRun();
        Debug.LogFormat("StartGAME:{0}",this.status);
    }

    public void UpdateUI()
    {
        this.panelReady.SetActive(this.status == GAME_STATUS.Ready);
        this.panelIngame.SetActive(this.status == GAME_STATUS.InGame);
        this.GameOver.SetActive(this.status == GAME_STATUS.GameOver);

    }
}
