using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayPlayerScores : MonoBehaviour
{
    public TMP_Text playerName;
    public TMP_Text playerScore;

    public SceneChanger sceneChanger;

    private void Start()
    {
        playerName.text = PlayerPrefs.GetString("Name");
        playerScore.text = PlayerPrefs.GetInt("Score").ToString() + "/10";

    }

    public void OnHomeClicked()
    {
        sceneChanger.ChangeToMainScene();
    }
}
