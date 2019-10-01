using Enums;
using UnityEngine;
using UnityEngine.UI;

public class HitPointsController : MonoBehaviour
{
   private DieType _dieType;
   public Text dieResult;
   public Text dieAvailable;
   private const int LowestDieRoll = 1;

   private void Start()
   {
      _dieType = CharacterSheetModel.GetHitDieTypeByClass(Class.Barbarian); // Barbarian is the default
      dieAvailable.text = _dieType.ToString();
   }

   public void OnClassChanged(Class class_)
   {
      _dieType = CharacterSheetModel.GetHitDieTypeByClass(class_);
      dieAvailable.text = _dieType.ToString();
      
      // Invalidate any previous rolls
      dieResult.text = "_";
   }
   
   public void RollHitDie()
   {
      dieResult.text = Random.Range(LowestDieRoll, _dieType.ToInt()).ToString();
   }
}
