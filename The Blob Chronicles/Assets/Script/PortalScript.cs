using UnityEngine;

public class PortalScript : MonoBehaviour
{

	private GameManager gameManager;

    [SerializeField] private string SceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.Collected = false;
            gameManager.SceneSwap(SceneName);
        }
    }
}
