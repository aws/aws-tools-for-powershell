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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Creates a model import job to import model that you have customized in other environments,
    /// such as Amazon SageMaker. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-customization-import-model.html">Import
    /// a customized model</a>
    /// </summary>
    [Cmdlet("New", "BDRModelImportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock CreateModelImportJob API operation.", Operation = new[] {"CreateModelImportJob"}, SelectReturnType = typeof(Amazon.Bedrock.Model.CreateModelImportJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Bedrock.Model.CreateModelImportJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Bedrock.Model.CreateModelImportJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBDRModelImportJobCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If this token matches a previous request, Amazon Bedrock ignores the
        /// request, but does not return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ImportedModelKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The imported model is encrypted at rest using this key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImportedModelKmsKeyId { get; set; }
        #endregion
        
        #region Parameter ImportedModelName
        /// <summary>
        /// <para>
        /// <para>The name of the imported model.</para>
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
        public System.String ImportedModelName { get; set; }
        #endregion
        
        #region Parameter ImportedModelTag
        /// <summary>
        /// <para>
        /// <para>Tags to attach to the imported model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportedModelTags")]
        public Amazon.Bedrock.Model.Tag[] ImportedModelTag { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The name of the import job.</para>
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
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter JobTag
        /// <summary>
        /// <para>
        /// <para>Tags to attach to this import job. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTags")]
        public Amazon.Bedrock.Model.Tag[] JobTag { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the model import job.</para>
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
        
        #region Parameter S3DataSource_S3Uri
        /// <summary>
        /// <para>
        /// <para>The URI of the Amazon S3 data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelDataSource_S3DataSource_S3Uri")]
        public System.String S3DataSource_S3Uri { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>VPC configuration security group Ids.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SubnetId
        /// <summary>
        /// <para>
        /// <para>VPC configuration subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SubnetIds")]
        public System.String[] VpcConfig_SubnetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.CreateModelImportJobResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.CreateModelImportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BDRModelImportJob (CreateModelImportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.CreateModelImportJobResponse, NewBDRModelImportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.ImportedModelKmsKeyId = this.ImportedModelKmsKeyId;
            context.ImportedModelName = this.ImportedModelName;
            #if MODULAR
            if (this.ImportedModelName == null && ParameterWasBound(nameof(this.ImportedModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportedModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ImportedModelTag != null)
            {
                context.ImportedModelTag = new List<Amazon.Bedrock.Model.Tag>(this.ImportedModelTag);
            }
            context.JobName = this.JobName;
            #if MODULAR
            if (this.JobName == null && ParameterWasBound(nameof(this.JobName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.JobTag != null)
            {
                context.JobTag = new List<Amazon.Bedrock.Model.Tag>(this.JobTag);
            }
            context.S3DataSource_S3Uri = this.S3DataSource_S3Uri;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_SubnetId != null)
            {
                context.VpcConfig_SubnetId = new List<System.String>(this.VpcConfig_SubnetId);
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
            var request = new Amazon.Bedrock.Model.CreateModelImportJobRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ImportedModelKmsKeyId != null)
            {
                request.ImportedModelKmsKeyId = cmdletContext.ImportedModelKmsKeyId;
            }
            if (cmdletContext.ImportedModelName != null)
            {
                request.ImportedModelName = cmdletContext.ImportedModelName;
            }
            if (cmdletContext.ImportedModelTag != null)
            {
                request.ImportedModelTags = cmdletContext.ImportedModelTag;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.JobTag != null)
            {
                request.JobTags = cmdletContext.JobTag;
            }
            
             // populate ModelDataSource
            var requestModelDataSourceIsNull = true;
            request.ModelDataSource = new Amazon.Bedrock.Model.ModelDataSource();
            Amazon.Bedrock.Model.S3DataSource requestModelDataSource_modelDataSource_S3DataSource = null;
            
             // populate S3DataSource
            var requestModelDataSource_modelDataSource_S3DataSourceIsNull = true;
            requestModelDataSource_modelDataSource_S3DataSource = new Amazon.Bedrock.Model.S3DataSource();
            System.String requestModelDataSource_modelDataSource_S3DataSource_s3DataSource_S3Uri = null;
            if (cmdletContext.S3DataSource_S3Uri != null)
            {
                requestModelDataSource_modelDataSource_S3DataSource_s3DataSource_S3Uri = cmdletContext.S3DataSource_S3Uri;
            }
            if (requestModelDataSource_modelDataSource_S3DataSource_s3DataSource_S3Uri != null)
            {
                requestModelDataSource_modelDataSource_S3DataSource.S3Uri = requestModelDataSource_modelDataSource_S3DataSource_s3DataSource_S3Uri;
                requestModelDataSource_modelDataSource_S3DataSourceIsNull = false;
            }
             // determine if requestModelDataSource_modelDataSource_S3DataSource should be set to null
            if (requestModelDataSource_modelDataSource_S3DataSourceIsNull)
            {
                requestModelDataSource_modelDataSource_S3DataSource = null;
            }
            if (requestModelDataSource_modelDataSource_S3DataSource != null)
            {
                request.ModelDataSource.S3DataSource = requestModelDataSource_modelDataSource_S3DataSource;
                requestModelDataSourceIsNull = false;
            }
             // determine if request.ModelDataSource should be set to null
            if (requestModelDataSourceIsNull)
            {
                request.ModelDataSource = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate VpcConfig
            var requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.Bedrock.Model.VpcConfig();
            List<System.String> requestVpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestVpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestVpcConfig_vpcConfig_SecurityGroupId != null)
            {
                request.VpcConfig.SecurityGroupIds = requestVpcConfig_vpcConfig_SecurityGroupId;
                requestVpcConfigIsNull = false;
            }
            List<System.String> requestVpcConfig_vpcConfig_SubnetId = null;
            if (cmdletContext.VpcConfig_SubnetId != null)
            {
                requestVpcConfig_vpcConfig_SubnetId = cmdletContext.VpcConfig_SubnetId;
            }
            if (requestVpcConfig_vpcConfig_SubnetId != null)
            {
                request.VpcConfig.SubnetIds = requestVpcConfig_vpcConfig_SubnetId;
                requestVpcConfigIsNull = false;
            }
             // determine if request.VpcConfig should be set to null
            if (requestVpcConfigIsNull)
            {
                request.VpcConfig = null;
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
        
        private Amazon.Bedrock.Model.CreateModelImportJobResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.CreateModelImportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "CreateModelImportJob");
            try
            {
                #if DESKTOP
                return client.CreateModelImportJob(request);
                #elif CORECLR
                return client.CreateModelImportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ImportedModelKmsKeyId { get; set; }
            public System.String ImportedModelName { get; set; }
            public List<Amazon.Bedrock.Model.Tag> ImportedModelTag { get; set; }
            public System.String JobName { get; set; }
            public List<Amazon.Bedrock.Model.Tag> JobTag { get; set; }
            public System.String S3DataSource_S3Uri { get; set; }
            public System.String RoleArn { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_SubnetId { get; set; }
            public System.Func<Amazon.Bedrock.Model.CreateModelImportJobResponse, NewBDRModelImportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobArn;
        }
        
    }
}
