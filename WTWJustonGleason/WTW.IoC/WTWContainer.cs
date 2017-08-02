using System;
using System.Collections.Generic;
using System.Reflection;
using WTW.IoC.Exceptions;
using System.Linq;

namespace WTW.IoC
{
    public class WTWContainer : IWTWContainer
    {
        private Dictionary<Type, Type> _registeredTypes = new Dictionary<Type, Type>();

        public void Register<TFrom, TTo>(LifecycleType lifecycle = LifecycleType.Transient)
        {
            _registeredTypes.Add(typeof(TFrom), typeof(TTo));
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
            if (_registeredTypes.ContainsKey(fromType))
            {
                Type toType = _registeredTypes[fromType];

                // Use the constructor with the least number of parameters to improve chances of success.
                ConstructorInfo[] constructors = toType.GetConstructors()
                    .OrderBy(c => c.GetParameters().Count())
                    .ToArray();
                ConstructorInfo ctorInfo = constructors.First();
                
                ParameterInfo[] parameters = ctorInfo.GetParameters();
                List<object> resolvedParameters = new List<object>();
                foreach(ParameterInfo paramInfo in parameters)
                {
                    // Use recursion to resolve the parameter.
                    object resolvedParam = Resolve(paramInfo.ParameterType);
                    resolvedParameters.Add(resolvedParam);
                }

                returnValue = ctorInfo.Invoke(resolvedParameters.ToArray());
            }
            else
            {
                throw new ResolutionFailedException(fromType);
            }

            return returnValue;
        }

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
    }
}
