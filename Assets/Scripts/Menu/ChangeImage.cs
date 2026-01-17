using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject backButton;

    [SerializeField] private UnityEngine.Sprite[] sprites;

    private int key = 0;
    // Start is called before the first frame update
    void Start()
    {
        ButtonAvailable();
        if(sprites[key] != null)
            image.sprite = sprites[key];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeSourceImarge(int added)
    {
        if(key+added >= 0 && key+added <= sprites.Length - 1)
        {
            key += added;
            image.sprite = sprites[key];
            ButtonAvailable();
        }
    }

    private void ButtonAvailable()
    {
        if (key <= 0)
        {
            backButton.SetActive(false);
        }
        else
        {
            backButton.SetActive(true);
        }
        if(key >= sprites.Length - 1)
        {
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
        }
    }

    public void GoNext()
    {
        ChangeSourceImarge(1);
    }

    public void GoBack()
    {
        ChangeSourceImarge(-1);
    }
}
