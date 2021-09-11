
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public gameInfo GameInfo;

    public GameObject woodUI;
    public GameObject stoneUI;
    public GameObject foodUI;
    public GameObject timeOfYear;
    public GameObject timeOfYearPanel;

    public GameObject autumnText;
    public GameObject winterText;
    public GameObject springText;
    public GameObject summerText;

    public GameObject yearText;

    public GameObject characterInfo;
    public GameObject nameVal;
    public GameObject hungerVal;
    public GameObject healthVal;
    public GameObject warmthVal;

    public seasonManager SeasonManager;

    public float currentDistanceFloat = 1f;
    public float incrementAmount = 5;

    void Start()
    {
        GameInfo = GetComponent<gameInfo>();

    }

    void Update()
    {
        SeasonManager = GetComponent<seasonManager>();
        woodUI.GetComponent<TextMeshProUGUI>().text = GameInfo.currentWood.ToString();
        stoneUI.GetComponent<TextMeshProUGUI>().text = GameInfo.currentStone.ToString();
        foodUI.GetComponent<TextMeshProUGUI>().text = GameInfo.currentFood.ToString();

        characterInfo.SetActive(GameInfo.activeVillager != null);

        if (GameInfo.activeVillager != null)
        {
            nameVal.GetComponent<TextMeshProUGUI>().text = "Name: " + GameInfo.activeVillager.GetComponent<villagerInfo>().villagerName;
            healthVal.GetComponent<TextMeshProUGUI>().text = "Health: " + GameInfo.activeVillager.GetComponent<villagerInfo>().health;
            hungerVal.GetComponent<TextMeshProUGUI>().text = "Hunger: " + GameInfo.activeVillager.GetComponent<villagerInfo>().hunger;
            warmthVal.GetComponent<TextMeshProUGUI>().text = "Warmth: " + GameInfo.activeVillager.GetComponent<villagerInfo>().warmth;
        }
        var numIncrementsCurrent = SeasonManager.seasonSliderCurrent;

        currentDistanceFloat = numIncrementsCurrent * incrementAmount;

        timeOfYear.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, currentDistanceFloat, timeOfYear.GetComponent<RectTransform>().rect.width);

        yearText.GetComponent<Text>().text = $"Year {SeasonManager.currentYear}";

        HandleNewSeason();
    }

    void HandleNewSeason()
    {
        switch (SeasonManager.currentSeason)
        {
            case Season.Autumn:
                autumnText.GetComponent<Text>().fontStyle = FontStyle.Bold;
                MakeTextNotBold(new GameObject[] { winterText, springText, summerText });
                break;

            case Season.Winter:
                winterText.GetComponent<Text>().fontStyle = FontStyle.Bold;
                MakeTextNotBold(new GameObject[] { autumnText, springText, summerText });
                break;

            case Season.Spring:
                springText.GetComponent<Text>().fontStyle = FontStyle.Bold;
                MakeTextNotBold(new GameObject[] { winterText, autumnText, summerText });
                break;

            case Season.Summer:
                summerText.GetComponent<Text>().fontStyle = FontStyle.Bold;
                MakeTextNotBold(new GameObject[] { winterText, springText, autumnText });
                break;
        }
    }

    void MakeTextNotBold(GameObject[] seasons)
    {
        foreach(GameObject season in seasons)
        {
            season.GetComponent<Text>().fontStyle = FontStyle.Normal;
        }
        
    }
}
