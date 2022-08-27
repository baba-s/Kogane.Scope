using System;
using UnityEngine;

namespace Kogane
{
    public sealed class TargetFrameRateScope : IDisposable
    {
        private readonly int m_oldTargetFrameRate;

        public TargetFrameRateScope( int targetFrameRate )
        {
            m_oldTargetFrameRate        = Application.targetFrameRate;
            Application.targetFrameRate = targetFrameRate;
        }

        public void Dispose()
        {
            Application.targetFrameRate = m_oldTargetFrameRate;
        }
    }
}