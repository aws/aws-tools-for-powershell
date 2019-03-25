/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.IO;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using System.Collections;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Creates a new Lambda function. If the function name already exists, the operation will fail. 
	/// Note that the function name is case-sensitive. 
    /// <para>
    /// This operation requires permission for the <code>lambda:CreateFunction</code> action.
    /// </para>
    /// <para>
    /// The code for the function may be supplied from a zip file in an S3 bucket,
    /// from a zip file on the local file system (the default) or from a memory stream onto
    /// a resource containing the code.
    /// </para>
    /// </summary>
    [Cmdlet("Publish", "LMFunction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium, DefaultParameterSetName = FromZipFile)]
    [OutputType("Amazon.Lambda.Model.CreateFunctionResult")]
    [AWSCmdlet("Calls the Amazon Lambda CreateFunction operation.", Operation = new[] { "CreateFunction" })]
    [AWSCmdletOutput("Amazon.Lambda.Model.CreateFunctionResult",
        "This cmdlet returns an Amazon.Lambda.Model.CreateFunctionResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class PublishLMFunctionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        const string FromZipFile = "FromZipFile";
        const string FromS3Object = "FromS3Object";
        private const string FromMemoryStream = "FromMemoryStream";

        #region Parameter Description
        /// <summary>
        /// A short user-defined function description. Lambda does not use this value. Assign
        /// a meaningful description as you see fit.
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion

        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// The name you want to assign to the function you are uploading. The function names appear in the console and are 
        /// returned in the ListFunctions API. Function names are used to specify functions to other AWS Lambda APIs, such 
        /// as Invoke.
        /// </para>
        /// <para>
        /// Length constraints: Minimum length of 1. Maximum length of 140.
        /// </para>
        /// <para>
        /// Pattern: (arn:aws:lambda:)?([a-z]{2}-[a-z]+-\d{1}:)?(\d{12}:)?(function:)?([a-zA-Z0-9-_]+)(:(\$LATEST|[a-zA-Z0-9-_]+))?
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String FunctionName { get; set; }
        #endregion

        #region Parameter BucketName
        /// <summary>
        /// Amazon S3 bucket name where the .zip file containing your deployment package is stored.
        /// This bucket must reside in the same AWS region where you are creating the Lambda function.
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
        [System.Management.Automation.Parameter(Position = 1, Mandatory = true, ParameterSetName = FromZipFile)]
        [Alias("FunctionZip", "Filename")]
        public System.String ZipFilename { get; set; }
        #endregion

        #region Parameter Handler
        /// <summary>
        /// <para>
        /// The function within your code that Lambda calls to begin execution. For Node.js, it
        /// is the <i>module-name</i>.<i>export</i> value in your function. For Java, it can be
        /// <code>package.class-name::handler</code> or <code>package.class-name</code>. For more
        /// information, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/java-programming-model-handler-types.html">Lambda
        /// Function Handler (Java)</a>. 
        /// </para>
        /// <para>
        /// Length constraints: Minimum length of 0. Maximum length of 128.
        /// </para>
        /// <para>
        /// Pattern: [^\s]+
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, Mandatory = true)]
        public System.String Handler { get; set; }
        #endregion

        #region Parameter MemorySize
        /// <summary>
        /// <para>
        /// The amount of memory, in MB, your Lambda function is given. Lambda uses this memory
        /// size to infer the amount of CPU and memory allocated to your function. Your function
        /// use-case determines your CPU and memory requirements. For example, a database operation
        /// might need less memory compared to an image processing function. The default value
        /// is 128 MB. The value must be a multiple of 64 MB.
        /// </para>
        /// <para>
        /// Valid range: Minimum value of 128. Maximum value of 1536.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32? MemorySize { get; set; }
        #endregion

        #region Parameter Role
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the IAM role that Lambda assumes when it executes
        /// your function to access any other Amazon Web Services (AWS) resources. For more information,
        /// see <a href="http://docs.aws.amazon.com/lambda/latest/dg/lambda-introduction.html">AWS
        /// Lambda: How it Works</a> 
        /// </para>
        /// <para>
        /// Pattern: arn:aws:iam::\d{12}:role/?[a-zA-Z_0-9+=,.@\-_/]+
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, Mandatory = true)]
        public System.String Role { get; set; }
        #endregion

        #region Parameter Runtime
        /// <summary>
		/// <para>
		/// The runtime environment for the Lambda function you are uploading. 
		/// </para>
		/// <para>
		/// To use the Node.js runtime v4.3, set the value to "nodejs4.3". To use earlier 
		/// runtime (v0.10.42), set the value to "nodejs".
		/// </para>
		/// <para>
        /// Valid values: nodejs | nodejs4.3 | nodejs6.10 | java8 | python2.7 | python3.6 | dotnetcore1.0 | nodejs4.3-edge
		/// </para>
        /// <para>
        /// <b>Note:</b> the list of options for runtime values is those available at the time the cmdlet was last built
        /// and released. AWS Lambda periodically introduces new runtimes. New runtime values not listed above may be used
        /// without requiring a new version of the cmdlet. Simply provide the required new value name to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        [AWSConstantClassSource("Amazon.Lambda.Runtime")]
        public Amazon.Lambda.Runtime Runtime { get; set; }
        #endregion

        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// The function execution time at which Lambda should terminate the function. Because
        /// the execution time has cost implications, we recommend you set this value based on
        /// your expected execution time. The default is 3 seconds. 
        /// </para>
        /// <para>
        /// Valid range: Minimum value of 1. Maximum value of 300.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32? Timeout { get; set; }
        #endregion

        #region Parameter DeadLetterConfig_TargetArn
        /// <summary>
        /// The ARN (Amazon Resource Value) of an Amazon SQS queue or Amazon SNS topic you specify
        /// as your Dead Letter Queue (DLQ).
        /// </summary>
        [System.Management.Automation.Parameter]
        public string DeadLetterConfig_TargetArn { get; set; }
        #endregion

        #region Parameter Environment_Variable
        /// <summary>
        /// Environment variable key-value pairs that represent your environment's configuration settings. The
        /// value(s) you specify cannot contain a ",".
        /// </summary>
        [System.Management.Automation.Parameter]
        public Hashtable Environment_Variable { get; set; }
        #endregion

        #region Parameter KMSKeyArn
        /// <summary>
        /// The Amazon Resource Name (ARN) of the KMS key used to encrypt your function's environment
        /// variables. If not provided, AWS Lambda will use a default service key.
        /// </summary>
        [System.Management.Automation.Parameter]
        public string KMSKeyArn { get; set;}
        #endregion

        #region Parameter Publish
        /// <summary>
        /// If set requests that AWS Lambda create the Lambda function and publish a version as an 
        /// atomic operation.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Publish { get; set; }
        #endregion

        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// If your Lambda function accesses resources in a VPC, you provide this parameter identifying
        /// the list of security group IDs. The security groups and subnets specified via the 
        /// VpcConfig_SubnetId parameter must belong to the same VPC.
        /// If you specify one or more security groups you must also provide at least one subnet ID.
        /// </para>
        /// <para>
        /// A list of one or more security groups IDs in your VPC.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public string[] VpcConfig_SecurityGroupId { get; set;}
        #endregion

        #region Parameter VpcConfig_SubnetId
        /// <summary>
        /// <para>
        /// If your Lambda function accesses resources in a VPC, you provide this parameter identifying
        /// the list of subnet IDs. The security groups and subnets specified via the 
        /// VpcConfig_SecurityGroupId parameter must belong to the same VPC.
        /// If you specify one or more subnets you must also provide at least one security group ID.
        /// </para>
        /// <para>
        /// A list of one or more subnet IDs in your VPC.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public string[] VpcConfig_SubnetId { get; set;}
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

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.FunctionName, "Publish-LMFunction (CreateFunction)"))
                return;

            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials, 
                Description = this.Description, 
                FunctionName = this.FunctionName,
                ZipFilename = this.ZipFilename,
                ZipFileContent = this.ZipFileContent,
                Handler = this.Handler,
                MemorySize = this.MemorySize,
                Role = this.Role, 
                Runtime = this.Runtime, 
                Timeout = this.Timeout,
                BucketName = this.BucketName,
                Key= this.Key,
                VersionId = this.VersionId,
                DeadLetterQueue_TargetArn = this.DeadLetterConfig_TargetArn,
                KMSKeyArn = this.KMSKeyArn,
                Environment_Variable = this.Environment_Variable,
                VpcConfig_SecurityGroupId = this.VpcConfig_SecurityGroupId,
                VpcConfig_SubnetId = this.VpcConfig_SubnetId
            };

            if (ParameterWasBound("Publish"))
                context.Publish = true;

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
                // create request
                var request = new CreateFunctionRequest();
            
                if (cmdletContext.Description != null)
                {
                    request.Description = cmdletContext.Description;
                }
                if (cmdletContext.FunctionName != null)
                {
                    request.FunctionName = cmdletContext.FunctionName;
                }
                if (cmdletContext.Handler != null)
                {
                    request.Handler = cmdletContext.Handler;
                }

                switch (this.ParameterSetName)
                {
                    case FromZipFile:
                        {
                            var fqZipFilename = PSHelpers.PSPathToAbsolute(this.SessionState.Path, cmdletContext.ZipFilename);
                            if (!File.Exists(fqZipFilename))
                            {
                                this.ThrowArgumentError(string.Format("'{0}' ('{1}') is not a valid file path for the ZipFilename parameter.", this.ZipFilename, fqZipFilename), this);
                            }

                            var content = File.ReadAllBytes(fqZipFilename);
                            _ZipFilenameStream = new MemoryStream(content);

                            request.Code = new FunctionCode
                            {
                                ZipFile = _ZipFilenameStream
                            };
                        }
                        break;

                    case FromMemoryStream:
                        {
                            request.Code = new FunctionCode
                            {
                                ZipFile = cmdletContext.ZipFileContent
                            };
                        }
                        break;

                    case FromS3Object:
                        {
                            request.Code = new FunctionCode
                            {
                                S3Bucket = cmdletContext.BucketName,
                                S3Key = cmdletContext.Key,
                                S3ObjectVersion = cmdletContext.VersionId
                            };
                        }
                        break;
                }

                if (cmdletContext.MemorySize != null)
                {
                    request.MemorySize = cmdletContext.MemorySize.Value;
                }
                if (cmdletContext.Role != null)
                {
                    request.Role = cmdletContext.Role;
                }
                if (cmdletContext.Runtime != null)
                {
                    request.Runtime = cmdletContext.Runtime;
                }
                if (cmdletContext.Timeout != null)
                {
                    request.Timeout = cmdletContext.Timeout.Value;
                }
                if (!string.IsNullOrEmpty(cmdletContext.KMSKeyArn))
                {
                    request.KMSKeyArn = cmdletContext.KMSKeyArn;
                }
                if (!string.IsNullOrEmpty(cmdletContext.DeadLetterQueue_TargetArn))
                {
                    request.DeadLetterConfig = new DeadLetterConfig
                    {
                        TargetArn = cmdletContext.DeadLetterQueue_TargetArn
                    };
                }

                // let the service error if the user provided one and not the other
                if (cmdletContext.VpcConfig_SecurityGroupId != null || cmdletContext.VpcConfig_SubnetId != null)
                {
                    request.VpcConfig = new VpcConfig
                    {
                        SecurityGroupIds = new List<string>(cmdletContext.VpcConfig_SecurityGroupId),
                        SubnetIds = new List<string>(cmdletContext.VpcConfig_SubnetId)
                    };
                }

                if (cmdletContext.Environment_Variable != null)
                {
                    request.Environment = new Lambda.Model.Environment
                    {
                        Variables = new Dictionary<string, string>()
                    };

                    foreach (var key in cmdletContext.Environment_Variable.Keys)
                    {
                        request.Environment.Variables.Add(key.ToString(), cmdletContext.Environment_Variable[key].ToString());
                    }
                }

                if (cmdletContext.Publish.HasValue)
                {
                    request.Publish = cmdletContext.Publish.GetValueOrDefault();
                }

                var client = Client ?? CreateClient(context.Credentials, context.Region);
                CmdletOutput output;

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

        private Amazon.Lambda.Model.CreateFunctionResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.CreateFunctionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lambda", "CreateFunction");

            try
            {
#if DESKTOP
                return client.CreateFunction(request);
#elif CORECLR
                return client.CreateFunctionAsync(request).GetAwaiter().GetResult();
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
            public String Description { get; set; }
            public String FunctionName { get; set; }
            public String ZipFilename { get; set; }
            public System.IO.MemoryStream ZipFileContent { get; set; }
            public String Handler { get; set; }
            public Int32? MemorySize { get; set; }
            public String Role { get; set; }
            public Amazon.Lambda.Runtime Runtime { get; set; }
            public Int32? Timeout { get; set; }
            public string BucketName { get; set; }
            public string Key { get; set; }
            public string VersionId { get; set; }
            public string DeadLetterQueue_TargetArn { get; set; }
            public string KMSKeyArn { get; set; }
            public bool? Publish { get; set; }
            public Hashtable Environment_Variable { get; set; }
            public string[] VpcConfig_SecurityGroupId { get; set; }
            public string[] VpcConfig_SubnetId { get; set; }
        }
        
    }
}
