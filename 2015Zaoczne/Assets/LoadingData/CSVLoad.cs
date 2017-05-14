using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVLoad : MonoBehaviour {

    //Zeby to dzialalo, w katalogu StreamingAssets w Unity
    //musi byc plik CSVTest.csv. Ten plik tekstowy musi wygladac takL
    /*
     
     health;180
     ap;10
     aim;30
     

     */
     //srednik oznacza nowa kolumne. Taki plik csv mozna otworzyc
     //i zapisac w Excelu.

     //zapis do pliku wymaga wywolania funkcji SaveData()
     //np. z buttona z UI.

    public int health;
    public int actionPoints;
    public int aim;

	// Use this for initialization
	void Start () {
        Debug.Log(Application.streamingAssetsPath);
        LoadDataFromCSV(Application.streamingAssetsPath + Path.DirectorySeparatorChar + "CSVTest.csv");
	}

    public void SaveData()
    {
        SaveDataToCSV(Application.streamingAssetsPath + Path.DirectorySeparatorChar + "CSVTest.csv");
    }

    void SaveDataToCSV(string path)
    {
        string[] save = new string[3];
        save[0] = "health;" + health.ToString();
        save[1] = "ap;" + actionPoints.ToString();
        save[2] = "aim;" + aim.ToString();
        File.WriteAllLines(path, save);
    }
    void LoadDataFromCSV(string path)
    {
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            string[] columns;
            for (int i = 0; i < lines.Length; i++)
            {
                columns = lines[i].Split(';');
                if (columns[0].StartsWith("health"))
                {
                    health = int.Parse(columns[1]);
                }
                else if (columns[0].StartsWith("ap"))
                {
                    actionPoints = int.Parse(columns[1]);
                }
                else if (columns[0].StartsWith("aim"))
                {
                    aim = int.Parse(columns[1]);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
