using UnityEngine;

public class StartMenuScript : MonoBehaviour
{
    public PlayerController playerControllerReference;
    public EnemyMovement enemyMovementReference;
    public GameObject darkenedBGPause;

    public bool gamePaused = false;

    public void StartGame()
    {
        playerControllerReference.StartGame();
        enemyMovementReference.StartGame();
    }

    public void PauseGame()
    {
        if (gamePaused == false)
        {
            gamePaused = true;
            enemyMovementReference.PauseGame();
            playerControllerReference.PauseGame();
            darkenedBGPause.SetActive(true);
        } else {
            gamePaused = false;
            enemyMovementReference.UnpauseGame();
            playerControllerReference.UnpauseGame();
            darkenedBGPause.SetActive(false);
        }
    }
}
