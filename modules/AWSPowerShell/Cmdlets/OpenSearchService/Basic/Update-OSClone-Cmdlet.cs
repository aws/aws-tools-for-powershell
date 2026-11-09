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
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Manages a cloned blue/green upgrade that is in progress on a domain. Use it to shift
    /// a percentage of search traffic to the cloned cluster, to cut over to the cloned cluster
    /// or back to the primary cluster, or to change the retention period. Specify exactly
    /// one of <c>TrafficSplitOptions</c>, <c>CutoverOptions</c>, or <c>RetentionOptions</c>
    /// in each request.
    /// </summary>
    [Cmdlet("Update", "OSClone", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchService.Model.UpdateCloneResponse")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service UpdateClone API operation.", Operation = new[] {"UpdateClone"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.UpdateCloneResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.UpdateCloneResponse",
        "This cmdlet returns an Amazon.OpenSearchService.Model.UpdateCloneResponse object containing multiple properties."
    )]
    public partial class UpdateOSCloneCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TrafficSplitOptions_CloneReadTrafficPercent
        /// <summary>
        /// <para>
        /// <para>The percentage of search traffic, from 0 to 100, to send to the cloned cluster. The
        /// rest goes to the primary cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TrafficSplitOptions_CloneReadTrafficPercent { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain that has a cloned blue/green upgrade in progress.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter RetentionOptions_RetentionAction
        /// <summary>
        /// <para>
        /// <para>Ends the retention period now. Valid only after cutover completes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.RetentionAction")]
        public Amazon.OpenSearchService.RetentionAction RetentionOptions_RetentionAction { get; set; }
        #endregion
        
        #region Parameter RetentionOptions_RetentionInHour
        /// <summary>
        /// <para>
        /// <para>The number of hours to keep the cluster that you cut over from. The retention period
        /// starts when cutover completes. The minimum is 1 hour. In an <c>UpdateClone</c> response
        /// after cutover completes, this value is the number of hours remaining in the retention
        /// period, rounded up.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetentionOptions_RetentionInHours")]
        public System.Int32? RetentionOptions_RetentionInHour { get; set; }
        #endregion
        
        #region Parameter TrafficSplitOptions_Strategy
        /// <summary>
        /// <para>
        /// <para>The traffic shifting strategy. The only valid value is <c>ShiftReadTrafficPercent</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.TrafficStrategy")]
        public Amazon.OpenSearchService.TrafficStrategy TrafficSplitOptions_Strategy { get; set; }
        #endregion
        
        #region Parameter CutoverOptions_Target
        /// <summary>
        /// <para>
        /// <para>The cluster to cut over to. <c>ClonedCluster</c> makes the cloned cluster serve the
        /// domain. <c>PrimaryCluster</c> keeps the primary cluster and ends the upgrade.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.CutoverTarget")]
        public Amazon.OpenSearchService.CutoverTarget CutoverOptions_Target { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.UpdateCloneResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.UpdateCloneResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OSClone (UpdateClone)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.UpdateCloneResponse, UpdateOSCloneCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CutoverOptions_Target = this.CutoverOptions_Target;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetentionOptions_RetentionAction = this.RetentionOptions_RetentionAction;
            context.RetentionOptions_RetentionInHour = this.RetentionOptions_RetentionInHour;
            context.TrafficSplitOptions_CloneReadTrafficPercent = this.TrafficSplitOptions_CloneReadTrafficPercent;
            context.TrafficSplitOptions_Strategy = this.TrafficSplitOptions_Strategy;
            
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
            var request = new Amazon.OpenSearchService.Model.UpdateCloneRequest();
            
            
             // populate CutoverOptions
            var requestCutoverOptionsIsNull = true;
            request.CutoverOptions = new Amazon.OpenSearchService.Model.CutoverRequestOptions();
            Amazon.OpenSearchService.CutoverTarget requestCutoverOptions_cutoverOptions_Target = null;
            if (cmdletContext.CutoverOptions_Target != null)
            {
                requestCutoverOptions_cutoverOptions_Target = cmdletContext.CutoverOptions_Target;
            }
            if (requestCutoverOptions_cutoverOptions_Target != null)
            {
                request.CutoverOptions.Target = requestCutoverOptions_cutoverOptions_Target;
                requestCutoverOptionsIsNull = false;
            }
             // determine if request.CutoverOptions should be set to null
            if (requestCutoverOptionsIsNull)
            {
                request.CutoverOptions = null;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate RetentionOptions
            var requestRetentionOptionsIsNull = true;
            request.RetentionOptions = new Amazon.OpenSearchService.Model.RetentionOptions();
            Amazon.OpenSearchService.RetentionAction requestRetentionOptions_retentionOptions_RetentionAction = null;
            if (cmdletContext.RetentionOptions_RetentionAction != null)
            {
                requestRetentionOptions_retentionOptions_RetentionAction = cmdletContext.RetentionOptions_RetentionAction;
            }
            if (requestRetentionOptions_retentionOptions_RetentionAction != null)
            {
                request.RetentionOptions.RetentionAction = requestRetentionOptions_retentionOptions_RetentionAction;
                requestRetentionOptionsIsNull = false;
            }
            System.Int32? requestRetentionOptions_retentionOptions_RetentionInHour = null;
            if (cmdletContext.RetentionOptions_RetentionInHour != null)
            {
                requestRetentionOptions_retentionOptions_RetentionInHour = cmdletContext.RetentionOptions_RetentionInHour.Value;
            }
            if (requestRetentionOptions_retentionOptions_RetentionInHour != null)
            {
                request.RetentionOptions.RetentionInHours = requestRetentionOptions_retentionOptions_RetentionInHour.Value;
                requestRetentionOptionsIsNull = false;
            }
             // determine if request.RetentionOptions should be set to null
            if (requestRetentionOptionsIsNull)
            {
                request.RetentionOptions = null;
            }
            
             // populate TrafficSplitOptions
            var requestTrafficSplitOptionsIsNull = true;
            request.TrafficSplitOptions = new Amazon.OpenSearchService.Model.TrafficSplitRequestOptions();
            System.Int32? requestTrafficSplitOptions_trafficSplitOptions_CloneReadTrafficPercent = null;
            if (cmdletContext.TrafficSplitOptions_CloneReadTrafficPercent != null)
            {
                requestTrafficSplitOptions_trafficSplitOptions_CloneReadTrafficPercent = cmdletContext.TrafficSplitOptions_CloneReadTrafficPercent.Value;
            }
            if (requestTrafficSplitOptions_trafficSplitOptions_CloneReadTrafficPercent != null)
            {
                request.TrafficSplitOptions.CloneReadTrafficPercent = requestTrafficSplitOptions_trafficSplitOptions_CloneReadTrafficPercent.Value;
                requestTrafficSplitOptionsIsNull = false;
            }
            Amazon.OpenSearchService.TrafficStrategy requestTrafficSplitOptions_trafficSplitOptions_Strategy = null;
            if (cmdletContext.TrafficSplitOptions_Strategy != null)
            {
                requestTrafficSplitOptions_trafficSplitOptions_Strategy = cmdletContext.TrafficSplitOptions_Strategy;
            }
            if (requestTrafficSplitOptions_trafficSplitOptions_Strategy != null)
            {
                request.TrafficSplitOptions.Strategy = requestTrafficSplitOptions_trafficSplitOptions_Strategy;
                requestTrafficSplitOptionsIsNull = false;
            }
             // determine if request.TrafficSplitOptions should be set to null
            if (requestTrafficSplitOptionsIsNull)
            {
                request.TrafficSplitOptions = null;
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
        
        private Amazon.OpenSearchService.Model.UpdateCloneResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.UpdateCloneRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "UpdateClone");
            try
            {
                return client.UpdateCloneAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.OpenSearchService.CutoverTarget CutoverOptions_Target { get; set; }
            public System.String DomainName { get; set; }
            public Amazon.OpenSearchService.RetentionAction RetentionOptions_RetentionAction { get; set; }
            public System.Int32? RetentionOptions_RetentionInHour { get; set; }
            public System.Int32? TrafficSplitOptions_CloneReadTrafficPercent { get; set; }
            public Amazon.OpenSearchService.TrafficStrategy TrafficSplitOptions_Strategy { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.UpdateCloneResponse, UpdateOSCloneCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
