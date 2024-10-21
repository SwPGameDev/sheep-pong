using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    InputAction resetAction;

    int player1Score;
    int player2Score;

    [SerializeField] TextMeshPro player1ScoreLabel;
    [SerializeField] TextMeshPro player2ScoreLabel;

    [SerializeField] BallMovement ballin;


    void Start()
    {
        resetAction = InputSystem.actions.FindAction("Reset");
    }

    void Update()
    {
        if (resetAction.WasPressedThisFrame())
        {
            GameRestart();
        }
    }

    void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Player1ScoreUp()
    {
        player1Score++;
        player1ScoreLabel.text = "P1: " + player1Score;
        ballin.LaunchBall();
    }

    public void Player2ScoreUp()
    {
        player2Score++;
        print("Player 2 Score: " + player2Score);
        player2ScoreLabel.text = "P2: " + player2Score;
        ballin.LaunchBall();
    }
}
