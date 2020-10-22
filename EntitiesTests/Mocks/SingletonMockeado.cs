using Moq;

namespace EntitiesTests.Mocks
{
   public class SingletonMockeado<T> where T : class
   {
      private SingletonMockeado() { }

      private static T _Instance = null;
      public static T Instance
      {
         get
         {
            if (_Instance == null)
            {
               _Instance = Singleton<Mock<T>>.Instance.Object;
            }

            return _Instance;
         }
      }
      public static Mock<T> Mock { get => Singleton<Mock<T>>.Instance; }
   }
}
