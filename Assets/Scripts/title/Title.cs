using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour{
    public FadeImage fade;
    private bool firstPush= false;
    private bool goNextScene = false;
    
    public void PressStart(){
        if (!firstPush){
            fade.StartFadeOut();
            firstPush=true;
        }
    }

    private void Update(){
        if (!goNextScene && fade.IsFadeOutComplete()){
            SceneManager.LoadScene(1);
            goNextScene = true;
        }
    }
}
