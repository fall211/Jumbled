using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public ObstacleSetter obstacleSetter;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioControl audioControl;
    private PlayerController playerController;
    [HideInInspector] public int score;

    public Transform startPosition;

    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI upText;
    public TextMeshProUGUI downText;
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;


    // Start is called before the first frame update
    void Start()
    {
        // set instance
        if (instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }

        playerController = player.GetComponent<PlayerController>();

    }

    public void GameOver(){
        audioControl.PlayHurtSound();
        playerController.ResetPlayer();
        obstacleSetter.SetObstacles(10 + score);
    }

    public void Finish(){
        audioControl.PlayFinishSound();
        playerController.ResetPlayer();
        score++;
        scoreUI.text = score.ToString();
        obstacleSetter.SetObstacles(10 + score);
    }

    public void ResetGame(){
        score = 0;
        scoreUI.text = score.ToString();
        obstacleSetter.SetObstacles(10);
        playerController.ResetPlayer(false);
    }

    public void ChangeKeyText(){
        upText.text = player.GetComponent<PlayerController>().upKey.ToString();
        downText.text = player.GetComponent<PlayerController>().downKey.ToString();
        leftText.text = player.GetComponent<PlayerController>().leftKey.ToString();
        rightText.text = player.GetComponent<PlayerController>().rightKey.ToString();
    }

}
