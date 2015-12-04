using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}

    public void startGame()
    {
        Application.LoadLevel("Scene1");
    }
}
