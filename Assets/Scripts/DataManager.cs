using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Globalization;
using UnityEngine.SceneManagement;

using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public int subNo;
    public Transform player;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        string userDir = Path.Combine(Application.dataPath, "Save", subNo.ToString());
        Directory.CreateDirectory(userDir);
        PlayerData data = new PlayerData
        {
            subNo = subNo,
            posX = player.position.x,
            posY = player.position.y,
            posZ = player.position.z,
            currentScene = SceneManager.GetActiveScene().name,
            saveTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        string json = JsonUtility.ToJson(data);
        string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        string fileName = $"{subNo}_{timestamp}.json";
        string path = Path.Combine(userDir, fileName);
        File.WriteAllText(path, json);

    }
}
