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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Authorizes the aggregator account and region to collect data from the source account
    /// and region. 
    /// 
    ///  <note><para><b>Tags are added at creation and cannot be updated with this operation</b></para><para><c>PutAggregationAuthorization</c> is an idempotent API. Subsequent requests won’t
    /// create a duplicate resource if one was already created. If a following request has
    /// different <c>tags</c> values, Config will ignore these differences and treat it as
    /// an idempotent request of the previous. In this case, <c>tags</c> will not be updated,
    /// even if they are different.
    /// </para><para>
    /// Use <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_TagResource.html">TagResource</a>
    /// and <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_UntagResource.html">UntagResource</a>
    /// to update tags after creation.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGAggregationAuthorization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConfigService.Model.AggregationAuthorization")]
    [AWSCmdlet("Calls the AWS Config PutAggregationAuthorization API operation.", Operation = new[] {"PutAggregationAuthorization"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutAggregationAuthorizationResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.AggregationAuthorization or Amazon.ConfigService.Model.PutAggregationAuthorizationResponse",
        "This cmdlet returns an Amazon.ConfigService.Model.AggregationAuthorization object.",
        "The service call response (type Amazon.ConfigService.Model.PutAggregationAuthorizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCFGAggregationAuthorizationCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AuthorizedAccountId
        /// <summary>
        /// <para>
        /// <para>The 12-digit account ID of the account authorized to aggregate data.</para>
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
        public System.String AuthorizedAccountId { get; set; }
        #endregion
        
        #region Parameter AuthorizedAwsRegion
        /// <summary>
        /// <para>
        /// <para>The region authorized to collect aggregated data.</para>
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
        public System.String AuthorizedAwsRegion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of tag object.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ConfigService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AggregationAuthorization'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutAggregationAuthorizationResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.PutAggregationAuthorizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AggregationAuthorization";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AuthorizedAccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGAggregationAuthorization (PutAggregationAuthorization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutAggregationAuthorizationResponse, WriteCFGAggregationAuthorizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthorizedAccountId = this.AuthorizedAccountId;
            #if MODULAR
            if (this.AuthorizedAccountId == null && ParameterWasBound(nameof(this.AuthorizedAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizedAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthorizedAwsRegion = this.AuthorizedAwsRegion;
            #if MODULAR
            if (this.AuthorizedAwsRegion == null && ParameterWasBound(nameof(this.AuthorizedAwsRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizedAwsRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ConfigService.Model.Tag>(this.Tag);
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
            var request = new Amazon.ConfigService.Model.PutAggregationAuthorizationRequest();
            
            if (cmdletContext.AuthorizedAccountId != null)
            {
                request.AuthorizedAccountId = cmdletContext.AuthorizedAccountId;
            }
            if (cmdletContext.AuthorizedAwsRegion != null)
            {
                request.AuthorizedAwsRegion = cmdletContext.AuthorizedAwsRegion;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ConfigService.Model.PutAggregationAuthorizationResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutAggregationAuthorizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutAggregationAuthorization");
            try
            {
                return client.PutAggregationAuthorizationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AuthorizedAccountId { get; set; }
            public System.String AuthorizedAwsRegion { get; set; }
            public List<Amazon.ConfigService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutAggregationAuthorizationResponse, WriteCFGAggregationAuthorizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AggregationAuthorization;
        }
        
    }
}
