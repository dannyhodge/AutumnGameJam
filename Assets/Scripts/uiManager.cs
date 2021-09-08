using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public GameObject woodUI;
    public GameObject stoneUI;
    public GameObject timeOfYear;
    public GameObject timeOfYearPanel;

    public float currentDistanceFloat = 1f;
    public float incrementAmount = 5;

    void Update()
    {
        woodUI.GetComponent<Text>().text = GetComponent<gameInfo>().currentWood.ToString();
        stoneUI.GetComponent<Text>().text = GetComponent<gameInfo>().currentStone.ToString();

        //var width = Mathf.Abs(timeOfYearPanel.GetComponent<RectTransform>().sizeDelta.x);
        //var numIncrementsMax = GetComponent<seasonManager>().seasonSliderMax;

        var numIncrementsCurrent = GetComponent<seasonManager>().seasonSliderCurrent;

        //var distPerIncrement = width / numIncrementsMax;

        //Debug.Log("width " + width);
        //Debug.Log("numIncrementsMax " + numIncrementsMax);
        //Debug.Log("distPerIncrement " + distPerIncrement);

        currentDistanceFloat = numIncrementsCurrent * incrementAmount;

        //Debug.Log("currentDistance " + currentDistanceFloat);

        timeOfYear.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, currentDistanceFloat, timeOfYear.GetComponent<RectTransform>().rect.width);
    }
}
