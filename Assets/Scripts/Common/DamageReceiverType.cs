using System;

namespace Common
{
    [Flags]
    public enum DamageReceiverType
    {
        Enemy = 1 << 0,
        Wall = 1 << 1
    }
}