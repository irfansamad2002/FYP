using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScoreTable : MonoBehaviour
{
    [SerializeField] private Transform entrycontainer;
    [SerializeField] private Transform entrytemplate;
    private List<Transform> highscoreEntryTransformList;

    const string PLAYERPREFDATABASE = "highscoreTable";
    private void Awake()
    {
        //Turn off the template
        entrytemplate.gameObject.SetActive(false);

      
        
        //Get the data
        string jsonString = PlayerPrefs.GetString(PLAYERPREFDATABASE);
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);




        //no nd check if there is no data
        if (CheckIfPlayerPrefSet())
        {
            Debug.Log("has highscoretable");
            //sort entry based on score
            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
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
        else
        {
            Debug.Log("dont have highscoretable");
        }




       


    }

    private bool CheckIfPlayerPrefSet()
    {
        if (PlayerPrefs.HasKey(PLAYERPREFDATABASE))
        {
            return true;
        }
        else
        {
            return false;
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
        string jsonString;
        HighScores highscores;

        //Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

       
        
        if (CheckIfPlayerPrefSet())//Check if there is data in playerpref
        {
            //Load saved Highscores
            jsonString = PlayerPrefs.GetString("highscoreTable");
            highscores = JsonUtility.FromJson<HighScores>(jsonString);


            //check if name already exist in database
            if (CheckNameInDatabase(name, highscores))
            {
                UpdateScore(name, score, highscores);
            }
            else
            {
                //Add new entry to Highscores
                highscores.highscoreEntryList.Add(highscoreEntry);
            }




            //Save updated Highscores
            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();

        }
        else //if there is no data in playerpref
        {
            Debug.Log("trying to add without player pref being set");
            List<HighscoreEntry> highscoreEntrylist = new List<HighscoreEntry>();
            HighscoreEntry tempHighscoreEntry = new HighscoreEntry { score = score, name = name };
            highscoreEntrylist.Add(tempHighscoreEntry);

            HighScores tempHighscores = new HighScores { highscoreEntryList = highscoreEntrylist };
            string json = JsonUtility.ToJson(tempHighscores);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
        }
    }


    private bool CheckNameInDatabase(string name, HighScores highscores)
    {
        //check if name already exist
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            if (highscores.highscoreEntryList[i].name == name)
            {
                Debug.Log("name exist in the database");

                return true;
            }
        }
        Debug.Log("no name exist in the database");
        return false;

    }


    private void UpdateScore(string name, int score, HighScores highscores)
    {
        
        string findName = name;
        int newScore = score;
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            if (highscores.highscoreEntryList[i].name == findName)
            {
                highscores.highscoreEntryList[i].score = newScore;

            }
        }

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
