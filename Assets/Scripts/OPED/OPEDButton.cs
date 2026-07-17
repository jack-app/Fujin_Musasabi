using UnityEngine;
using UnityEngine.SceneManagement;

public class OPEDButton : MonoBehaviour
{
    [SerializeField] private GameObject seal;
    [SerializeField] private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        EDButtonActivate();
    }

    private void EDButtonActivate()
    {
        if(seal == null || scoreManager == null)
            return;

        if(scoreManager.End() > 0)
        {
            seal.SetActive(false);
        }
    }

    public void OPButton()
    {
        SceneManager.LoadScene("Opening");
    }

    public void EDButton()
    {
        SceneManager.LoadScene("Ending");
    }
}
