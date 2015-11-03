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
    /// Updates the code for the specified Lambda function. This operation must only be used
    /// on an existing Lambda function and cannot be used to update the function configuration.
    /// 
    /// 
    ///  
    /// <para>
    /// This operation requires permission for the <code>lambda:UpdateFunctionCode</code>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LMFunctionCode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.UpdateFunctionCodeResponse")]
    [AWSCmdlet("Invokes the UpdateFunctionCode operation against Amazon Lambda.", Operation = new[] {"UpdateFunctionCode"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.UpdateFunctionCodeResponse",
        "This cmdlet returns a Amazon.Lambda.Model.UpdateFunctionCodeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateLMFunctionCodeCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The existing Lambda function name whose code you want to replace.</para><para> You can specify an unqualified function name (for example, "Thumbnail") or you can
        /// specify Amazon Resource Name (ARN) of the function (for example, "arn:aws:lambda:us-west-2:account-id:function:ThumbNail").
        /// AWS Lambda also allows you to specify only the account ID qualifier (for example,
        /// "account-id:Thumbnail"). Note that the length constraint applies only to the ARN.
        /// If you specify only the function name, it is limited to 64 character in length. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter Publish
        /// <summary>
        /// <para>
        /// <para>This boolean parameter can be used to request AWS Lambda to update the Lambda function
        /// and publish a version as an atomic operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Publish { get; set; }
        #endregion
        
        #region Parameter S3Bucket
        /// <summary>
        /// <para>
        /// <para>Amazon S3 bucket name where the .zip file containing your deployment package is stored.
        /// This bucket must reside in the same AWS region where you are creating the Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String S3Bucket { get; set; }
        #endregion
        
        #region Parameter S3Key
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 object (the deployment package) key name you want to upload. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String S3Key { get; set; }
        #endregion
        
        #region Parameter S3ObjectVersion
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 object (the deployment package) version you want to upload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String S3ObjectVersion { get; set; }
        #endregion
        
        #region Parameter ZipFile
        /// <summary>
        /// <para>
        /// <para>Based64-encoded .zip file containing your packaged source code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.IO.MemoryStream ZipFile { get; set; }
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
            
            context.FunctionName = this.FunctionName;
            if (ParameterWasBound("Publish"))
                context.Publish = this.Publish;
            context.S3Bucket = this.S3Bucket;
            context.S3Key = this.S3Key;
            context.S3ObjectVersion = this.S3ObjectVersion;
            context.ZipFile = this.ZipFile;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Lambda.Model.UpdateFunctionCodeRequest();
            
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.Publish != null)
            {
                request.Publish = cmdletContext.Publish.Value;
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
                request.ZipFile = cmdletContext.ZipFile;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateFunctionCode(request);
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String FunctionName { get; set; }
            public System.Boolean? Publish { get; set; }
            public System.String S3Bucket { get; set; }
            public System.String S3Key { get; set; }
            public System.String S3ObjectVersion { get; set; }
            public System.IO.MemoryStream ZipFile { get; set; }
        }
        
    }
}
