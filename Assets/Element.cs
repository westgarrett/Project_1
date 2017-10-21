using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {

	// determines whether this is a mine
	public bool mine;

	// Different textures
	public Sprite[] emptyTextures;
	public Sprite mineTexture;

	// Use this for initialization
	void Start () {
		// determines if this is a mine or not randomly
		// random returns # btwn 0 and 1
		// we want a 15% probability
		mine = Random.value < 0.15;

        // put location into Grid
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Grid.elements[x, y] = this;

    }

	public void loadTexture(int adjacentCount) {
		if (mine)
			GetComponent<SpriteRenderer> ().sprite = mineTexture;
		else
			GetComponent<SpriteRenderer> ().sprite = emptyTextures [adjacentCount];
	}

	public bool isCovered() {
		return GetComponent<SpriteRenderer> ().sprite.texture.name == "Blank";
	}

	void OnMouseUpAsButton(0) {
		if (mine) {
            Grid.uncoverMines();
			print ("you lose");
		}
		else {
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            loadTexture(Grid.adjacentMines(x, y));

            Grid.floodFillUncover(x, y, new bool[Grid.w, Grid.h]);

            if (Grid.isFinished())
                print("you win");
        }
	}
}
