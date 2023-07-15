using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI
{
    public class TabletController : MonoBehaviour
    {
        [SerializeField] private Text BottomText;
        [SerializeField] private Text UIText;
        [SerializeField] private List<String> Sentences;

        private int characterIndex;
        private float timePerCharacter;
        private float timer;
        private string textToWrite;
        
        private void OnEnable()
        {
            BottomText.text = "";
            UIText = BottomText;
            var rand = Random.Range(0, Sentences.Count);
            textToWrite = Sentences[rand];
            characterIndex = 0;
        }

        private void Update()
        {
            if(!UIText)
                return;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer += timePerCharacter;
                characterIndex++;
                UIText.text = textToWrite.Substring(0, characterIndex);

                if (characterIndex >= textToWrite.Length)
                {
                    UIText = null;
                    return;
                }
            }
        }
    }
}