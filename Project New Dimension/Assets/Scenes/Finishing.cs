using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finishing : MonoBehaviour
{
    #region Singleton
    public static Finishing instance;

    private void Awake()
    {
        if (instance != null) return;

        instance = this;
    }
    #endregion

    [SerializeField]
    GameObject fail;

    [SerializeField]
    GameObject win;

    int nextScene;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void setWin()
    {
        win.SetActive(true);
        nextScene = 2;
        gameObject.SetActive(true);
    }

    public void setFail()
    {
        fail.SetActive(true);
        nextScene = 3;
        gameObject.SetActive(true);
    }

    public void GoToFinish()
    {
        SceneManager.LoadScene(nextScene);
    }
}
