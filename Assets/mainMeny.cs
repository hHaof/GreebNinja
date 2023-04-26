using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMeny : MonoBehaviour
{

    void Start(){
        Time.timeScale = 0f;
    }
    // Start is called before the first frame update
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void QuitGame(){
        Application.Quit();
    }
}
