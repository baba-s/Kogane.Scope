using System;
using UnityEngine.Profiling;

namespace Kogane
{
    public sealed class CustomSamplerScope : IDisposable
    {
        private readonly CustomSampler m_sampler;

        public CustomSamplerScope( string name )
        {
            m_sampler = CustomSampler.Create( name );
            m_sampler.Begin();
        }

        public CustomSamplerScope( string name, UnityEngine.Object targetObject )
        {
            m_sampler = CustomSampler.Create( name );
            m_sampler.Begin( targetObject );
        }

        public void Dispose()
        {
            m_sampler.End();
        }
    }
}