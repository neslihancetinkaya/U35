using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class İnVacum : MonoBehaviour
{
   
    public Animator animator; // Karakterinizdeki Animator bileşeni

    private bool İnvacum = false; // Animasyon boolinginin durumunu tutmak için değişken

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // Aktivasyon tuşuna basıldığında
        {
            İnvacum = !İnvacum; // Durumu tersine çevir

            animator.SetBool("İnVacum", İnvacum); // Animator bileşenindeki boolingi güncelle
            
        }
       
    }

}
