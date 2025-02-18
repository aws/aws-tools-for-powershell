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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a Network Access Scope.
    /// 
    ///  
    /// <para>
    /// Amazon Web Services Network Access Analyzer enables cloud networking and cloud operations
    /// teams to verify that their networks on Amazon Web Services conform to their network
    /// security and governance objectives. For more information, see the <a href="https://docs.aws.amazon.com/vpc/latest/network-access-analyzer/">Amazon
    /// Web Services Network Access Analyzer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2NetworkInsightsAccessScope", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateNetworkInsightsAccessScopeResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateNetworkInsightsAccessScope API operation.", Operation = new[] {"CreateNetworkInsightsAccessScope"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateNetworkInsightsAccessScopeResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateNetworkInsightsAccessScopeResponse",
        "This cmdlet returns an Amazon.EC2.Model.CreateNetworkInsightsAccessScopeResponse object containing multiple properties."
    )]
    public partial class NewEC2NetworkInsightsAccessScopeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExcludePath
        /// <summary>
        /// <para>
        /// <para>The paths to exclude.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExcludePaths")]
        public Amazon.EC2.Model.AccessScopePathRequest[] ExcludePath { get; set; }
        #endregion
        
        #region Parameter MatchPath
        /// <summary>
        /// <para>
        /// <para>The paths to match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MatchPaths")]
        public Amazon.EC2.Model.AccessScopePathRequest[] MatchPath { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">How
        /// to ensure idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateNetworkInsightsAccessScopeResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateNetworkInsightsAccessScopeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TagSpecification), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2NetworkInsightsAccessScope (CreateNetworkInsightsAccessScope)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateNetworkInsightsAccessScopeResponse, NewEC2NetworkInsightsAccessScopeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.ExcludePath != null)
            {
                context.ExcludePath = new List<Amazon.EC2.Model.AccessScopePathRequest>(this.ExcludePath);
            }
            if (this.MatchPath != null)
            {
                context.MatchPath = new List<Amazon.EC2.Model.AccessScopePathRequest>(this.MatchPath);
            }
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            
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
            var request = new Amazon.EC2.Model.CreateNetworkInsightsAccessScopeRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ExcludePath != null)
            {
                request.ExcludePaths = cmdletContext.ExcludePath;
            }
            if (cmdletContext.MatchPath != null)
            {
                request.MatchPaths = cmdletContext.MatchPath;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreateNetworkInsightsAccessScopeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateNetworkInsightsAccessScopeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateNetworkInsightsAccessScope");
            try
            {
                return client.CreateNetworkInsightsAccessScopeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<Amazon.EC2.Model.AccessScopePathRequest> ExcludePath { get; set; }
            public List<Amazon.EC2.Model.AccessScopePathRequest> MatchPath { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateNetworkInsightsAccessScopeResponse, NewEC2NetworkInsightsAccessScopeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
