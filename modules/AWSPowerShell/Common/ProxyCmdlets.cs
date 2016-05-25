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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text;

using Amazon.Runtime;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// Sets AWS default proxy for the shell.
    /// </summary>
    [Cmdlet("Set", "AWSProxy")]
    [AWSCmdlet("Sets AWS default proxy for the shell. Subsequent AWS cmdlet invocations will use the configured proxy.")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class SetProxyCmdlet : PSCmdlet
    {
        /// <summary>
        /// Proxy server host
        /// </summary>
        [Parameter(Position = 0, Mandatory = true)]
        public string Hostname { get; set; }

        /// <summary>
        /// Proxy server port
        /// </summary>
        [Parameter(Position = 1, Mandatory = true)]
        public int Port { get; set; }

        /// <summary>
        /// Username to submit to the proxy server for authentication
        /// </summary>
        [Parameter(Position = 2, Mandatory = false)]
        public string Username { get; set; }

        /// <summary>
        /// Password to submit to the proxy server for authentication
        /// </summary>
        [Parameter(Position = 3, Mandatory = false)]
        public string Password { get; set; }
        
        /// <summary>
        /// The credentials to submit to the proxy server for authentication
        /// </summary>
        [Parameter(Position = 4, Mandatory = false)]
        [Alias("Credentials")]
        public ICredentials Credential { get; set; }


        protected override void ProcessRecord()
        {
            var settings = ProxySettings.GetSettings(this);
            settings.Hostname = Hostname;
            settings.Port = Port;

            if (Credential != null)
                settings.Credentials = Credential;
            else if (!string.IsNullOrEmpty(Username) || !string.IsNullOrEmpty(Password))
                settings.Credentials = new NetworkCredential(Username, Password ?? String.Empty);

            settings.SaveSettings(this);
        }
    }

    /// <summary>
    /// Clears AWS default proxy for the shell.
    /// </summary>
    [Cmdlet("Clear", "AWSProxy")]
    [AWSCmdlet("Clears AWS default proxy for the shell. Subsequent AWS cmdlet invocations will not use a proxy.")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class ClearProxyCmdlet : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            ProxySettings.SaveSettings(this, null);
        }
    }

    /// <summary>
    /// Proxy settings for AWS cmdlets
    /// </summary>
    public class ProxySettings
    {
        /// <summary>
        /// Proxy host
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// Proxy port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Proxy credentials
        /// </summary>
        public ICredentials Credentials { get; set; }

        internal bool UseProxy
        {
            get
            {
                return !string.IsNullOrEmpty(Hostname) && Port != 0;
            }
        }

        internal WebProxy GetWebProxy()
        {
            WebProxy proxy = null;
            if (!string.IsNullOrEmpty(Hostname) && Port > 0)
            {
                proxy = new WebProxy(Hostname, Port);
            }
            if (proxy != null && Credentials != null)
            {
                proxy.Credentials = Credentials;
            }

            return proxy;
        }

        internal static ProxySettings GetSettings(PSCmdlet cmdlet)
        {
            ProxySettings ps = GetFromSettingsVariable(cmdlet.SessionState);
            if (ps == null)
                ps = new ProxySettings();

            return ps;
        }

        internal static ProxySettings GetFromSettingsVariable(SessionState session)
        {
            ProxySettings ps = null;

            var variable = session.PSVariable.Get(SessionKeys.AWSProxyVariableName);
            if (variable != null && variable.Value != null)
                ps = variable.Value as ProxySettings;

            return ps;
        }

        internal void SaveSettings(PSCmdlet cmdlet)
        {
            SaveSettings(cmdlet, this);
        }
        internal static void SaveSettings(PSCmdlet cmdlet, ProxySettings settings)
        {
            cmdlet.SessionState.PSVariable.Set(SessionKeys.AWSProxyVariableName, settings);
        }
    }
}
