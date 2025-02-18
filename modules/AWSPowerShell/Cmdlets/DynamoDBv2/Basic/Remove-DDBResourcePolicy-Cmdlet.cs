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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Deletes the resource-based policy attached to the resource, which can be a table or
    /// stream.
    /// 
    ///  
    /// <para><c>DeleteResourcePolicy</c> is an idempotent operation; running it multiple times
    /// on the same resource <i>doesn't</i> result in an error response, unless you specify
    /// an <c>ExpectedRevisionId</c>, which will then return a <c>PolicyNotFoundException</c>.
    /// </para><important><para>
    /// To make sure that you don't inadvertently lock yourself out of your own resources,
    /// the root principal in your Amazon Web Services account can perform <c>DeleteResourcePolicy</c>
    /// requests, even if your resource-based policy explicitly denies the root principal's
    /// access. 
    /// </para></important><note><para><c>DeleteResourcePolicy</c> is an asynchronous operation. If you issue a <c>GetResourcePolicy</c>
    /// request immediately after running the <c>DeleteResourcePolicy</c> request, DynamoDB
    /// might still return the deleted policy. This is because the policy for your resource
    /// might not have been deleted yet. Wait for a few seconds, and then try the <c>GetResourcePolicy</c>
    /// request again.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "DDBResourcePolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon DynamoDB DeleteResourcePolicy API operation.", Operation = new[] {"DeleteResourcePolicy"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.DeleteResourcePolicyResponse))]
    [AWSCmdletOutput("System.String or Amazon.DynamoDBv2.Model.DeleteResourcePolicyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DynamoDBv2.Model.DeleteResourcePolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveDDBResourcePolicyCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExpectedRevisionId
        /// <summary>
        /// <para>
        /// <para>A string value that you can use to conditionally delete your policy. When you provide
        /// an expected revision ID, if the revision ID of the existing policy on the resource
        /// doesn't match or if there's no policy attached to the resource, the request will fail
        /// and return a <c>PolicyNotFoundException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedRevisionId { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the DynamoDB resource from which the policy will
        /// be removed. The resources you can specify include tables and streams. If you remove
        /// the policy of a table, it will also remove the permissions for the table's indexes
        /// defined in that policy document. This is because index permissions are defined in
        /// the table's policy.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RevisionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.DeleteResourcePolicyResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.DeleteResourcePolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RevisionId";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-DDBResourcePolicy (DeleteResourcePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.DeleteResourcePolicyResponse, RemoveDDBResourcePolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExpectedRevisionId = this.ExpectedRevisionId;
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DynamoDBv2.Model.DeleteResourcePolicyRequest();
            
            if (cmdletContext.ExpectedRevisionId != null)
            {
                request.ExpectedRevisionId = cmdletContext.ExpectedRevisionId;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
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
        
        private Amazon.DynamoDBv2.Model.DeleteResourcePolicyResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.DeleteResourcePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "DeleteResourcePolicy");
            try
            {
                return client.DeleteResourcePolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ExpectedRevisionId { get; set; }
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.DeleteResourcePolicyResponse, RemoveDDBResourcePolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RevisionId;
        }
        
    }
}
