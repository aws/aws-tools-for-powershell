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
    /// Updates the behavior configuration of Route 53 Resolver behavior for a single VPC
    /// from Amazon Virtual Private Cloud.
    /// </summary>
    [Cmdlet("Update", "R53RResolverConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53Resolver.Model.ResolverConfig")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver UpdateResolverConfig API operation.", Operation = new[] {"UpdateResolverConfig"}, SelectReturnType = typeof(Amazon.Route53Resolver.Model.UpdateResolverConfigResponse))]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.ResolverConfig or Amazon.Route53Resolver.Model.UpdateResolverConfigResponse",
        "This cmdlet returns an Amazon.Route53Resolver.Model.ResolverConfig object.",
        "The service call response (type Amazon.Route53Resolver.Model.UpdateResolverConfigResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateR53RResolverConfigCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutodefinedReverseFlag
        /// <summary>
        /// <para>
        /// <para>Indicates whether or not the Resolver will create autodefined rules for reverse DNS
        /// lookups. This is enabled by default. Disabling this option will also affect EC2-Classic
        /// instances using ClassicLink. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/vpc-classiclink.html">ClassicLink</a>
        /// in the <i>Amazon EC2 guide</i>.</para><important><para>We are retiring EC2-Classic on August 15, 2022. We recommend that you migrate from
        /// EC2-Classic to a VPC. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/vpc-migrate.html">Migrate
        /// from EC2-Classic to a VPC</a> in the <i>Amazon EC2 guide</i> and the blog <a href="http://aws.amazon.com/blogs/aws/ec2-classic-is-retiring-heres-how-to-prepare/">EC2-Classic
        /// Networking is Retiring – Here’s How to Prepare</a>.</para></important><note><para>It can take some time for the status change to be completed.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Route53Resolver.AutodefinedReverseFlag")]
        public Amazon.Route53Resolver.AutodefinedReverseFlag AutodefinedReverseFlag { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>Resource ID of the Amazon VPC that you want to update the Resolver configuration for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResolverConfig'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Resolver.Model.UpdateResolverConfigResponse).
        /// Specifying the name of a property of type Amazon.Route53Resolver.Model.UpdateResolverConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResolverConfig";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53RResolverConfig (UpdateResolverConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Resolver.Model.UpdateResolverConfigResponse, UpdateR53RResolverConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutodefinedReverseFlag = this.AutodefinedReverseFlag;
            #if MODULAR
            if (this.AutodefinedReverseFlag == null && ParameterWasBound(nameof(this.AutodefinedReverseFlag)))
            {
                WriteWarning("You are passing $null as a value for parameter AutodefinedReverseFlag which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Route53Resolver.Model.UpdateResolverConfigRequest();
            
            if (cmdletContext.AutodefinedReverseFlag != null)
            {
                request.AutodefinedReverseFlag = cmdletContext.AutodefinedReverseFlag;
            }
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
        
        private Amazon.Route53Resolver.Model.UpdateResolverConfigResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.UpdateResolverConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "UpdateResolverConfig");
            try
            {
                return client.UpdateResolverConfigAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Route53Resolver.AutodefinedReverseFlag AutodefinedReverseFlag { get; set; }
            public System.String ResourceId { get; set; }
            public System.Func<Amazon.Route53Resolver.Model.UpdateResolverConfigResponse, UpdateR53RResolverConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResolverConfig;
        }
        
    }
}
