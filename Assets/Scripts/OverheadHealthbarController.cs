using UnityEngine;
using System.Collections;

public class OverheadHealthbarController : MonoBehaviour {
    private SpriteRenderer rend;

    public Sprite[] healthbarSprites;
    private GameController gameCtrl;

    protected void ChangeSprite(float progress, float maxProgress) {
        switch (gameCtrl.gameState) {

            case "live":
                float hpPerc = (progress / maxProgress) * maxProgress;
                if (hpPerc > maxProgress) hpPerc = maxProgress;

                float indexDivider = maxProgress / (healthbarSprites.Length - 1);
                //what is 2.5 arbitary number
                int spriteIndex = (int)((hpPerc + 2.5f) / indexDivider);
                //print("spriteIndex " + spriteIndex);
                rend.sprite = healthbarSprites[spriteIndex];

                break;
        }

    }
    protected void Initialise() {
        rend = GetComponent<SpriteRenderer>();
        gameCtrl = GameObject.Find("GameController").GetComponent<GameController>();
    }
}
