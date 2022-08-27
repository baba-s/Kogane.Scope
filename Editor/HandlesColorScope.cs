using System;
using UnityEditor;
using UnityEngine;

namespace Kogane
{
    public sealed class HandlesColorScope : IDisposable
    {
        private readonly Color m_oldColor;

        public HandlesColorScope( Color color )
        {
            m_oldColor    = GUI.color;
            Handles.color = color;
        }

        public void Dispose()
        {
            Handles.color = m_oldColor;
        }
    }
}