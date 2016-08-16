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
using System.IO;
using System.Management.Automation;
using System.Reflection;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.Util.Internal;

namespace Amazon.PowerShell.Utils
{
    internal static class Common
    {

        public static void PopulateConfig(PSCmdlet cmdlet, ClientConfig clientConfig)
        {
#if DESKTOP
            var proxySettings = ProxySettings.GetSettings(cmdlet);
            if (proxySettings != null && proxySettings.UseProxy)
            {
                clientConfig.ProxyHost = proxySettings.Hostname;
                clientConfig.ProxyPort = proxySettings.Port;
                clientConfig.ProxyCredentials = proxySettings.Credentials;
            }
#endif
        }

        public static void SetAWSPowerShellUserAgent(System.Version hostVersion)
        {
#if DESKTOP
            var moduleName = "AWSPowerShell";
#else
            var moduleName = "AWSPowerShell.NetCore";
#endif
            Util.Internal.InternalSDKUtils.SetUserAgent(moduleName, 
                                                        TypeFactory.GetTypeInfo(typeof(BaseCmdlet)).Assembly.GetName().Version.ToString(),
                                                        string.Format("WindowsPowerShell/{0}.{1}", hostVersion.Major, hostVersion.MajorRevision));
        }

        public static ServerSideEncryptionMethod Convert(string serverSideEncryption)
        {
            ServerSideEncryptionMethod value = serverSideEncryption;
            if (string.Equals(value.Value, serverSideEncryptionNone.Value, System.StringComparison.OrdinalIgnoreCase))
                value = ServerSideEncryptionMethod.None;
            return value;
        }

        private static readonly ServerSideEncryptionMethod serverSideEncryptionNone = "None";

        public static void CopyStream(Stream source, Stream destination, int bufferSize = 8192)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (destination == null)
                throw new ArgumentNullException("destination");
            if (bufferSize <= 0)
                throw new ArgumentOutOfRangeException("bufferSize");

            byte[] array = new byte[bufferSize];
            int count;
            while ((count = source.Read(array, 0, array.Length)) != 0)
            {
                destination.Write(array, 0, count);
            }
        }

    }
}
