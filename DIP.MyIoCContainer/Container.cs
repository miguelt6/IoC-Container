using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DIP.MyIoCContainer
{
    public class Container
    {
        private Dictionary<Type, Type> iocMap = new Dictionary<Type, Type>();

        public void Register<TypeToResolve, ResolvedType>()
        {
            if (iocMap.ContainsKey(typeof(TypeToResolve)))
            {
                throw new Exception(string.Format("Type {0} already registered.", typeof(TypeToResolve).FullName));
            }
            iocMap.Add(typeof(TypeToResolve), typeof(ResolvedType));
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type typeToResolve)
        {
            // Find the registered type for typeToResolve
            if (!iocMap.ContainsKey(typeToResolve))
                throw new Exception(string.Format("Can't resolve {0}. Type is not registed.", typeToResolve.FullName));

            Type resolvedType = iocMap[typeToResolve];

            // Try to construct the object
            // Step-1: find the constructor (ideally first constructor if multiple constructos present for the type)
            ConstructorInfo ctorInfo = resolvedType.GetConstructors().First();

            // Step-2: find the parameters for the constructor and try to resolve those
            List<ParameterInfo> paramsInfo = ctorInfo.GetParameters().ToList();
            List<object> resolvedParams = new List<object>();
            foreach (ParameterInfo param in paramsInfo)
            {
                Type t = param.ParameterType;
                object res = Resolve(t);
                resolvedParams.Add(res);
            }

            // Step-3: using reflection invoke constructor to create the object
            object retObject = ctorInfo.Invoke(resolvedParams.ToArray());

            return retObject;
        }
    }
}
