using System;
using System.Collections.Generic;
using CodeBase.Switch;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "DescriptionComponent", fileName = "NewDescriptionComponent", order = 50)]
    public class DescriptionComponents : ScriptableObject
    {
        public LanguageType languageType;
        public List<DescriptionComponent> descriptionComponents;
    }

    [Serializable]
    public class DescriptionComponent
    {
        public SwitchComponentsType switchComponentsType;
        public string nameComponents;
        public string description;
    }

    public enum LanguageType
    {
        Default = 0,
        RU = 1,
        EN = 2,
    }
}