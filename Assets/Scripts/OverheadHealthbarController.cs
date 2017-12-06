using UnityEngine;
using System.Collections;

public class OverheadHealthbarController : MonoBehaviour {
    private SpriteRenderer rend;

    public Sprite[] healthbarSprites;
    private GameController gameCtrl;

    protected void ChangeSprite(float progress) {
        switch (gameCtrl.gameState) {

            case "live":
                float hpPerc = (progress / 100f) * 100f;
                if (hpPerc > 100) hpPerc = 100f;

                float indexDivider = 100 / (healthbarSprites.Length - 1);
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
