using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Slider healthSlider;
    public int maxHealth;   // <===== init the max health in the player script

    // private void Start(){
    //     if(g == null){
    // //        g = GameManager.Instance;
    //     }
    //     healthSlider = GetComponent<Slider>();
    //     maxHealth = 100;
    //     healthSlider.maxValue = maxHealth;
    //     healthSlider.value = maxHealth;
    // }

    public void SetMaxHealth(int maxHealth){   // <<==== call this func in the player script start func  
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        Debug.Log("Akhil : Max health set");
    }

    public void updateHealth (int health) {
        healthSlider.value = health;          // <<==== call this func in damage or update func 
        Debug.Log("Akhil : health update");
    }

}
