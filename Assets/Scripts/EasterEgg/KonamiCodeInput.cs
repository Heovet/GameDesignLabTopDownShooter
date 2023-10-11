using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class KonamiCodeInput : MonoBehaviour
{
    private string[] konamiCode = { "Up", "Up", "Down", "Down", "Left", "Right", "Left", "Right", "b", "a" };
    private int currentIndex = 0;
    private bool konamiCodeEntered = false;

    [SerializeField]private UnityEvent loadKonami;

    private void Update()
    {
        if (konamiCodeEntered)
        {
            Debug.Log("Konami Code Entered!");
            // Perform your desired action here.
            // For example, you can activate a cheat, unlock a secret feature, or whatever you need.
            // Reset the index to listen for the Konami code again if needed.
            currentIndex = 0;
            konamiCodeEntered = false;
            loadKonami.Invoke();
        }
    }
    private void OnKonamiUp(InputValue iv)
    {
        if (konamiCode[currentIndex] == "Up")
        {
/*            Debug.Log(konamiCode[currentIndex]);*/
            currentIndex++;
        }
        else
        {
            currentIndex = 0;
        }
    }
    private void OnKonamiDown(InputValue iv)
    {
        if (konamiCode[currentIndex] == "Down")
        {
/*            Debug.Log(konamiCode[currentIndex]);*/
            currentIndex++;
        }
        else
        {
            currentIndex = 0;
        }
    }
    private void OnKonamiLeft(InputValue iv)
    {
        if (konamiCode[currentIndex] == "Left")
        {
/*            Debug.Log(konamiCode[currentIndex]);*/
            currentIndex++;
        }
        else
        {
            currentIndex = 0;
        }
    }
    private void OnKonamiRight(InputValue iv)
    {
        if (konamiCode[currentIndex] == "Right")
        {
/*            Debug.Log(konamiCode[currentIndex]);*/
            currentIndex++;
        }
        else
        {
            currentIndex = 0;
        }
    }
    private void OnKonamiB(InputValue iv)
    {
        if (konamiCode[currentIndex] == "b")
        {
/*            Debug.Log(konamiCode[currentIndex]);*/
            currentIndex++;
        }
        else
        {
            currentIndex = 0;
        }
    }
    private void OnKonamiA(InputValue iv)
    {
        if (konamiCode[currentIndex] == "a")
        {
            konamiCodeEntered = true;
        }
        else
        {
            currentIndex = 0;
        }
    }
}
