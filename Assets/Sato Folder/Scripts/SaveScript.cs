using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveScript : MonoBehaviour
{

    // public float score = 140;
    private string rankingKey = "ranking";
    private int rankingNum;
    private float[] ranking;

    public void Start()
    {
        rankingNum = 5;
        ranking = new float[rankingNum];
        GetRanking();
    }


    public void Save(float score)
    {
        SaveRanking(score);
        GetRanking();
        PlayerPrefs.Save();
    }

    public void GetRanking()
    {
        var _ranking = PlayerPrefs.GetString(rankingKey);
        if (_ranking.Length > 0)
        {
            var _score = _ranking.Split(","[0]);
            for (int i = 0; i < _score.Length && i < rankingNum; i++)
            {
                ranking[i] = float.Parse(_score[i]);
            }
        }
    }

    public void SaveRanking(float new_score)
    {
        if (ranking.Length > 0)
        {
            float _tmp = 0.0f;
            for (int i = 0; i < ranking.Length; i++)
            {
                if (ranking[i] < new_score)
                {
                    _tmp = ranking[i];
                    ranking[i] = new_score;
                    new_score = _tmp;
                }
            }
        }
        else
        {
            ranking[0] = new_score;
        }

        /*
		for (int i = 0; i < ranking.Length; i++) 
		{
			Debug.Log(ranking [i].ToString ());
		}
		*/

        string ranking_string = string.Format("{0},{1},{2},{3},{4}", ranking[0], ranking[1], ranking[2], ranking[3], ranking[4]);

        PlayerPrefs.SetString(rankingKey, ranking_string);
        //Debug.Log(PlayerPrefs.GetString(rankingKey));
    }

    public string StringRanking()
    {
        string ranking_string = "";
        for (int i = 0; i < ranking.Length; i++)
        {
            ranking_string = ranking_string + (i + 1) + "位" + "                  " + ranking[i] + "point\n";
        }
        return ranking_string;
    }

    public void deleteRanking()
    {
        PlayerPrefs.DeleteKey(rankingKey);
    }

}
