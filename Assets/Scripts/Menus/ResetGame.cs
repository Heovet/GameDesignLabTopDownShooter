using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private HealthController playerHC;
    [SerializeField] private CarryOverPlayerStats stats;

    public void Awake()
    {
        playerHC = player.GetComponent<HealthController>();
    }
    public void ResetTheGame()
    {
        stats.loadedPreviously = false;
        if (playerHC.remainingHealthPercent >0)
        {
            playerHC.kill();
            StartCoroutine(resetGame());
        }
        else
        {
            Loader.load(Loader.Scene.BaseGame);
        }
/*        Debug.Log("GameReset!");*/

    }
    IEnumerator resetGame()
    {
        yield return new WaitForSeconds(1f);
        Loader.load(Loader.Scene.BaseGame);
    }
}
