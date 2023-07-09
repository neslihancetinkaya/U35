using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private bool IsTimeLine = true;
    [SerializeField] private int SceneIndex;
    void OnEnable()
    {
        if (IsTimeLine)
        {
            SceneManager.LoadScene(SceneIndex);
        }
    }
    
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
