using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Switch
{
    public class PartSwitch : MonoBehaviour
    {
        [SerializeField] private SwitchComponentsType _switchComponents;
        [SerializeField] private ComponentOutline _outline;

        public SwitchComponentsType SwitchComponentsType => _switchComponents;
        public ComponentOutline Outline => _outline;
    }
}