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
using Amazon.PrometheusService;
using Amazon.PrometheusService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PROM
{
    /// <summary>
    /// Use this operation to create or update the label sets, label set limits, and retention
    /// period of a workspace.
    /// 
    ///  
    /// <para>
    /// You must specify at least one of <c>limitsPerLabelSet</c> or <c>retentionPeriodInDays</c>
    /// for the request to be valid.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "PROMWorkspaceConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PrometheusService.Model.WorkspaceConfigurationStatus")]
    [AWSCmdlet("Calls the Amazon Prometheus Service UpdateWorkspaceConfiguration API operation.", Operation = new[] {"UpdateWorkspaceConfiguration"}, SelectReturnType = typeof(Amazon.PrometheusService.Model.UpdateWorkspaceConfigurationResponse))]
    [AWSCmdletOutput("Amazon.PrometheusService.Model.WorkspaceConfigurationStatus or Amazon.PrometheusService.Model.UpdateWorkspaceConfigurationResponse",
        "This cmdlet returns an Amazon.PrometheusService.Model.WorkspaceConfigurationStatus object.",
        "The service call response (type Amazon.PrometheusService.Model.UpdateWorkspaceConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePROMWorkspaceConfigurationCmdlet : AmazonPrometheusServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LimitsPerLabelSet
        /// <summary>
        /// <para>
        /// <para>This is an array of structures, where each structure defines a label set for the workspace,
        /// and defines the active time series limit for each of those label sets. Each label
        /// name in a label set must be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.PrometheusService.Model.LimitsPerLabelSet[] LimitsPerLabelSet { get; set; }
        #endregion
        
        #region Parameter RetentionPeriodInDay
        /// <summary>
        /// <para>
        /// <para>Specifies how many days that metrics will be retained in the workspace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetentionPeriodInDays")]
        public System.Int32? RetentionPeriodInDay { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the workspace that you want to update. To find the IDs of your workspaces,
        /// use the <a href="https://docs.aws.amazon.com/prometheus/latest/APIReference/API_ListWorkspaces.htm">ListWorkspaces</a>
        /// operation.</para>
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
        public System.String WorkspaceId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>You can include a token in your operation to make it an idempotent opeartion. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PrometheusService.Model.UpdateWorkspaceConfigurationResponse).
        /// Specifying the name of a property of type Amazon.PrometheusService.Model.UpdateWorkspaceConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkspaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PROMWorkspaceConfiguration (UpdateWorkspaceConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PrometheusService.Model.UpdateWorkspaceConfigurationResponse, UpdatePROMWorkspaceConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.LimitsPerLabelSet != null)
            {
                context.LimitsPerLabelSet = new List<Amazon.PrometheusService.Model.LimitsPerLabelSet>(this.LimitsPerLabelSet);
            }
            context.RetentionPeriodInDay = this.RetentionPeriodInDay;
            context.WorkspaceId = this.WorkspaceId;
            #if MODULAR
            if (this.WorkspaceId == null && ParameterWasBound(nameof(this.WorkspaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkspaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PrometheusService.Model.UpdateWorkspaceConfigurationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.LimitsPerLabelSet != null)
            {
                request.LimitsPerLabelSet = cmdletContext.LimitsPerLabelSet;
            }
            if (cmdletContext.RetentionPeriodInDay != null)
            {
                request.RetentionPeriodInDays = cmdletContext.RetentionPeriodInDay.Value;
            }
            if (cmdletContext.WorkspaceId != null)
            {
                request.WorkspaceId = cmdletContext.WorkspaceId;
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
        
        private Amazon.PrometheusService.Model.UpdateWorkspaceConfigurationResponse CallAWSServiceOperation(IAmazonPrometheusService client, Amazon.PrometheusService.Model.UpdateWorkspaceConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Prometheus Service", "UpdateWorkspaceConfiguration");
            try
            {
                return client.UpdateWorkspaceConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.PrometheusService.Model.LimitsPerLabelSet> LimitsPerLabelSet { get; set; }
            public System.Int32? RetentionPeriodInDay { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.Func<Amazon.PrometheusService.Model.UpdateWorkspaceConfigurationResponse, UpdatePROMWorkspaceConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
