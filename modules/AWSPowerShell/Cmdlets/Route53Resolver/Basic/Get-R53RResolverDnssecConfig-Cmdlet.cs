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
using Amazon.Route53Resolver;
using Amazon.Route53Resolver.Model;

namespace Amazon.PowerShell.Cmdlets.R53R
{
    /// <summary>
    /// Gets DNSSEC validation information for a specified resource.
    /// </summary>
    [Cmdlet("Get", "R53RResolverDnssecConfig")]
    [OutputType("Amazon.Route53Resolver.Model.ResolverDnssecConfig")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver GetResolverDnssecConfig API operation.", Operation = new[] {"GetResolverDnssecConfig"}, SelectReturnType = typeof(Amazon.Route53Resolver.Model.GetResolverDnssecConfigResponse))]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.ResolverDnssecConfig or Amazon.Route53Resolver.Model.GetResolverDnssecConfigResponse",
        "This cmdlet returns an Amazon.Route53Resolver.Model.ResolverDnssecConfig object.",
        "The service call response (type Amazon.Route53Resolver.Model.GetResolverDnssecConfigResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetR53RResolverDnssecConfigCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual private cloud (VPC) for the DNSSEC validation status.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResolverDNSSECConfig'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Resolver.Model.GetResolverDnssecConfigResponse).
        /// Specifying the name of a property of type Amazon.Route53Resolver.Model.GetResolverDnssecConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResolverDNSSECConfig";
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
                context.Select = CreateSelectDelegate<Amazon.Route53Resolver.Model.GetResolverDnssecConfigResponse, GetR53RResolverDnssecConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Route53Resolver.Model.GetResolverDnssecConfigRequest();
            
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
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
        
        private Amazon.Route53Resolver.Model.GetResolverDnssecConfigResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.GetResolverDnssecConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "GetResolverDnssecConfig");
            try
            {
                return client.GetResolverDnssecConfigAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ResourceId { get; set; }
            public System.Func<Amazon.Route53Resolver.Model.GetResolverDnssecConfigResponse, GetR53RResolverDnssecConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResolverDNSSECConfig;
        }
        
    }
}
