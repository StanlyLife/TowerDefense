using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Waves", menuName = "ScriptableObject: Waves")]
public class Waves : ScriptableObject
{
	[System.Serializable]
	public class WaveDifficulty {
		public  string name;
		public Wave[] WaveNumber;
	}
	
	[System.Serializable]
	public class Wave {
		public  GameObject[] enemies;
		public  int[] numberOfEnemies;
		public	float[] timeBetweenEnemies;
	}
	
	public WaveDifficulty WaveDifficulties;


}
