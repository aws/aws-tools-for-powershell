using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using AWSPowerShellGenerator.ServiceConfig;
using AWSPowerShellGenerator.Generators;
using AWSPowerShellGenerator.Writers;

namespace AWSPowerShellGenerator.Analysis
{
    public class AnalyzedResult
    {
        /// <summary>
        /// The output type of the method that contains the actual result data.
        /// Usually the same as ResponseType except for scenarios where the SDK
        /// generator has wrapped the true output into another type addressed
        /// by a member of ResponseType.
        /// </summary>
        public Type ReturnType { get; private set; }

        // The inner property representing the true output for Response classes 
        // analyzed as a SinglePropertyResult output type
        public SimplePropertyInfo SingleResultProperty { get; private set; }

        public AnalyzedResult(Type returnType, SimplePropertyInfo singleResultProperty)
        {
            ReturnType = returnType;
            SingleResultProperty = singleResultProperty;
        }
    }
}
