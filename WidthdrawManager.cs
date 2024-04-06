using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using TMPro;

public class WithdrawManager : MonoBehaviour
{
    public InputField amountInput;
    public TMP_Text outputText;

    private int numSteaksToWithdraw;

    public async void WithdrawSteaks()
    {

        if (int.TryParse(amountInput.text, out numSteaksToWithdraw))
        {
            int steakCount = CountSteaks.Stakes;
            if(steakCount > numSteaksToWithdraw)
            {
                bool success = await MetaMaskManager.withdrawsteak(numSteaksToWithdraw);
                if(success == true)
                {
                    outputText.text = "Success Withdraw";
                }
                else outputText.text = "Failed Withdraw";
            }
            else
            {
                UpdateOutputText("Steak balance is not enough");
            }

            
        }
        else
        {
            UpdateOutputText("Please Input Integer Steak amount");
        }
        StartCoroutine(removetext());


    }

    private void UpdateOutputText(string message)
    {
        outputText.text = message;
    }
    IEnumerator removetext()
    {
        yield return new WaitForSeconds(3f);
        outputText.text = "";
        //warmtext.gameObject.SetActive(false);
    }
}