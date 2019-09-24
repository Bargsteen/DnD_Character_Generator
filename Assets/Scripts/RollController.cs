using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RollController : MonoBehaviour
{
    private const int LowestDieRoll = 1;
    private const int HighestDieRoll = 6;
    
    private List<Text> _dieResults;
    public Text dieResultOne;
    public Text dieResultTwo;
    public Text dieResultThree;
    public Text dieResultFour;
    public Text dieResultFive;
    private void Start()
    {
        _dieResults = new List<Text> {dieResultOne, dieResultTwo, dieResultThree, dieResultFour, dieResultFive};
    }

    public void OnRollPressed() 
    {
        _dieResults.ForEach(t => t.text = Random.Range(LowestDieRoll, HighestDieRoll + 1).ToString());
    }
}
