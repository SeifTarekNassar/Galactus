using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Splash : MonoBehaviour {
    public Image splashimage;
    public string loadlevel;




    IEnumerator Start()
    {
        splashimage.canvasRenderer.SetAlpha(0.0f);

        fadein();
        yield return new WaitForSeconds(2.5f);
        fadeout();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(loadlevel);
    }

    void fadein()
    {
        splashimage.CrossFadeAlpha(1.0f,1.5f,false);
    }
    void fadeout()
    {
        splashimage.CrossFadeAlpha(0.0f, 2.5f, false);
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
