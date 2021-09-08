
using UnityEngine;

public class seasonManager : MonoBehaviour
{
    public Season currentSeason = Season.Autumn;
    public int seasonSliderMax = 100;
    public int seasonSliderCurrent = 1;
    public float amountForSliderToIncrement = 3f;
    public float sliderTimer = 0f;


    //autumn lasts 2 mins, other seasons 1 each, 5 total
    //5 * 60 = 300, so 3 seconds per increment

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sliderTimer += Time.deltaTime;
        if(sliderTimer >= amountForSliderToIncrement)
        {
            seasonSliderCurrent++;
            sliderTimer = 0f;
        }
    }
}

public enum Season
{
    Autumn = 0,
    Winter = 1,
    Spring = 2,
    Summer = 3
}