using System;
using UnityEditor;
using UnityEngine;

namespace Kogane
{
    public sealed class LoadPrefabContentsScope : IDisposable
    {
        public string     PrefabPath { get; }
        public GameObject Prefab     { get; }

        public bool IsSave { get; set; } = true;

        public LoadPrefabContentsScope( string prefabPath )
        {
            PrefabPath = prefabPath;
            Prefab     = PrefabUtility.LoadPrefabContents( prefabPath );
        }

        public void Dispose()
        {
            if ( IsSave )
            {
                PrefabUtility.SaveAsPrefabAsset( Prefab, PrefabPath );
            }

            PrefabUtility.UnloadPrefabContents( Prefab );
        }
    }
}