using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScoreTable : MonoBehaviour
{
    [SerializeField] private Transform entrycontainer;
    [SerializeField] private Transform entrytemplate;
    private List<Transform> highscoreEntryTransformList;

    public SceneChanger sceneChanger;

    // IRFAN
    const string  PLAYERPREFDATABASE = "highscoreTable";
    private void Awake()
    {
        //Turn off the template
        entrytemplate.gameObject.SetActive(false);

        #region test entries
        //for (int i = 0; i < 50; i++)
        //{
        //    AddHighscoreEntry(9 + i, "man" + i.ToString());
        //}

        //AddHighscoreEntry(8, "guy10");
        //AddHighscoreEntry(9, "guy100");
        //AddHighscoreEntry(7, "guy19");
        //AddHighscoreEntry(6, "guy18");
        //AddHighscoreEntry(0, "guy17");
        //AddHighscoreEntry(5, "guy16");
        //AddHighscoreEntry(4, "guy13");
        //AddHighscoreEntry(3, "guy15");
        //AddHighscoreEntry(2, "guy12");
        //AddHighscoreEntry(1, "guy1");
        //AddHighscoreEntry(1, "guy2");
        //AddHighscoreEntry(1, "guy3");
        //AddHighscoreEntry(1, "guy4");
        //AddHighscoreEntry(1, "guy5");
        //AddHighscoreEntry(1, "guy6");
        //AddHighscoreEntry(1, "guy7");
        //AddHighscoreEntry(1, "guy8");
        //AddHighscoreEntry(1, "guy20");
        //AddHighscoreEntry(1, "guy11");
        //AddHighscoreEntry(1, "guy20");
        //AddHighscoreEntry(1, "guy21");
        //AddHighscoreEntry(1, "guy22");
        //AddHighscoreEntry(1, "guy23");
        //AddHighscoreEntry(1, "gu24");
        //AddHighscoreEntry(1, "guy57");
        //AddHighscoreEntry(1, "gu879");
        //AddHighscoreEntry(1, "guy66");
        //AddHighscoreEntry(1, "gu56765");
        #endregion

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
                rankString = rank + "th"; break;

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

    public void AddHighscoreEntry(int score, string name)
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

    public void OnHomeClicked()
    {
        ButtonReferenceManager.Instance.storedDTHButtonID = DTHEnum.NONE;
        sceneChanger.ChangeToMainScene();
    }
}
