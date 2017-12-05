using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text MoneyUI,waveUI;
    GameController gameCtrl;
	// Use this for initialization
	void Start () {
        gameCtrl = GameObject.Find("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        waveUI.text = "Wave: "+gameCtrl.wave.ToString();
        switch (gameCtrl.gameState)
        {
            case "waiting":
                MoneyUI.text = "Press Enter to start game.";
                break;
            case "live":
                MoneyUI.text = "Money: £" + gameCtrl.money.ToString();
                break;
            default:
                break;
        }
        
	}
}
