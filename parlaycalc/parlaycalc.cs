using UnityEngine;
using TMPro;

public class ParlayCalc : MonoBehaviour
// sceen 1 = home screen
// screen 2 = input screen
// screen 3 = result screen
// make it go full circle 
{
    public GameObject HomeScreen;
    public GameObject InputScreen;
    public GameObject ResultScreen;

    public TMP_InputField Odds1;
    public TMP_InputField Odds2;

    public TMP_Text Leg1Chance;
    public TMP_Text Leg2Chance;

    public TMP_Text Chance;
    public TMP_Text Risk;
// 1st screen
    void Start()
    {
        HomeScreen.SetActive(true);
        InputScreen.SetActive(false);
        ResultScreen.SetActive(false);
    }
// 2nd screen 
    public void OpenInputScreen()
    {
        HomeScreen.SetActive(false);
        InputScreen.SetActive(true);
    }
// 3rd sceen
    float ConvertOdds(float odds)
    {
        if (odds < 0)
        {
            return (-odds) / ((-odds) + 100f);
        }
        else
        {
            return 100f / (odds + 100f);
        }
    }
// hard rock odds prizepicks was to hard 
    public void CalculateParlay()
    {
        if (Odds1.text == "")
        {
            return;
        }

        float o1 = float.Parse(Odds1.text);
        float p1 = ConvertOdds(o1);

        Leg1Chance.text = (p1 * 100f).ToString("F1") + "%";

        float overallChance;

        if (Odds2.text == "")
        {
            Leg2Chance.text = "N/A";
            overallChance = p1 * 100f;
        }
        else
        {
            float o2 = float.Parse(Odds2.text);
            float p2 = ConvertOdds(o2);

            Leg2Chance.text = (p2 * 100f).ToString("F1") + "%";

            overallChance = p1 * p2 * 100f;
        }

        Chance.text = overallChance.ToString("F1") + "%";
// anything under 40% is high risk, anything between 40% and 80% is medium risk, and anything over 80% is low risk
        if (overallChance >= 80)
        {
            Risk.text = "LOW RISK";
        }
        else if (overallChance >= 40)
        {
            Risk.text = "MEDIUM RISK";
        }
        else
        {
            Risk.text = "HIGH RISK";
        }

        InputScreen.SetActive(false);
        ResultScreen.SetActive(true);
    }
// everything in order at percentage 1st leg, 2nd leg and parlay overall chance and risk level
    public void BackToHome()
    {
        ResultScreen.SetActive(false);
        HomeScreen.SetActive(true);
    }
}