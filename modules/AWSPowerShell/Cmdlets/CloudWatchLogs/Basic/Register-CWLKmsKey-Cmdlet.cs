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
    /// Associates the specified KMS key with either one log group in the account, or with
    /// all stored CloudWatch Logs query insights results in the account.
    /// 
    ///  
    /// <para>
    /// When you use <c>AssociateKmsKey</c>, you specify either the <c>logGroupName</c> parameter
    /// or the <c>resourceIdentifier</c> parameter. You can't specify both of those parameters
    /// in the same operation.
    /// </para><ul><li><para>
    /// Specify the <c>logGroupName</c> parameter to cause all log events stored in the log
    /// group to be encrypted with that key. Only the log events ingested after the key is
    /// associated are encrypted with that key.
    /// </para><para>
    /// Associating a KMS key with a log group overrides any existing associations between
    /// the log group and a KMS key. After a KMS key is associated with a log group, all newly
    /// ingested data for the log group is encrypted using the KMS key. This association is
    /// stored as long as the data encrypted with the KMS key is still within CloudWatch Logs.
    /// This enables CloudWatch Logs to decrypt this data whenever it is requested.
    /// </para><para>
    /// Associating a key with a log group does not cause the results of queries of that log
    /// group to be encrypted with that key. To have query results encrypted with a KMS key,
    /// you must use an <c>AssociateKmsKey</c> operation with the <c>resourceIdentifier</c>
    /// parameter that specifies a <c>query-result</c> resource. 
    /// </para></li><li><para>
    /// Specify the <c>resourceIdentifier</c> parameter with a <c>query-result</c> resource,
    /// to use that key to encrypt the stored results of all future <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_StartQuery.html">StartQuery</a>
    /// operations in the account. The response from a <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_GetQueryResults.html">GetQueryResults</a>
    /// operation will still return the query results in plain text.
    /// </para><para>
    /// Even if you have not associated a key with your query results, the query results are
    /// encrypted when stored, using the default CloudWatch Logs method.
    /// </para><para>
    /// If you run a query from a monitoring account that queries logs in a source account,
    /// the query results key from the monitoring account, if any, is used.
    /// </para></li></ul><important><para>
    /// If you delete the key that is used to encrypt log events or log group query results,
    /// then all the associated stored log events or query results that were encrypted with
    /// that key will be unencryptable and unusable.
    /// </para></important><note><para>
    /// CloudWatch Logs supports only symmetric KMS keys. Do not use an associate an asymmetric
    /// KMS key with your log group or query results. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html">Using
    /// Symmetric and Asymmetric Keys</a>.
    /// </para></note><para>
    /// It can take up to 5 minutes for this operation to take effect.
    /// </para><para>
    /// If you attempt to associate a KMS key with a log group but the KMS key does not exist
    /// or the KMS key is disabled, you receive an <c>InvalidParameterException</c> error.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Register", "CWLKmsKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs AssociateKmsKey API operation.", Operation = new[] {"AssociateKmsKey"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.AssociateKmsKeyResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatchLogs.Model.AssociateKmsKeyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatchLogs.Model.AssociateKmsKeyResponse) be returned by specifying '-Select *'."
    )]
    public partial class RegisterCWLKmsKeyCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key to use when encrypting log data. This
        /// must be a symmetric KMS key. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-kms">Amazon
        /// Resource Names</a> and <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html">Using
        /// Symmetric and Asymmetric Keys</a>.</para>
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
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group.</para><para>In your <c>AssociateKmsKey</c> operation, you must specify either the <c>resourceIdentifier</c>
        /// parameter or the <c>logGroup</c> parameter, but you can't specify both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>Specifies the target for this operation. You must specify one of the following:</para><ul><li><para>Specify the following ARN to have future <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_GetQueryResults.html">GetQueryResults</a>
        /// operations in this account encrypt the results with the specified KMS key. Replace
        /// <i>REGION</i> and <i>ACCOUNT_ID</i> with your Region and account ID.</para><para><c>arn:aws:logs:<i>REGION</i>:<i>ACCOUNT_ID</i>:query-result:*</c></para></li><li><para>Specify the ARN of a log group to have CloudWatch Logs use the KMS key to encrypt
        /// log events that are ingested and stored by that log group. The log group ARN must
        /// be in the following format. Replace <i>REGION</i> and <i>ACCOUNT_ID</i> with your
        /// Region and account ID.</para><para><c>arn:aws:logs:<i>REGION</i>:<i>ACCOUNT_ID</i>:log-group:<i>LOG_GROUP_NAME</i></c></para></li></ul><para>In your <c>AssociateKmsKey</c> operation, you must specify either the <c>resourceIdentifier</c>
        /// parameter or the <c>logGroup</c> parameter, but you can't specify both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.AssociateKmsKeyResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KmsKeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-CWLKmsKey (AssociateKmsKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.AssociateKmsKeyResponse, RegisterCWLKmsKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KmsKeyId = this.KmsKeyId;
            #if MODULAR
            if (this.KmsKeyId == null && ParameterWasBound(nameof(this.KmsKeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KmsKeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.CloudWatchLogs.Model.AssociateKmsKeyRequest();
            
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
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
        
        private Amazon.CloudWatchLogs.Model.AssociateKmsKeyResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.AssociateKmsKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "AssociateKmsKey");
            try
            {
                #if DESKTOP
                return client.AssociateKmsKey(request);
                #elif CORECLR
                return client.AssociateKmsKeyAsync(request).GetAwaiter().GetResult();
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
            public System.String KmsKeyId { get; set; }
            public System.String LogGroupName { get; set; }
            public System.String ResourceIdentifier { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.AssociateKmsKeyResponse, RegisterCWLKmsKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
