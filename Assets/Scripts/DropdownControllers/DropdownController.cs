using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace DropdownControllers
{
    public class DropdownController<T> : MonoBehaviour where T : struct, IConvertible
    {
        public Dropdown dropdown;
        private T _selectedOption;
        public T SelectedOption => _selectedOption;

        public void Start()
        {
            dropdown.options.Clear();
            dropdown.AddOptions(Enum.GetNames(typeof(T)).ToList());
            dropdown.onValueChanged.AddListener(DropdownIndexChanged);
        }

        public virtual void DropdownIndexChanged(int newIndex)
        {
            // Should never fail, as the options are created from the enum itself.
            Enum.TryParse(dropdown.options[newIndex].text, out _selectedOption);
        }
    }
}