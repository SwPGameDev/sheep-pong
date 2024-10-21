using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    enum Sides
    {
        left,
        right
    }

    [SerializeField] Sides SideSelection;

    private void OnCollisionEnter(Collision collision)
    {
        if (SideSelection == Sides.left)
        {
            gameManager.Player2ScoreUp();
        }
        else if (SideSelection == Sides.right)
        {
            gameManager.Player1ScoreUp();
        }
    }
}
