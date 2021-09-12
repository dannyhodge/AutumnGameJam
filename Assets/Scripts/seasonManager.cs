
using UnityEngine;

public class seasonManager : MonoBehaviour
{
    public int currentYear = 0;
    public Season currentSeason = Season.Autumn;
    public int seasonSliderMax = 100;
    public int seasonSliderCurrent = 1;
    public float amountForSliderToIncrement = 3f;
    public float sliderTimer = 0f;

    public int amountToHitWinter = 38;
    public int amountToHitSpring = 62;
    public int amountToHitSummer = 80;
    public int amountToHitAutumn = 1;


    //autumn lasts 2 mins, other seasons 1 each, 5 total
    //5 * 60 = 300, so 3 seconds per increment


    void FixedUpdate()
    {
        sliderTimer += Time.deltaTime;
        if(sliderTimer >= amountForSliderToIncrement)
        {
            seasonSliderCurrent++;
            sliderTimer = 0f;

            if (seasonSliderCurrent == 101)
            {
                seasonSliderCurrent = 1;
                currentYear++;
            }

            if (seasonSliderCurrent == amountToHitAutumn || seasonSliderCurrent == amountToHitWinter || seasonSliderCurrent == amountToHitSpring || seasonSliderCurrent == amountToHitSummer)
            {
                ChangeSeason();
            }
        }

  

       
        
    }

    void ChangeSeason()
    {
        if (seasonSliderCurrent == amountToHitWinter) currentSeason = Season.Winter;
        if (seasonSliderCurrent == amountToHitSpring) currentSeason = Season.Spring;
        if (seasonSliderCurrent == amountToHitSummer) currentSeason = Season.Summer;
        if (seasonSliderCurrent == amountToHitAutumn) currentSeason = Season.Autumn;
    }
}

public enum Season
{
    Autumn = 0,
    Winter = 1,
    Spring = 2,
    Summer = 3
}