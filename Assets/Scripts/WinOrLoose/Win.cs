using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Win : MonoBehaviour
{
    [SerializeField] private Button restart;
    [SerializeField] private TMP_Text win;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Car>())
        {
            restart.gameObject.SetActive(true);
            win.gameObject.SetActive(true);
        }
    }
}
