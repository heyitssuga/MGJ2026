using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Tablet;

    [SerializeField] GameObject Portal;

    private bool collected = false;

    public bool Collected
    {
        get => collected;
        set => collected = value;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (collected == true && Portal != null)
        {
            Portal.SetActive(true);
        }
    }


    public void SceneSwap(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "TitleScreen")
        {
            return;
        }

        Tablet = GameObject.Find("tablet_piece");
        Portal = GameObject.Find("Portal");
        if (Portal != null)
        {
            Portal.SetActive(false);
        }
    }
}
