using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chopchop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buyButton;
    public GameObject chopButton;
    public GameObject treeToChop;
    void Start()
    {
        chopButton.SetActive(false);
    }

    public void UpdateUI()
    {

        buyButton.SetActive(false);
        StartCoroutine(DelayedFunction1());
        
    }
    // Wait for 2 seconds before executing the next line of code
    IEnumerator DelayedFunction1()
    {
        yield return new WaitForSeconds(3);
        // Code to execute after the delay
        chopButton.SetActive(true);
    }

    IEnumerator DelayedFunction2()
    {
        yield return new WaitForSeconds(5);
        // Code to execute after the delay
        treeToChop.SetActive(false);
    }

    public void hidebutton()
    {
        chopButton.SetActive(false);
    }


    // Update is called once per frame
    public void DestroyTree()
    {
        StartCoroutine(DelayedFunction2());
        
    }
}
