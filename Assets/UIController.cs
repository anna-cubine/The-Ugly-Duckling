using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    [SerializeField] TMP_Text scoreLabel;
    //[SerializeField] SettingsPopup settingsPopup;
    private SceneController sceneController;

    public int score;

    void OnEnable() {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);     
    }

    void OnDisable() {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);  
    }

    void Start() {
        score = 0;
        scoreLabel.text = score.ToString() + "/4";                         
       // settingsPopup.Close();
    }

    public void OnEnemyHit() {
        // Check if score reaches 5, and if so, quit the game
       
        
        // Increment score and update UI
        score += 1;
        scoreLabel.text = score.ToString() + "/4";
		if (score == 4) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return; // Make sure to return after quitting to prevent further score increment
        }
    }
}