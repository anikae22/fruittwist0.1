using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupController : MonoBehaviour
{
    public UIController ui;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Coin")) {
            ui.UpdateScore();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Coinx5")) {
            ui.UpdateScore(5);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Coinx25")) {
            ui.UpdateScore(25);
            Destroy(other.gameObject);
        }
    }

}