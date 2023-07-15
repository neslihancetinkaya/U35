using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject MainPanel;
        [SerializeField] private GameObject OptionsPanel;
        [SerializeField] private Animator Transition;
        
        private static readonly int Start = Animator.StringToHash("Start");


        public void QuitGame()
        {
            Application.Quit();
        }
        
        public void ChangeScene(int index)
        {
            StartCoroutine(LoadLevel(index));
        }
        
        IEnumerator LoadLevel(int sceneIndex)
        {
            Transition.SetTrigger(Start);

            yield return new WaitForSeconds(1);
        
            SceneManager.LoadScene(sceneIndex);
        }

        public void OnOptions()
        {
            OptionsPanel.SetActive(true);
            MainPanel.SetActive(false);
        }

        public void OnBack()
        {
            MainPanel.SetActive(true);
            OptionsPanel.SetActive(false);
        }
        
        
    }
}