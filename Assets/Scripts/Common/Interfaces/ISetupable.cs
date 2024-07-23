using System;

namespace Common
{
    public interface ISetupable
    {
        IDisposable Setup();
    }
}