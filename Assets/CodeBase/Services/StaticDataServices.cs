using System.Linq;
using CodeBase.StaticData;
using CodeBase.Switch;
using UnityEngine;

namespace CodeBase.Services
{
    public class StaticDataServices
    {
        private DescriptionComponents _descriptionComponents;

        public void Load(LanguageType languageType)
        {
            _descriptionComponents = Resources.LoadAll<DescriptionComponents>(PathProver.DescriptionComponents)
                .FirstOrDefault(x => x.languageType == languageType);
        }

        public DescriptionComponent GetDescriptionOfType(SwitchComponentsType componentsType) =>
            _descriptionComponents.descriptionComponents
                .FirstOrDefault(x => x.switchComponentsType == componentsType);
    }
}