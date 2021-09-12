using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheatGrow : MonoBehaviour
{
    public WheatSize wheatSize1 = new WheatSize
    {
        xScale = 0.03f,
        yScale = 0.03f,
        zScale = 0.05f,
        yPosition = -0.902f,
        color = new Color(136, 242, 61, 1)
    };

    public WheatSize wheatSize2 = new WheatSize
    {
        xScale = 0.04f,
        yScale = 0.04f,
        zScale = 0.1f,
        yPosition = -0.853f,
        color = new Color(170, 182, 61, 1)
    };    
    
    public WheatSize wheatSize3 = new WheatSize
    {
        xScale = 0.04f,
        yScale = 0.04f,
        zScale = 0.2f,
        yPosition = -0.753f,
        color = new Color(200, 182, 61, 1)
    };    
    
    public WheatSize wheatSize4 = new WheatSize
    {
        xScale = 0.04f,
        yScale = 0.04f,
        zScale = 0.3f,
        yPosition = -0.67f,
        color = new Color(242, 182, 61, 1)
    };

    public List<WheatSize> wheatSizes = new List<WheatSize>();

    public WheatSize currentWheatSize;

    public int currentWheatSizeId = 0;

    void Start()
    {
        wheatSizes.Add(wheatSize1);
        wheatSizes.Add(wheatSize2);
        wheatSizes.Add(wheatSize3);
        wheatSizes.Add(wheatSize4);

        currentWheatSize = wheatSize1;
    }

    public void GrowWheat()
    {
        currentWheatSizeId++;
        currentWheatSize = wheatSizes[currentWheatSizeId];

        GetComponent<Renderer>().material.color = currentWheatSize.color;

        var tempPos = transform.localPosition;
        tempPos.y = currentWheatSize.yPosition;
        transform.localPosition = tempPos;

        var tempScale = transform.localScale;
        tempScale.x = currentWheatSize.xScale;
        tempScale.y = currentWheatSize.yScale;
        tempScale.z = currentWheatSize.zScale;
        transform.localScale = tempScale;
    }
}

public class WheatSize
{
    public float xScale;
    public float yScale;
    public float zScale;

    public float yPosition;
    public Color color;
}
