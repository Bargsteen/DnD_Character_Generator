using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class RollController : MonoBehaviour
    {
        private const int LowestDieRoll = 1;
        private const int HighestDieRoll = 6;
        private const int MaxRolls = 6;
        private const int TopXRollCount = 3;

        private int RollCount { get; set; }
        
        private List<Text> _dieResults;
        public Text dieResultOne;
        public Text dieResultTwo;
        public Text dieResultThree;
        public Text dieResultFour;
        public Text dieResultFive;

        private List<Text> _abilityScores;
        public Text abilityScoreOne;
        public Text abilityScoreTwo;
        public Text abilityScoreThree;
        public Text abilityScoreFour;
        public Text abilityScoreFive;
        public Text abilityScoreSix;

        private void Start()
        {
            _dieResults = new List<Text> {dieResultOne, dieResultTwo, dieResultThree, dieResultFour, dieResultFive};
            _abilityScores = new List<Text>
                {abilityScoreOne, abilityScoreTwo, abilityScoreThree, abilityScoreFour, abilityScoreFive, abilityScoreSix};
        }

        public void OnRollPressed() 
        {
            if (RollCount >= MaxRolls) return;

            var intResults = new List<int>();
            
            _dieResults.ForEach(t =>
            {
                int dieResult = Random.Range(LowestDieRoll, HighestDieRoll + 1);
                intResults.Add(dieResult);
                t.text = dieResult.ToString();
            });

            // Set the appropriate abilityScore text
            _abilityScores[RollCount].text = intResults
                .OrderByDescending(x => x)
                .Take(TopXRollCount)
                .Sum()
                .ToString();

            RollCount++;
        }
    }
}
