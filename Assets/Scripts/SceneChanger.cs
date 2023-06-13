using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void ChangeToARScene()
    {
        SceneManager.LoadScene("AR Scene");
        
    }
    public void ChangeToVideoScene()
    {
        SceneManager.LoadScene("Demo Videos");
    }
    public void ChangeToMainScene()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void ChangeToAssessmentScene()
    {
        SceneManager.LoadScene("Assessment Scene");
    }
}
