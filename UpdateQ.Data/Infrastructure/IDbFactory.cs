namespace UpdateQ.Data.Infrastructure
{
    using System;

    public interface IDbFactory : IDisposable
    {
        UpdateQContext Init();
    }
}
