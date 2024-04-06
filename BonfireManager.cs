using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class BonfireManager : MonoBehaviour
{

    public static int bonfirelimit = 0;
    public static int userlevel = 0;
    public static string userbonfire;

    public GameObject WaitEndFireText;
    //public GameObject ButtonYesFire;
    public GameObject Button;
    public GameObject TextDoneSteak;
    private static float timerStart = 7f;
    public TMP_Text textTimer;
    public GameObject ZeroCoins;
    public GameObject TextZeroStakes;
    public GameObject SpichkaSound;
    public AudioSource FireSound;
    public AudioSource FireSoundQuite;
    public Sprite ButtonKypleno;
    public GameObject ParticleSystemFire;
    //public GameObject LockOff;
    //public Sprite LockOnn;
    public GameObject FireSleepParticles;
    public GameObject BonfireKyplen;
    //private Color ColorBlue = Color.;
    public GameObject ButtonNoWork;

    public Text LevelText;
    public Text ResultText;

    public GameObject BluefirefryButton;
    public GameObject GreenfirefryButton;
    public GameObject HellfirefryButton;
    public GameObject BarbiefirefryButton;

    public GameObject Shoppanel;


    //bool timerRunningBust = false;
    bool FireSoundd = false;
    bool timerRunning = false;
    float deltatime = 0;
    //bool StakesZero = false;
    //bool StakesZeroBalance = false;
    //bool ButtonKyplenoo;

    //bool timerRuninngBlueFire = false;




    void Start()
    {
        MetaMaskManager.Getvalue("coin");
        MetaMaskManager.Getvalue("steak");
        MetaMaskManager.Getvalue("token");
        MetaMaskManager.Getvalue("userlimit");
        MetaMaskManager.Getvalue("userlevel");
        MetaMaskManager.Getvalue("bonfire");

        textTimer.text = timerStart.ToString("F2");


    }


    private void Awake()
    {

        if (!PlayerPrefs.HasKey("LockOn"))
        {
            PlayerPrefs.SetInt("LockOn", 0);
        }


    }

    [System.Obsolete]
    void Update()
    {

        if (timerRunning == true)
        {
            ParticleSystemFire.SetActive(true);
            textTimer.text = timerStart.ToString("F2");
            //timerStart -= Time.deltaTime;
            int startTime = PlayerPrefs.GetInt("TimerStart");
            int currentTime = GetCurrentUnixTimestamp();
            deltatime += Time.deltaTime;
            if (deltatime >= 1)
            {
                deltatime = 0;
            }
            timerStart = startTime + 7 - currentTime - deltatime;
        } 

        if(bonfirelimit > 0 && coinForMeat.CoinCount >= 1)
        {
            FireSleepParticles.SetActive(true);
            Button.SetActive(true);
            ButtonNoWork.SetActive(false);
            if(Shoppanel.active == true || timerRunning == true)
            {
                Button.SetActive(false);
                BluefirefryButton.SetActive(false);
                GreenfirefryButton.SetActive(false);
                HellfirefryButton.SetActive(false);
                BarbiefirefryButton.SetActive(false);
            }
        }

        if (bonfirelimit < 1)
        {
            FireSleepParticles.SetActive(false);
            Button.SetActive(false);
            //Button.interactable = false;
        }

        if (userlevel >= 104 && userlevel < 216)
        {
            LevelText.text="LVL2";
        }
        if (userlevel >= 216 && userlevel < 364)
        {
            LevelText.text = "LVL3";
        }
        if (userlevel >= 364 && userlevel < 656)
        {
            LevelText.text = "LVL4";
        }
        if (userlevel >= 656)
        {
            LevelText.text = "LVL5";
        }

        if (coinForMeat.CoinCount < 1 && timerStart <= 0)
        {

            StartCoroutine(if20coins());
        }

        

        if (timerStart < 7)
        {
            Button.SetActive(false);
        }

        IEnumerator if20coins()
        {

            Button.SetActive(false);
            //ButtonNoWork.SetActive(true);
            yield return new WaitForSeconds(2f);
            ZeroCoins.SetActive(true);
            yield return new WaitForSeconds(4f);
            ZeroCoins.SetActive(false);
        }

        if (timerStart <= 0)
        {
            StartCoroutine(ifTimerStart0());
        }


        IEnumerator ifTimerStart0()
        {

            FireSoundd = false;
            Instantiate(FireSoundQuite);

            timerStart = 7f;
            timerRunning = false;
            Button.SetActive(true);
            MetaMaskManager.Getvalue("steak");
            MetaMaskManager.Getvalue("userlevel");
            TextDoneSteak.SetActive(true);
                       
            yield return new WaitForSeconds(2f);
            TextDoneSteak.SetActive(false);
            ParticleSystemFire.SetActive(false);

            if (FireSoundd == true)
            {
                Instantiate(FireSound);
            }

            if (FireSoundd == false)
            {
                DestroyImmediate(FireSound, true);
            }

        }

        if(timerRunning == false)
        {
            if (userbonfire == "Bluefire")
            {
            
                ParticleSystemFire.GetComponent<ParticleSystem>().startColor = Color.blue;
                FireSleepParticles.GetComponent<ParticleSystem>().startColor = Color.blue;
                if (Shoppanel.active == true)
                {
                    BluefirefryButton.SetActive(false);
                    GreenfirefryButton.SetActive(false);
                    HellfirefryButton.SetActive(false);
                    BarbiefirefryButton.SetActive(false);
                }
                else
                {
                    BluefirefryButton.SetActive(true);
                    GreenfirefryButton.SetActive(false);
                    HellfirefryButton.SetActive(false);
                    BarbiefirefryButton.SetActive(false);
                }
                //LockOff.GetComponent<SpriteRenderer>().sprite = LockOnn;
                //BuyFire.GetComponent<Image>().sprite = ButtonKypleno;
            }
            if(userbonfire == "Greenfire")
            {
                ParticleSystemFire.GetComponent<ParticleSystem>().startColor = Color.green;
                FireSleepParticles.GetComponent<ParticleSystem>().startColor = Color.green;
                if (Shoppanel.active == true)
                {
                    BluefirefryButton.SetActive(false);
                    GreenfirefryButton.SetActive(false);
                    HellfirefryButton.SetActive(false);
                    BarbiefirefryButton.SetActive(false);
                }
                else
                {
                    GreenfirefryButton.SetActive(true);
                    BluefirefryButton.SetActive(false);
                    HellfirefryButton.SetActive(false);
                    BarbiefirefryButton.SetActive(false);
                }
            }
            if (userbonfire == "Hellfire")
            {
                ParticleSystemFire.GetComponent<ParticleSystem>().startColor = Color.red;
                FireSleepParticles.GetComponent<ParticleSystem>().startColor = Color.red;
                if (Shoppanel.active == true)
                {
                    BluefirefryButton.SetActive(false);
                    GreenfirefryButton.SetActive(false);
                    HellfirefryButton.SetActive(false);
                    BarbiefirefryButton.SetActive(false);
                }
                else
                {
                    HellfirefryButton.SetActive(true);
                    BluefirefryButton.SetActive(false);
                    GreenfirefryButton.SetActive(false);
                    BarbiefirefryButton.SetActive(false);
                }
            }
            if (userbonfire == "Barbiefire")
            {
                ParticleSystemFire.GetComponent<ParticleSystem>().startColor = Color.magenta;
                FireSleepParticles.GetComponent<ParticleSystem>().startColor = Color.magenta;
                if (Shoppanel.active == true)
                {
                    BluefirefryButton.SetActive(false);
                    GreenfirefryButton.SetActive(false);
                    HellfirefryButton.SetActive(false);
                    BarbiefirefryButton.SetActive(false);
                }
                else
                {
                    BarbiefirefryButton.SetActive (true);
                    BluefirefryButton.SetActive(false);
                    GreenfirefryButton.SetActive(false);
                    HellfirefryButton.SetActive(false);
                }
            }
            if (userbonfire == "Rainbow")
            {
                ParticleSystem particleSystem = ParticleSystemFire.GetComponent<ParticleSystem>();

                Gradient gradient = new Gradient();
                gradient.mode = GradientMode.Fixed;

                GradientColorKey[] colorKeys = new GradientColorKey[7];
                colorKeys[0] = new GradientColorKey(Color.red, 0f);
                colorKeys[1] = new GradientColorKey(Color.yellow, 0.17f);
                colorKeys[2] = new GradientColorKey(Color.green, 0.33f);
                colorKeys[3] = new GradientColorKey(Color.cyan, 0.5f);
                colorKeys[4] = new GradientColorKey(Color.blue, 0.67f);
                colorKeys[5] = new GradientColorKey(Color.magenta, 0.83f);
                colorKeys[6] = new GradientColorKey(Color.red, 1f);

                GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
                alphaKeys[0] = new GradientAlphaKey(1f, 0f);
                alphaKeys[1] = new GradientAlphaKey(1f, 1f);

                gradient.SetKeys(colorKeys, alphaKeys);

                ParticleSystem.MainModule mainModule = particleSystem.main;
                mainModule.startColor = new ParticleSystem.MinMaxGradient(gradient);

                ParticleSystem firesleep = FireSleepParticles.GetComponent<ParticleSystem>();
                ParticleSystem.MainModule sleepModule = firesleep.main;
                sleepModule.startColor = new ParticleSystem.MinMaxGradient(gradient);

                BarbiefirefryButton.SetActive(true);
                BluefirefryButton.SetActive(false);
                GreenfirefryButton.SetActive(false);
                HellfirefryButton.SetActive(false);
            }
            if (userbonfire == "Firstfire")
            {
                ParticleSystemFire.GetComponent<ParticleSystem>().startColor = Color.yellow;
                FireSleepParticles.GetComponent<ParticleSystem>().startColor = Color.yellow;
                BluefirefryButton.SetActive(false);
                GreenfirefryButton.SetActive(false);
                HellfirefryButton.SetActive(false);
                BarbiefirefryButton.SetActive(false);
            }
        }

    }


    public void ButtonNoWorks()
    {
        StartCoroutine(ButtonNoWorking());
    }




    IEnumerator ButtonNoWorking()
    {
        if (coinForMeat.CoinCount < 1)
        {
            Button.SetActive(false);
            ButtonNoWork.SetActive(true);
            ZeroCoins.SetActive(true);
            yield return new WaitForSeconds(2);
            ZeroCoins.SetActive(false);
        }


    }

    public async void ManagerBonfire()
    {
        ResultText.text = "Waiting Transaction...";
        var success = await MetaMaskManager.frysteak();
        if (success == true)
        {
            ResultText.text = "";
            StartCoroutine(MinusCoins());
        }
        else
        {
            ResultText.text = "Failed Transaction";
            StartCoroutine(MinusCoins());
        }
        if (bonfirelimit < 1)
        {
            FireSleepParticles.SetActive(false);
            Button.SetActive(false);
            ButtonNoWork.SetActive(true);
        }

    }
    public IEnumerator RemoveText()
    {
        yield return new WaitForSeconds(2f);
        ResultText.text = "";
    }

    public void RemoveMenuScene()
    {
        SceneManager.UnloadSceneAsync("MenuRegister", UnloadSceneOptions.None); print("ÑÖÅÍÀ ÌÅÍÞ ÓÄÀËÈËÀÑÜ");
    }

    public IEnumerator MinusCoins()
    {
        int currentTime = GetCurrentUnixTimestamp();
        PlayerPrefs.SetInt("TimerStart", currentTime);
        PlayerPrefs.Save();
        timerRunning = true;
        Instantiate(SpichkaSound);
        FireSoundd = true;
        ParticleSystemFire.SetActive(true);
        Button.SetActive(false);
        yield return new WaitForSeconds(0.5f);
    }

    private int GetCurrentUnixTimestamp()
    {
        return (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(2023, 11, 1))).TotalSeconds;
    }
}