using System.Collections.Generic;
using CodeBase.Services;
using CodeBase.Switch;
using CodeBase.UI.Button;
using UnityEngine;

namespace CodeBase.UI.Canvas
{
    public class SelectComponentCanvas : MonoBehaviour
    {
        [SerializeField] private List<SelectComponentButton> _selectComponentButtons;

        public void Construct(SwitchModel switchModel, SwitchModel switchModelView, DescriptionCanvas descriptionCanvas,
            StaticDataServices staticDataServices)
        {
            foreach (SelectComponentButton selectComponentButton in _selectComponentButtons)
                selectComponentButton.Init(switchModel, switchModelView, descriptionCanvas, staticDataServices);
        } 
    }
}