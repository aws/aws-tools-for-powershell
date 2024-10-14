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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Disassociates the specified KMS key from the specified log group or from all CloudWatch
    /// Logs Insights query results in the account.
    /// 
    ///  
    /// <para>
    /// When you use <c>DisassociateKmsKey</c>, you specify either the <c>logGroupName</c>
    /// parameter or the <c>resourceIdentifier</c> parameter. You can't specify both of those
    /// parameters in the same operation.
    /// </para><ul><li><para>
    /// Specify the <c>logGroupName</c> parameter to stop using the KMS key to encrypt future
    /// log events ingested and stored in the log group. Instead, they will be encrypted with
    /// the default CloudWatch Logs method. The log events that were ingested while the key
    /// was associated with the log group are still encrypted with that key. Therefore, CloudWatch
    /// Logs will need permissions for the key whenever that data is accessed.
    /// </para></li><li><para>
    /// Specify the <c>resourceIdentifier</c> parameter with the <c>query-result</c> resource
    /// to stop using the KMS key to encrypt the results of all future <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_StartQuery.html">StartQuery</a>
    /// operations in the account. They will instead be encrypted with the default CloudWatch
    /// Logs method. The results from queries that ran while the key was associated with the
    /// account are still encrypted with that key. Therefore, CloudWatch Logs will need permissions
    /// for the key whenever that data is accessed.
    /// </para></li></ul><para>
    /// It can take up to 5 minutes for this operation to take effect.
    /// </para>
    /// </summary>
    [Cmdlet("Unregister", "CWLKmsKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs DisassociateKmsKey API operation.", Operation = new[] {"DisassociateKmsKey"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.DisassociateKmsKeyResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatchLogs.Model.DisassociateKmsKeyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatchLogs.Model.DisassociateKmsKeyResponse) be returned by specifying '-Select *'."
    )]
    public partial class UnregisterCWLKmsKeyCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group.</para><para>In your <c>DisassociateKmsKey</c> operation, you must specify either the <c>resourceIdentifier</c>
        /// parameter or the <c>logGroup</c> parameter, but you can't specify both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>Specifies the target for this operation. You must specify one of the following:</para><ul><li><para>Specify the ARN of a log group to stop having CloudWatch Logs use the KMS key to encrypt
        /// log events that are ingested and stored by that log group. After you run this operation,
        /// CloudWatch Logs encrypts ingested log events with the default CloudWatch Logs method.
        /// The log group ARN must be in the following format. Replace <i>REGION</i> and <i>ACCOUNT_ID</i>
        /// with your Region and account ID.</para><para><c>arn:aws:logs:<i>REGION</i>:<i>ACCOUNT_ID</i>:log-group:<i>LOG_GROUP_NAME</i></c></para></li><li><para>Specify the following ARN to stop using this key to encrypt the results of future
        /// <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_StartQuery.html">StartQuery</a>
        /// operations in this account. Replace <i>REGION</i> and <i>ACCOUNT_ID</i> with your
        /// Region and account ID.</para><para><c>arn:aws:logs:<i>REGION</i>:<i>ACCOUNT_ID</i>:query-result:*</c></para></li></ul><para>In your <c>DisssociateKmsKey</c> operation, you must specify either the <c>resourceIdentifier</c>
        /// parameter or the <c>logGroup</c> parameter, but you can't specify both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.DisassociateKmsKeyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LogGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LogGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LogGroupName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LogGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-CWLKmsKey (DisassociateKmsKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.DisassociateKmsKeyResponse, UnregisterCWLKmsKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LogGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LogGroupName = this.LogGroupName;
            context.ResourceIdentifier = this.ResourceIdentifier;
            
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
            var request = new Amazon.CloudWatchLogs.Model.DisassociateKmsKeyRequest();
            
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.ResourceIdentifier != null)
            {
                request.ResourceIdentifier = cmdletContext.ResourceIdentifier;
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
        
        private Amazon.CloudWatchLogs.Model.DisassociateKmsKeyResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.DisassociateKmsKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "DisassociateKmsKey");
            try
            {
                #if DESKTOP
                return client.DisassociateKmsKey(request);
                #elif CORECLR
                return client.DisassociateKmsKeyAsync(request).GetAwaiter().GetResult();
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
            public System.String LogGroupName { get; set; }
            public System.String ResourceIdentifier { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.DisassociateKmsKeyResponse, UnregisterCWLKmsKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
