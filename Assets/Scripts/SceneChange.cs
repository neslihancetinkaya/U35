using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private int SceneIndex;
    [SerializeField] private Animator Transition;
    [SerializeField] private float Duration = 1;
    private static readonly int Start = Animator.StringToHash("Start");

    void OnEnable()
    {
        StartCoroutine(LoadLevel(SceneIndex));
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        Transition.SetTrigger(Start);

        yield return new WaitForSeconds(Duration);
        
        SceneManager.LoadScene(sceneIndex);
    }

}
