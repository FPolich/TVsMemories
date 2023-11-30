using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause
{

    

    public void PausedGame(GameObject canvasPaused, bool estate, float time)
    {
        canvasPaused.SetActive(estate);
        Time.timeScale = time;
    }
}
