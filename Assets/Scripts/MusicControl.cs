using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.M))
        {
            
            AudioSource audio = GetComponent<AudioSource>();
            if (audio.isPlaying)
                audio.Stop();
            else
                audio.Play();
        }
    }
}
