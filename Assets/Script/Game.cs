using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public enum GAME_STATUS
    {
        Ready,
        InGame,
        GameOver
    }

    private GAME_STATUS status;

    private GAME_STATUS Status
    {
        get { return status; }
        set { this.status = value;
            UpdateUI();
        }
    }

    public GameObject panelReady;
    public GameObject panelIngame;
    public GameObject GameOver;

    public PipelineManger pipelineManger;
    public uniManager uniManager;

    public player player;

    public int score;
    public Text uiScore;
    public Text uiScore2;

    public Slider hpbar;

    public int Score
    {
        get { return score; }
        set { this.score = value;
            this.uiScore.text = this.score.ToString();
            this.uiScore2.text = this.score.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        this.panelReady.SetActive(true);
        player.Idle();
        this.player.onDeath += Player_onDeath;
    }

    private void Player_onDeath()
    {
        this.Status = GAME_STATUS.GameOver;
        this.pipelineManger.Stop();
        this.uniManager.Stop();
    }

    // Update is called once per frame
    void Update () {
		this.hpbar.value = Mathf.Lerp(this.hpbar.value,this.player.HP,Time.deltaTime);
	}

    public void StartGame()
    {
        this.Status = GAME_STATUS.InGame;
        pipelineManger.StartRun();
        uniManager.Begin();
        player.Fly();
        this.player.onScore = onPlayerScore;
        this.hpbar.value = this.player.HP;
    }

    void onPlayerScore(int score)
    {
        this.Score += score;
    }

    public void UpdateUI()
    {
        this.panelReady.SetActive(this.status == GAME_STATUS.Ready);
        this.panelIngame.SetActive(this.status == GAME_STATUS.InGame);
        this.GameOver.SetActive(this.status == GAME_STATUS.GameOver);

    }

    public void reStart()
    {
        
        this.Status = GAME_STATUS.Ready;
        this.pipelineManger.Init();
        this.player.init();
        this.Score = 0;
    }
}
