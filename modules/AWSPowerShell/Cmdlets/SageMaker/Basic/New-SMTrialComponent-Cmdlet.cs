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
    /// Creates a <i>trial component</i>, which is a stage of a machine learning <i>trial</i>.
    /// A trial is composed of one or more trial components. A trial component can be used
    /// in multiple trials.
    /// 
    ///  
    /// <para>
    /// Trial components include pre-processing jobs, training jobs, and batch transform jobs.
    /// </para><para>
    /// When you use Amazon SageMaker Studio or the Amazon SageMaker Python SDK, all experiments,
    /// trials, and trial components are automatically tracked, logged, and indexed. When
    /// you use the AWS SDK for Python (Boto), you must use the logging APIs provided by the
    /// SDK.
    /// </para><para>
    /// You can add tags to a trial component and then use the <a>Search</a> API to search
    /// for the tags.
    /// </para><note><para>
    /// You can create a trial component through a direct call to the <code>CreateTrialComponent</code>
    /// API. However, you can't specify the <code>Source</code> property of the component
    /// in the request, therefore, the component isn't associated with an Amazon SageMaker
    /// job. You must use Amazon SageMaker Studio, the Amazon SageMaker Python SDK, or the
    /// AWS SDK for Python (Boto) to create the component with a valid <code>Source</code>
    /// property.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SMTrialComponent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateTrialComponent API operation.", Operation = new[] {"CreateTrialComponent"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateTrialComponentResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateTrialComponentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateTrialComponentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMTrialComponentCmdlet : AmazonSageMakerClientCmdlet, IExecutor
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
        /// <para>The input artifacts for the component. Examples of input artifacts are datasets, algorithms,
        /// hyperparameters, source code, and instance types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputArtifacts")]
        public System.Collections.Hashtable InputArtifact { get; set; }
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
        /// <para>The output artifacts for the component. Examples of output artifacts are metrics,
        /// snapshots, logs, and images.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputArtifacts")]
        public System.Collections.Hashtable OutputArtifact { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The hyperparameters for the component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to associate with the component. You can use <a>Search</a> API to search
        /// on the tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrialComponentName
        /// <summary>
        /// <para>
        /// <para>The name of the component. The name must be unique in your AWS account and is not
        /// case-sensitive.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateTrialComponentResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateTrialComponentResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrialComponentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMTrialComponent (CreateTrialComponent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateTrialComponentResponse, NewSMTrialComponentCmdlet>(Select) ??
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
            if (this.OutputArtifact != null)
            {
                context.OutputArtifact = new Dictionary<System.String, Amazon.SageMaker.Model.TrialComponentArtifact>(StringComparer.Ordinal);
                foreach (var hashKey in this.OutputArtifact.Keys)
                {
                    context.OutputArtifact.Add((String)hashKey, (TrialComponentArtifact)(this.OutputArtifact[hashKey]));
                }
            }
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, Amazon.SageMaker.Model.TrialComponentParameterValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameter.Add((String)hashKey, (TrialComponentParameterValue)(this.Parameter[hashKey]));
                }
            }
            context.StartTime = this.StartTime;
            context.Status_Message = this.Status_Message;
            context.Status_PrimaryStatus = this.Status_PrimaryStatus;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.SageMaker.Model.CreateTrialComponentRequest();
            
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
            if (cmdletContext.OutputArtifact != null)
            {
                request.OutputArtifacts = cmdletContext.OutputArtifact;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SageMaker.Model.CreateTrialComponentResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateTrialComponentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateTrialComponent");
            try
            {
                #if DESKTOP
                return client.CreateTrialComponent(request);
                #elif CORECLR
                return client.CreateTrialComponentAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.SageMaker.Model.TrialComponentArtifact> OutputArtifact { get; set; }
            public Dictionary<System.String, Amazon.SageMaker.Model.TrialComponentParameterValue> Parameter { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.String Status_Message { get; set; }
            public Amazon.SageMaker.TrialComponentPrimaryStatus Status_PrimaryStatus { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.String TrialComponentName { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateTrialComponentResponse, NewSMTrialComponentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrialComponentArn;
        }
        
    }
}
