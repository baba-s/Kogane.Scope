using System;
using UnityEditor;

namespace Kogane
{
	public sealed class LockReloadAssembliesScope : IDisposable
	{
		public LockReloadAssembliesScope()
		{
			EditorApplication.LockReloadAssemblies();
		}

		public void Dispose()
		{
			EditorApplication.UnlockReloadAssemblies();
		}
	}
}