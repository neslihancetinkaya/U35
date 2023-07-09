using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject MainPanel;
        [SerializeField] private GameObject OptionsPanel;
        public void QuitGame()
        {
            Application.Quit();
        }
        
        public void ChangeScene(int index)
        {
                SceneManager.LoadScene(index);
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