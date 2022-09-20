using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    public bool firstFadeInComp; 
    private Image img = null;
    private int frameCount = 0;
    private bool fadeIn = false;
    private bool fadeOut = false; 
    private bool compFadeIn = false; 
    private bool compFadeOut = false;
    private float timer = 0.0f;

    public void StartFadeIn(){
        if(fadeIn || fadeOut){
            return;
        }
        fadeIn = true;
        compFadeIn = false;
        timer = 0.0f;
        img.color = new Color (1, 1, 1, 1);
        img.raycastTarget = true;
    }

    public bool IsFadeInComplete(){
        return compFadeIn;
    }

    public void StartFadeOut(){
        if(fadeIn || fadeOut){
            return; 
        }
        fadeOut = true;
        compFadeOut = false;
        timer = 0.0f;
        img.color = new Color (1, 1, 1, 0);
        img.raycastTarget = true;
    }

    public bool IsFadeOutComplete(){
        return compFadeOut;
    }

    void Start(){
        img = GetComponent<Image>();
        if (firstFadeInComp){
            FadeInComplete();
        }
        else{
            StartFadeIn();
        }
    }


    void Update(){
        if (frameCount > 2){
            if (fadeIn){
                FadeInUpdate();
            }
            else if (fadeOut){
                FadeOutUpdate();
            }
        }
        ++frameCount;
    }
    private void FadeInUpdate(){
        if (timer < 1f){
            img.color = new Color (1, 1, 1, 1f - timer);
        }
        else{
            FadeInComplete();
        }
        timer += Time.unscaledDeltaTime;
    }

    private void FadeOutUpdate(){
        if (timer < 1f){
            img.color = new Color(1, 1, 1, timer);
        }
        else{
            FadeOutComplete();
        }
        timer += Time.unscaledDeltaTime;
    }

    private void FadeInComplete(){
        img.color = new Color(1, 1, 1, 0);
        img.raycastTarget = false;
        timer = 0.0f;
        fadeIn = false;
        compFadeIn = true;
    }

    private void FadeOutComplete(){
        img.color = new Color(1, 1, 1, 1);
        img.raycastTarget = false;
        timer = 0.0f;
        fadeOut = false;
        compFadeOut = true;
    }
}