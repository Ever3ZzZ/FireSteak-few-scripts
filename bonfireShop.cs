using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml;

public class bonfireShop : MonoBehaviour
{

    public GameObject BluefireLock;
    public GameObject GreenfireLock;
    public GameObject HellfireLock;
    public GameObject BarbiefireLock;

    public TMP_Text Bluefiretxt;
    public TMP_Text Greenfiretxt;
    public TMP_Text Hellfiretxt;
    public TMP_Text Barbiefiretxt;

    public TMP_Text boughtBlue;
    public TMP_Text boughtGreen;
    public TMP_Text boughtHell;
    public TMP_Text boughtBarbie;

    // Start is called before the first frame update
    void Start()
    {
        MetaMaskManager.Getvalue("userlevel");
        BluefireLock.SetActive(true);
        GreenfireLock.SetActive(true);
        HellfireLock.SetActive(true);
        BarbiefireLock.SetActive(true);

        boughtBlue.gameObject.SetActive(false);
        boughtGreen.gameObject.SetActive(false);
        boughtHell.gameObject.SetActive(false);
        boughtBarbie.gameObject.SetActive(false);

        Bluefiretxt.gameObject.SetActive(false);
        Greenfiretxt.gameObject.SetActive(false);
        Hellfiretxt.gameObject.SetActive(false);
        Barbiefiretxt.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        int user_level = BonfireManager.userlevel;
        if(user_level >= 104)
        {
            BluefireLock.SetActive(false);
        }
        if(user_level >= 216)
        {
            GreenfireLock.SetActive(false);
        }
        if (user_level >= 364)
        {
            HellfireLock.SetActive(false);
        }
        if (user_level >= 656)
        {
            BarbiefireLock.SetActive(false);
        }
    }

    IEnumerator delayTime()
    {
        yield return new WaitForSeconds(3f);
    }

    public async void buyNFTfire()
    {
        await MetaMaskManager.buynft();
    }
    public async void buyBluefire()
    {
        int tokenbalance = BalanceManager.BalanceCount;
        if (tokenbalance >= 150) {
            bool sucess = await MetaMaskManager.buybonfire(1, 150);
            if(sucess)
            {
                boughtBlue.gameObject.SetActive(true);
                float delay = 3f;

                Invoke("DeactivateBoughtBlue", delay);

                void DeactivateBoughtBlue()
                {
                    boughtBlue.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            Bluefiretxt.gameObject.SetActive(true);
            float delay = 3f;

            Invoke("DeactivateBluefiretext", delay);

            void DeactivateBluefiretext()
            {
                Bluefiretxt.gameObject.SetActive(true);
            }
        }
    }

    public async void buyGreenfire()
    {
        int tokenbalance = BalanceManager.BalanceCount;
        if (tokenbalance >= 150)
        {
            bool sucess = await MetaMaskManager.buybonfire(2, 150);
            if (sucess)
            {
                boughtGreen.gameObject.SetActive(true);
                float delay = 3f;

                Invoke("DeactivateBoughtGreen", delay);

                void DeactivateBoughtGreen()
                {
                    boughtGreen.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            Greenfiretxt.gameObject.SetActive(true);
            float delay = 3f;

            Invoke("DeactivateGreenfiretext", delay);

            void DeactivateGreenfiretext()
            {
                Greenfiretxt.gameObject.SetActive(true);
            }
        }
    }

    public async void buyHellfire()
    {
        int tokenbalance = BalanceManager.BalanceCount;
        if (tokenbalance >= 300)
        {
            bool sucess = await MetaMaskManager.buybonfire(3, 300);
            if (sucess)
            {
                boughtHell.gameObject.SetActive(true);
                float delay = 3f;

                Invoke("DeactivateBoughtHell", delay);

                void DeactivateBoughtHell()
                {
                    boughtHell.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            Hellfiretxt.gameObject.SetActive(true);
            float delay = 3f;

            Invoke("DeactivateHellfiretext", delay);

            void DeactivateHellfiretext()
            {
                Hellfiretxt.gameObject.SetActive(true);
            }
        }
    }

    public async void buyBarbiefire()
    {
        int tokenbalance = BalanceManager.BalanceCount;
        if (tokenbalance >= 500)
        {
            bool sucess = await MetaMaskManager.buybonfire(4, 500);
            if (sucess)
            {
                boughtBarbie.gameObject.SetActive(true);
                float delay = 3f;

                Invoke("DeactivateBoughtBarbie", delay);

                void DeactivateBoughtBarbie()
                {
                    boughtBarbie.gameObject.SetActive(false);
                }

            }
        }
        else
        {
            Barbiefiretxt.gameObject.SetActive(true);
            float delay = 3f;

            Invoke("DeactivateBarbiefiretext", delay);

            void DeactivateBarbiefiretext()
            {
                Barbiefiretxt.gameObject.SetActive(true);
            }
        }
    }
}
