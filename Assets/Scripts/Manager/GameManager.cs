using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private string playerTag;
    public GameObject endPanel;
    public GameObject storyPanel;
    public Transform Player { get; private set; }
    public ObjectPool ObjectPool { get; private set; }
    public MonsterPool monsterPool { get; private set; }
    public static bool isGameOver;
    public bool isOncetime = false;
    public Text ScoreTxt;
    private float time = 0.0f;
    private bool isPlay;
    public Text nowScore;
    public Text bestScore;


    private void Awake()
    {
        if(Instance != null)
            Destroy(gameObject);

        Instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
        ObjectPool = GetComponent<ObjectPool>();
        monsterPool = GetComponent<MonsterPool>();
        isGameOver = false;
        isPlay = true;
    }
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        if (isGameOver)
        {
            // 게임 오버 시 사망 연출 표현 후 게임 종료를 위해 지연호출
            Invoke("GameOver", 1.5f);
        }

        if (isPlay)
        {
            time += Time.deltaTime;
            ScoreTxt.text = (time.ToString("N1"));
        }

    }
    public void NextBtn()
    {
        storyPanel.SetActive(false);
        endPanel.SetActive(true);
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuBtn()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        if(isOncetime == false)
        {
            storyPanel.SetActive(true);
            isOncetime=true;
        }
        isPlay = false;
        Time.timeScale = 0.0f;

        nowScore.text = time.ToString("N1");

        // 최고점수가 있다면
        if (PlayerPrefs.HasKey("bestScore"))
        {
            // 최고점수 < 현재점수
            if (PlayerPrefs.GetFloat("bestScore") < time)
            {
                // 최고점수 = 현재점수
                PlayerPrefs.SetFloat("bestScore", time);
                bestScore.text = time.ToString("N1");
            }
            else
            {
                bestScore.text = PlayerPrefs.GetFloat("bestScore").ToString("N1");
            }
        }
        // 최고점수가 없다면
        else
        {
            // 현재 점수를 저장한다.
            PlayerPrefs.SetFloat("bestScore", time);
            bestScore.text = time.ToString("N1");

        }
    }
}
