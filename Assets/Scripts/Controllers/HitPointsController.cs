using Enums;
using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
   public class HitPointsController : MonoBehaviour
   {
      private const string InvalidDieResult = "_";
      private DieType _dieType;
      public Text dieResult;
      public Text dieAvailable;
      private const int LowestDieRoll = 1;

      private void Start()
      {
         // Arbitrarily chose Barbarian to be the default
         _dieType = CharacterSheetModel.GetHitDieTypeByClass(Class.Barbarian); 
         dieAvailable.text = _dieType.ToString();
      }

      public void OnClassChanged(Class class_)
      {
         _dieType = CharacterSheetModel.GetHitDieTypeByClass(class_);
         dieAvailable.text = _dieType.ToString();
      
         // Invalidate any previous rolls
         dieResult.text = InvalidDieResult;
      }
   
      public void RollHitDie()
      {
         // Do not allow re-rolls (except for change of class)
         if (dieResult.text != InvalidDieResult) return;
         
         dieResult.text = Random.Range(LowestDieRoll, _dieType.ToInt() + 1).ToString();
      }
   }
}
