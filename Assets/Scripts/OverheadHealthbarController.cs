using UnityEngine;
using System.Collections;

public class OverheadHealthbarController : MonoBehaviour
{
    SpriteRenderer rend;
    
    public Sprite[] healthbarSprites;
    GameController gameCtrl;
    CookingContainer objCtrl;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        objCtrl = GetComponentInParent<CookingContainer>();
        gameCtrl = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Update()
    {

        switch (gameCtrl.gameState)
        {
            
            case "live":

                
                float hpPerc = ((float)objCtrl.progress / 100f) * 100f;
                if (hpPerc > 100) hpPerc = 100f;

				float indexDivider = 100 / (healthbarSprites.Length - 1);
				int spriteIndex = (int) ((hpPerc + 2.5f) / indexDivider);
				//print("spriteIndex " + spriteIndex);
				rend.sprite = healthbarSprites[spriteIndex];
                
                break;
        }
        
        
    }
}
