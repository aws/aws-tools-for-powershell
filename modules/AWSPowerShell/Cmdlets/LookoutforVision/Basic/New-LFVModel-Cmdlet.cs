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
using Amazon.LookoutforVision;
using Amazon.LookoutforVision.Model;

namespace Amazon.PowerShell.Cmdlets.LFV
{
    /// <summary>
    /// Creates a new version of a model within an an Amazon Lookout for Vision project. <c>CreateModel</c>
    /// is an asynchronous operation in which Amazon Lookout for Vision trains, tests, and
    /// evaluates a new version of a model. 
    /// 
    ///  
    /// <para>
    /// To get the current status, check the <c>Status</c> field returned in the response
    /// from <a>DescribeModel</a>.
    /// </para><para>
    /// If the project has a single dataset, Amazon Lookout for Vision internally splits the
    /// dataset to create a training and a test dataset. If the project has a training and
    /// a test dataset, Lookout for Vision uses the respective datasets to train and test
    /// the model. 
    /// </para><para>
    /// After training completes, the evaluation metrics are stored at the location specified
    /// in <c>OutputConfig</c>. 
    /// </para><para>
    /// This operation requires permissions to perform the <c>lookoutvision:CreateModel</c>
    /// operation. If you want to tag your model, you also require permission to the <c>lookoutvision:TagResource</c>
    /// operation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LFVModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LookoutforVision.Model.ModelMetadata")]
    [AWSCmdlet("Calls the Amazon Lookout for Vision CreateModel API operation.", Operation = new[] {"CreateModel"}, SelectReturnType = typeof(Amazon.LookoutforVision.Model.CreateModelResponse))]
    [AWSCmdletOutput("Amazon.LookoutforVision.Model.ModelMetadata or Amazon.LookoutforVision.Model.CreateModelResponse",
        "This cmdlet returns an Amazon.LookoutforVision.Model.ModelMetadata object.",
        "The service call response (type Amazon.LookoutforVision.Model.CreateModelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLFVModelCmdlet : AmazonLookoutforVisionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Output_S3Location_Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket that contains the training or model packaging job output. If you are
        /// training a model, the bucket must in your AWS account. If you use an S3 bucket for
        /// a model packaging job, the S3 bucket must be in the same AWS Region and AWS account
        /// in which you use AWS IoT Greengrass.</para>
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
        [Alias("OutputConfig_S3Location_Bucket")]
        public System.String Output_S3Location_Bucket { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the version of the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier for your AWS KMS key. The key is used to encrypt training and test
        /// images copied into the service for model training. Your source images are unaffected.
        /// If this parameter is not specified, the copied images are encrypted by a key that
        /// AWS owns and manages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Output_S3Location_Prefix
        /// <summary>
        /// <para>
        /// <para>The path of the folder, within the S3 bucket, that contains the output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputConfig_S3Location_Prefix")]
        public System.String Output_S3Location_Prefix { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the project in which you want to create a model version.</para>
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
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of tags (key-value pairs) that you want to attach to the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.LookoutforVision.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>ClientToken is an idempotency token that ensures a call to <c>CreateModel</c> completes
        /// only once. You choose the value to pass. For example, An issue might prevent you from
        /// getting a response from <c>CreateModel</c>. In this case, safely retry your call to
        /// <c>CreateModel</c> by using the same <c>ClientToken</c> parameter value. </para><para>If you don't supply a value for <c>ClientToken</c>, the AWS SDK you are using inserts
        /// a value for you. This prevents retries after a network error from starting multiple
        /// training jobs. You'll need to provide your own value for other use cases. </para><para>An error occurs if the other input parameters are not the same as in the first request.
        /// Using a different value for <c>ClientToken</c> is considered a new call to <c>CreateModel</c>.
        /// An idempotency token is active for 8 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ModelMetadata'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutforVision.Model.CreateModelResponse).
        /// Specifying the name of a property of type Amazon.LookoutforVision.Model.CreateModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ModelMetadata";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LFVModel (CreateModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutforVision.Model.CreateModelResponse, NewLFVModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.KmsKeyId = this.KmsKeyId;
            context.Output_S3Location_Bucket = this.Output_S3Location_Bucket;
            #if MODULAR
            if (this.Output_S3Location_Bucket == null && ParameterWasBound(nameof(this.Output_S3Location_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter Output_S3Location_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Output_S3Location_Prefix = this.Output_S3Location_Prefix;
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.LookoutforVision.Model.Tag>(this.Tag);
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
            var request = new Amazon.LookoutforVision.Model.CreateModelRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.LookoutforVision.Model.OutputConfig();
            Amazon.LookoutforVision.Model.S3Location requestOutputConfig_outputConfig_S3Location = null;
            
             // populate S3Location
            var requestOutputConfig_outputConfig_S3LocationIsNull = true;
            requestOutputConfig_outputConfig_S3Location = new Amazon.LookoutforVision.Model.S3Location();
            System.String requestOutputConfig_outputConfig_S3Location_output_S3Location_Bucket = null;
            if (cmdletContext.Output_S3Location_Bucket != null)
            {
                requestOutputConfig_outputConfig_S3Location_output_S3Location_Bucket = cmdletContext.Output_S3Location_Bucket;
            }
            if (requestOutputConfig_outputConfig_S3Location_output_S3Location_Bucket != null)
            {
                requestOutputConfig_outputConfig_S3Location.Bucket = requestOutputConfig_outputConfig_S3Location_output_S3Location_Bucket;
                requestOutputConfig_outputConfig_S3LocationIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_S3Location_output_S3Location_Prefix = null;
            if (cmdletContext.Output_S3Location_Prefix != null)
            {
                requestOutputConfig_outputConfig_S3Location_output_S3Location_Prefix = cmdletContext.Output_S3Location_Prefix;
            }
            if (requestOutputConfig_outputConfig_S3Location_output_S3Location_Prefix != null)
            {
                requestOutputConfig_outputConfig_S3Location.Prefix = requestOutputConfig_outputConfig_S3Location_output_S3Location_Prefix;
                requestOutputConfig_outputConfig_S3LocationIsNull = false;
            }
             // determine if requestOutputConfig_outputConfig_S3Location should be set to null
            if (requestOutputConfig_outputConfig_S3LocationIsNull)
            {
                requestOutputConfig_outputConfig_S3Location = null;
            }
            if (requestOutputConfig_outputConfig_S3Location != null)
            {
                request.OutputConfig.S3Location = requestOutputConfig_outputConfig_S3Location;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
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
        
        private Amazon.LookoutforVision.Model.CreateModelResponse CallAWSServiceOperation(IAmazonLookoutforVision client, Amazon.LookoutforVision.Model.CreateModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Vision", "CreateModel");
            try
            {
                #if DESKTOP
                return client.CreateModel(request);
                #elif CORECLR
                return client.CreateModelAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Output_S3Location_Bucket { get; set; }
            public System.String Output_S3Location_Prefix { get; set; }
            public System.String ProjectName { get; set; }
            public List<Amazon.LookoutforVision.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.LookoutforVision.Model.CreateModelResponse, NewLFVModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ModelMetadata;
        }
        
    }
}
