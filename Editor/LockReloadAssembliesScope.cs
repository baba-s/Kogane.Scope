using System;
using UnityEditor;

namespace Kogane
{
    public sealed class LockReloadAssembliesScope : IDisposable
    {
        private static int m_count;

        public LockReloadAssembliesScope()
        {
            if ( m_count == 0 )
            {
                EditorApplication.LockReloadAssemblies();
            }

            m_count++;
        }

        public void Dispose()
        {
            m_count--;

            if ( m_count == 0 )
            {
                EditorApplication.UnlockReloadAssemblies();
            }
        }
    }
}