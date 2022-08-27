using System;
using UnityEditor;

namespace Kogane
{
    public sealed class AssetEditingScope : IDisposable
    {
        private static int m_count;

        public AssetEditingScope()
        {
            if ( m_count == 0 )
            {
                AssetDatabase.StartAssetEditing();
            }

            m_count++;
        }

        public void Dispose()
        {
            m_count--;

            if ( m_count == 0 )
            {
                AssetDatabase.StopAssetEditing();
            }
        }
    }
}