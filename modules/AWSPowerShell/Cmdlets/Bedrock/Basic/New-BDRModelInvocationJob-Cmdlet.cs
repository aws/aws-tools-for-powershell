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
    /// Creates a batch inference job to invoke a model on multiple prompts. Format your data
    /// according to <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/batch-inference-data">Format
    /// your inference data</a> and upload it to an Amazon S3 bucket. For more information,
    /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/batch-inference.html">Process
    /// multiple prompts with batch inference</a>.
    /// 
    ///  
    /// <para>
    /// The response returns a <c>jobArn</c> that you can use to stop or get details about
    /// the job.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BDRModelInvocationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock CreateModelInvocationJob API operation.", Operation = new[] {"CreateModelInvocationJob"}, SelectReturnType = typeof(Amazon.Bedrock.Model.CreateModelInvocationJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Bedrock.Model.CreateModelInvocationJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Bedrock.Model.CreateModelInvocationJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBDRModelInvocationJobCmdlet : AmazonBedrockClientCmdlet, IExecutor
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
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>A name to give the batch inference job.</para>
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
        
        #region Parameter ModelId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the foundation model to use for the batch inference job.</para>
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
        public System.String ModelId { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the service role with permissions to carry out and
        /// manage batch inference. You can use the console to create a default service role or
        /// follow the steps at <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/batch-iam-sr.html">Create
        /// a service role for batch inference</a>.</para>
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
        
        #region Parameter S3InputDataConfig_S3BucketOwner
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that owns the S3 bucket containing the input
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_S3InputDataConfig_S3BucketOwner")]
        public System.String S3InputDataConfig_S3BucketOwner { get; set; }
        #endregion
        
        #region Parameter S3OutputDataConfig_S3BucketOwner
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that owns the S3 bucket containing the output
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputDataConfig_S3OutputDataConfig_S3BucketOwner")]
        public System.String S3OutputDataConfig_S3BucketOwner { get; set; }
        #endregion
        
        #region Parameter S3OutputDataConfig_S3EncryptionKeyId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the key that encrypts the S3 location of the output data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputDataConfig_S3OutputDataConfig_S3EncryptionKeyId")]
        public System.String S3OutputDataConfig_S3EncryptionKeyId { get; set; }
        #endregion
        
        #region Parameter S3InputDataConfig_S3InputFormat
        /// <summary>
        /// <para>
        /// <para>The format of the input data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_S3InputDataConfig_S3InputFormat")]
        [AWSConstantClassSource("Amazon.Bedrock.S3InputFormat")]
        public Amazon.Bedrock.S3InputFormat S3InputDataConfig_S3InputFormat { get; set; }
        #endregion
        
        #region Parameter S3InputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 location of the input data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_S3InputDataConfig_S3Uri")]
        public System.String S3InputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter S3OutputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 location of the output data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputDataConfig_S3OutputDataConfig_S3Uri")]
        public System.String S3OutputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>An array of IDs for each security group in the VPC to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SubnetId
        /// <summary>
        /// <para>
        /// <para>An array of IDs for each subnet in the VPC to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SubnetIds")]
        public System.String[] VpcConfig_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Any tags to associate with the batch inference job. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/tagging.html">Tagging
        /// Amazon Bedrock resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Bedrock.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TimeoutDurationInHour
        /// <summary>
        /// <para>
        /// <para>The number of hours after which to force the batch inference job to time out.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutDurationInHours")]
        public System.Int32? TimeoutDurationInHour { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.CreateModelInvocationJobResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.CreateModelInvocationJobResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BDRModelInvocationJob (CreateModelInvocationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.CreateModelInvocationJobResponse, NewBDRModelInvocationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.S3InputDataConfig_S3BucketOwner = this.S3InputDataConfig_S3BucketOwner;
            context.S3InputDataConfig_S3InputFormat = this.S3InputDataConfig_S3InputFormat;
            context.S3InputDataConfig_S3Uri = this.S3InputDataConfig_S3Uri;
            context.JobName = this.JobName;
            #if MODULAR
            if (this.JobName == null && ParameterWasBound(nameof(this.JobName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelId = this.ModelId;
            #if MODULAR
            if (this.ModelId == null && ParameterWasBound(nameof(this.ModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3OutputDataConfig_S3BucketOwner = this.S3OutputDataConfig_S3BucketOwner;
            context.S3OutputDataConfig_S3EncryptionKeyId = this.S3OutputDataConfig_S3EncryptionKeyId;
            context.S3OutputDataConfig_S3Uri = this.S3OutputDataConfig_S3Uri;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Bedrock.Model.Tag>(this.Tag);
            }
            context.TimeoutDurationInHour = this.TimeoutDurationInHour;
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
            var request = new Amazon.Bedrock.Model.CreateModelInvocationJobRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate InputDataConfig
            var requestInputDataConfigIsNull = true;
            request.InputDataConfig = new Amazon.Bedrock.Model.ModelInvocationJobInputDataConfig();
            Amazon.Bedrock.Model.ModelInvocationJobS3InputDataConfig requestInputDataConfig_inputDataConfig_S3InputDataConfig = null;
            
             // populate S3InputDataConfig
            var requestInputDataConfig_inputDataConfig_S3InputDataConfigIsNull = true;
            requestInputDataConfig_inputDataConfig_S3InputDataConfig = new Amazon.Bedrock.Model.ModelInvocationJobS3InputDataConfig();
            System.String requestInputDataConfig_inputDataConfig_S3InputDataConfig_s3InputDataConfig_S3BucketOwner = null;
            if (cmdletContext.S3InputDataConfig_S3BucketOwner != null)
            {
                requestInputDataConfig_inputDataConfig_S3InputDataConfig_s3InputDataConfig_S3BucketOwner = cmdletContext.S3InputDataConfig_S3BucketOwner;
            }
            if (requestInputDataConfig_inputDataConfig_S3InputDataConfig_s3InputDataConfig_S3BucketOwner != null)
            {
                requestInputDataConfig_inputDataConfig_S3InputDataConfig.S3BucketOwner = requestInputDataConfig_inputDataConfig_S3InputDataConfig_s3InputDataConfig_S3BucketOwner;
                requestInputDataConfig_inputDataConfig_S3InputDataConfigIsNull = false;
            }
            Amazon.Bedrock.S3InputFormat requestInputDataConfig_inputDataConfig_S3InputDataConfig_s3InputDataConfig_S3InputFormat = null;
            if (cmdletContext.S3InputDataConfig_S3InputFormat != null)
            {
                requestInputDataConfig_inputDataConfig_S3InputDataConfig_s3InputDataConfig_S3InputFormat = cmdletContext.S3InputDataConfig_S3InputFormat;
            }
            if (requestInputDataConfig_inputDataConfig_S3InputDataConfig_s3InputDataConfig_S3InputFormat != null)
            {
                requestInputDataConfig_inputDataConfig_S3InputDataConfig.S3InputFormat = requestInputDataConfig_inputDataConfig_S3InputDataConfig_s3InputDataConfig_S3InputFormat;
                requestInputDataConfig_inputDataConfig_S3InputDataConfigIsNull = false;
            }
            System.String requestInputDataConfig_inputDataConfig_S3InputDataConfig_s3InputDataConfig_S3Uri = null;
            if (cmdletContext.S3InputDataConfig_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_S3InputDataConfig_s3InputDataConfig_S3Uri = cmdletContext.S3InputDataConfig_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_S3InputDataConfig_s3InputDataConfig_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_S3InputDataConfig.S3Uri = requestInputDataConfig_inputDataConfig_S3InputDataConfig_s3InputDataConfig_S3Uri;
                requestInputDataConfig_inputDataConfig_S3InputDataConfigIsNull = false;
            }
             // determine if requestInputDataConfig_inputDataConfig_S3InputDataConfig should be set to null
            if (requestInputDataConfig_inputDataConfig_S3InputDataConfigIsNull)
            {
                requestInputDataConfig_inputDataConfig_S3InputDataConfig = null;
            }
            if (requestInputDataConfig_inputDataConfig_S3InputDataConfig != null)
            {
                request.InputDataConfig.S3InputDataConfig = requestInputDataConfig_inputDataConfig_S3InputDataConfig;
                requestInputDataConfigIsNull = false;
            }
             // determine if request.InputDataConfig should be set to null
            if (requestInputDataConfigIsNull)
            {
                request.InputDataConfig = null;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.ModelId != null)
            {
                request.ModelId = cmdletContext.ModelId;
            }
            
             // populate OutputDataConfig
            var requestOutputDataConfigIsNull = true;
            request.OutputDataConfig = new Amazon.Bedrock.Model.ModelInvocationJobOutputDataConfig();
            Amazon.Bedrock.Model.ModelInvocationJobS3OutputDataConfig requestOutputDataConfig_outputDataConfig_S3OutputDataConfig = null;
            
             // populate S3OutputDataConfig
            var requestOutputDataConfig_outputDataConfig_S3OutputDataConfigIsNull = true;
            requestOutputDataConfig_outputDataConfig_S3OutputDataConfig = new Amazon.Bedrock.Model.ModelInvocationJobS3OutputDataConfig();
            System.String requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3BucketOwner = null;
            if (cmdletContext.S3OutputDataConfig_S3BucketOwner != null)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3BucketOwner = cmdletContext.S3OutputDataConfig_S3BucketOwner;
            }
            if (requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3BucketOwner != null)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfig.S3BucketOwner = requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3BucketOwner;
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfigIsNull = false;
            }
            System.String requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3EncryptionKeyId = null;
            if (cmdletContext.S3OutputDataConfig_S3EncryptionKeyId != null)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3EncryptionKeyId = cmdletContext.S3OutputDataConfig_S3EncryptionKeyId;
            }
            if (requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3EncryptionKeyId != null)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfig.S3EncryptionKeyId = requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3EncryptionKeyId;
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfigIsNull = false;
            }
            System.String requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3Uri = null;
            if (cmdletContext.S3OutputDataConfig_S3Uri != null)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3Uri = cmdletContext.S3OutputDataConfig_S3Uri;
            }
            if (requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3Uri != null)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfig.S3Uri = requestOutputDataConfig_outputDataConfig_S3OutputDataConfig_s3OutputDataConfig_S3Uri;
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfigIsNull = false;
            }
             // determine if requestOutputDataConfig_outputDataConfig_S3OutputDataConfig should be set to null
            if (requestOutputDataConfig_outputDataConfig_S3OutputDataConfigIsNull)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputDataConfig = null;
            }
            if (requestOutputDataConfig_outputDataConfig_S3OutputDataConfig != null)
            {
                request.OutputDataConfig.S3OutputDataConfig = requestOutputDataConfig_outputDataConfig_S3OutputDataConfig;
                requestOutputDataConfigIsNull = false;
            }
             // determine if request.OutputDataConfig should be set to null
            if (requestOutputDataConfigIsNull)
            {
                request.OutputDataConfig = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TimeoutDurationInHour != null)
            {
                request.TimeoutDurationInHours = cmdletContext.TimeoutDurationInHour.Value;
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
        
        private Amazon.Bedrock.Model.CreateModelInvocationJobResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.CreateModelInvocationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "CreateModelInvocationJob");
            try
            {
                #if DESKTOP
                return client.CreateModelInvocationJob(request);
                #elif CORECLR
                return client.CreateModelInvocationJobAsync(request).GetAwaiter().GetResult();
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
            public System.String S3InputDataConfig_S3BucketOwner { get; set; }
            public Amazon.Bedrock.S3InputFormat S3InputDataConfig_S3InputFormat { get; set; }
            public System.String S3InputDataConfig_S3Uri { get; set; }
            public System.String JobName { get; set; }
            public System.String ModelId { get; set; }
            public System.String S3OutputDataConfig_S3BucketOwner { get; set; }
            public System.String S3OutputDataConfig_S3EncryptionKeyId { get; set; }
            public System.String S3OutputDataConfig_S3Uri { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.Bedrock.Model.Tag> Tag { get; set; }
            public System.Int32? TimeoutDurationInHour { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_SubnetId { get; set; }
            public System.Func<Amazon.Bedrock.Model.CreateModelInvocationJobResponse, NewBDRModelInvocationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobArn;
        }
        
    }
}
