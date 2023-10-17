using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelsMenu : MonoBehaviour
{
    public GameObject levelButtonsGameObject;
    public Button[] levelButtons;
    public void Awake(){
        AssignLevelButtons();
        UpdateLevelsAcces();
    }

    public void StartLevel(int levelId){
        string levelName = "Level" + levelId;
        SceneManager.LoadSceneAsync(levelName);
    }

    public void UpdateLevelsAcces(){
        int unlockedLevelsAmount = PlayerPrefs.GetInt("LevelsAmount", 1);
        for (int i = 0; i < levelButtons.Length; i++){
            if (i < unlockedLevelsAmount){
                levelButtons[i].interactable = true;
            } else {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void AssignLevelButtons(){
        int levelsAmount = levelButtonsGameObject.transform.childCount;
        levelButtons = new Button[levelsAmount];
        for (int i = 0; i < levelButtons.Length; i++){
            levelButtons[i] = transform.GetChild(i).GetComponent<Button>();
        }
    }
}
