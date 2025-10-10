using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalHitter : MonoBehaviour
{
    private GameFlowManager gameFlowManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        gameFlowManager = gameManager.GetComponent<GameFlowManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (transform.position.x - collision.transform.position.x < 0)
            {
                StartCoroutine(gameFlowManager.GameEnd());
            }
        }
    }

    IEnumerator GameClear()
    {
        float originTimeScale = Time.timeScale;

        Debug.Log("ゴール！");
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(0.5f);

        Time.timeScale = originTimeScale;
        SceneManager.LoadScene("ResultScene");
    }
}
