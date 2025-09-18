using UnityEngine;

public class GoalHitter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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
                Debug.Log("ゴール！");
                Time.timeScale = 0;
            } 
        }
    }
}
