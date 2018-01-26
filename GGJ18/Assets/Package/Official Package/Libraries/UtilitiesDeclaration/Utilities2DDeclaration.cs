using UnityEngine;

namespace Package.CustomLibrary
{
    /// <summary> Provides tested 2D functions. </summary>
    public class Utilities2D
    {
        #region Private Singleton

        private static Implementation.Utilities2D _utilities2DInstance;

        private static Implementation.Utilities2D Utilities2DInstance
        {
            get
            {
                if (_utilities2DInstance == null)
                    _utilities2DInstance = Object.FindObjectOfType<Implementation.Utilities2D>();

                return _utilities2DInstance;
            }
        }

        #endregion
    }
}