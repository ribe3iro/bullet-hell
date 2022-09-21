using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject score;
    [SerializeField] TextMeshProUGUI finalScore;
    public FadeImage fade;
    private bool retrying = false;
    private bool quiting = false;

    // Start is called before the first frame update
    void Start()
    {
        int points = score.GetComponent<ScoreController>().score;
        finalScore.text = points.ToString() + " pts";
        score.SetActive(false);
    }

    // Update is called once per frame
    public void Retry()
    {
        if (!retrying){
            fade.StartFadeOut();
            retrying = true;
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    private void Update(){
        if (retrying && fade.IsFadeOutComplete()){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
            retrying = false;
        }
    }
}
