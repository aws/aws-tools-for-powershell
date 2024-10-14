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
using Amazon.SupplyChain;
using Amazon.SupplyChain.Model;

namespace Amazon.PowerShell.Cmdlets.SUPCH
{
    /// <summary>
    /// Update the DataIntegrationFlow.
    /// </summary>
    [Cmdlet("Update", "SUPCHDataIntegrationFlow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SupplyChain.Model.DataIntegrationFlow")]
    [AWSCmdlet("Calls the AWS Supply Chain UpdateDataIntegrationFlow API operation.", Operation = new[] {"UpdateDataIntegrationFlow"}, SelectReturnType = typeof(Amazon.SupplyChain.Model.UpdateDataIntegrationFlowResponse))]
    [AWSCmdletOutput("Amazon.SupplyChain.Model.DataIntegrationFlow or Amazon.SupplyChain.Model.UpdateDataIntegrationFlowResponse",
        "This cmdlet returns an Amazon.SupplyChain.Model.DataIntegrationFlow object.",
        "The service call response (type Amazon.SupplyChain.Model.UpdateDataIntegrationFlowResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSUPCHDataIntegrationFlowCmdlet : AmazonSupplyChainClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3Target_BucketName
        /// <summary>
        /// <para>
        /// <para>The bucketName of the S3 target objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_S3Target_BucketName")]
        public System.String S3Target_BucketName { get; set; }
        #endregion
        
        #region Parameter DatasetTarget_DatasetIdentifier
        /// <summary>
        /// <para>
        /// <para>The dataset ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_DatasetTarget_DatasetIdentifier")]
        public System.String DatasetTarget_DatasetIdentifier { get; set; }
        #endregion
        
        #region Parameter Options_DedupeRecord
        /// <summary>
        /// <para>
        /// <para>The dataset load option to remove duplicates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_DatasetTarget_Options_DedupeRecords")]
        public System.Boolean? Options_DedupeRecord { get; set; }
        #endregion
        
        #region Parameter Options_FileType
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 file type in S3 options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_S3Target_Options_FileType")]
        [AWSConstantClassSource("Amazon.SupplyChain.DataIntegrationFlowFileType")]
        public Amazon.SupplyChain.DataIntegrationFlowFileType Options_FileType { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Supply Chain instance identifier.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Options_LoadType
        /// <summary>
        /// <para>
        /// <para>The dataset data load type in dataset options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_DatasetTarget_Options_LoadType")]
        [AWSConstantClassSource("Amazon.SupplyChain.DataIntegrationFlowLoadType")]
        public Amazon.SupplyChain.DataIntegrationFlowLoadType Options_LoadType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the DataIntegrationFlow to be updated.</para>
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
        
        #region Parameter S3Target_Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix of the S3 target objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_S3Target_Prefix")]
        public System.String S3Target_Prefix { get; set; }
        #endregion
        
        #region Parameter SqlTransformation_Query
        /// <summary>
        /// <para>
        /// <para>The transformation SQL query body based on SparkSQL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Transformation_SqlTransformation_Query")]
        public System.String SqlTransformation_Query { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The new source configurations for the DataIntegrationFlow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Sources")]
        public Amazon.SupplyChain.Model.DataIntegrationFlowSource[] Source { get; set; }
        #endregion
        
        #region Parameter Target_TargetType
        /// <summary>
        /// <para>
        /// <para>The DataIntegrationFlow target type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SupplyChain.DataIntegrationFlowTargetType")]
        public Amazon.SupplyChain.DataIntegrationFlowTargetType Target_TargetType { get; set; }
        #endregion
        
        #region Parameter Transformation_TransformationType
        /// <summary>
        /// <para>
        /// <para>The DataIntegrationFlow transformation type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SupplyChain.DataIntegrationFlowTransformationType")]
        public Amazon.SupplyChain.DataIntegrationFlowTransformationType Transformation_TransformationType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Flow'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SupplyChain.Model.UpdateDataIntegrationFlowResponse).
        /// Specifying the name of a property of type Amazon.SupplyChain.Model.UpdateDataIntegrationFlowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Flow";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SUPCHDataIntegrationFlow (UpdateDataIntegrationFlow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SupplyChain.Model.UpdateDataIntegrationFlowResponse, UpdateSUPCHDataIntegrationFlowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Source != null)
            {
                context.Source = new List<Amazon.SupplyChain.Model.DataIntegrationFlowSource>(this.Source);
            }
            context.DatasetTarget_DatasetIdentifier = this.DatasetTarget_DatasetIdentifier;
            context.Options_DedupeRecord = this.Options_DedupeRecord;
            context.Options_LoadType = this.Options_LoadType;
            context.S3Target_BucketName = this.S3Target_BucketName;
            context.Options_FileType = this.Options_FileType;
            context.S3Target_Prefix = this.S3Target_Prefix;
            context.Target_TargetType = this.Target_TargetType;
            context.SqlTransformation_Query = this.SqlTransformation_Query;
            context.Transformation_TransformationType = this.Transformation_TransformationType;
            
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
            var request = new Amazon.SupplyChain.Model.UpdateDataIntegrationFlowRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Source != null)
            {
                request.Sources = cmdletContext.Source;
            }
            
             // populate Target
            var requestTargetIsNull = true;
            request.Target = new Amazon.SupplyChain.Model.DataIntegrationFlowTarget();
            Amazon.SupplyChain.DataIntegrationFlowTargetType requestTarget_target_TargetType = null;
            if (cmdletContext.Target_TargetType != null)
            {
                requestTarget_target_TargetType = cmdletContext.Target_TargetType;
            }
            if (requestTarget_target_TargetType != null)
            {
                request.Target.TargetType = requestTarget_target_TargetType;
                requestTargetIsNull = false;
            }
            Amazon.SupplyChain.Model.DataIntegrationFlowDatasetTargetConfiguration requestTarget_target_DatasetTarget = null;
            
             // populate DatasetTarget
            var requestTarget_target_DatasetTargetIsNull = true;
            requestTarget_target_DatasetTarget = new Amazon.SupplyChain.Model.DataIntegrationFlowDatasetTargetConfiguration();
            System.String requestTarget_target_DatasetTarget_datasetTarget_DatasetIdentifier = null;
            if (cmdletContext.DatasetTarget_DatasetIdentifier != null)
            {
                requestTarget_target_DatasetTarget_datasetTarget_DatasetIdentifier = cmdletContext.DatasetTarget_DatasetIdentifier;
            }
            if (requestTarget_target_DatasetTarget_datasetTarget_DatasetIdentifier != null)
            {
                requestTarget_target_DatasetTarget.DatasetIdentifier = requestTarget_target_DatasetTarget_datasetTarget_DatasetIdentifier;
                requestTarget_target_DatasetTargetIsNull = false;
            }
            Amazon.SupplyChain.Model.DataIntegrationFlowDatasetOptions requestTarget_target_DatasetTarget_target_DatasetTarget_Options = null;
            
             // populate Options
            var requestTarget_target_DatasetTarget_target_DatasetTarget_OptionsIsNull = true;
            requestTarget_target_DatasetTarget_target_DatasetTarget_Options = new Amazon.SupplyChain.Model.DataIntegrationFlowDatasetOptions();
            System.Boolean? requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_DedupeRecord = null;
            if (cmdletContext.Options_DedupeRecord != null)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_DedupeRecord = cmdletContext.Options_DedupeRecord.Value;
            }
            if (requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_DedupeRecord != null)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options.DedupeRecords = requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_DedupeRecord.Value;
                requestTarget_target_DatasetTarget_target_DatasetTarget_OptionsIsNull = false;
            }
            Amazon.SupplyChain.DataIntegrationFlowLoadType requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_LoadType = null;
            if (cmdletContext.Options_LoadType != null)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_LoadType = cmdletContext.Options_LoadType;
            }
            if (requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_LoadType != null)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options.LoadType = requestTarget_target_DatasetTarget_target_DatasetTarget_Options_options_LoadType;
                requestTarget_target_DatasetTarget_target_DatasetTarget_OptionsIsNull = false;
            }
             // determine if requestTarget_target_DatasetTarget_target_DatasetTarget_Options should be set to null
            if (requestTarget_target_DatasetTarget_target_DatasetTarget_OptionsIsNull)
            {
                requestTarget_target_DatasetTarget_target_DatasetTarget_Options = null;
            }
            if (requestTarget_target_DatasetTarget_target_DatasetTarget_Options != null)
            {
                requestTarget_target_DatasetTarget.Options = requestTarget_target_DatasetTarget_target_DatasetTarget_Options;
                requestTarget_target_DatasetTargetIsNull = false;
            }
             // determine if requestTarget_target_DatasetTarget should be set to null
            if (requestTarget_target_DatasetTargetIsNull)
            {
                requestTarget_target_DatasetTarget = null;
            }
            if (requestTarget_target_DatasetTarget != null)
            {
                request.Target.DatasetTarget = requestTarget_target_DatasetTarget;
                requestTargetIsNull = false;
            }
            Amazon.SupplyChain.Model.DataIntegrationFlowS3TargetConfiguration requestTarget_target_S3Target = null;
            
             // populate S3Target
            var requestTarget_target_S3TargetIsNull = true;
            requestTarget_target_S3Target = new Amazon.SupplyChain.Model.DataIntegrationFlowS3TargetConfiguration();
            System.String requestTarget_target_S3Target_s3Target_BucketName = null;
            if (cmdletContext.S3Target_BucketName != null)
            {
                requestTarget_target_S3Target_s3Target_BucketName = cmdletContext.S3Target_BucketName;
            }
            if (requestTarget_target_S3Target_s3Target_BucketName != null)
            {
                requestTarget_target_S3Target.BucketName = requestTarget_target_S3Target_s3Target_BucketName;
                requestTarget_target_S3TargetIsNull = false;
            }
            System.String requestTarget_target_S3Target_s3Target_Prefix = null;
            if (cmdletContext.S3Target_Prefix != null)
            {
                requestTarget_target_S3Target_s3Target_Prefix = cmdletContext.S3Target_Prefix;
            }
            if (requestTarget_target_S3Target_s3Target_Prefix != null)
            {
                requestTarget_target_S3Target.Prefix = requestTarget_target_S3Target_s3Target_Prefix;
                requestTarget_target_S3TargetIsNull = false;
            }
            Amazon.SupplyChain.Model.DataIntegrationFlowS3Options requestTarget_target_S3Target_target_S3Target_Options = null;
            
             // populate Options
            var requestTarget_target_S3Target_target_S3Target_OptionsIsNull = true;
            requestTarget_target_S3Target_target_S3Target_Options = new Amazon.SupplyChain.Model.DataIntegrationFlowS3Options();
            Amazon.SupplyChain.DataIntegrationFlowFileType requestTarget_target_S3Target_target_S3Target_Options_options_FileType = null;
            if (cmdletContext.Options_FileType != null)
            {
                requestTarget_target_S3Target_target_S3Target_Options_options_FileType = cmdletContext.Options_FileType;
            }
            if (requestTarget_target_S3Target_target_S3Target_Options_options_FileType != null)
            {
                requestTarget_target_S3Target_target_S3Target_Options.FileType = requestTarget_target_S3Target_target_S3Target_Options_options_FileType;
                requestTarget_target_S3Target_target_S3Target_OptionsIsNull = false;
            }
             // determine if requestTarget_target_S3Target_target_S3Target_Options should be set to null
            if (requestTarget_target_S3Target_target_S3Target_OptionsIsNull)
            {
                requestTarget_target_S3Target_target_S3Target_Options = null;
            }
            if (requestTarget_target_S3Target_target_S3Target_Options != null)
            {
                requestTarget_target_S3Target.Options = requestTarget_target_S3Target_target_S3Target_Options;
                requestTarget_target_S3TargetIsNull = false;
            }
             // determine if requestTarget_target_S3Target should be set to null
            if (requestTarget_target_S3TargetIsNull)
            {
                requestTarget_target_S3Target = null;
            }
            if (requestTarget_target_S3Target != null)
            {
                request.Target.S3Target = requestTarget_target_S3Target;
                requestTargetIsNull = false;
            }
             // determine if request.Target should be set to null
            if (requestTargetIsNull)
            {
                request.Target = null;
            }
            
             // populate Transformation
            var requestTransformationIsNull = true;
            request.Transformation = new Amazon.SupplyChain.Model.DataIntegrationFlowTransformation();
            Amazon.SupplyChain.DataIntegrationFlowTransformationType requestTransformation_transformation_TransformationType = null;
            if (cmdletContext.Transformation_TransformationType != null)
            {
                requestTransformation_transformation_TransformationType = cmdletContext.Transformation_TransformationType;
            }
            if (requestTransformation_transformation_TransformationType != null)
            {
                request.Transformation.TransformationType = requestTransformation_transformation_TransformationType;
                requestTransformationIsNull = false;
            }
            Amazon.SupplyChain.Model.DataIntegrationFlowSQLTransformationConfiguration requestTransformation_transformation_SqlTransformation = null;
            
             // populate SqlTransformation
            var requestTransformation_transformation_SqlTransformationIsNull = true;
            requestTransformation_transformation_SqlTransformation = new Amazon.SupplyChain.Model.DataIntegrationFlowSQLTransformationConfiguration();
            System.String requestTransformation_transformation_SqlTransformation_sqlTransformation_Query = null;
            if (cmdletContext.SqlTransformation_Query != null)
            {
                requestTransformation_transformation_SqlTransformation_sqlTransformation_Query = cmdletContext.SqlTransformation_Query;
            }
            if (requestTransformation_transformation_SqlTransformation_sqlTransformation_Query != null)
            {
                requestTransformation_transformation_SqlTransformation.Query = requestTransformation_transformation_SqlTransformation_sqlTransformation_Query;
                requestTransformation_transformation_SqlTransformationIsNull = false;
            }
             // determine if requestTransformation_transformation_SqlTransformation should be set to null
            if (requestTransformation_transformation_SqlTransformationIsNull)
            {
                requestTransformation_transformation_SqlTransformation = null;
            }
            if (requestTransformation_transformation_SqlTransformation != null)
            {
                request.Transformation.SqlTransformation = requestTransformation_transformation_SqlTransformation;
                requestTransformationIsNull = false;
            }
             // determine if request.Transformation should be set to null
            if (requestTransformationIsNull)
            {
                request.Transformation = null;
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
        
        private Amazon.SupplyChain.Model.UpdateDataIntegrationFlowResponse CallAWSServiceOperation(IAmazonSupplyChain client, Amazon.SupplyChain.Model.UpdateDataIntegrationFlowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Supply Chain", "UpdateDataIntegrationFlow");
            try
            {
                #if DESKTOP
                return client.UpdateDataIntegrationFlow(request);
                #elif CORECLR
                return client.UpdateDataIntegrationFlowAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.SupplyChain.Model.DataIntegrationFlowSource> Source { get; set; }
            public System.String DatasetTarget_DatasetIdentifier { get; set; }
            public System.Boolean? Options_DedupeRecord { get; set; }
            public Amazon.SupplyChain.DataIntegrationFlowLoadType Options_LoadType { get; set; }
            public System.String S3Target_BucketName { get; set; }
            public Amazon.SupplyChain.DataIntegrationFlowFileType Options_FileType { get; set; }
            public System.String S3Target_Prefix { get; set; }
            public Amazon.SupplyChain.DataIntegrationFlowTargetType Target_TargetType { get; set; }
            public System.String SqlTransformation_Query { get; set; }
            public Amazon.SupplyChain.DataIntegrationFlowTransformationType Transformation_TransformationType { get; set; }
            public System.Func<Amazon.SupplyChain.Model.UpdateDataIntegrationFlowResponse, UpdateSUPCHDataIntegrationFlowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Flow;
        }
        
    }
}
