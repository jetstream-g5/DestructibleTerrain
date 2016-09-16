using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckForPos : MonoBehaviour {

    [SerializeField]private Text text;

	void Update () {
	    if(transform.position.y <= -20)
        {
            LoseGame();
            Destroy(this.gameObject);
            Time.timeScale = 0;
        }
	}

    void LoseGame()
    {
        text.text = gameObject.name + " Lost";
    }
}
