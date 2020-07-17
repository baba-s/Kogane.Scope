using System;
using UnityEditor;

namespace Kogane
{
	public sealed class AssetEditingScope : IDisposable
	{
		public AssetEditingScope()
		{
			AssetDatabase.StartAssetEditing();
		}

		public void Dispose()
		{
			AssetDatabase.StopAssetEditing();
		}
	}
}