/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Lambda;
using System.IO;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Updates the code for the specified Lambda function. This operation must only be used
    /// on an existing Lambda function and cannot be used to update the function configuration.
    /// <para>
    /// If you are using the versioning feature, note this API will always update the $LATEST
    /// version of your Lambda function. For information about the versioning feature, see
    /// <a href="http://docs.aws.amazon.com/lambda/latest/dg/versioning-aliases.html">AWS
    /// Lambda Function Versioning and Aliases</a>. 
    /// </para><para>
    /// This operation requires permission for the <code>lambda:UpdateFunctionCode</code>
    /// action.
    /// </para>
    /// <para>
    /// The updated code for the function may be supplied from a zip file in an S3 bucket,
    /// from a zip file on the local file system (the default) or from a memory stream onto
    /// a resource containing the code.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LMFunctionCode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium, DefaultParameterSetName = FromZipFile)]
    [OutputType("Amazon.Lambda.Model.UpdateFunctionCodeResponse")]
    [AWSCmdlet("Invokes the UpdateFunctionCode operation against Amazon Lambda.", Operation = new[] {"UpdateFunctionCode"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.UpdateFunctionCodeResponse",
        "This cmdlet returns a Amazon.Lambda.Model.UpdateFunctionCodeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLMFunctionCodeCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        const string FromZipFile = "FromZipFile";
        const string FromS3Object = "FromS3Object";
        const string FromMemoryStream = "FromMemoryStream"

        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The existing Lambda function name whose code you want to replace.</para><para> You can specify a function name (for example, <code>Thumbnail</code>) or you can
        /// specify Amazon Resource Name (ARN) of the function (for example, <code>arn:aws:lambda:us-west-2:account-id:function:ThumbNail</code>).
        /// AWS Lambda also allows you to specify a partial ARN (for example, <code>account-id:Thumbnail</code>).
        /// Note that the length constraint applies only to the ARN. If you specify only the function
        /// name, it is limited to 64 character in length. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String FunctionName { get; set; }
        #endregion

        #region Parameter BucketName
        /// <summary>
        /// Amazon S3 bucket name where the .zip file containing your deployment package is stored.
        /// This bucket must reside in the same AWS region as the existing Lambda function.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = FromS3Object)]
        [Alias("S3Bucket", "FunctionCode_S3Bucket")]
        public string BucketName { get; set; }
        #endregion

        #region Parameter Key
        /// <summary>
        /// The key name of the Amazon S3 object (the deployment package) you want to upload to Lambda.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = FromS3Object)]
        [Alias("S3Key", "FunctionCode_S3Key")]
        public string Key { get; set; }
        #endregion

        #region Parameter VersionId
        /// <summary>
        /// Optional version ID of the Amazon S3 object (the deployment package) you want to upload to Lambda.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = FromS3Object)]
        [Alias("S3ObjectVersion", "FunctionCode_S3ObjectVersion")]
        public string VersionId { get; set; }
        #endregion
        
        #region Parameter ZipFileContent
        /// <summary>
        /// <para>
        /// <para>A stream onto the zip file containing your deployment package.
        /// For more information about creating a .zip file, go to <a href="http://docs.aws.amazon.com/lambda/latest/dg/intro-permission-model.html#lambda-intro-execution-role.html">Execution
        /// Permissions</a> in the <i>AWS Lambda Developer Guide</i>. </para>
        /// </para>
        /// <para>Note: the supplied stream is not disposed when the cmdlet exits.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ParameterSetName = FromMemoryStream, Mandatory = true)]
        [Alias("ZipContent")]
        public System.IO.MemoryStream ZipFileContent { get; set; }
        #endregion

        #region Parameter ZipFilename
        /// <summary>
        /// <para>
        /// The path to a zip file containing your deployment package. For more information about creating a .zip file,
        /// go to <a href="http://docs.aws.amazon.com/lambda/latest/dg/intro-permission-model.html#lambda-intro-execution-role.html">Execution
        /// Permissions</a> in the <i>AWS Lambda Developer Guide</i>.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ParameterSetName = FromZipFile, Mandatory = true)]
        [Alias("FunctionZip", "Filename")]
        public System.String ZipFilename { get; set; }
        #endregion

        #region Parameter Publish
        /// <summary>
        /// If set requests that AWS Lambda update the Lambda function and publish a version as an 
        /// atomic operation.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Publish { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FunctionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMFunctionCode (UpdateFunctionCode)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.FunctionName = this.FunctionName;
            if (ParameterWasBound("Publish"))
                context.Publish = this.Publish;
            context.BucketName = this.BucketName;
            context.Key = this.Key;
            context.VersionId = this.VersionId;
            context.ZipFileContent = this.ZipFileContent;
            context.ZipFilename = this.ZipFilename;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _ZipFilenameStream = null;

            try
            {
                var cmdletContext = context as CmdletContext;
                var request = new Amazon.Lambda.Model.UpdateFunctionCodeRequest
                {
                    FunctionName = cmdletContext.FunctionName;
                };

                if (cmdletContext.Publish != null)
                {
                    request.Publish = cmdletContext.Publish.Value;
                }

                switch (this.ParameterSetName)
                {
                    case FromZipFile:
                        {
                            if (!string.IsNullOrEmpty(cmdletContext.ZipFilename))
                            {
                                var fqZipFilename = PSHelpers.PSPathToAbsolute(this.SessionState.Path, cmdletContext.ZipFilename);
                                if (!File.Exists(fqZipFilename))
                                {
                                    this.ThrowArgumentError(string.Format("'{0}' ('{1}') is not a valid file path for the ZipFilename parameter.", this.ZipFilename, fqZipFilename), this);
                                }

                                var content = File.ReadAllBytes(fqZipFilename);
                                _ZipFilenameStream = new MemoryStream(content);
                                request.ZipFile = _ZipFilenameStream;
                            }
                        }
                        break;

                    case FromMemoryStream:
                        {
                            request.ZipFile = cmdletContext.ZipFileContent;
                        }
                        break;

                    case FromS3Object:
                        {
                            request.S3Bucket = cmdletContext.BucketName;
                            request.S3Key = cmdletContext.Key;
                            request.S3ObjectVersion = cmdletContext.VersionId;
                        }
                        break;
                }

                CmdletOutput output;

                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response;
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response,
                        Notes = notes
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
                if (_ZipFilenameStream != null)
                {
                    _ZipFilenameStream.Dispose();
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lambda", "UpdateFunctionCode");

            try
            {
#if DESKTOP
                return client.UpdateFunctionCode(request);
#elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateFunctionCodeAsync(request);
                return task.Result;
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
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String FunctionName { get; set; }
            public System.Boolean? Publish { get; set; }
            public string BucketName { get; set; }
            public string Key { get; set; }
            public string VersionId { get; set; }
            public System.IO.MemoryStream ZipFileContent { get; set; }
            public System.String ZipFilename { get; set; }
        }
        
    }
}
