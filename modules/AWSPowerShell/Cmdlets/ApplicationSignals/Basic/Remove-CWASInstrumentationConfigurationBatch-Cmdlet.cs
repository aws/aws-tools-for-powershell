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
using Amazon.ApplicationSignals;
using Amazon.ApplicationSignals.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWAS
{
    /// <summary>
    /// Deletes multiple instrumentation configurations in a single request. Supports two
    /// mutually exclusive selection methods:
    /// 
    ///  <ul><li>By scope: Delete all configurations matching a Service + Environment + InstrumentationType</li><li>By ARN list: Delete specific configurations by providing a list of resource ARNs</li></ul>
    /// </summary>
    [Cmdlet("Remove", "CWASInstrumentationConfigurationBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ApplicationSignals.Model.BatchDeleteInstrumentationConfigurationsResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Signals BatchDeleteInstrumentationConfigurations API operation.", Operation = new[] {"BatchDeleteInstrumentationConfigurations"}, SelectReturnType = typeof(Amazon.ApplicationSignals.Model.BatchDeleteInstrumentationConfigurationsResponse))]
    [AWSCmdletOutput("Amazon.ApplicationSignals.Model.BatchDeleteInstrumentationConfigurationsResponse",
        "This cmdlet returns an Amazon.ApplicationSignals.Model.BatchDeleteInstrumentationConfigurationsResponse object containing multiple properties."
    )]
    public partial class RemoveCWASInstrumentationConfigurationBatchCmdlet : AmazonApplicationSignalsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeletionTarget_Scope_Environment
        /// <summary>
        /// <para>
        /// <para>Environment identifier for the instrumentation configurations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeletionTarget_Scope_Environment { get; set; }
        #endregion
        
        #region Parameter DeletionTarget_ResourceArns_InstrumentationType
        /// <summary>
        /// <para>
        /// <para>Instrumentation type: BREAKPOINT or PROBE.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationSignals.InstrumentationType")]
        public Amazon.ApplicationSignals.InstrumentationType DeletionTarget_ResourceArns_InstrumentationType { get; set; }
        #endregion
        
        #region Parameter DeletionTarget_Scope_InstrumentationType
        /// <summary>
        /// <para>
        /// <para>Instrumentation type: BREAKPOINT or PROBE.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationSignals.InstrumentationType")]
        public Amazon.ApplicationSignals.InstrumentationType DeletionTarget_Scope_InstrumentationType { get; set; }
        #endregion
        
        #region Parameter DeletionTarget_ResourceArns_ResourceArn
        /// <summary>
        /// <para>
        /// <para>List of resource ARNs to delete.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeletionTarget_ResourceArns_ResourceArns")]
        public System.String[] DeletionTarget_ResourceArns_ResourceArn { get; set; }
        #endregion
        
        #region Parameter DeletionTarget_Scope_Service
        /// <summary>
        /// <para>
        /// <para>Service name for the instrumentation configurations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeletionTarget_Scope_Service { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationSignals.Model.BatchDeleteInstrumentationConfigurationsResponse).
        /// Specifying the name of a property of type Amazon.ApplicationSignals.Model.BatchDeleteInstrumentationConfigurationsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeletionTarget_ResourceArns_ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CWASInstrumentationConfigurationBatch (BatchDeleteInstrumentationConfigurations)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationSignals.Model.BatchDeleteInstrumentationConfigurationsResponse, RemoveCWASInstrumentationConfigurationBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeletionTarget_ResourceArns_InstrumentationType = this.DeletionTarget_ResourceArns_InstrumentationType;
            if (this.DeletionTarget_ResourceArns_ResourceArn != null)
            {
                context.DeletionTarget_ResourceArns_ResourceArn = new List<System.String>(this.DeletionTarget_ResourceArns_ResourceArn);
            }
            context.DeletionTarget_Scope_Environment = this.DeletionTarget_Scope_Environment;
            context.DeletionTarget_Scope_InstrumentationType = this.DeletionTarget_Scope_InstrumentationType;
            context.DeletionTarget_Scope_Service = this.DeletionTarget_Scope_Service;
            
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
            var request = new Amazon.ApplicationSignals.Model.BatchDeleteInstrumentationConfigurationsRequest();
            
            
             // populate DeletionTarget
            var requestDeletionTargetIsNull = true;
            request.DeletionTarget = new Amazon.ApplicationSignals.Model.BatchDeleteDeletionTarget();
            Amazon.ApplicationSignals.Model.BatchDeleteByResourceArns requestDeletionTarget_deletionTarget_ResourceArns = null;
            
             // populate ResourceArns
            var requestDeletionTarget_deletionTarget_ResourceArnsIsNull = true;
            requestDeletionTarget_deletionTarget_ResourceArns = new Amazon.ApplicationSignals.Model.BatchDeleteByResourceArns();
            Amazon.ApplicationSignals.InstrumentationType requestDeletionTarget_deletionTarget_ResourceArns_deletionTarget_ResourceArns_InstrumentationType = null;
            if (cmdletContext.DeletionTarget_ResourceArns_InstrumentationType != null)
            {
                requestDeletionTarget_deletionTarget_ResourceArns_deletionTarget_ResourceArns_InstrumentationType = cmdletContext.DeletionTarget_ResourceArns_InstrumentationType;
            }
            if (requestDeletionTarget_deletionTarget_ResourceArns_deletionTarget_ResourceArns_InstrumentationType != null)
            {
                requestDeletionTarget_deletionTarget_ResourceArns.InstrumentationType = requestDeletionTarget_deletionTarget_ResourceArns_deletionTarget_ResourceArns_InstrumentationType;
                requestDeletionTarget_deletionTarget_ResourceArnsIsNull = false;
            }
            List<System.String> requestDeletionTarget_deletionTarget_ResourceArns_deletionTarget_ResourceArns_ResourceArn = null;
            if (cmdletContext.DeletionTarget_ResourceArns_ResourceArn != null)
            {
                requestDeletionTarget_deletionTarget_ResourceArns_deletionTarget_ResourceArns_ResourceArn = cmdletContext.DeletionTarget_ResourceArns_ResourceArn;
            }
            if (requestDeletionTarget_deletionTarget_ResourceArns_deletionTarget_ResourceArns_ResourceArn != null)
            {
                requestDeletionTarget_deletionTarget_ResourceArns.ResourceArns = requestDeletionTarget_deletionTarget_ResourceArns_deletionTarget_ResourceArns_ResourceArn;
                requestDeletionTarget_deletionTarget_ResourceArnsIsNull = false;
            }
             // determine if requestDeletionTarget_deletionTarget_ResourceArns should be set to null
            if (requestDeletionTarget_deletionTarget_ResourceArnsIsNull)
            {
                requestDeletionTarget_deletionTarget_ResourceArns = null;
            }
            if (requestDeletionTarget_deletionTarget_ResourceArns != null)
            {
                request.DeletionTarget.ResourceArns = requestDeletionTarget_deletionTarget_ResourceArns;
                requestDeletionTargetIsNull = false;
            }
            Amazon.ApplicationSignals.Model.BatchDeleteScope requestDeletionTarget_deletionTarget_Scope = null;
            
             // populate Scope
            var requestDeletionTarget_deletionTarget_ScopeIsNull = true;
            requestDeletionTarget_deletionTarget_Scope = new Amazon.ApplicationSignals.Model.BatchDeleteScope();
            System.String requestDeletionTarget_deletionTarget_Scope_deletionTarget_Scope_Environment = null;
            if (cmdletContext.DeletionTarget_Scope_Environment != null)
            {
                requestDeletionTarget_deletionTarget_Scope_deletionTarget_Scope_Environment = cmdletContext.DeletionTarget_Scope_Environment;
            }
            if (requestDeletionTarget_deletionTarget_Scope_deletionTarget_Scope_Environment != null)
            {
                requestDeletionTarget_deletionTarget_Scope.Environment = requestDeletionTarget_deletionTarget_Scope_deletionTarget_Scope_Environment;
                requestDeletionTarget_deletionTarget_ScopeIsNull = false;
            }
            Amazon.ApplicationSignals.InstrumentationType requestDeletionTarget_deletionTarget_Scope_deletionTarget_Scope_InstrumentationType = null;
            if (cmdletContext.DeletionTarget_Scope_InstrumentationType != null)
            {
                requestDeletionTarget_deletionTarget_Scope_deletionTarget_Scope_InstrumentationType = cmdletContext.DeletionTarget_Scope_InstrumentationType;
            }
            if (requestDeletionTarget_deletionTarget_Scope_deletionTarget_Scope_InstrumentationType != null)
            {
                requestDeletionTarget_deletionTarget_Scope.InstrumentationType = requestDeletionTarget_deletionTarget_Scope_deletionTarget_Scope_InstrumentationType;
                requestDeletionTarget_deletionTarget_ScopeIsNull = false;
            }
            System.String requestDeletionTarget_deletionTarget_Scope_deletionTarget_Scope_Service = null;
            if (cmdletContext.DeletionTarget_Scope_Service != null)
            {
                requestDeletionTarget_deletionTarget_Scope_deletionTarget_Scope_Service = cmdletContext.DeletionTarget_Scope_Service;
            }
            if (requestDeletionTarget_deletionTarget_Scope_deletionTarget_Scope_Service != null)
            {
                requestDeletionTarget_deletionTarget_Scope.Service = requestDeletionTarget_deletionTarget_Scope_deletionTarget_Scope_Service;
                requestDeletionTarget_deletionTarget_ScopeIsNull = false;
            }
             // determine if requestDeletionTarget_deletionTarget_Scope should be set to null
            if (requestDeletionTarget_deletionTarget_ScopeIsNull)
            {
                requestDeletionTarget_deletionTarget_Scope = null;
            }
            if (requestDeletionTarget_deletionTarget_Scope != null)
            {
                request.DeletionTarget.Scope = requestDeletionTarget_deletionTarget_Scope;
                requestDeletionTargetIsNull = false;
            }
             // determine if request.DeletionTarget should be set to null
            if (requestDeletionTargetIsNull)
            {
                request.DeletionTarget = null;
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
        
        private Amazon.ApplicationSignals.Model.BatchDeleteInstrumentationConfigurationsResponse CallAWSServiceOperation(IAmazonApplicationSignals client, Amazon.ApplicationSignals.Model.BatchDeleteInstrumentationConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Signals", "BatchDeleteInstrumentationConfigurations");
            try
            {
                return client.BatchDeleteInstrumentationConfigurationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.ApplicationSignals.InstrumentationType DeletionTarget_ResourceArns_InstrumentationType { get; set; }
            public List<System.String> DeletionTarget_ResourceArns_ResourceArn { get; set; }
            public System.String DeletionTarget_Scope_Environment { get; set; }
            public Amazon.ApplicationSignals.InstrumentationType DeletionTarget_Scope_InstrumentationType { get; set; }
            public System.String DeletionTarget_Scope_Service { get; set; }
            public System.Func<Amazon.ApplicationSignals.Model.BatchDeleteInstrumentationConfigurationsResponse, RemoveCWASInstrumentationConfigurationBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
