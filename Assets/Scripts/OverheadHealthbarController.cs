using UnityEngine;
using System.Collections;

public class OverheadHealthbarController : MonoBehaviour {
    private SpriteRenderer rend;
    public Sprite[] healthbarSprites;
    private GameController gameCtrl;

    protected void ChangeSprite(float progress, float maxProgress) {
        switch (gameCtrl.gameState) {

            case "live":
                //percentage
                float hpPerc = (progress / maxProgress) * maxProgress;
                //limit max progress
                if (hpPerc > 100f) hpPerc = 100f;
                //limit min progress
                if (hpPerc < 0f) hpPerc = 0f;
                //divides maximum progress by amount of sprite images
                float indexDivider = maxProgress / (healthbarSprites.Length - 1);
                //rounds down
                int spriteIndex = Mathf.FloorToInt((hpPerc) / indexDivider);
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
