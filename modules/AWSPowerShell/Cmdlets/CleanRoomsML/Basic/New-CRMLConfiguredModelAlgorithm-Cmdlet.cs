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
using Amazon.CleanRoomsML;
using Amazon.CleanRoomsML.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CRML
{
    /// <summary>
    /// Creates a configured model algorithm using a container image stored in an ECR repository.
    /// </summary>
    [Cmdlet("New", "CRMLConfiguredModelAlgorithm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the CleanRoomsML CreateConfiguredModelAlgorithm API operation.", Operation = new[] {"CreateConfiguredModelAlgorithm"}, SelectReturnType = typeof(Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmResponse))]
    [AWSCmdletOutput("System.String or Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCRMLConfiguredModelAlgorithmCmdlet : AmazonCleanRoomsMLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TrainingContainerConfig_Argument
        /// <summary>
        /// <para>
        /// <para>The arguments for a container used to run a training job. See How Amazon SageMaker
        /// Runs Your Training Image for additional information. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/your-algorithms-training-algo-dockerfile.html">How
        /// Sagemaker runs your training image</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingContainerConfig_Arguments")]
        public System.String[] TrainingContainerConfig_Argument { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the configured model algorithm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter TrainingContainerConfig_Entrypoint
        /// <summary>
        /// <para>
        /// <para>The entrypoint script for a Docker container used to run a training job. This script
        /// takes precedence over the default train processing instructions. See How Amazon SageMaker
        /// Runs Your Training Image for additional information. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/your-algorithms-training-algo-dockerfile.html">How
        /// Sagemaker runs your training image</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] TrainingContainerConfig_Entrypoint { get; set; }
        #endregion
        
        #region Parameter InferenceContainerConfig_ImageUri
        /// <summary>
        /// <para>
        /// <para>The registry path of the docker image that contains the inference algorithm. Clean
        /// Rooms ML currently only supports the <c>registry/repository[:tag]</c> image path format.
        /// For more information about using images in Clean Rooms ML, see the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_AlgorithmSpecification.html#sagemaker-Type-AlgorithmSpecification-TrainingImage">Sagemaker
        /// API reference</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InferenceContainerConfig_ImageUri { get; set; }
        #endregion
        
        #region Parameter TrainingContainerConfig_ImageUri
        /// <summary>
        /// <para>
        /// <para>The registry path of the docker image that contains the algorithm. Clean Rooms ML
        /// currently only supports the <c>registry/repository[:tag]</c> image path format. For
        /// more information about using images in Clean Rooms ML, see the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_AlgorithmSpecification.html#sagemaker-Type-AlgorithmSpecification-TrainingImage">Sagemaker
        /// API reference</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TrainingContainerConfig_ImageUri { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key. This key is used to encrypt and decrypt
        /// customer-owned data in the configured ML model algorithm and associated data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter TrainingContainerConfig_MetricDefinition
        /// <summary>
        /// <para>
        /// <para>A list of metric definition objects. Each object specifies the metric name and regular
        /// expressions used to parse algorithm logs. Amazon Web Services Clean Rooms ML publishes
        /// each metric to all members' Amazon CloudWatch using IAM role configured in <a>PutMLConfiguration</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingContainerConfig_MetricDefinitions")]
        public Amazon.CleanRoomsML.Model.MetricDefinition[] TrainingContainerConfig_MetricDefinition { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the configured model algorithm.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role that is used to access the repository.</para>
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
        /// <para>The optional metadata that you apply to the resource to help you categorize and organize
        /// them. Each tag consists of a key and an optional value, both of which you define.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50.</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
        /// value.</para></li><li><para>Maximum key length - 128 Unicode characters in UTF-8.</para></li><li><para>Maximum value length - 256 Unicode characters in UTF-8.</para></li><li><para>If your tagging schema is used across multiple services and resources, remember that
        /// other services may have restrictions on allowed characters. Generally allowed characters
        /// are: letters, numbers, and spaces representable in UTF-8, and the following characters:
        /// + - = . _ : / @.</para></li><li><para>Tag keys and values are case sensitive.</para></li><li><para>Do not use aws:, AWS:, or any upper or lowercase combination of such as a prefix for
        /// keys as it is reserved for AWS use. You cannot edit or delete tag keys with this prefix.
        /// Values can have this prefix. If a tag value has aws as its prefix but the key does
        /// not, then Clean Rooms ML considers it to be a user tag and will count against the
        /// limit of 50 tags. Tags with only the key prefix of aws do not count against your tags
        /// per resource limit.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConfiguredModelAlgorithmArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmResponse).
        /// Specifying the name of a property of type Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfiguredModelAlgorithmArn";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRMLConfiguredModelAlgorithm (CreateConfiguredModelAlgorithm)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmResponse, NewCRMLConfiguredModelAlgorithmCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.InferenceContainerConfig_ImageUri = this.InferenceContainerConfig_ImageUri;
            context.KmsKeyArn = this.KmsKeyArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.TrainingContainerConfig_Argument != null)
            {
                context.TrainingContainerConfig_Argument = new List<System.String>(this.TrainingContainerConfig_Argument);
            }
            if (this.TrainingContainerConfig_Entrypoint != null)
            {
                context.TrainingContainerConfig_Entrypoint = new List<System.String>(this.TrainingContainerConfig_Entrypoint);
            }
            context.TrainingContainerConfig_ImageUri = this.TrainingContainerConfig_ImageUri;
            if (this.TrainingContainerConfig_MetricDefinition != null)
            {
                context.TrainingContainerConfig_MetricDefinition = new List<Amazon.CleanRoomsML.Model.MetricDefinition>(this.TrainingContainerConfig_MetricDefinition);
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
            var request = new Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate InferenceContainerConfig
            var requestInferenceContainerConfigIsNull = true;
            request.InferenceContainerConfig = new Amazon.CleanRoomsML.Model.InferenceContainerConfig();
            System.String requestInferenceContainerConfig_inferenceContainerConfig_ImageUri = null;
            if (cmdletContext.InferenceContainerConfig_ImageUri != null)
            {
                requestInferenceContainerConfig_inferenceContainerConfig_ImageUri = cmdletContext.InferenceContainerConfig_ImageUri;
            }
            if (requestInferenceContainerConfig_inferenceContainerConfig_ImageUri != null)
            {
                request.InferenceContainerConfig.ImageUri = requestInferenceContainerConfig_inferenceContainerConfig_ImageUri;
                requestInferenceContainerConfigIsNull = false;
            }
             // determine if request.InferenceContainerConfig should be set to null
            if (requestInferenceContainerConfigIsNull)
            {
                request.InferenceContainerConfig = null;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TrainingContainerConfig
            var requestTrainingContainerConfigIsNull = true;
            request.TrainingContainerConfig = new Amazon.CleanRoomsML.Model.ContainerConfig();
            List<System.String> requestTrainingContainerConfig_trainingContainerConfig_Argument = null;
            if (cmdletContext.TrainingContainerConfig_Argument != null)
            {
                requestTrainingContainerConfig_trainingContainerConfig_Argument = cmdletContext.TrainingContainerConfig_Argument;
            }
            if (requestTrainingContainerConfig_trainingContainerConfig_Argument != null)
            {
                request.TrainingContainerConfig.Arguments = requestTrainingContainerConfig_trainingContainerConfig_Argument;
                requestTrainingContainerConfigIsNull = false;
            }
            List<System.String> requestTrainingContainerConfig_trainingContainerConfig_Entrypoint = null;
            if (cmdletContext.TrainingContainerConfig_Entrypoint != null)
            {
                requestTrainingContainerConfig_trainingContainerConfig_Entrypoint = cmdletContext.TrainingContainerConfig_Entrypoint;
            }
            if (requestTrainingContainerConfig_trainingContainerConfig_Entrypoint != null)
            {
                request.TrainingContainerConfig.Entrypoint = requestTrainingContainerConfig_trainingContainerConfig_Entrypoint;
                requestTrainingContainerConfigIsNull = false;
            }
            System.String requestTrainingContainerConfig_trainingContainerConfig_ImageUri = null;
            if (cmdletContext.TrainingContainerConfig_ImageUri != null)
            {
                requestTrainingContainerConfig_trainingContainerConfig_ImageUri = cmdletContext.TrainingContainerConfig_ImageUri;
            }
            if (requestTrainingContainerConfig_trainingContainerConfig_ImageUri != null)
            {
                request.TrainingContainerConfig.ImageUri = requestTrainingContainerConfig_trainingContainerConfig_ImageUri;
                requestTrainingContainerConfigIsNull = false;
            }
            List<Amazon.CleanRoomsML.Model.MetricDefinition> requestTrainingContainerConfig_trainingContainerConfig_MetricDefinition = null;
            if (cmdletContext.TrainingContainerConfig_MetricDefinition != null)
            {
                requestTrainingContainerConfig_trainingContainerConfig_MetricDefinition = cmdletContext.TrainingContainerConfig_MetricDefinition;
            }
            if (requestTrainingContainerConfig_trainingContainerConfig_MetricDefinition != null)
            {
                request.TrainingContainerConfig.MetricDefinitions = requestTrainingContainerConfig_trainingContainerConfig_MetricDefinition;
                requestTrainingContainerConfigIsNull = false;
            }
             // determine if request.TrainingContainerConfig should be set to null
            if (requestTrainingContainerConfigIsNull)
            {
                request.TrainingContainerConfig = null;
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
        
        private Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmResponse CallAWSServiceOperation(IAmazonCleanRoomsML client, Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CleanRoomsML", "CreateConfiguredModelAlgorithm");
            try
            {
                return client.CreateConfiguredModelAlgorithmAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String InferenceContainerConfig_ImageUri { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<System.String> TrainingContainerConfig_Argument { get; set; }
            public List<System.String> TrainingContainerConfig_Entrypoint { get; set; }
            public System.String TrainingContainerConfig_ImageUri { get; set; }
            public List<Amazon.CleanRoomsML.Model.MetricDefinition> TrainingContainerConfig_MetricDefinition { get; set; }
            public System.Func<Amazon.CleanRoomsML.Model.CreateConfiguredModelAlgorithmResponse, NewCRMLConfiguredModelAlgorithmCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfiguredModelAlgorithmArn;
        }
        
    }
}
