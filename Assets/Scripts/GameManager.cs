using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public GameObject Player;

    private PlayerController playerController;

    private TextMeshProUGUI scoreText;
    //public TextMeshProUGUI gameOverText;

    private string message;


    

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        scoreText = GetComponent<TextMeshProUGUI>();
        playerController = Player.GetComponent<PlayerController>();
        //playerController.score = 0;
        message = $"Score: {playerController.score}";
        scoreText.text = message;

    }

    // Update is called once per frame
    void Update()
    {
        message = $"Score: {playerController.score}";
        scoreText.text = message;
        
    }

   
}
