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
using Amazon.Lambda;
using Amazon.Lambda.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Updates a Lambda function's code. If code signing is enabled for the function, the
    /// code package must be signed by a trusted publisher. For more information, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/configuration-codesigning.html">Configuring
    /// code signing for Lambda</a>.
    /// 
    ///  
    /// <para>
    /// If the function's package type is <c>Image</c>, then you must specify the code package
    /// in <c>ImageUri</c> as the URI of a <a href="https://docs.aws.amazon.com/lambda/latest/dg/lambda-images.html">container
    /// image</a> in the Amazon ECR registry.
    /// </para><para>
    /// If the function's package type is <c>Zip</c>, then you must specify the deployment
    /// package as a <a href="https://docs.aws.amazon.com/lambda/latest/dg/gettingstarted-package.html#gettingstarted-package-zip">.zip
    /// file archive</a>. Enter the Amazon S3 bucket and key of the code .zip file location.
    /// You can also provide the function code inline using the <c>ZipFile</c> field.
    /// </para><para>
    /// The code in the deployment package must be compatible with the target instruction
    /// set architecture of the function (<c>x86-64</c> or <c>arm64</c>).
    /// </para><para>
    /// The function's code is locked when you publish a version. You can't modify the code
    /// of a published version, only the unpublished version.
    /// </para><note><para>
    /// For a function defined as a container image, Lambda resolves the image tag to an image
    /// digest. In Amazon ECR, if you update the image tag to a new image, Lambda does not
    /// automatically update the function.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "LMFunctionCode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium, DefaultParameterSetName="FromMemoryStream")]
    [OutputType("Amazon.Lambda.Model.UpdateFunctionCodeResponse")]
    [AWSCmdlet("Calls the AWS Lambda UpdateFunctionCode API operation.", Operation = new[] {"UpdateFunctionCode"}, SelectReturnType = typeof(Amazon.Lambda.Model.UpdateFunctionCodeResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.UpdateFunctionCodeResponse",
        "This cmdlet returns an Amazon.Lambda.Model.UpdateFunctionCodeResponse object containing multiple properties."
    )]
    public partial class UpdateLMFunctionCodeCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Architecture
        /// <summary>
        /// <para>
        /// <para>The instruction set architecture that the function supports. Enter a string array
        /// with one of the valid values (arm64 or x86_64). The default value is <c>x86_64</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Architectures")]
        public System.String[] Architecture { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Set to true to validate the request parameters and access permissions without modifying
        /// the function code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the Lambda function.</para><para><b>Name formats</b></para><ul><li><para><b>Function name</b> – <c>my-function</c>.</para></li><li><para><b>Function ARN</b> – <c>arn:aws:lambda:us-west-2:123456789012:function:my-function</c>.</para></li><li><para><b>Partial ARN</b> – <c>123456789012:function:my-function</c>.</para></li></ul><para>The length constraint applies only to the full ARN. If you specify only the function
        /// name, it is limited to 64 characters in length.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter ImageUri
        /// <summary>
        /// <para>
        /// <para>URI of a container image in the Amazon ECR registry. Do not use for a function defined
        /// with a .zip file archive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "FromImage")]
        public System.String ImageUri { get; set; }
        #endregion
        
        #region Parameter PublishVersion
        /// <summary>
        /// <para>
        /// <para>Set to true to publish a new version of the function after updating the code. This
        /// has the same effect as calling <a>PublishVersion</a> separately.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PublishVersion { get; set; }
        #endregion
        
        #region Parameter RevisionId
        /// <summary>
        /// <para>
        /// <para>Update the function only if the revision ID matches the ID that's specified. Use this
        /// option to avoid modifying a function that has changed since you last read it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionId { get; set; }
        #endregion
        
        #region Parameter S3Bucket
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 bucket in the same Amazon Web Services Region as your function. The bucket
        /// can be in a different Amazon Web Services account. Use only with a function defined
        /// with a .zip file archive deployment package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "FromS3Object")]
        [Alias("BucketName","FunctionCode_S3Bucket")]
        public System.String S3Bucket { get; set; }
        #endregion
        
        #region Parameter S3Key
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 key of the deployment package. Use only with a function defined with
        /// a .zip file archive deployment package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "FromS3Object")]
        [Alias("FunctionCode_S3Key","Key")]
        public System.String S3Key { get; set; }
        #endregion
        
        #region Parameter S3ObjectVersion
        /// <summary>
        /// <para>
        /// <para>For versioned objects, the version of the deployment package object to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = "FromS3Object")]
        [Alias("FunctionCode_S3ObjectVersion","VersionId")]
        public System.String S3ObjectVersion { get; set; }
        #endregion
        
        #region Parameter SourceKMSKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Key Management Service (KMS) customer managed key that's used to encrypt
        /// your function's .zip deployment package. If you don't provide a customer managed key,
        /// Lambda uses an Amazon Web Services managed key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceKMSKeyArn { get; set; }
        #endregion
        
        #region Parameter ZipFile
        /// <summary>
        /// <para>
        /// <para>The base64-encoded contents of the deployment package. Amazon Web Services SDK and
        /// CLI clients handle the encoding for you. Use only with a function defined with a .zip
        /// file archive deployment package.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "FromMemoryStream")]
        [Alias("ZipContent","ZipFileContent")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] ZipFile { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.UpdateFunctionCodeResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.UpdateFunctionCodeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMFunctionCode (UpdateFunctionCode)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.UpdateFunctionCodeResponse, UpdateLMFunctionCodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Architecture != null)
            {
                context.Architecture = new List<System.String>(this.Architecture);
            }
            context.DryRun = this.DryRun;
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImageUri = this.ImageUri;
            context.PublishVersion = this.PublishVersion;
            context.RevisionId = this.RevisionId;
            context.S3Bucket = this.S3Bucket;
            context.S3Key = this.S3Key;
            context.S3ObjectVersion = this.S3ObjectVersion;
            context.SourceKMSKeyArn = this.SourceKMSKeyArn;
            context.ZipFile = this.ZipFile;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _ZipFileStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Lambda.Model.UpdateFunctionCodeRequest();
                
                if (cmdletContext.Architecture != null)
                {
                    request.Architectures = cmdletContext.Architecture;
                }
                if (cmdletContext.DryRun != null)
                {
                    request.DryRun = cmdletContext.DryRun.Value;
                }
                if (cmdletContext.FunctionName != null)
                {
                    request.FunctionName = cmdletContext.FunctionName;
                }
                if (cmdletContext.ImageUri != null)
                {
                    request.ImageUri = cmdletContext.ImageUri;
                }
                if (cmdletContext.PublishVersion != null)
                {
                    request.Publish = cmdletContext.PublishVersion.Value;
                }
                if (cmdletContext.RevisionId != null)
                {
                    request.RevisionId = cmdletContext.RevisionId;
                }
                if (cmdletContext.S3Bucket != null)
                {
                    request.S3Bucket = cmdletContext.S3Bucket;
                }
                if (cmdletContext.S3Key != null)
                {
                    request.S3Key = cmdletContext.S3Key;
                }
                if (cmdletContext.S3ObjectVersion != null)
                {
                    request.S3ObjectVersion = cmdletContext.S3ObjectVersion;
                }
                if (cmdletContext.SourceKMSKeyArn != null)
                {
                    request.SourceKMSKeyArn = cmdletContext.SourceKMSKeyArn;
                }
                if (cmdletContext.ZipFile != null)
                {
                    _ZipFileStream = new System.IO.MemoryStream(cmdletContext.ZipFile);
                    request.ZipFile = _ZipFileStream;
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
            finally
            {
                if( _ZipFileStream != null)
                {
                    _ZipFileStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Lambda.Model.UpdateFunctionCodeResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.UpdateFunctionCodeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "UpdateFunctionCode");
            try
            {
                return client.UpdateFunctionCodeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Architecture { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String FunctionName { get; set; }
            public System.String ImageUri { get; set; }
            public System.Boolean? PublishVersion { get; set; }
            public System.String RevisionId { get; set; }
            public System.String S3Bucket { get; set; }
            public System.String S3Key { get; set; }
            public System.String S3ObjectVersion { get; set; }
            public System.String SourceKMSKeyArn { get; set; }
            public byte[] ZipFile { get; set; }
            public System.Func<Amazon.Lambda.Model.UpdateFunctionCodeResponse, UpdateLMFunctionCodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
