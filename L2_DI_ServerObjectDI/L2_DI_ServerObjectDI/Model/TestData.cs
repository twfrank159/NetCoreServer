using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L2_DI_ServerObjectDI.Model
{
    public class TestDataService
    {
        private readonly ITestData _transient;
        private readonly ITestData _scoped;
        private readonly ITestData _singleton;
        public TestDataService(ITransientTestData transient,
                             IScopedTestData scoped,
                             ISingletonTestData singleton)
        {
            _transient = transient;
            _scoped = scoped;
            _singleton = singleton;
        }

        public string GetTestData()
        {
            return $"[Transient] GetTime {_transient.GetTime()} GetHash {_transient.GetHashCode()}\n "
                    + $"[Scoped]:  GetTime {_scoped.GetTime()} GetHash {_scoped.GetHashCode()}\n "
                    + $"[Singleton]: GetTime {_singleton.GetTime()} GetHash {_singleton.GetHashCode()}\n";
        }
    }

    //這邊定義介面，就是這個ITestData類別的方法與參數有哪些
    public interface ITestData
    {
        public string GetTime();
        public void UpdateTime();
    }

    public interface IScopedTestData : ITestData
    {

    }

    public interface ISingletonTestData : ITestData
    {

    }

    public interface ITransientTestData : ITestData
    {

    }

    //這邊則是定義TestData的方法的實作
    public class TestData : ITestData, IScopedTestData, ISingletonTestData, ITransientTestData
    {
        public DateTime Time;

        public TestData()
        {
            this.Time = DateTime.Now;
        }

        public string GetTime()
        {
            return this.Time.ToString();
        }

        public void UpdateTime()
        {
            this.Time = DateTime.Now;
        }
    }
}
