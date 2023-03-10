using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausingManager : MonoBehaviour
{
    private static PausingManager instance;
    public static PausingManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseGame()
    {
        GameManager.Instance.paused = true;
        GameManager.Instance.mutationUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        GameManager.Instance.paused = false;
        GameManager.Instance.mutationUI.SetActive(false);
        Time.timeScale = 1;
    }
}
