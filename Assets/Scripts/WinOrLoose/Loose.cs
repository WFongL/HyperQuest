using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Loose : MonoBehaviour
{
    [SerializeField] private Button restart;
    [SerializeField] private TMP_Text loose;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Car>())
        {
            restart.gameObject.SetActive(true);
            loose.gameObject.SetActive(true);
        }
    }
}
