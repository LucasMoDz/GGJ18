using UnityEngine;

namespace Package.CustomLibrary.Implementation
{
    public class Utilities3D : MonoBehaviour
    {
        [SerializeField]
        private bool debugMode;

        #region Activation and Deactivation

        public void EnableModel3D(params GameObject[] _models)
        {
            foreach (var model in _models)
            {
                Renderer[] renderers = model.GetComponentsInChildren<Renderer>();

                foreach (var component in renderers)
                    component.enabled = true;
            }
        }
                
        public void DisableModel3D(params GameObject[] _models)
        {
            foreach (var model in _models)
            {
                Renderer[] renderers = model.GetComponentsInChildren<Renderer>();

                foreach (var component in renderers)
                    component.enabled = false;
            }
        }

        #endregion
    }
}