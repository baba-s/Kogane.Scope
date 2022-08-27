using System;
using UnityEngine;

namespace Kogane
{
    public sealed class GUIEnabledScope : IDisposable
    {
        private readonly bool m_oldEnabled;

        public GUIEnabledScope( bool enabled )
        {
            m_oldEnabled = GUI.enabled;
            GUI.enabled  = enabled;
        }

        public void Dispose()
        {
            GUI.enabled = m_oldEnabled;
        }
    }
}