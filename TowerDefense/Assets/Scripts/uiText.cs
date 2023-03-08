using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class uiText : MonoBehaviour
{
    Spawner spawn;
    [SerializeField]
    private TextMeshProUGUI roundCount;
    [SerializeField]
    private TextMeshProUGUI roundTimer;
    [SerializeField]
    private TextMeshProUGUI upcomingEnemies;
    void Update()
    {
        roundCount.text = "Current Round: " + Spawner.currentRound.ToString();

        roundTimer.text = "" + Spawner.roundDelay.ToString("f0");

        upcomingEnemies.text = "Upcoming Enemies: " + Spawner.currentEnemies.ToString();

        if (Spawner.roundDelay > 0)
        {
            Spawner.roundDelay-=Time.deltaTime;
        }
        else
        {
            Spawner.roundDelay = 0;
        }
    }
}
