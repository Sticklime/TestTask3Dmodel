using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Switch
{
    public class ComponentOutline : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _materialOutline;

        private List<Material> _originalMaterials = new List<Material>();

        private void Start() =>
            _originalMaterials.AddRange(_meshRenderer.materials);

        public void EnableOutline()
        {
            List<Material> materials = new List<Material>(_originalMaterials);
            materials.Add(_materialOutline);
            _meshRenderer.materials = materials.ToArray();
        }

        public void DisableOutline() =>
            _meshRenderer.materials = _originalMaterials.ToArray();
    }
}