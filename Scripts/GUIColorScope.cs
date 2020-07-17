using System;
using UnityEngine;

namespace Kogane
{
	public sealed class GUIColorScope : IDisposable
	{
		private readonly Color m_oldColor;

		public GUIColorScope( Color color )
		{
			m_oldColor = GUI.color;
			GUI.color  = color;
		}

		public void Dispose()
		{
			GUI.color = m_oldColor;
		}
	}
}