using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenuScene : MonoBehaviour
{
    [SerializeField] private Image black;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip startSound;

    [SerializeField] private float blackoutTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(LoadMenu());
        }
    }

    IEnumerator LoadMenu()
    {
        audioSource.PlayOneShot(startSound);
        yield return new WaitForSeconds(0.4f);

        Color color = black.color;
        for(int i= 1; i <= 60; i++)
        {
            color.a = ((float)i)/60.0f;
            black.color = color;
            yield return new WaitForSeconds(blackoutTime/60.0f);
        }

        yield return new WaitForSeconds(0.1f);

        if(PlayerPrefs.GetInt("OP", 0) != 0)
        {
            SceneManager.LoadScene("MenuScene");
        }
        else
        {
            PlayerPrefs.SetInt("OP", 1);
            SceneManager.LoadScene("Opening");
        }
        
    }
}
