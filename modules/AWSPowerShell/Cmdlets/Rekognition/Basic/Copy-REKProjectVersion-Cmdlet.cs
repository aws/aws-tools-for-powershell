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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// <note><para>
    /// This operation applies only to Amazon Rekognition Custom Labels.
    /// </para></note><para>
    /// Copies a version of an Amazon Rekognition Custom Labels model from a source project
    /// to a destination project. The source and destination projects can be in different
    /// AWS accounts but must be in the same AWS Region. You can't copy a model to another
    /// AWS service. 
    /// </para><para>
    /// To copy a model version to a different AWS account, you need to create a resource-based
    /// policy known as a <i>project policy</i>. You attach the project policy to the source
    /// project by calling <a>PutProjectPolicy</a>. The project policy gives permission to
    /// copy the model version from a trusting AWS account to a trusted account.
    /// </para><para>
    /// For more information creating and attaching a project policy, see Attaching a project
    /// policy (SDK) in the <i>Amazon Rekognition Custom Labels Developer Guide</i>. 
    /// </para><para>
    /// If you are copying a model version to a project in the same AWS account, you don't
    /// need to create a project policy.
    /// </para><note><para>
    /// Copying project versions is supported only for Custom Labels models. 
    /// </para><para>
    /// To copy a model, the destination project, source project, and source model version
    /// must already exist.
    /// </para></note><para>
    /// Copying a model version takes a while to complete. To get the current status, call
    /// <a>DescribeProjectVersions</a> and check the value of <c>Status</c> in the <a>ProjectVersionDescription</a>
    /// object. The copy operation has finished when the value of <c>Status</c> is <c>COPYING_COMPLETED</c>.
    /// </para><para>
    /// This operation requires permissions to perform the <c>rekognition:CopyProjectVersion</c>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "REKProjectVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Rekognition CopyProjectVersion API operation.", Operation = new[] {"CopyProjectVersion"}, SelectReturnType = typeof(Amazon.Rekognition.Model.CopyProjectVersionResponse))]
    [AWSCmdletOutput("System.String or Amazon.Rekognition.Model.CopyProjectVersionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Rekognition.Model.CopyProjectVersionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CopyREKProjectVersionCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DestinationProjectArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the project in the trusted AWS account that you want to copy the model
        /// version to. </para>
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
        public System.String DestinationProjectArn { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier for your AWS Key Management Service key (AWS KMS key). You can supply
        /// the Amazon Resource Name (ARN) of your KMS key, the ID of your KMS key, an alias for
        /// your KMS key, or an alias ARN. The key is used to encrypt training results and manifest
        /// files written to the output Amazon S3 bucket (<c>OutputConfig</c>).</para><para>If you choose to use your own KMS key, you need the following permissions on the KMS
        /// key.</para><ul><li><para>kms:CreateGrant</para></li><li><para>kms:DescribeKey</para></li><li><para>kms:GenerateDataKey</para></li><li><para>kms:Decrypt</para></li></ul><para>If you don't specify a value for <c>KmsKeyId</c>, images copied into the service are
        /// encrypted using a key that AWS owns and manages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket where training output is placed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_S3Bucket { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The prefix applied to the training output files. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter SourceProjectArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the source project in the trusting AWS account.</para>
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
        public System.String SourceProjectArn { get; set; }
        #endregion
        
        #region Parameter SourceProjectVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the model version in the source project that you want to copy to a destination
        /// project.</para>
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
        public System.String SourceProjectVersionArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value tags to assign to the model version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter VersionName
        /// <summary>
        /// <para>
        /// <para>A name for the version of the model that's copied to the destination project.</para>
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
        public System.String VersionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProjectVersionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.CopyProjectVersionResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.CopyProjectVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProjectVersionArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-REKProjectVersion (CopyProjectVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.CopyProjectVersionResponse, CopyREKProjectVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DestinationProjectArn = this.DestinationProjectArn;
            #if MODULAR
            if (this.DestinationProjectArn == null && ParameterWasBound(nameof(this.DestinationProjectArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationProjectArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyId = this.KmsKeyId;
            context.OutputConfig_S3Bucket = this.OutputConfig_S3Bucket;
            context.OutputConfig_S3KeyPrefix = this.OutputConfig_S3KeyPrefix;
            context.SourceProjectArn = this.SourceProjectArn;
            #if MODULAR
            if (this.SourceProjectArn == null && ParameterWasBound(nameof(this.SourceProjectArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceProjectArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceProjectVersionArn = this.SourceProjectVersionArn;
            #if MODULAR
            if (this.SourceProjectVersionArn == null && ParameterWasBound(nameof(this.SourceProjectVersionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceProjectVersionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.VersionName = this.VersionName;
            #if MODULAR
            if (this.VersionName == null && ParameterWasBound(nameof(this.VersionName)))
            {
                WriteWarning("You are passing $null as a value for parameter VersionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Rekognition.Model.CopyProjectVersionRequest();
            
            if (cmdletContext.DestinationProjectArn != null)
            {
                request.DestinationProjectArn = cmdletContext.DestinationProjectArn;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.Rekognition.Model.OutputConfig();
            System.String requestOutputConfig_outputConfig_S3Bucket = null;
            if (cmdletContext.OutputConfig_S3Bucket != null)
            {
                requestOutputConfig_outputConfig_S3Bucket = cmdletContext.OutputConfig_S3Bucket;
            }
            if (requestOutputConfig_outputConfig_S3Bucket != null)
            {
                request.OutputConfig.S3Bucket = requestOutputConfig_outputConfig_S3Bucket;
                requestOutputConfigIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_S3KeyPrefix = null;
            if (cmdletContext.OutputConfig_S3KeyPrefix != null)
            {
                requestOutputConfig_outputConfig_S3KeyPrefix = cmdletContext.OutputConfig_S3KeyPrefix;
            }
            if (requestOutputConfig_outputConfig_S3KeyPrefix != null)
            {
                request.OutputConfig.S3KeyPrefix = requestOutputConfig_outputConfig_S3KeyPrefix;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
            }
            if (cmdletContext.SourceProjectArn != null)
            {
                request.SourceProjectArn = cmdletContext.SourceProjectArn;
            }
            if (cmdletContext.SourceProjectVersionArn != null)
            {
                request.SourceProjectVersionArn = cmdletContext.SourceProjectVersionArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VersionName != null)
            {
                request.VersionName = cmdletContext.VersionName;
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
        
        private Amazon.Rekognition.Model.CopyProjectVersionResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.CopyProjectVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "CopyProjectVersion");
            try
            {
                #if DESKTOP
                return client.CopyProjectVersion(request);
                #elif CORECLR
                return client.CopyProjectVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationProjectArn { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String OutputConfig_S3Bucket { get; set; }
            public System.String OutputConfig_S3KeyPrefix { get; set; }
            public System.String SourceProjectArn { get; set; }
            public System.String SourceProjectVersionArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String VersionName { get; set; }
            public System.Func<Amazon.Rekognition.Model.CopyProjectVersionResponse, CopyREKProjectVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProjectVersionArn;
        }
        
    }
}
