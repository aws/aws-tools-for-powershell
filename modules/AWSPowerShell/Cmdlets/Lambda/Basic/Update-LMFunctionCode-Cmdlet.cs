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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Updates a Lambda function's code. If code signing is enabled for the function, the
    /// code package must be signed by a trusted publisher. For more information, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/configuration-trustedcode.html">Configuring
    /// code signing</a>.
    /// 
    ///  
    /// <para>
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
        "This cmdlet returns an Amazon.Lambda.Model.UpdateFunctionCodeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLMFunctionCodeCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
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
        /// Amazon.Lambda.Model.UpdateFunctionCodeRequest.FunctionName
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter ImageUri
        /// <summary>
        /// <para>
        /// <para>URI of a container image in the Amazon ECR registry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// <para>Only update the function if the revision ID matches the ID that's specified. Use this
        /// option to avoid modifying a function that has changed since you last read it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionId { get; set; }
        #endregion
        
        #region Parameter S3Bucket
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 bucket in the same AWS Region as your function. The bucket can be in
        /// a different AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = "FromS3Object", Mandatory = true)]
        [Alias("BucketName","FunctionCode_S3Bucket")]
        public System.String S3Bucket { get; set; }
        #endregion
        
        #region Parameter S3Key
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 key of the deployment package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = "FromS3Object", Mandatory = true)]
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
        
        #region Parameter ZipFile
        /// <summary>
        /// <para>
        /// <para>The base64-encoded contents of the deployment package. AWS SDK and AWS CLI clients
        /// handle the encoding for you.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = "FromMemoryStream", Mandatory = true)]
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FunctionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FunctionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FunctionName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMFunctionCode (UpdateFunctionCode)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.UpdateFunctionCodeResponse, UpdateLMFunctionCodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FunctionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
                #if DESKTOP
                return client.UpdateFunctionCode(request);
                #elif CORECLR
                return client.UpdateFunctionCodeAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.String FunctionName { get; set; }
            public System.String ImageUri { get; set; }
            public System.Boolean? PublishVersion { get; set; }
            public System.String RevisionId { get; set; }
            public System.String S3Bucket { get; set; }
            public System.String S3Key { get; set; }
            public System.String S3ObjectVersion { get; set; }
            public byte[] ZipFile { get; set; }
            public System.Func<Amazon.Lambda.Model.UpdateFunctionCodeResponse, UpdateLMFunctionCodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
