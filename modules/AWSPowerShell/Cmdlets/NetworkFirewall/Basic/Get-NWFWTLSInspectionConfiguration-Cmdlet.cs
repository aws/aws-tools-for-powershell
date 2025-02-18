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
using System.Threading;
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Returns the data objects for the specified TLS inspection configuration.
    /// </summary>
    [Cmdlet("Get", "NWFWTLSInspectionConfiguration")]
    [OutputType("Amazon.NetworkFirewall.Model.DescribeTLSInspectionConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall DescribeTLSInspectionConfiguration API operation.", Operation = new[] {"DescribeTLSInspectionConfiguration"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.DescribeTLSInspectionConfigurationResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.DescribeTLSInspectionConfigurationResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.DescribeTLSInspectionConfigurationResponse object containing multiple properties."
    )]
    public partial class GetNWFWTLSInspectionConfigurationCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TLSInspectionConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the TLS inspection configuration.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TLSInspectionConfigurationArn { get; set; }
        #endregion
        
        #region Parameter TLSInspectionConfigurationName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the TLS inspection configuration. You can't change the name
        /// of a TLS inspection configuration after you create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TLSInspectionConfigurationName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.DescribeTLSInspectionConfigurationResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.DescribeTLSInspectionConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.DescribeTLSInspectionConfigurationResponse, GetNWFWTLSInspectionConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TLSInspectionConfigurationArn = this.TLSInspectionConfigurationArn;
            context.TLSInspectionConfigurationName = this.TLSInspectionConfigurationName;
            
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
            var request = new Amazon.NetworkFirewall.Model.DescribeTLSInspectionConfigurationRequest();
            
            if (cmdletContext.TLSInspectionConfigurationArn != null)
            {
                request.TLSInspectionConfigurationArn = cmdletContext.TLSInspectionConfigurationArn;
            }
            if (cmdletContext.TLSInspectionConfigurationName != null)
            {
                request.TLSInspectionConfigurationName = cmdletContext.TLSInspectionConfigurationName;
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
        
        private Amazon.NetworkFirewall.Model.DescribeTLSInspectionConfigurationResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.DescribeTLSInspectionConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "DescribeTLSInspectionConfiguration");
            try
            {
                return client.DescribeTLSInspectionConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String TLSInspectionConfigurationArn { get; set; }
            public System.String TLSInspectionConfigurationName { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.DescribeTLSInspectionConfigurationResponse, GetNWFWTLSInspectionConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
