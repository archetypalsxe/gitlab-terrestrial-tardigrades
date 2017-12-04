using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class SettingsController {

	public bool musicPlaying = true;

	public void saveSettings() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/settings.gd");
		bf.Serialize(file, this);
		file.Close();
	}
}
