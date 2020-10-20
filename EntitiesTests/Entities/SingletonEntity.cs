using Skyrmium.Composed.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesTests.Entities
{
    public class SingletonEntity<TEntity> where TEntity : IEntity
    {
        private readonly Func<TEntity> _getInstanceFunc;
        public SingletonEntity(Func<TEntity> getInstanceFunc)
        {
            _getInstanceFunc = getInstanceFunc;
        }
        private TEntity _Instance;
        public TEntity Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = _getInstanceFunc();
                }

                return _Instance;
            }
        }
    }
}
