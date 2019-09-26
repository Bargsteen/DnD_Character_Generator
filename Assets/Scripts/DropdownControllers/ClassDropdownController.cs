using Enums;
using UnityEngine.Serialization;

namespace DropdownControllers
{
    public class ClassDropdownController : DropdownController<Class>
    {
        public HitPointsController hitPointsController;
        
        public override void DropdownIndexChanged(int newIndex)
        {
            base.DropdownIndexChanged(newIndex);
            hitPointsController.OnClassChanged(SelectedOption);
        }
    }
}
