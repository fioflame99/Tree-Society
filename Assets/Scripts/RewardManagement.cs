using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardManagement : MonoBehaviour
{
    public Text AxeDisplay;
    public Text CoinsDisplay;
    private int axes;
    private int coins;
    public GameObject options;
    public GameObject defaultbuttons;
    public GameObject buyingpanel;
    public GameObject mainPanel;
    public GameObject Error;
    public TextMeshProUGUI errortext;
    public Button buy1;
    public Button buy2;
    public Button buy3;
    [SerializeField] public int treeID;
    [SerializeField] public int price;
    private bool bought = false;
    // Start is called before the first frame update
    void Start()
    {
	  PlayerPrefs.SetInt("axes", 0);
	  PlayerPrefs.SetInt("coins", 0);
	  PlayerPrefs.SetInt("tree", 0);
        AxeDisplay.text = "0";
	  CoinsDisplay.text = "0";	
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //add in logic to make start button reappear after?
    public void selectAxeReward(){
	axes = PlayerPrefs.GetInt("axes");
	axes+=1;
	AxeDisplay.text = axes.ToString();
	PlayerPrefs.SetInt("axes", axes);
	options.gameObject.SetActive(false);
	defaultbuttons.gameObject.SetActive(true);
    }
    public void selectCoinReward(){
	coins = PlayerPrefs.GetInt("coins");
	coins+=10;
	CoinsDisplay.text = coins.ToString();
	PlayerPrefs.SetInt("coins", coins);
	options.gameObject.SetActive(false);
	defaultbuttons.gameObject.SetActive(true);
    }
    public void chopfriendtree(){
	//implement logic for reduce axes and photon tie in
	axes = PlayerPrefs.GetInt("axes");
	if (axes>=1){
		axes = axes - 1;
		PlayerPrefs.SetInt("axes",axes);
		axes= PlayerPrefs.GetInt("axes");
		AxeDisplay.text = axes.ToString();
		//photon tie in to remove the tree
	}
	else{
		//may need to make other things inactive
		Error.gameObject.SetActive(true);
		errortext.text ="You do not have enough axes.Please Try Again";
	}
    }
    public void buyingPanel(){
	//implement logic of displaying the buy panel and disable the current panel
      buyingpanel.gameObject.SetActive(true);
	mainPanel.gameObject.SetActive(false);
    }
    public void buyingTree(int price){
	// this method stores the treeID if used to plant next tree and deducts the price of the tree from coins
	coins = PlayerPrefs.GetInt("coins");
	if (price>coins){
		buy1.interactable = false;
		buy2.interactable = false;
		buy3.interactable = false;
		Error.gameObject.SetActive(true);
		errortext.text ="You do not have enough coins.Please Try Again";
	}
	else{
		coins= coins - price;
		bought = true;
		PlayerPrefs.SetInt("coins",coins);
		buyingpanel.gameObject.SetActive(false);
		mainPanel.gameObject.SetActive(true);
		coins= PlayerPrefs.GetInt("coins");
		CoinsDisplay.text = coins.ToString();
	}
    }
    public void storetree(int treeID){
	if (bought == true){
		PlayerPrefs.SetInt("tree",treeID);
		bought =  false;
	}
    }
    public void clearerror(){
	Error.gameObject.SetActive(false);
	buy1.interactable = true;
	buy2.interactable = true;
	buy3.interactable = true;
    }
    public void returnbacktomain(){
	buyingpanel.gameObject.SetActive(false);
	mainPanel.gameObject.SetActive(true);
    }
}
