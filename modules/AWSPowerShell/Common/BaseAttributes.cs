/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;

namespace Amazon.PowerShell.Common
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class AWSCmdletAttribute : Attribute
    {
        public string[] Operation { get; set; }
        public string Synopsis { get; set; }

        public AWSCmdletAttribute(string synopsis)
        {
            if (string.IsNullOrEmpty(synopsis)) throw new ArgumentNullException("synopsis");

            Synopsis = synopsis;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class AWSCmdletOutputAttribute : Attribute
    {
        public string ReturnType { get; set; }
        public string Description { get; set; }

        public AWSCmdletOutputAttribute(string returnType, string description)
        {
            this.ReturnType = returnType;
            this.Description = description;
        }
        public AWSCmdletOutputAttribute(string returnType, params string[] descriptions)
        {
            this.ReturnType = returnType;
            this.Description = string.Join(Environment.NewLine, descriptions);
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class AWSClientCmdletAttribute : Attribute
    {
        public string ServiceName { get; set; }
        public string ServicePrefix { get; set; }
        public string Version { get; set; }

        public AWSClientCmdletAttribute(string serviceName, string servicePrefix, string version)
        {
            if (string.IsNullOrEmpty(serviceName)) throw new ArgumentNullException("serviceName");
            if (string.IsNullOrEmpty(servicePrefix)) throw new ArgumentNullException("servicePrefix");
            if (string.IsNullOrEmpty(version)) throw new ArgumentNullException("version");

            ServiceName = serviceName;
            ServicePrefix = servicePrefix;
            Version = version;
        }
    }
}
