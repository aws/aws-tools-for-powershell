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
using Amazon.CleanRoomsML;
using Amazon.CleanRoomsML.Model;

namespace Amazon.PowerShell.Cmdlets.CRML
{
    /// <summary>
    /// Defines the information necessary to begin a trained model inference job.
    /// </summary>
    [Cmdlet("Start", "CRMLTrainedModelInferenceJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the CleanRoomsML StartTrainedModelInferenceJob API operation.", Operation = new[] {"StartTrainedModelInferenceJob"}, SelectReturnType = typeof(Amazon.CleanRoomsML.Model.StartTrainedModelInferenceJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.CleanRoomsML.Model.StartTrainedModelInferenceJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CleanRoomsML.Model.StartTrainedModelInferenceJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCRMLTrainedModelInferenceJobCmdlet : AmazonCleanRoomsMLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OutputConfiguration_Accept
        /// <summary>
        /// <para>
        /// <para>The MIME type used to specify the output data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfiguration_Accept { get; set; }
        #endregion
        
        #region Parameter ConfiguredModelAlgorithmAssociationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the configured model algorithm association that
        /// is used for this trained model inference job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfiguredModelAlgorithmAssociationArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the trained model inference job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Environment
        /// <summary>
        /// <para>
        /// <para>The environment variables to set in the Docker container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Environment { get; set; }
        #endregion
        
        #region Parameter ResourceConfig_InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of instances to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ResourceConfig_InstanceCount { get; set; }
        #endregion
        
        #region Parameter ResourceConfig_InstanceType
        /// <summary>
        /// <para>
        /// <para>The type of instance that is used to perform model inference.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRoomsML.InferenceInstanceType")]
        public Amazon.CleanRoomsML.InferenceInstanceType ResourceConfig_InstanceType { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key. This key is used to encrypt and decrypt
        /// customer-owned data in the ML inference job and associated data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter ContainerExecutionParameters_MaxPayloadInMB
        /// <summary>
        /// <para>
        /// <para>The maximum size of the inference container payload, specified in MB. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ContainerExecutionParameters_MaxPayloadInMB { get; set; }
        #endregion
        
        #region Parameter OutputConfiguration_Member
        /// <summary>
        /// <para>
        /// <para>Defines the members that can receive inference output.</para>
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
        [Alias("OutputConfiguration_Members")]
        public Amazon.CleanRoomsML.Model.InferenceReceiverMember[] OutputConfiguration_Member { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>The membership ID of the membership that contains the trained model inference job.</para>
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
        
        #region Parameter DataSource_MlInputChannelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the ML input channel for this model inference data
        /// source.</para>
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
        public System.String DataSource_MlInputChannelArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the trained model inference job.</para>
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
        /// per resource limit.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TrainedModelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the trained model that is used for this trained
        /// model inference job.</para>
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
        public System.String TrainedModelArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrainedModelInferenceJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRoomsML.Model.StartTrainedModelInferenceJobResponse).
        /// Specifying the name of a property of type Amazon.CleanRoomsML.Model.StartTrainedModelInferenceJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrainedModelInferenceJobArn";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CRMLTrainedModelInferenceJob (StartTrainedModelInferenceJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRoomsML.Model.StartTrainedModelInferenceJobResponse, StartCRMLTrainedModelInferenceJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfiguredModelAlgorithmAssociationArn = this.ConfiguredModelAlgorithmAssociationArn;
            context.ContainerExecutionParameters_MaxPayloadInMB = this.ContainerExecutionParameters_MaxPayloadInMB;
            context.DataSource_MlInputChannelArn = this.DataSource_MlInputChannelArn;
            #if MODULAR
            if (this.DataSource_MlInputChannelArn == null && ParameterWasBound(nameof(this.DataSource_MlInputChannelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSource_MlInputChannelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.OutputConfiguration_Accept = this.OutputConfiguration_Accept;
            if (this.OutputConfiguration_Member != null)
            {
                context.OutputConfiguration_Member = new List<Amazon.CleanRoomsML.Model.InferenceReceiverMember>(this.OutputConfiguration_Member);
            }
            #if MODULAR
            if (this.OutputConfiguration_Member == null && ParameterWasBound(nameof(this.OutputConfiguration_Member)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfiguration_Member which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TrainedModelArn = this.TrainedModelArn;
            #if MODULAR
            if (this.TrainedModelArn == null && ParameterWasBound(nameof(this.TrainedModelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainedModelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CleanRoomsML.Model.StartTrainedModelInferenceJobRequest();
            
            if (cmdletContext.ConfiguredModelAlgorithmAssociationArn != null)
            {
                request.ConfiguredModelAlgorithmAssociationArn = cmdletContext.ConfiguredModelAlgorithmAssociationArn;
            }
            
             // populate ContainerExecutionParameters
            var requestContainerExecutionParametersIsNull = true;
            request.ContainerExecutionParameters = new Amazon.CleanRoomsML.Model.InferenceContainerExecutionParameters();
            System.Int32? requestContainerExecutionParameters_containerExecutionParameters_MaxPayloadInMB = null;
            if (cmdletContext.ContainerExecutionParameters_MaxPayloadInMB != null)
            {
                requestContainerExecutionParameters_containerExecutionParameters_MaxPayloadInMB = cmdletContext.ContainerExecutionParameters_MaxPayloadInMB.Value;
            }
            if (requestContainerExecutionParameters_containerExecutionParameters_MaxPayloadInMB != null)
            {
                request.ContainerExecutionParameters.MaxPayloadInMB = requestContainerExecutionParameters_containerExecutionParameters_MaxPayloadInMB.Value;
                requestContainerExecutionParametersIsNull = false;
            }
             // determine if request.ContainerExecutionParameters should be set to null
            if (requestContainerExecutionParametersIsNull)
            {
                request.ContainerExecutionParameters = null;
            }
            
             // populate DataSource
            var requestDataSourceIsNull = true;
            request.DataSource = new Amazon.CleanRoomsML.Model.ModelInferenceDataSource();
            System.String requestDataSource_dataSource_MlInputChannelArn = null;
            if (cmdletContext.DataSource_MlInputChannelArn != null)
            {
                requestDataSource_dataSource_MlInputChannelArn = cmdletContext.DataSource_MlInputChannelArn;
            }
            if (requestDataSource_dataSource_MlInputChannelArn != null)
            {
                request.DataSource.MlInputChannelArn = requestDataSource_dataSource_MlInputChannelArn;
                requestDataSourceIsNull = false;
            }
             // determine if request.DataSource should be set to null
            if (requestDataSourceIsNull)
            {
                request.DataSource = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Environment != null)
            {
                request.Environment = cmdletContext.Environment;
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
            
             // populate OutputConfiguration
            var requestOutputConfigurationIsNull = true;
            request.OutputConfiguration = new Amazon.CleanRoomsML.Model.InferenceOutputConfiguration();
            System.String requestOutputConfiguration_outputConfiguration_Accept = null;
            if (cmdletContext.OutputConfiguration_Accept != null)
            {
                requestOutputConfiguration_outputConfiguration_Accept = cmdletContext.OutputConfiguration_Accept;
            }
            if (requestOutputConfiguration_outputConfiguration_Accept != null)
            {
                request.OutputConfiguration.Accept = requestOutputConfiguration_outputConfiguration_Accept;
                requestOutputConfigurationIsNull = false;
            }
            List<Amazon.CleanRoomsML.Model.InferenceReceiverMember> requestOutputConfiguration_outputConfiguration_Member = null;
            if (cmdletContext.OutputConfiguration_Member != null)
            {
                requestOutputConfiguration_outputConfiguration_Member = cmdletContext.OutputConfiguration_Member;
            }
            if (requestOutputConfiguration_outputConfiguration_Member != null)
            {
                request.OutputConfiguration.Members = requestOutputConfiguration_outputConfiguration_Member;
                requestOutputConfigurationIsNull = false;
            }
             // determine if request.OutputConfiguration should be set to null
            if (requestOutputConfigurationIsNull)
            {
                request.OutputConfiguration = null;
            }
            
             // populate ResourceConfig
            var requestResourceConfigIsNull = true;
            request.ResourceConfig = new Amazon.CleanRoomsML.Model.InferenceResourceConfig();
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
            Amazon.CleanRoomsML.InferenceInstanceType requestResourceConfig_resourceConfig_InstanceType = null;
            if (cmdletContext.ResourceConfig_InstanceType != null)
            {
                requestResourceConfig_resourceConfig_InstanceType = cmdletContext.ResourceConfig_InstanceType;
            }
            if (requestResourceConfig_resourceConfig_InstanceType != null)
            {
                request.ResourceConfig.InstanceType = requestResourceConfig_resourceConfig_InstanceType;
                requestResourceConfigIsNull = false;
            }
             // determine if request.ResourceConfig should be set to null
            if (requestResourceConfigIsNull)
            {
                request.ResourceConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TrainedModelArn != null)
            {
                request.TrainedModelArn = cmdletContext.TrainedModelArn;
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
        
        private Amazon.CleanRoomsML.Model.StartTrainedModelInferenceJobResponse CallAWSServiceOperation(IAmazonCleanRoomsML client, Amazon.CleanRoomsML.Model.StartTrainedModelInferenceJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CleanRoomsML", "StartTrainedModelInferenceJob");
            try
            {
                #if DESKTOP
                return client.StartTrainedModelInferenceJob(request);
                #elif CORECLR
                return client.StartTrainedModelInferenceJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfiguredModelAlgorithmAssociationArn { get; set; }
            public System.Int32? ContainerExecutionParameters_MaxPayloadInMB { get; set; }
            public System.String DataSource_MlInputChannelArn { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, System.String> Environment { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.String Name { get; set; }
            public System.String OutputConfiguration_Accept { get; set; }
            public List<Amazon.CleanRoomsML.Model.InferenceReceiverMember> OutputConfiguration_Member { get; set; }
            public System.Int32? ResourceConfig_InstanceCount { get; set; }
            public Amazon.CleanRoomsML.InferenceInstanceType ResourceConfig_InstanceType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TrainedModelArn { get; set; }
            public System.Func<Amazon.CleanRoomsML.Model.StartTrainedModelInferenceJobResponse, StartCRMLTrainedModelInferenceJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrainedModelInferenceJobArn;
        }
        
    }
}
