using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScoreTable : MonoBehaviour
{
    private Transform entrycontainer;
    private Transform entrytemplate;
    private List<Transform> highscoreEntryTransformList;
    private void Awake()
    {
        entrycontainer = transform.Find("highScoreEntryContainer");
        entrytemplate = entrycontainer.Find("highscoreEntryTemplate");

        entrytemplate.gameObject.SetActive(false);

        //AddHighscoreEntry(1000, "newGuy");

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

        //sort entry based on score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    //swap
                    HighscoreEntry temp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = temp;

                }
            }
        }


        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highscoreEntry, entrycontainer, highscoreEntryTransformList);
        }


    }

    private void CreateHighScoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;

        Transform entryTransform = Instantiate(entrytemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;

        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }
        entryTransform.Find("posText").GetComponent<TMP_Text>().text = rankString;

        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<TMP_Text>().text = score.ToString();


        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TMP_Text>().text = name;

        transformList.Add(entryTransform);

    }

    private void AddHighscoreEntry(int score, string name)
    {
        //Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        //Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

        //Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        //Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

    }

    private class HighScores
    {
        public List<HighscoreEntry> highscoreEntryList; 
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }


}
