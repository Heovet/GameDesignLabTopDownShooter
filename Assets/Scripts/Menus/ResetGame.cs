using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private HealthController playerHC;

    public void Awake()
    {
        playerHC = player.GetComponent<HealthController>();
    }
    public void ResetTheGame()
    {
        if (playerHC.remainingHealthPercent >0)
        {
            playerHC.kill();
            StartCoroutine(resetGame());
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
/*        Debug.Log("GameReset!");*/

    }
    IEnumerator resetGame()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
