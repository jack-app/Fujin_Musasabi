using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlickText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] private float scale = 0.004f;

    private bool isVanish = true;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(isVanish == true)
        {
            text.alpha -= scale;
            if(text.alpha < 0.5f)
            {
                isVanish = false;
            }
        }
        else
        {
            text.alpha += scale;
            if(text.alpha >= 1.0f)
            {
                isVanish = true;
            }
        }
    }
}
