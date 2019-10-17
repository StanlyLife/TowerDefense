using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TowerInfoHandler : MonoBehaviour
{
	[Header("GAMESETTINGS")]
	[SerializeField]
	private GameSettings gameSettings;
	[Header ("TOWER")]
	[SerializeField]
	private TowerSoCollection _TowerCollection;
	private TowerSoCollection.TowerCollectionClass currentCollection;
	private Tower currentTower;
	[Header ("Tower Attribute Values")]
	public TMPro.TMP_Text VTAttackSpeed;
	public TMPro.TMP_Text VTRadius;

	public TMPro.TMP_Text VTPrice;
	public TMPro.TMP_Text VTSellPrice;
	[Header ("Projectile Attribute Values")]
	public TMPro.TMP_Text VPDamage;
	public TMPro.TMP_Text VPSpeed;
	[Header ("Images")]
	public Image towerImage;
	public Image projectileImage;
	[Header ("Description")]
	public TMPro.TMP_Text Description;

	private float orginPHeight;
	private float orginPWidth;

	[HideInInspector]
	public bool fromTower = false;
	[HideInInspector]
	public bool isActive = false;
	//TODO
	//Fix sellprices
	//Fix sellScript
	//Fix buyprices

	//OnClick screen slideDown
	public Animator sliderAnimator;
	public GameObject button;
	[HideInInspector]
	public GameObject towerGO;
	private void Start() {
		orginPHeight = projectileImage.rectTransform.rect.height;
		orginPWidth = projectileImage.rectTransform.rect.width;
	}
	public void SetText(int id) {
		currentCollection = GetTowerCollection(id);
		currentTower = currentCollection._Tower;
		SetTowerAttributes();
		SetProjectileAttributes();

		SetDescription();
		SetImages();

		if (fromTower) {
			button.SetActive(true);
			fromTower = false;
		} else {
			button.SetActive(false);
		}


		Slide("in");
	}
	public void Exit() {
		Slide("Out");
	}


	public void Slide(string direction) {
		switch (direction.ToLower()){
			case "in":
			sliderAnimator.ResetTrigger("SlideOut");
			sliderAnimator.SetTrigger("SlideIn");
			isActive = true;
			break;

			case "out":
			sliderAnimator.ResetTrigger("SlideIn");
			sliderAnimator.SetTrigger("SlideOut");
			isActive = false;
			break;

			default:
			print("Error in Slide()");
			break;
		}
	}
	private void SetTowerAttributes() {
			/*Tower Attributes*/
		VTAttackSpeed.text = currentTower.projectileCooldown.ToString();
		VTRadius.text = currentTower.radius.ToString();
		VTPrice.text = currentTower.storePrice.ToString();
		VTSellPrice.text = currentTower.sellPrice.ToString();
	}
	private void SetProjectileAttributes() {
			/*Projectile Atttributes*/
		VPDamage.text = currentTower.projectileDamage.ToString();
		VPSpeed.text = currentTower.projectileSpeed.ToString();
	}
	private void SetDescription() {
		Description.text = currentCollection.description;
	}
	private void SetImages() {
		towerImage.sprite = currentCollection.towerImage;
		projectileImage.sprite = currentCollection.ProjectileImage;

		if (
			orginPWidth >= currentCollection.ProjectileImage.rect.width &&
			orginPHeight >= currentCollection.ProjectileImage.rect.height
			) {
			//UIImage is bigger than projectile image
			/*Scaling of image is allowed inside the margins given in the if statement*/
			projectileImage.SetNativeSize();
		} else {
			/*Scaling not allowed, scaled back to normal*/
			projectileImage.rectTransform.sizeDelta = new Vector2(orginPWidth,orginPHeight);
		}

	}
	private TowerSoCollection.TowerCollectionClass GetTowerCollection(int id) {
		int count = 0;
		foreach (TowerSoCollection.TowerCollectionClass tc in _TowerCollection.Towers) {
			if(tc.ID == id) {
				return tc;
			} else {
				count++;
				/*Keep searching*/
			}
		}
		print("Did not find any class with that ID");
		return null;
	} 

	public void SellTower() {
		gameSettings.MapMoney += towerGO.GetComponent<TowerBase>()._Tower.sellPrice;
		Destroy(towerGO);
	}
}
