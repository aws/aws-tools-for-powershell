/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Updates one or more properties of a trial component.
    /// </summary>
    [Cmdlet("Update", "SMTrialComponent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateTrialComponent API operation.", Operation = new[] {"UpdateTrialComponent"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateTrialComponentResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateTrialComponentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateTrialComponentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMTrialComponentCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The name of the component as displayed. The name doesn't need to be unique. If <code>DisplayName</code>
        /// isn't specified, <code>TrialComponentName</code> is displayed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>When the component ended.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter InputArtifact
        /// <summary>
        /// <para>
        /// <para>Replaces all of the component's input artifacts with the specified artifacts or adds
        /// new input artifacts. Existing input artifacts are replaced if the trial component
        /// is updated with an identical input artifact key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputArtifacts")]
        public System.Collections.Hashtable InputArtifact { get; set; }
        #endregion
        
        #region Parameter InputArtifactsToRemove
        /// <summary>
        /// <para>
        /// <para>The input artifacts to remove from the component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] InputArtifactsToRemove { get; set; }
        #endregion
        
        #region Parameter Status_Message
        /// <summary>
        /// <para>
        /// <para>If the component failed, a message describing why.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Status_Message { get; set; }
        #endregion
        
        #region Parameter OutputArtifact
        /// <summary>
        /// <para>
        /// <para>Replaces all of the component's output artifacts with the specified artifacts or adds
        /// new output artifacts. Existing output artifacts are replaced if the trial component
        /// is updated with an identical output artifact key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputArtifacts")]
        public System.Collections.Hashtable OutputArtifact { get; set; }
        #endregion
        
        #region Parameter OutputArtifactsToRemove
        /// <summary>
        /// <para>
        /// <para>The output artifacts to remove from the component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OutputArtifactsToRemove { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>Replaces all of the component's hyperparameters with the specified hyperparameters
        /// or add new hyperparameters. Existing hyperparameters are replaced if the trial component
        /// is updated with an identical hyperparameter key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter ParametersToRemove
        /// <summary>
        /// <para>
        /// <para>The hyperparameters to remove from the component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ParametersToRemove { get; set; }
        #endregion
        
        #region Parameter Status_PrimaryStatus
        /// <summary>
        /// <para>
        /// <para>The status of the trial component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.TrialComponentPrimaryStatus")]
        public Amazon.SageMaker.TrialComponentPrimaryStatus Status_PrimaryStatus { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>When the component started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter TrialComponentName
        /// <summary>
        /// <para>
        /// <para>The name of the component to update.</para>
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
        public System.String TrialComponentName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrialComponentArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateTrialComponentResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateTrialComponentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrialComponentArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrialComponentName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrialComponentName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrialComponentName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrialComponentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMTrialComponent (UpdateTrialComponent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateTrialComponentResponse, UpdateSMTrialComponentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrialComponentName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DisplayName = this.DisplayName;
            context.EndTime = this.EndTime;
            if (this.InputArtifact != null)
            {
                context.InputArtifact = new Dictionary<System.String, Amazon.SageMaker.Model.TrialComponentArtifact>(StringComparer.Ordinal);
                foreach (var hashKey in this.InputArtifact.Keys)
                {
                    context.InputArtifact.Add((String)hashKey, (TrialComponentArtifact)(this.InputArtifact[hashKey]));
                }
            }
            if (this.InputArtifactsToRemove != null)
            {
                context.InputArtifactsToRemove = new List<System.String>(this.InputArtifactsToRemove);
            }
            if (this.OutputArtifact != null)
            {
                context.OutputArtifact = new Dictionary<System.String, Amazon.SageMaker.Model.TrialComponentArtifact>(StringComparer.Ordinal);
                foreach (var hashKey in this.OutputArtifact.Keys)
                {
                    context.OutputArtifact.Add((String)hashKey, (TrialComponentArtifact)(this.OutputArtifact[hashKey]));
                }
            }
            if (this.OutputArtifactsToRemove != null)
            {
                context.OutputArtifactsToRemove = new List<System.String>(this.OutputArtifactsToRemove);
            }
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, Amazon.SageMaker.Model.TrialComponentParameterValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameter.Add((String)hashKey, (TrialComponentParameterValue)(this.Parameter[hashKey]));
                }
            }
            if (this.ParametersToRemove != null)
            {
                context.ParametersToRemove = new List<System.String>(this.ParametersToRemove);
            }
            context.StartTime = this.StartTime;
            context.Status_Message = this.Status_Message;
            context.Status_PrimaryStatus = this.Status_PrimaryStatus;
            context.TrialComponentName = this.TrialComponentName;
            #if MODULAR
            if (this.TrialComponentName == null && ParameterWasBound(nameof(this.TrialComponentName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrialComponentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.UpdateTrialComponentRequest();
            
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.InputArtifact != null)
            {
                request.InputArtifacts = cmdletContext.InputArtifact;
            }
            if (cmdletContext.InputArtifactsToRemove != null)
            {
                request.InputArtifactsToRemove = cmdletContext.InputArtifactsToRemove;
            }
            if (cmdletContext.OutputArtifact != null)
            {
                request.OutputArtifacts = cmdletContext.OutputArtifact;
            }
            if (cmdletContext.OutputArtifactsToRemove != null)
            {
                request.OutputArtifactsToRemove = cmdletContext.OutputArtifactsToRemove;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.ParametersToRemove != null)
            {
                request.ParametersToRemove = cmdletContext.ParametersToRemove;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            
             // populate Status
            var requestStatusIsNull = true;
            request.Status = new Amazon.SageMaker.Model.TrialComponentStatus();
            System.String requestStatus_status_Message = null;
            if (cmdletContext.Status_Message != null)
            {
                requestStatus_status_Message = cmdletContext.Status_Message;
            }
            if (requestStatus_status_Message != null)
            {
                request.Status.Message = requestStatus_status_Message;
                requestStatusIsNull = false;
            }
            Amazon.SageMaker.TrialComponentPrimaryStatus requestStatus_status_PrimaryStatus = null;
            if (cmdletContext.Status_PrimaryStatus != null)
            {
                requestStatus_status_PrimaryStatus = cmdletContext.Status_PrimaryStatus;
            }
            if (requestStatus_status_PrimaryStatus != null)
            {
                request.Status.PrimaryStatus = requestStatus_status_PrimaryStatus;
                requestStatusIsNull = false;
            }
             // determine if request.Status should be set to null
            if (requestStatusIsNull)
            {
                request.Status = null;
            }
            if (cmdletContext.TrialComponentName != null)
            {
                request.TrialComponentName = cmdletContext.TrialComponentName;
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
        
        private Amazon.SageMaker.Model.UpdateTrialComponentResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateTrialComponentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateTrialComponent");
            try
            {
                #if DESKTOP
                return client.UpdateTrialComponent(request);
                #elif CORECLR
                return client.UpdateTrialComponentAsync(request).GetAwaiter().GetResult();
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
            public System.String DisplayName { get; set; }
            public System.DateTime? EndTime { get; set; }
            public Dictionary<System.String, Amazon.SageMaker.Model.TrialComponentArtifact> InputArtifact { get; set; }
            public List<System.String> InputArtifactsToRemove { get; set; }
            public Dictionary<System.String, Amazon.SageMaker.Model.TrialComponentArtifact> OutputArtifact { get; set; }
            public List<System.String> OutputArtifactsToRemove { get; set; }
            public Dictionary<System.String, Amazon.SageMaker.Model.TrialComponentParameterValue> Parameter { get; set; }
            public List<System.String> ParametersToRemove { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.String Status_Message { get; set; }
            public Amazon.SageMaker.TrialComponentPrimaryStatus Status_PrimaryStatus { get; set; }
            public System.String TrialComponentName { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateTrialComponentResponse, UpdateSMTrialComponentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrialComponentArn;
        }
        
    }
}
