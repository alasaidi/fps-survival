using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    [SerializeField]
    public Image health_Stats, stamina_Stats, water_Stats, food_Stats;
    public int maxThirst;
    public float thirstFallRate;
    public int maxHunger;
    public int hungerFallRate;
    private object player;
    public bool is_Player;


    public float healthFallRate;
    private bool is_Dead;

   
    public void Display_HealthStats(float healthValue) {

        healthValue /= 100f;

        health_Stats.fillAmount = healthValue;

    }

    public void Display_StaminaStats(float staminaValue) {

        staminaValue /= 100f;

        stamina_Stats.fillAmount = staminaValue;

    }
    public void Display_waterStats(float waterValue)
    {

        waterValue /= 100f;

        stamina_Stats.fillAmount = waterValue;

    }
    public void Display_foodStats(float foodValue)
    {

        foodValue /= 100f;

        stamina_Stats.fillAmount = foodValue;

    }
    void Update()
    {
        // if we died don't execute the rest of the code
        if (is_Dead)
            return;
        //HEALTH CONTROL SECTION
         if (food_Stats.fillAmount <= 0 && (water_Stats.fillAmount <= 0))
        {
            health_Stats.fillAmount -= Time.deltaTime / healthFallRate * 2;
        }

        if (water_Stats.fillAmount <= 0)
        {
            health_Stats.fillAmount -= Time.deltaTime / healthFallRate;
        }

        if (health_Stats.fillAmount <= 0)
        {
            PlayerDied();
            is_Dead = true;
        }

            //HUNGER CONTROL SECTION
            if (food_Stats.fillAmount >= 0)
        {
           food_Stats.fillAmount -= Time.deltaTime / hungerFallRate;
        }

       else if (food_Stats.fillAmount <= 0)
       {
            food_Stats.fillAmount = 0;
        }

        else if (food_Stats.fillAmount >= maxHunger)
        {
            food_Stats.fillAmount = maxHunger;
        }

        //THIRST CONTROL SECTION
        if (water_Stats.fillAmount >= 0)
        {
            water_Stats.fillAmount -= Time.deltaTime / thirstFallRate;
        }

        else if (water_Stats.fillAmount <= 0)
        {
            water_Stats.fillAmount = 0;
        }

        else if (water_Stats.fillAmount >= maxThirst)
        {
            water_Stats.fillAmount = maxThirst;
        }
    }

    private void PlayerDied()
    {
        if (is_Player)
        {

            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().enabled = false;
            }

            // call enemy manager to stop spawning enemis
            // EnemyManager.instance.StopSpawning();

            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);

        }

        if (tag == Tags.PLAYER_TAG)
        {

            Invoke("RestartGame", 3f);

        }
        else
        {

            Invoke("TurnOffGameObject", 3f);

        }



    }
    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }
} // class





























