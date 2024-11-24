using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public LevelManager levelManager;

    public TMP_Text timer;
    public TMP_Text score;

    private float scoreRound;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GetComponent<LevelManager>();
        timer.text = levelManager.levelTimer.ToString();
        score.text = levelManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = levelManager.score.ToString();
        timer.text = Mathf.Floor(levelManager.levelTimer / 60).ToString("00") + ":" + (levelManager.levelTimer % 60).ToString("00");
    }
}
