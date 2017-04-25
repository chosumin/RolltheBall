using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gamestate
{
    idle, idle2, generate, ing, stageclear, death, end, pause
}

public class GameManager : MonoBehaviour {
    public static Gamestate gs;
    public static float screenX; //화면 길이
    public static float screenY;
    public GameObject Ball;
    public GameObject Hole;
    public static int count;
    public GameObject Intro;
    public GameObject NextStage;
    public GameObject Pause;
    public GameObject Clear;
    public GameObject Death;
    private int stage;
    private GameObject[] ballList = new GameObject[5];
    private GameObject[] holeList = new GameObject[5];
    private int changeX; //랜덤으로 선택되는 객체 좌표
    private int changeZ;
	// Use this for initialization
	void Start () {
        gs = Gamestate.idle;
        screenX = Camera.main.orthographicSize * Camera.main.aspect;
        screenY = Camera.main.orthographicSize;
        stage = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if(gs == Gamestate.idle)
        {
            Intro.SetActive(true);
            if (Input.touchCount > 0)
            {
                gs = Gamestate.idle2;
            }
        }
        else if(gs == Gamestate.idle2)
        {
            if (Input.touchCount > 0)
            {
                gs = Gamestate.generate;
            }
        }
        else if(gs == Gamestate.generate)
        {
            Intro.SetActive(false);
            NextStage.SetActive(false);
            stage++; // 1스테이지부터 시작
            if (stage > 3)
            {
                gs = Gamestate.end; //올 클리어
            }
            for (int i=0;i<stage;i++)
            {
                GenerateBallHall(i); //공, 구멍 스테이지만큼 생성
            }
            count = stage;
            gs = Gamestate.ing;
        }
        else if(gs == Gamestate.ing)
        {
            Pause.SetActive(false);
            if (count <= 0) //성공시
            {
                gs = Gamestate.stageclear;
            }
            //진행 한뒤 idle or death or end로 전환
        }
        else if(gs == Gamestate.stageclear)
        {
            NextStage.SetActive(true);
            for (int i = 0; i < stage; i++)
            {
                Destroy(holeList[i].gameObject);
            }
        }
        else if(gs == Gamestate.end) //올 클리어
        {
            Clear.SetActive(true);
            for (int i = 0; i < stage; i++)
            {
                Destroy(holeList[i].gameObject);
            }
            if (Input.touchCount > 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
            }
        }
        else if(gs == Gamestate.death)
        {
            Death.SetActive(true);
            for (int i = 0; i < stage; i++)
            {
                Destroy(holeList[i].gameObject);
            }
        }
        else if(gs == Gamestate.pause)
        {
            Pause.SetActive(true);
        }
	}

    void GenerateBallHall(int stage) //arraylist로 바꾸기
    {
        ballList[stage] = Instantiate(Ball, new Vector3(0,0,0), transform.rotation);
        ballList[stage].GetComponent<MeshRenderer>().material.color = ColorChange(stage);
        holeList[stage] = Instantiate(Hole, new Vector3(0, 0, 0), transform.rotation);
        holeList[stage].GetComponent<MeshRenderer>().material.color = ColorChange(stage);
        ballList[stage].SetActive(true);
        holeList[stage].SetActive(true);
    }
    Color ColorChange(int stage)
    {
        if (stage == 0) { return Color.red; }
        else if (stage == 1) { return Color.blue; }
        else { return Color.white; }
    }
}
