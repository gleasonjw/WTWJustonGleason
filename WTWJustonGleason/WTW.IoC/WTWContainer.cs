using System;
using System.Collections.Generic;
using System.Reflection;
using WTW.IoC.Exceptions;
using System.Linq;
using WTW.IoC.LifeTime;

namespace WTW.IoC
{
    /// <summary>
    /// Simple IoC container built for WTW code challenge.
    /// </summary>
    public class WTWContainer : IWTWContainer
    {
        private Dictionary<Type, LifeTimeManager> _registeredTypeManagers = new Dictionary<Type, LifeTimeManager>();

        public void Register<TFrom, TTo>()
        {
            Register<TFrom, TTo>(new TransientLifeTimeManager());
        }

        public void Register<TFrom, TTo>(LifeTimeManager lifeTimeMgr)
        {
            if (lifeTimeMgr == null)
            {
                throw new ArgumentNullException(nameof(lifeTimeMgr));
            }
            lifeTimeMgr.DataType = typeof(TTo);

            _registeredTypeManagers.Add(typeof(TFrom), lifeTimeMgr);
        }

        public object Resolve<TFrom>()
        {
            Type fromType = typeof(TFrom);
            return Resolve(fromType);
        }

        /// <summary>
        /// Attempts to resolve the specified type. If the target type has multiple constructors, the constructor
        /// with the least number of parameters is used.
        /// </summary>
        /// <param name="fromType"></param>
        /// <returns></returns>
        public object Resolve(Type fromType)
        {
            object returnValue = null;
            if (_registeredTypeManagers.ContainsKey(fromType))
            {
                LifeTimeManager lifeTimeMgr = _registeredTypeManagers[fromType];
                returnValue = lifeTimeMgr.GetObject();

                if (returnValue == null)
                {
                    // Use the constructor with the least number of parameters to improve chances of success.
                    ConstructorInfo[] constructors = lifeTimeMgr.DataType.GetConstructors()
                        .OrderBy(c => c.GetParameters().Count())
                        .ToArray();
                    ConstructorInfo ctorInfo = constructors.First();

                    ParameterInfo[] parameters = ctorInfo.GetParameters();
                    List<object> resolvedParameters = new List<object>();
                    foreach (ParameterInfo paramInfo in parameters)
                    {
                        // Use recursion to resolve the parameter.
                        object resolvedParam = Resolve(paramInfo.ParameterType);
                        resolvedParameters.Add(resolvedParam);
                    }

                    returnValue = ctorInfo.Invoke(resolvedParameters.ToArray());
                    lifeTimeMgr.SetObject(returnValue);
                }
            }
            else
            {
                throw new ResolutionFailedException(fromType);
            }

            return returnValue;
        }

        #region Required for the WebAPI dependency resolver.
        public IEnumerable<object> ResolveAll(Type fromType)
        {
            throw new NotImplementedException();
        }

        public IWTWContainer CreateChildContainer()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
