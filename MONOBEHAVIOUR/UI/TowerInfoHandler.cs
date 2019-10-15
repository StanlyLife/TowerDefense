using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TowerInfoHandler : MonoBehaviour
{
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

	//TODO
	//Fix sellprices
	//Fix sellScript
	//Fix buyprices

	//OnClick screen slideDown
	public Animator sliderAnimator;

	public void SetText(int id) {
		currentCollection = GetTowerCollection(id);
		currentTower = currentCollection._Tower;
		SetTowerAttributes();
		SetProjectileAttributes();

		SetDescription();
		SetImages();

		Slide("in");
	}
	public void Exit() {
		Slide("Out");
	}


	private void Slide(string direction) {
		switch (direction.ToLower()){
			case "in":
			sliderAnimator.SetTrigger("SlideIn");
			break;

			case "out":
			sliderAnimator.SetTrigger("SlideOut");
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
		projectileImage.sprite = currentCollection.ProjectileImage;
		towerImage.sprite = currentCollection.towerImage;

		projectileImage.SetNativeSize();
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
}
