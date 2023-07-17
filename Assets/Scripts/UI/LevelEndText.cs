using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelEndText : MonoBehaviour
    {
        [SerializeField] private Text UIText;
        [SerializeField] private string Sentence;

        private int characterIndex;
        private float timePerCharacter;
        private float timer;

        private void Update()
        {
            if(!UIText)
                return;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer += timePerCharacter;
                characterIndex++;
                UIText.text = Sentence.Substring(0, characterIndex);

                if (characterIndex >= Sentence.Length)
                {
                    UIText = null;
                    return;
                }
            }
        }
    }
}