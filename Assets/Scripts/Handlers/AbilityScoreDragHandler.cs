using UnityEngine;
using UnityEngine.EventSystems;

namespace Handlers
{
    public class AbilityScoreDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        private Vector3 _oldLocalPosition;
        private void Start()
        {
            _oldLocalPosition = transform.localPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            RectTransform rt = transform as RectTransform;
            if (rt == null) return;
            
            // Center it over the mouse
            var rect = rt.rect;
            rt.position = Input.mousePosition + new Vector3(-rect.width/2, -rect.height/2);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // AbilityScore -> AbilityScoreSpot, let the DropHandler take care of it
            if (eventData.pointerEnter.GetComponent<AbilityScoreDropHandler>() != null)
            {
                return;
            }
            
            // AbilityScore -> Any where else, reset its position
            transform.localPosition = _oldLocalPosition;
        }
        
    }
}
