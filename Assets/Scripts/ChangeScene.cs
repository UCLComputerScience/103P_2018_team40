using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    void Awake()
    {
        Screen.SetResolution(1366, 768, true);
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}