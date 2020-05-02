using UnityEngine;
using System.Collections;

public class ItemProperties : MonoBehaviour
{
    [Header("Your Consumables")]
    public string itemName;

    [SerializeField] private bool food;
    [SerializeField] private bool water;
    [SerializeField] private float value;

  
    public void Interaction(PlayerStats PlayerStats)
    {
        if (food)
        {
            PlayerStats.food_Stats.fillAmount += value;
            this.gameObject.SetActive(false);
        }

        else if (water)
        {
            PlayerStats.water_Stats.fillAmount += value;
            this.gameObject.SetActive(false);
        }

       
       
    }
}
