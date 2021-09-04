using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //NEED

public class LevelLoader : MonoBehaviour
{
    public string sLevelToLoad;
    public bool useIntegerToLoadLevel = false;

    public void OnTriggerEnter2D(Collider2D collision){
        //GameObject collisionGameObject = collision.gameObject;
        if(collision.gameObject.CompareTag("Player")){
            LoadScene();
        }
    }

    void LoadScene(){
        StateNameController.score= ScoreManager.score;
        SceneManager.LoadScene(sLevelToLoad);
    }
}
