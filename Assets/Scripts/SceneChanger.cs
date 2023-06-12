using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
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
