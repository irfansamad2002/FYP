using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARExplorationSceneChanger : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Scene");
    }
    public void GoToExploration()
    {
        SceneManager.LoadScene("AR Exploration");
    }
    public void GoToImageScan()
    {
        SceneManager.LoadScene("AR ImageScan");
    }
    public void GoToMultiDiffImg()
    {
        SceneManager.LoadScene("AR MultDifferentImage");
    }
    public void GoToSameimageDiffColor()
    {
        SceneManager.LoadScene("AR SameimageDiffColor");
    }
    public void GoToTextRecognition()
    {
        SceneManager.LoadScene("AR TextRecognition");
    }
    public void GoToModelTargetRecognition()
    {
        SceneManager.LoadScene("AR ModelTargetRecognition");
    }
    public void GoToModelSpawn()
    {
        SceneManager.LoadScene("AR ModelSpawn");
    }
}
