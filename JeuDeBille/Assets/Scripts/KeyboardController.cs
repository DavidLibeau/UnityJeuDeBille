using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyboardController : MonoBehaviour {

    public GameObject EndScreen;
    private Text texteFin;
    private bool jeuFin;

	void Start () {
        jeuFin = false;
	}
	
	void Update () {
        if(!jeuFin){
            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.1f, 0f, 0f), ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-0.1f, 0f, 0f), ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0.1f, 0f), ForceMode.Impulse);
            }
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (!jeuFin)
        {
            //Debug.Log("OnCollisionStay");
            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.4f, 0f, 0f), ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-0.4f, 0f, 0f), ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //Debug.Log(collisionInfo.collider.name);
                if (collisionInfo.collider.name == "Tapis1" || collisionInfo.collider.name == "Tapis2")
                {
                    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 4f, 0f), ForceMode.Impulse);
                }
                else
                {
                    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0.1f, 0f), ForceMode.Impulse);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "Finish")
        {
            //Debug.Log("Finish!");
            EndScreen.SetActive(true);
            texteFin = EndScreen.GetComponent<Text>();
            texteFin.text = "You win ! :)";
            jeuFin = true;
        }
        if (collisionInfo.collider.name == "Loose")
        {
            Debug.Log("Loose!");
            EndScreen.SetActive(true);
            texteFin=EndScreen.GetComponent<Text>();
            texteFin.text = "You loose ! :(";
            jeuFin = true;
        }
    }
}
