/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Returns the data objects for the specified proxy configuration.
    /// </summary>
    [Cmdlet("Get", "NWFWProxyConfigurationDetail")]
    [OutputType("Amazon.NetworkFirewall.Model.DescribeProxyConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall DescribeProxyConfiguration API operation.", Operation = new[] {"DescribeProxyConfiguration"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.DescribeProxyConfigurationResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.DescribeProxyConfigurationResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.DescribeProxyConfigurationResponse object containing multiple properties."
    )]
    public partial class GetNWFWProxyConfigurationDetailCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ProxyConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a proxy configuration.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProxyConfigurationArn { get; set; }
        #endregion
        
        #region Parameter ProxyConfigurationName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the proxy configuration. You can't change the name of a proxy
        /// configuration after you create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProxyConfigurationName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.DescribeProxyConfigurationResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.DescribeProxyConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.DescribeProxyConfigurationResponse, GetNWFWProxyConfigurationDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ProxyConfigurationArn = this.ProxyConfigurationArn;
            context.ProxyConfigurationName = this.ProxyConfigurationName;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.NetworkFirewall.Model.DescribeProxyConfigurationRequest();
            
            if (cmdletContext.ProxyConfigurationArn != null)
            {
                request.ProxyConfigurationArn = cmdletContext.ProxyConfigurationArn;
            }
            if (cmdletContext.ProxyConfigurationName != null)
            {
                request.ProxyConfigurationName = cmdletContext.ProxyConfigurationName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.NetworkFirewall.Model.DescribeProxyConfigurationResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.DescribeProxyConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "DescribeProxyConfiguration");
            try
            {
                #if DESKTOP
                return client.DescribeProxyConfiguration(request);
                #elif CORECLR
                return client.DescribeProxyConfigurationAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ProxyConfigurationArn { get; set; }
            public System.String ProxyConfigurationName { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.DescribeProxyConfigurationResponse, GetNWFWProxyConfigurationDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
