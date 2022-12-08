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
    /// Creates a pipeline using a JSON pipeline definition.
    /// </summary>
    [Cmdlet("New", "SMPipeline", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreatePipeline API operation.", Operation = new[] {"CreatePipeline"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreatePipelineResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreatePipelineResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreatePipelineResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMPipelineCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter PipelineDefinitionS3Location_Bucket
        /// <summary>
        /// <para>
        /// <para>Name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PipelineDefinitionS3Location_Bucket { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the operation. An idempotent operation completes no more than one time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ParallelismConfiguration_MaxParallelExecutionStep
        /// <summary>
        /// <para>
        /// <para>The max number of steps that can be executed in parallel. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ParallelismConfiguration_MaxParallelExecutionSteps")]
        public System.Int32? ParallelismConfiguration_MaxParallelExecutionStep { get; set; }
        #endregion
        
        #region Parameter PipelineDefinitionS3Location_ObjectKey
        /// <summary>
        /// <para>
        /// <para>The object key (or key name) uniquely identifies the object in an S3 bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PipelineDefinitionS3Location_ObjectKey { get; set; }
        #endregion
        
        #region Parameter PipelineDefinition
        /// <summary>
        /// <para>
        /// <para>The JSON pipeline definition of the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PipelineDefinition { get; set; }
        #endregion
        
        #region Parameter PipelineDescription
        /// <summary>
        /// <para>
        /// <para>A description of the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PipelineDescription { get; set; }
        #endregion
        
        #region Parameter PipelineDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PipelineDisplayName { get; set; }
        #endregion
        
        #region Parameter PipelineName
        /// <summary>
        /// <para>
        /// <para>The name of the pipeline.</para>
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
        public System.String PipelineName { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role used by the pipeline to access and create
        /// resources.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to apply to the created pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter PipelineDefinitionS3Location_VersionId
        /// <summary>
        /// <para>
        /// <para>Version Id of the pipeline definition file. If not specified, Amazon SageMaker will
        /// retrieve the latest version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PipelineDefinitionS3Location_VersionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PipelineArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreatePipelineResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreatePipelineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PipelineArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PipelineName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PipelineName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PipelineName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PipelineName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMPipeline (CreatePipeline)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreatePipelineResponse, NewSMPipelineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PipelineName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.ParallelismConfiguration_MaxParallelExecutionStep = this.ParallelismConfiguration_MaxParallelExecutionStep;
            context.PipelineDefinition = this.PipelineDefinition;
            context.PipelineDefinitionS3Location_Bucket = this.PipelineDefinitionS3Location_Bucket;
            context.PipelineDefinitionS3Location_ObjectKey = this.PipelineDefinitionS3Location_ObjectKey;
            context.PipelineDefinitionS3Location_VersionId = this.PipelineDefinitionS3Location_VersionId;
            context.PipelineDescription = this.PipelineDescription;
            context.PipelineDisplayName = this.PipelineDisplayName;
            context.PipelineName = this.PipelineName;
            #if MODULAR
            if (this.PipelineName == null && ParameterWasBound(nameof(this.PipelineName)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreatePipelineRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate ParallelismConfiguration
            var requestParallelismConfigurationIsNull = true;
            request.ParallelismConfiguration = new Amazon.SageMaker.Model.ParallelismConfiguration();
            System.Int32? requestParallelismConfiguration_parallelismConfiguration_MaxParallelExecutionStep = null;
            if (cmdletContext.ParallelismConfiguration_MaxParallelExecutionStep != null)
            {
                requestParallelismConfiguration_parallelismConfiguration_MaxParallelExecutionStep = cmdletContext.ParallelismConfiguration_MaxParallelExecutionStep.Value;
            }
            if (requestParallelismConfiguration_parallelismConfiguration_MaxParallelExecutionStep != null)
            {
                request.ParallelismConfiguration.MaxParallelExecutionSteps = requestParallelismConfiguration_parallelismConfiguration_MaxParallelExecutionStep.Value;
                requestParallelismConfigurationIsNull = false;
            }
             // determine if request.ParallelismConfiguration should be set to null
            if (requestParallelismConfigurationIsNull)
            {
                request.ParallelismConfiguration = null;
            }
            if (cmdletContext.PipelineDefinition != null)
            {
                request.PipelineDefinition = cmdletContext.PipelineDefinition;
            }
            
             // populate PipelineDefinitionS3Location
            var requestPipelineDefinitionS3LocationIsNull = true;
            request.PipelineDefinitionS3Location = new Amazon.SageMaker.Model.PipelineDefinitionS3Location();
            System.String requestPipelineDefinitionS3Location_pipelineDefinitionS3Location_Bucket = null;
            if (cmdletContext.PipelineDefinitionS3Location_Bucket != null)
            {
                requestPipelineDefinitionS3Location_pipelineDefinitionS3Location_Bucket = cmdletContext.PipelineDefinitionS3Location_Bucket;
            }
            if (requestPipelineDefinitionS3Location_pipelineDefinitionS3Location_Bucket != null)
            {
                request.PipelineDefinitionS3Location.Bucket = requestPipelineDefinitionS3Location_pipelineDefinitionS3Location_Bucket;
                requestPipelineDefinitionS3LocationIsNull = false;
            }
            System.String requestPipelineDefinitionS3Location_pipelineDefinitionS3Location_ObjectKey = null;
            if (cmdletContext.PipelineDefinitionS3Location_ObjectKey != null)
            {
                requestPipelineDefinitionS3Location_pipelineDefinitionS3Location_ObjectKey = cmdletContext.PipelineDefinitionS3Location_ObjectKey;
            }
            if (requestPipelineDefinitionS3Location_pipelineDefinitionS3Location_ObjectKey != null)
            {
                request.PipelineDefinitionS3Location.ObjectKey = requestPipelineDefinitionS3Location_pipelineDefinitionS3Location_ObjectKey;
                requestPipelineDefinitionS3LocationIsNull = false;
            }
            System.String requestPipelineDefinitionS3Location_pipelineDefinitionS3Location_VersionId = null;
            if (cmdletContext.PipelineDefinitionS3Location_VersionId != null)
            {
                requestPipelineDefinitionS3Location_pipelineDefinitionS3Location_VersionId = cmdletContext.PipelineDefinitionS3Location_VersionId;
            }
            if (requestPipelineDefinitionS3Location_pipelineDefinitionS3Location_VersionId != null)
            {
                request.PipelineDefinitionS3Location.VersionId = requestPipelineDefinitionS3Location_pipelineDefinitionS3Location_VersionId;
                requestPipelineDefinitionS3LocationIsNull = false;
            }
             // determine if request.PipelineDefinitionS3Location should be set to null
            if (requestPipelineDefinitionS3LocationIsNull)
            {
                request.PipelineDefinitionS3Location = null;
            }
            if (cmdletContext.PipelineDescription != null)
            {
                request.PipelineDescription = cmdletContext.PipelineDescription;
            }
            if (cmdletContext.PipelineDisplayName != null)
            {
                request.PipelineDisplayName = cmdletContext.PipelineDisplayName;
            }
            if (cmdletContext.PipelineName != null)
            {
                request.PipelineName = cmdletContext.PipelineName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.SageMaker.Model.CreatePipelineResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreatePipelineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreatePipeline");
            try
            {
                #if DESKTOP
                return client.CreatePipeline(request);
                #elif CORECLR
                return client.CreatePipelineAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.Int32? ParallelismConfiguration_MaxParallelExecutionStep { get; set; }
            public System.String PipelineDefinition { get; set; }
            public System.String PipelineDefinitionS3Location_Bucket { get; set; }
            public System.String PipelineDefinitionS3Location_ObjectKey { get; set; }
            public System.String PipelineDefinitionS3Location_VersionId { get; set; }
            public System.String PipelineDescription { get; set; }
            public System.String PipelineDisplayName { get; set; }
            public System.String PipelineName { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreatePipelineResponse, NewSMPipelineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PipelineArn;
        }
        
    }
}
