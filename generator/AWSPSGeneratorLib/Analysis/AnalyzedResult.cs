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
    internal class AnalyzedResult
    {
        /// <summary>
        /// The output type of the method that contains the actual result data.
        /// Usually the same as ResponseType except for scenarios where the SDK
        /// generator has wrapped the true output into another type addressed
        /// by a member of ResponseType.
        /// </summary>
        public Type ReturnType { get; private set; }

        public List<PropertyInfo> MetadataProperties { get; private set; }

        // The inner property representing the true output for Response classes 
        // analyzed as a SinglePropertyResult output type
        public SimplePropertyInfo SingleResultProperty { get; private set; }

        /// <summary>
        /// If not empty, this holds the parameter that can be piped into the
        /// cmdlet and which should be emitted to the pipeline if the -PassThru
        /// switch (which will be added if this is not empty) is set.
        /// </summary>
        public SimplePropertyInfo PassThruParameter { get; set; }

        public AnalyzedResult(Type returnType, SimplePropertyInfo singleResultProperty, List<PropertyInfo> metadataProperties)
        {
            ReturnType = returnType;
            SingleResultProperty = singleResultProperty;
            MetadataProperties = metadataProperties;
        }
    }
}
