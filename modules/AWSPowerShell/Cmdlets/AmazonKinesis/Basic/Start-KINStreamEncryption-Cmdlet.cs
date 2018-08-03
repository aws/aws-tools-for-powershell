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
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Enables or updates server-side encryption using an AWS KMS key for a specified stream.
    /// 
    /// 
    ///  
    /// <para>
    /// Starting encryption is an asynchronous operation. Upon receiving the request, Kinesis
    /// Data Streams returns immediately and sets the status of the stream to <code>UPDATING</code>.
    /// After the update is complete, Kinesis Data Streams sets the status of the stream back
    /// to <code>ACTIVE</code>. Updating or applying encryption normally takes a few seconds
    /// to complete, but it can take minutes. You can continue to read and write data to your
    /// stream while its status is <code>UPDATING</code>. Once the status of the stream is
    /// <code>ACTIVE</code>, encryption begins for records written to the stream. 
    /// </para><para>
    /// API Limits: You can successfully apply a new AWS KMS key for server-side encryption
    /// 25 times in a rolling 24-hour period.
    /// </para><para>
    /// Note: It can take up to 5 seconds after the stream is in an <code>ACTIVE</code> status
    /// before all records written to the stream are encrypted. After you enable encryption,
    /// you can verify that encryption is applied by inspecting the API response from <code>PutRecord</code>
    /// or <code>PutRecords</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "KINStreamEncryption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis StartStreamEncryption API operation.", Operation = new[] {"StartStreamEncryption"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the StreamName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Kinesis.Model.StartStreamEncryptionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartKINStreamEncryptionCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter EncryptionType
        /// <summary>
        /// <para>
        /// <para>The encryption type to use. The only valid value is <code>KMS</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Kinesis.EncryptionType")]
        public Amazon.Kinesis.EncryptionType EncryptionType { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The GUID for the customer-managed AWS KMS key to use for encryption. This value can
        /// be a globally unique identifier, a fully specified Amazon Resource Name (ARN) to either
        /// an alias or a key, or an alias name prefixed by "alias/".You can also use a master
        /// key owned by Kinesis Data Streams by specifying the alias <code>aws/kinesis</code>.</para><ul><li><para>Key ARN example: <code>arn:aws:kms:us-east-1:123456789012:key/12345678-1234-1234-1234-123456789012</code></para></li><li><para>Alias ARN example: <code>arn:aws:kms:us-east-1:123456789012:alias/MyAliasName</code></para></li><li><para>Globally unique key ID example: <code>12345678-1234-1234-1234-123456789012</code></para></li><li><para>Alias name example: <code>alias/MyAliasName</code></para></li><li><para>Master key owned by Kinesis Data Streams: <code>alias/aws/kinesis</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream for which to start encrypting records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the StreamName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StreamName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-KINStreamEncryption (StartStreamEncryption)"))
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
            
            context.EncryptionType = this.EncryptionType;
            context.KeyId = this.KeyId;
            context.StreamName = this.StreamName;
            
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
            var request = new Amazon.Kinesis.Model.StartStreamEncryptionRequest();
            
            if (cmdletContext.EncryptionType != null)
            {
                request.EncryptionType = cmdletContext.EncryptionType;
            }
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.StreamName;
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
        
        #region AWS Service Operation Call
        
        private Amazon.Kinesis.Model.StartStreamEncryptionResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.StartStreamEncryptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "StartStreamEncryption");
            try
            {
                #if DESKTOP
                return client.StartStreamEncryption(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StartStreamEncryptionAsync(request);
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
        
        internal partial class CmdletContext : ExecutorContext
        {
            public Amazon.Kinesis.EncryptionType EncryptionType { get; set; }
            public System.String KeyId { get; set; }
            public System.String StreamName { get; set; }
        }
        
    }
}
