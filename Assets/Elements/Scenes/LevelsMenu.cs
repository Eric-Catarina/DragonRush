using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    public void StartLevel(int levelId){
        string levelName = "Level" + levelId;
        SceneManager.LoadSceneAsync(levelName);
    }
}
