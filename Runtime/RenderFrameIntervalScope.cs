using System;
using UnityEngine.Rendering;

namespace Kogane
{
    public sealed class RenderFrameIntervalScope : IDisposable
    {
        private readonly int m_oldRenderFrameInterval;

        public RenderFrameIntervalScope( int renderFrameInterval )
        {
            m_oldRenderFrameInterval              = OnDemandRendering.renderFrameInterval;
            OnDemandRendering.renderFrameInterval = renderFrameInterval;
        }

        public void Dispose()
        {
            OnDemandRendering.renderFrameInterval = m_oldRenderFrameInterval;
        }
    }
}