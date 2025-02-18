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
using Amazon.FIS;
using Amazon.FIS.Model;

namespace Amazon.PowerShell.Cmdlets.FIS
{
    /// <summary>
    /// Starts running an experiment from the specified experiment template.
    /// </summary>
    [Cmdlet("Start", "FISExperiment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FIS.Model.Experiment")]
    [AWSCmdlet("Calls the AWS Fault Injection Simulator StartExperiment API operation.", Operation = new[] {"StartExperiment"}, SelectReturnType = typeof(Amazon.FIS.Model.StartExperimentResponse))]
    [AWSCmdletOutput("Amazon.FIS.Model.Experiment or Amazon.FIS.Model.StartExperimentResponse",
        "This cmdlet returns an Amazon.FIS.Model.Experiment object.",
        "The service call response (type Amazon.FIS.Model.StartExperimentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartFISExperimentCmdlet : AmazonFISClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExperimentOptions_ActionsMode
        /// <summary>
        /// <para>
        /// <para>Specifies the actions mode for experiment options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FIS.ActionsMode")]
        public Amazon.FIS.ActionsMode ExperimentOptions_ActionsMode { get; set; }
        #endregion
        
        #region Parameter ExperimentTemplateId
        /// <summary>
        /// <para>
        /// <para>The ID of the experiment template.</para>
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
        public System.String ExperimentTemplateId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the experiment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Experiment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FIS.Model.StartExperimentResponse).
        /// Specifying the name of a property of type Amazon.FIS.Model.StartExperimentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Experiment";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExperimentTemplateId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-FISExperiment (StartExperiment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FIS.Model.StartExperimentResponse, StartFISExperimentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ExperimentOptions_ActionsMode = this.ExperimentOptions_ActionsMode;
            context.ExperimentTemplateId = this.ExperimentTemplateId;
            #if MODULAR
            if (this.ExperimentTemplateId == null && ParameterWasBound(nameof(this.ExperimentTemplateId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExperimentTemplateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.FIS.Model.StartExperimentRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ExperimentOptions
            var requestExperimentOptionsIsNull = true;
            request.ExperimentOptions = new Amazon.FIS.Model.StartExperimentExperimentOptionsInput();
            Amazon.FIS.ActionsMode requestExperimentOptions_experimentOptions_ActionsMode = null;
            if (cmdletContext.ExperimentOptions_ActionsMode != null)
            {
                requestExperimentOptions_experimentOptions_ActionsMode = cmdletContext.ExperimentOptions_ActionsMode;
            }
            if (requestExperimentOptions_experimentOptions_ActionsMode != null)
            {
                request.ExperimentOptions.ActionsMode = requestExperimentOptions_experimentOptions_ActionsMode;
                requestExperimentOptionsIsNull = false;
            }
             // determine if request.ExperimentOptions should be set to null
            if (requestExperimentOptionsIsNull)
            {
                request.ExperimentOptions = null;
            }
            if (cmdletContext.ExperimentTemplateId != null)
            {
                request.ExperimentTemplateId = cmdletContext.ExperimentTemplateId;
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
        
        private Amazon.FIS.Model.StartExperimentResponse CallAWSServiceOperation(IAmazonFIS client, Amazon.FIS.Model.StartExperimentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Fault Injection Simulator", "StartExperiment");
            try
            {
                return client.StartExperimentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.FIS.ActionsMode ExperimentOptions_ActionsMode { get; set; }
            public System.String ExperimentTemplateId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.FIS.Model.StartExperimentResponse, StartFISExperimentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Experiment;
        }
        
    }
}
