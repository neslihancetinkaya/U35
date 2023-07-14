using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private int SceneIndex;
    void OnEnable()
    {
        SceneManager.LoadScene(SceneIndex);
    }

}
