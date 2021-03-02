using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player : MonoBehaviour {
	public Text starText;
	private int totalStars = 0;
	private int totalHp = 0;
	public Image starImage;
	public Sprite iconStar;
	public Sprite iconNoStar;
	private bool carryingStar = false;
	private PlayerInventoryDisplay playerInventoryDisplay;

	void Start() {
		UpdateStarText();
		playerInventoryDisplay = GetComponent <PlayerInventoryDisplay>();
	}
	
	void OnTriggerEnter2D(Collider2D hit) {
		if (hit.CompareTag("Coin")) {
			totalStars++;
			UpdateStarText();
			Destroy(hit.gameObject);
		}
		else if (hit.CompareTag("Banana")) {
			totalHp++;
			playerInventoryDisplay.OnChangeStarTotal(totalHp);
			Destroy(hit.gameObject);
		}
		if (hit.CompareTag("Coconut")) {
			carryingStar = true;
			UpdateStarImage();
			Destroy(hit.gameObject);
		}
	}
	
	private void UpdateStarImage() {
		if (carryingStar)
			starImage.sprite = iconStar;
		else
			starImage.sprite = iconNoStar;
	}

	
	private void UpdateStarText() {
		string starMessage = "Total Coin = " + totalStars;
		starText.text = starMessage;
	}
}