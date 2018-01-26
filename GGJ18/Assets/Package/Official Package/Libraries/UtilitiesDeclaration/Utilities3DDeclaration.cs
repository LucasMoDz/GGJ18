using UnityEngine;
using Object = UnityEngine.Object;

namespace Package.CustomLibrary
{
    /// <summary> Provides tested 3D functions. </summary>
    public class Utilities3D
    {
        #region Private Singleton

        private static Implementation.Utilities3D _utilities3DInstance;

        private static Implementation.Utilities3D Utilities3DInstance
        {
            get
            {
                if (_utilities3DInstance == null)
                    _utilities3DInstance = Object.FindObjectOfType<Implementation.Utilities3D>();

                return _utilities3DInstance;
            }
        }

        #endregion
        
        /// <summary> Enable all renderer components (itself and childs). </summary>
        /// <param name="_models"> Gameobject to enable own graphic. </param>
        public static void EnableModel3D(params GameObject[] _models)
        {
            Utilities3DInstance.EnableModel3D(_models);
        }

        /// <summary> Disable all renderer components (itself and childs). </summary>
        /// <param name="_models"> Gameobject to disable own graphic. </param>
        public static void DisableModel3D(params GameObject[] _models)
        {
            Utilities3DInstance.DisableModel3D(_models);
        }
    }
}