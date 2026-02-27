using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugController : MonoBehaviour
{
    private int progress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        progress = PlayerPrefs.GetInt("Progress", 1);
    }

    public void AddProgress()
    {
        PlayerPrefs.SetInt("Progress", progress+1);
    }

    public void SubtractProgress()
    {
        PlayerPrefs.SetInt("Progress", progress-1);
    }

    public void ResetProgress()
    {
        PlayerPrefs.SetInt("Progress", 1);
    }

    public void ReloadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
