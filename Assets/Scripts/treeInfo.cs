
using UnityEngine;

public class treeInfo : MonoBehaviour
{
    public int health = 10;
    public bool isSelected = false;
    public GameObject active;

    void Start()
    {
        
    }

    void Update()
    {
        if(isSelected)
        {
            active.SetActive(true);
        }
        else
        {
            active.SetActive(false);
        }
        
    }
}
