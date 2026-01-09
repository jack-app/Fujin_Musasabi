using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageButton : MonoBehaviour
{
    [SerializeField] private string stageName;
    [SerializeField] private int stageNumber;
    [SerializeField] private GameObject unreachedImage;
    [SerializeField] private GameObject numberText;
    private int stageProgress;
    // Start is called before the first frame update
    void Start()
    {
        stageProgress = PlayerPrefs.GetInt("Progress", 1);
        if(stageProgress >= stageNumber)
        {
            unreachedImage.SetActive(false);
            this.gameObject.GetComponent<Image>().enabled = true;
            numberText.SetActive(true);
        }
        else
        {
            unreachedImage.SetActive(true);
            this.gameObject.GetComponent<Image>().enabled = false;
            numberText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToStage()
    {
        if(stageProgress >= stageNumber)
        {
            SceneManager.LoadScene($"{stageName}");
        }
    }
}
