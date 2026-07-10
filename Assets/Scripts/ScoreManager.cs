using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    public List<int> rating=new List<int>();
    public void Save(int stage, int evaluate)
    {
        Load();
        if(rating[stage-1]<evaluate)
        {
            rating.RemoveAt(stage-1);
            rating.Insert(stage-1,evaluate);
        }
        string json=JsonUtility.ToJson(this);
        PlayerPrefs.SetString("SavedData",json);
        PlayerPrefs.Save();
    }
    public void Load()
    {
        string json=PlayerPrefs.GetString("SavedData");
        JsonUtility.FromJsonOverwrite(json,this);
    }
    public int End()
    {
        int e=rating.Min()-1;
        if(e<=0)
        {
            e=0;
        }
        return e;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Save(1,0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Load();
            Debug.Log(End());
        }
    }
}
