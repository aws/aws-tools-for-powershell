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
    /// Creates a trained model from an associated configured model algorithm using data from
    /// any member of the collaboration.
    /// </summary>
    [Cmdlet("New", "CRMLTrainedModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the CleanRoomsML CreateTrainedModel API operation.", Operation = new[] {"CreateTrainedModel"}, SelectReturnType = typeof(Amazon.CleanRoomsML.Model.CreateTrainedModelResponse))]
    [AWSCmdletOutput("System.String or Amazon.CleanRoomsML.Model.CreateTrainedModelResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CleanRoomsML.Model.CreateTrainedModelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCRMLTrainedModelCmdlet : AmazonCleanRoomsMLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfiguredModelAlgorithmAssociationArn
        /// <summary>
        /// <para>
        /// <para>The associated configured model algorithm used to train this model.</para>
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
        public System.String ConfiguredModelAlgorithmAssociationArn { get; set; }
        #endregion
        
        #region Parameter DataChannel
        /// <summary>
        /// <para>
        /// <para>Defines the data channels that are used as input for the trained model request.</para><para>Limit: Maximum of 20 channels total (including both <c>dataChannels</c> and <c>incrementalTrainingDataChannels</c>).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DataChannels")]
        public Amazon.CleanRoomsML.Model.ModelTrainingDataChannel[] DataChannel { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the trained model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Environment
        /// <summary>
        /// <para>
        /// <para>The environment variables to set in the Docker container.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Environment { get; set; }
        #endregion
        
        #region Parameter Hyperparameter
        /// <summary>
        /// <para>
        /// <para>Algorithm-specific parameters that influence the quality of the model. You set hyperparameters
        /// before you start the learning process.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Hyperparameters")]
        public System.Collections.Hashtable Hyperparameter { get; set; }
        #endregion
        
        #region Parameter IncrementalTrainingDataChannel
        /// <summary>
        /// <para>
        /// <para>Specifies the incremental training data channels for the trained model. </para><para>Incremental training allows you to create a new trained model with updates without
        /// retraining from scratch. You can specify up to one incremental training data channel
        /// that references a previously trained model and its version.</para><para>Limit: Maximum of 20 channels total (including both <c>incrementalTrainingDataChannels</c>
        /// and <c>dataChannels</c>).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncrementalTrainingDataChannels")]
        public Amazon.CleanRoomsML.Model.IncrementalTrainingDataChannel[] IncrementalTrainingDataChannel { get; set; }
        #endregion
        
        #region Parameter ResourceConfig_InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of resources that are used to train the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ResourceConfig_InstanceCount { get; set; }
        #endregion
        
        #region Parameter ResourceConfig_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type that is used to train the model.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRoomsML.InstanceType")]
        public Amazon.CleanRoomsML.InstanceType ResourceConfig_InstanceType { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key. This key is used to encrypt and decrypt
        /// customer-owned data in the trained ML model and the associated data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time, in seconds, that model training can run before it is terminated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoppingCondition_MaxRuntimeInSeconds")]
        public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>The membership ID of the member that is creating the trained model.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the trained model.</para>
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
        
        #region Parameter TrainingInputMode
        /// <summary>
        /// <para>
        /// <para>The input mode for accessing the training data. This parameter determines how the
        /// training data is made available to the training algorithm. Valid values are:</para><ul><li><para><c>File</c> - The training data is downloaded to the training instance and made available
        /// as files.</para></li><li><para><c>FastFile</c> - The training data is streamed directly from Amazon S3 to the training
        /// algorithm, providing faster access for large datasets.</para></li><li><para><c>Pipe</c> - The training data is streamed to the training algorithm using named
        /// pipes, which can improve performance for certain algorithms.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CleanRoomsML.TrainingInputMode")]
        public Amazon.CleanRoomsML.TrainingInputMode TrainingInputMode { get; set; }
        #endregion
        
        #region Parameter ResourceConfig_VolumeSizeInGB
        /// <summary>
        /// <para>
        /// <para>The volume size of the instance that is used to train the model. Please see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-store-volumes.html">EC2
        /// volume limit</a> for volume size limitations on different instance types.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? ResourceConfig_VolumeSizeInGB { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrainedModelArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRoomsML.Model.CreateTrainedModelResponse).
        /// Specifying the name of a property of type Amazon.CleanRoomsML.Model.CreateTrainedModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrainedModelArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRMLTrainedModel (CreateTrainedModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRoomsML.Model.CreateTrainedModelResponse, NewCRMLTrainedModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfiguredModelAlgorithmAssociationArn = this.ConfiguredModelAlgorithmAssociationArn;
            #if MODULAR
            if (this.ConfiguredModelAlgorithmAssociationArn == null && ParameterWasBound(nameof(this.ConfiguredModelAlgorithmAssociationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfiguredModelAlgorithmAssociationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DataChannel != null)
            {
                context.DataChannel = new List<Amazon.CleanRoomsML.Model.ModelTrainingDataChannel>(this.DataChannel);
            }
            #if MODULAR
            if (this.DataChannel == null && ParameterWasBound(nameof(this.DataChannel)))
            {
                WriteWarning("You are passing $null as a value for parameter DataChannel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            if (this.Environment != null)
            {
                context.Environment = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Environment.Keys)
                {
                    context.Environment.Add((String)hashKey, (System.String)(this.Environment[hashKey]));
                }
            }
            if (this.Hyperparameter != null)
            {
                context.Hyperparameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Hyperparameter.Keys)
                {
                    context.Hyperparameter.Add((String)hashKey, (System.String)(this.Hyperparameter[hashKey]));
                }
            }
            if (this.IncrementalTrainingDataChannel != null)
            {
                context.IncrementalTrainingDataChannel = new List<Amazon.CleanRoomsML.Model.IncrementalTrainingDataChannel>(this.IncrementalTrainingDataChannel);
            }
            context.KmsKeyArn = this.KmsKeyArn;
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceConfig_InstanceCount = this.ResourceConfig_InstanceCount;
            context.ResourceConfig_InstanceType = this.ResourceConfig_InstanceType;
            #if MODULAR
            if (this.ResourceConfig_InstanceType == null && ParameterWasBound(nameof(this.ResourceConfig_InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceConfig_InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceConfig_VolumeSizeInGB = this.ResourceConfig_VolumeSizeInGB;
            #if MODULAR
            if (this.ResourceConfig_VolumeSizeInGB == null && ParameterWasBound(nameof(this.ResourceConfig_VolumeSizeInGB)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceConfig_VolumeSizeInGB which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StoppingCondition_MaxRuntimeInSecond = this.StoppingCondition_MaxRuntimeInSecond;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TrainingInputMode = this.TrainingInputMode;
            
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
            var request = new Amazon.CleanRoomsML.Model.CreateTrainedModelRequest();
            
            if (cmdletContext.ConfiguredModelAlgorithmAssociationArn != null)
            {
                request.ConfiguredModelAlgorithmAssociationArn = cmdletContext.ConfiguredModelAlgorithmAssociationArn;
            }
            if (cmdletContext.DataChannel != null)
            {
                request.DataChannels = cmdletContext.DataChannel;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Environment != null)
            {
                request.Environment = cmdletContext.Environment;
            }
            if (cmdletContext.Hyperparameter != null)
            {
                request.Hyperparameters = cmdletContext.Hyperparameter;
            }
            if (cmdletContext.IncrementalTrainingDataChannel != null)
            {
                request.IncrementalTrainingDataChannels = cmdletContext.IncrementalTrainingDataChannel;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ResourceConfig
            var requestResourceConfigIsNull = true;
            request.ResourceConfig = new Amazon.CleanRoomsML.Model.ResourceConfig();
            System.Int32? requestResourceConfig_resourceConfig_InstanceCount = null;
            if (cmdletContext.ResourceConfig_InstanceCount != null)
            {
                requestResourceConfig_resourceConfig_InstanceCount = cmdletContext.ResourceConfig_InstanceCount.Value;
            }
            if (requestResourceConfig_resourceConfig_InstanceCount != null)
            {
                request.ResourceConfig.InstanceCount = requestResourceConfig_resourceConfig_InstanceCount.Value;
                requestResourceConfigIsNull = false;
            }
            Amazon.CleanRoomsML.InstanceType requestResourceConfig_resourceConfig_InstanceType = null;
            if (cmdletContext.ResourceConfig_InstanceType != null)
            {
                requestResourceConfig_resourceConfig_InstanceType = cmdletContext.ResourceConfig_InstanceType;
            }
            if (requestResourceConfig_resourceConfig_InstanceType != null)
            {
                request.ResourceConfig.InstanceType = requestResourceConfig_resourceConfig_InstanceType;
                requestResourceConfigIsNull = false;
            }
            System.Int32? requestResourceConfig_resourceConfig_VolumeSizeInGB = null;
            if (cmdletContext.ResourceConfig_VolumeSizeInGB != null)
            {
                requestResourceConfig_resourceConfig_VolumeSizeInGB = cmdletContext.ResourceConfig_VolumeSizeInGB.Value;
            }
            if (requestResourceConfig_resourceConfig_VolumeSizeInGB != null)
            {
                request.ResourceConfig.VolumeSizeInGB = requestResourceConfig_resourceConfig_VolumeSizeInGB.Value;
                requestResourceConfigIsNull = false;
            }
             // determine if request.ResourceConfig should be set to null
            if (requestResourceConfigIsNull)
            {
                request.ResourceConfig = null;
            }
            
             // populate StoppingCondition
            var requestStoppingConditionIsNull = true;
            request.StoppingCondition = new Amazon.CleanRoomsML.Model.StoppingCondition();
            System.Int32? requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond = null;
            if (cmdletContext.StoppingCondition_MaxRuntimeInSecond != null)
            {
                requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond = cmdletContext.StoppingCondition_MaxRuntimeInSecond.Value;
            }
            if (requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond != null)
            {
                request.StoppingCondition.MaxRuntimeInSeconds = requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond.Value;
                requestStoppingConditionIsNull = false;
            }
             // determine if request.StoppingCondition should be set to null
            if (requestStoppingConditionIsNull)
            {
                request.StoppingCondition = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TrainingInputMode != null)
            {
                request.TrainingInputMode = cmdletContext.TrainingInputMode;
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
        
        private Amazon.CleanRoomsML.Model.CreateTrainedModelResponse CallAWSServiceOperation(IAmazonCleanRoomsML client, Amazon.CleanRoomsML.Model.CreateTrainedModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CleanRoomsML", "CreateTrainedModel");
            try
            {
                return client.CreateTrainedModelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfiguredModelAlgorithmAssociationArn { get; set; }
            public List<Amazon.CleanRoomsML.Model.ModelTrainingDataChannel> DataChannel { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, System.String> Environment { get; set; }
            public Dictionary<System.String, System.String> Hyperparameter { get; set; }
            public List<Amazon.CleanRoomsML.Model.IncrementalTrainingDataChannel> IncrementalTrainingDataChannel { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.String Name { get; set; }
            public System.Int32? ResourceConfig_InstanceCount { get; set; }
            public Amazon.CleanRoomsML.InstanceType ResourceConfig_InstanceType { get; set; }
            public System.Int32? ResourceConfig_VolumeSizeInGB { get; set; }
            public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.CleanRoomsML.TrainingInputMode TrainingInputMode { get; set; }
            public System.Func<Amazon.CleanRoomsML.Model.CreateTrainedModelResponse, NewCRMLTrainedModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrainedModelArn;
        }
        
    }
}
