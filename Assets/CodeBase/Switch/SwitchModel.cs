using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Switch
{
    public class SwitchModel : MonoBehaviour
    {
        [SerializeField] private List<PartSwitch> _partsSwitch;
        [SerializeField] private Transform _centralPoint;

        public Transform CentralPoint => _centralPoint;

        public void HideShowComponent(SwitchComponentsType componentsType)
        {
            foreach (var partSwitch in _partsSwitch)
            {
                if (componentsType == partSwitch.SwitchComponentsType)
                {
                    partSwitch.gameObject.SetActive(!partSwitch.gameObject.activeInHierarchy);
                }
            }
        }

        public void ShowComponent(SwitchComponentsType componentsType)
        {
            foreach (var partSwitch in _partsSwitch)
            {
                if (componentsType == partSwitch.SwitchComponentsType)
                {
                    partSwitch.gameObject.SetActive(true);
                    continue;
                }

                partSwitch.gameObject.SetActive(false);
            }
        }

        public void ShowAllComponent()
        {
            foreach (PartSwitch partSwitch in _partsSwitch)
            {
                partSwitch.gameObject.SetActive(true);
            }
        }

        public void ShowOutlineComponent(SwitchComponentsType componentsType)
        {
            foreach (PartSwitch partSwitch in _partsSwitch)
            {
                if (componentsType != partSwitch.SwitchComponentsType)
                    continue;

                if (partSwitch.Outline != null)
                    partSwitch.Outline.EnableOutline();
            
                return;
            }
        }

        public void HideOutlineComponent(SwitchComponentsType componentsType)
        {
            foreach (PartSwitch partSwitch in _partsSwitch)
            {
                if (componentsType != partSwitch.SwitchComponentsType)
                    continue;

                if (partSwitch.Outline != null)
                    partSwitch.Outline.DisableOutline();
                return;
            }
        }
    }
}