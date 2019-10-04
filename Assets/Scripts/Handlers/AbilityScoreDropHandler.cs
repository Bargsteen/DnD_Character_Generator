using UnityEngine;
using UnityEngine.EventSystems;

namespace Handlers
{
    public class AbilityScoreDropHandler : MonoBehaviour, IDropHandler
    {

        private AbilityScoreDragHandler _abilityScore;
        
        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log($"OnDrop: {eventData.pointerDrag.name}");
            // Ignore if the dropped object isn't an ability
            /*var newAbilityScore = eventData.pointerDrag.GetComponent<AbilityScoreDragHandler>()
            if (newAbilityScore == null) return;
            
            // RollArea -> Empty abilityScoreSpot
            RectTransform abilityScoreSpot = transform as RectTransform;
            if (_abilityScore == null)
            {
                // set property = incoming
                _abilityScore = newAbilityScore;
                // put it perfectly in place
                // TODO: _abilityScore.transform
            }
            // RollArea -> Filled ability spot
            else if(_abilityScore != null)
            {
                // Move it back to the rollArea
                // TODO: abilityScore.transform.localPosition
            }
            */
            // AbilitySpot -> Outside
            // set property = null
            // Move it back to the rollArea
        }
    }
}