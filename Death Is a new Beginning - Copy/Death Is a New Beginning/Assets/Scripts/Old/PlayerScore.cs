using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]private float timePassed = 0;
    public int playerTime = 0;
    public int playerScore = 0;

    public int statuesInspected = 0;
    public int enemiesFought = 0;
    public int chestsOpened = 0;
    [SerializeField] private float winBonus = 1f;

    public TextMeshProUGUI DeathUI;

    public TextMeshProUGUI playerScoreUI;
    public TextMeshProUGUI timeScoreUI;
    public TextMeshProUGUI statueScoreUI;
    public TextMeshProUGUI chestsScoreUI;
    public TextMeshProUGUI enemiesScoreUI;

    public GameObject WinBonusUI;

    private Health health;


    public static PlayerScore instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GameObject player = PlayerManager.instance.player;
        health = player.GetComponent<Health>();
    }
    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        //if (timePassed < 0.1f)
        //{
        //    SceneManager.LoadScene("SampleScene");
        //}

    }

    public void ResetAllScore()
    {
        timePassed = 0;
        playerTime = 0;
        playerScore = 0;

        statuesInspected = 0;
        enemiesFought = 0;
        chestsOpened = 0;
    }  

    public void CountScore(bool death)
    {

        int heartsLeft = 1;
        if (death)
        {
            DeathUI.text = "You Died :(";
            WinBonusUI.SetActive(false);
            winBonus = 1f/5f; 
        }
        else
        {
            Debug.Log("Hearts Left");
            heartsLeft = health.health / 5;
            winBonus = 2f * heartsLeft;
            DeathUI.text = "You Win! :)";
            WinBonusUI.SetActive(true);
        }

        playerTime = (int)timePassed;
        timeScoreUI.text = "Time Survived: " +  playerTime.ToString();
        statueScoreUI.text = "Statues Inspected: " + statuesInspected.ToString();
        chestsScoreUI.text = "Chests Opened: " + chestsOpened.ToString();
        enemiesScoreUI.text = "Enemies Fought: " + enemiesFought.ToString();

        Debug.Log(winBonus);
        playerScore = (int)((statuesInspected * chestsOpened * enemiesFought * winBonus *playerTime));
        Debug.Log(playerScore);
        checkZeros();

        playerScore = (int)((statuesInspected * chestsOpened * enemiesFought * winBonus *playerTime));
        Debug.Log(playerScore);
        playerScoreUI.text = "Total Score: " + ((int)playerScore).ToString();
    }

    private void checkZeros()
    {
        if (statuesInspected < 1) statuesInspected = 1;
        if (chestsOpened < 1) chestsOpened= 1;
        if (enemiesFought < 1) enemiesFought = 1;
    }
}
