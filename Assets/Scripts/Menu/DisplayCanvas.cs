using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCanvas : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    // Start is called before the first frame update
    void Awake()
    {
        /*if(canvas.activeSelf == true)
            canvas.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayButton()
    {
        canvas.SetActive(true);
    }

    public void BackToMenu()
    {
        canvas.SetActive(false);
    }
}
