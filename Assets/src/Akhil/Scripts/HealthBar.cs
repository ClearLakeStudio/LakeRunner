using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Slider healthSlider;
    private GameManager g;
    public int maxHealth;

    private void Start(){
        if(g == null){
    //        g = GameManager.Instance;
        }
        healthSlider = GetComponent<Slider>();
        maxHealth = 100;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void SetMaxHealth(int maxHealth){
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

 /*   public void subtract_damage(){
        healthSlider.value -= 1;
        if(healthSlider.value <= 0){
            g.game_over();
        }
    }  */

}
