using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    public GameObject origin;
    private string m_CurrentScene;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentScene = "start";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNewScene(string sceneName)
    {
        //SceneManager.LoadScene(sceneName);
        //AdjustPlayerSpawn();
        StartCoroutine(SwitchScenes(sceneName));
    }

    private IEnumerator SwitchScenes(string newScene)
    {
        yield return SceneManager.UnloadSceneAsync(m_CurrentScene);
        yield return SceneManager.LoadSceneAsync(newScene);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(newScene));
        m_CurrentScene = newScene;
        AdjustPlayerSpawn();
    }

    private void AdjustPlayerSpawn()
    {
        GameObject spawnPoint = GameObject.Find("SpawnPoint");
        if (spawnPoint != null)
        {
            origin.transform.SetPositionAndRotation(
                spawnPoint.transform.position,
                spawnPoint.transform.rotation
                );
        }
    }
}
