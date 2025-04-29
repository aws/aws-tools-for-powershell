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
using Amazon.WorkMailMessageFlow;
using Amazon.WorkMailMessageFlow.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WMMF
{
    /// <summary>
    /// Updates the raw content of an in-transit email message, in MIME format.
    /// 
    ///  
    /// <para>
    /// This example describes how to update in-transit email message. For more information
    /// and examples for using this API, see <a href="https://docs.aws.amazon.com/workmail/latest/adminguide/update-with-lambda.html">
    /// Updating message content with AWS Lambda</a>.
    /// </para><note><para>
    /// Updates to an in-transit message only appear when you call <c>PutRawMessageContent</c>
    /// from an AWS Lambda function configured with a synchronous <a href="https://docs.aws.amazon.com/workmail/latest/adminguide/lambda.html#synchronous-rules">
    /// Run Lambda</a> rule. If you call <c>PutRawMessageContent</c> on a delivered or sent
    /// message, the message remains unchanged, even though <a href="https://docs.aws.amazon.com/workmail/latest/APIReference/API_messageflow_GetRawMessageContent.html">GetRawMessageContent</a>
    /// returns an updated message. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "WMMFRawMessageContent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkMail Message Flow PutRawMessageContent API operation.", Operation = new[] {"PutRawMessageContent"}, SelectReturnType = typeof(Amazon.WorkMailMessageFlow.Model.PutRawMessageContentResponse))]
    [AWSCmdletOutput("None or Amazon.WorkMailMessageFlow.Model.PutRawMessageContentResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkMailMessageFlow.Model.PutRawMessageContentResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteWMMFRawMessageContentCmdlet : AmazonWorkMailMessageFlowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter S3Reference_Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket name.</para>
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
        [Alias("Content_S3Reference_Bucket")]
        public System.String S3Reference_Bucket { get; set; }
        #endregion
        
        #region Parameter S3Reference_Key
        /// <summary>
        /// <para>
        /// <para>The S3 key object name.</para>
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
        [Alias("Content_S3Reference_Key")]
        public System.String S3Reference_Key { get; set; }
        #endregion
        
        #region Parameter MessageId
        /// <summary>
        /// <para>
        /// <para>The identifier of the email message being updated.</para>
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
        public System.String MessageId { get; set; }
        #endregion
        
        #region Parameter S3Reference_ObjectVersion
        /// <summary>
        /// <para>
        /// <para>If you enable versioning for the bucket, you can specify the object version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_S3Reference_ObjectVersion")]
        public System.String S3Reference_ObjectVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkMailMessageFlow.Model.PutRawMessageContentResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MessageId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-WMMFRawMessageContent (PutRawMessageContent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkMailMessageFlow.Model.PutRawMessageContentResponse, WriteWMMFRawMessageContentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.S3Reference_Bucket = this.S3Reference_Bucket;
            #if MODULAR
            if (this.S3Reference_Bucket == null && ParameterWasBound(nameof(this.S3Reference_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Reference_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Reference_Key = this.S3Reference_Key;
            #if MODULAR
            if (this.S3Reference_Key == null && ParameterWasBound(nameof(this.S3Reference_Key)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Reference_Key which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Reference_ObjectVersion = this.S3Reference_ObjectVersion;
            context.MessageId = this.MessageId;
            #if MODULAR
            if (this.MessageId == null && ParameterWasBound(nameof(this.MessageId)))
            {
                WriteWarning("You are passing $null as a value for parameter MessageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkMailMessageFlow.Model.PutRawMessageContentRequest();
            
            
             // populate Content
            var requestContentIsNull = true;
            request.Content = new Amazon.WorkMailMessageFlow.Model.RawMessageContent();
            Amazon.WorkMailMessageFlow.Model.S3Reference requestContent_content_S3Reference = null;
            
             // populate S3Reference
            var requestContent_content_S3ReferenceIsNull = true;
            requestContent_content_S3Reference = new Amazon.WorkMailMessageFlow.Model.S3Reference();
            System.String requestContent_content_S3Reference_s3Reference_Bucket = null;
            if (cmdletContext.S3Reference_Bucket != null)
            {
                requestContent_content_S3Reference_s3Reference_Bucket = cmdletContext.S3Reference_Bucket;
            }
            if (requestContent_content_S3Reference_s3Reference_Bucket != null)
            {
                requestContent_content_S3Reference.Bucket = requestContent_content_S3Reference_s3Reference_Bucket;
                requestContent_content_S3ReferenceIsNull = false;
            }
            System.String requestContent_content_S3Reference_s3Reference_Key = null;
            if (cmdletContext.S3Reference_Key != null)
            {
                requestContent_content_S3Reference_s3Reference_Key = cmdletContext.S3Reference_Key;
            }
            if (requestContent_content_S3Reference_s3Reference_Key != null)
            {
                requestContent_content_S3Reference.Key = requestContent_content_S3Reference_s3Reference_Key;
                requestContent_content_S3ReferenceIsNull = false;
            }
            System.String requestContent_content_S3Reference_s3Reference_ObjectVersion = null;
            if (cmdletContext.S3Reference_ObjectVersion != null)
            {
                requestContent_content_S3Reference_s3Reference_ObjectVersion = cmdletContext.S3Reference_ObjectVersion;
            }
            if (requestContent_content_S3Reference_s3Reference_ObjectVersion != null)
            {
                requestContent_content_S3Reference.ObjectVersion = requestContent_content_S3Reference_s3Reference_ObjectVersion;
                requestContent_content_S3ReferenceIsNull = false;
            }
             // determine if requestContent_content_S3Reference should be set to null
            if (requestContent_content_S3ReferenceIsNull)
            {
                requestContent_content_S3Reference = null;
            }
            if (requestContent_content_S3Reference != null)
            {
                request.Content.S3Reference = requestContent_content_S3Reference;
                requestContentIsNull = false;
            }
             // determine if request.Content should be set to null
            if (requestContentIsNull)
            {
                request.Content = null;
            }
            if (cmdletContext.MessageId != null)
            {
                request.MessageId = cmdletContext.MessageId;
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
        
        private Amazon.WorkMailMessageFlow.Model.PutRawMessageContentResponse CallAWSServiceOperation(IAmazonWorkMailMessageFlow client, Amazon.WorkMailMessageFlow.Model.PutRawMessageContentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkMail Message Flow", "PutRawMessageContent");
            try
            {
                return client.PutRawMessageContentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String S3Reference_Bucket { get; set; }
            public System.String S3Reference_Key { get; set; }
            public System.String S3Reference_ObjectVersion { get; set; }
            public System.String MessageId { get; set; }
            public System.Func<Amazon.WorkMailMessageFlow.Model.PutRawMessageContentResponse, WriteWMMFRawMessageContentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
