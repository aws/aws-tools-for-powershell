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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Attaches a resource-based policy document to the resource, which can be a table or
    /// stream. When you attach a resource-based policy using this API, the policy application
    /// is <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.ReadConsistency.html"><i>eventually consistent</i></a>.
    /// 
    ///  
    /// <para><c>PutResourcePolicy</c> is an idempotent operation; running it multiple times on
    /// the same resource using the same policy document will return the same revision ID.
    /// If you specify an <c>ExpectedRevisionId</c> that doesn't match the current policy's
    /// <c>RevisionId</c>, the <c>PolicyNotFoundException</c> will be returned.
    /// </para><note><para><c>PutResourcePolicy</c> is an asynchronous operation. If you issue a <c>GetResourcePolicy</c>
    /// request immediately after a <c>PutResourcePolicy</c> request, DynamoDB might return
    /// your previous policy, if there was one, or return the <c>PolicyNotFoundException</c>.
    /// This is because <c>GetResourcePolicy</c> uses an eventually consistent query, and
    /// the metadata for your policy or table might not be available at that moment. Wait
    /// for a few seconds, and then try the <c>GetResourcePolicy</c> request again.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "DDBResourcePolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon DynamoDB PutResourcePolicy API operation.", Operation = new[] {"PutResourcePolicy"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.PutResourcePolicyResponse))]
    [AWSCmdletOutput("System.String or Amazon.DynamoDBv2.Model.PutResourcePolicyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DynamoDBv2.Model.PutResourcePolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteDDBResourcePolicyCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfirmRemoveSelfResourceAccess
        /// <summary>
        /// <para>
        /// <para>Set this parameter to <c>true</c> to confirm that you want to remove your permissions
        /// to change the policy of this resource in the future.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConfirmRemoveSelfResourceAccess { get; set; }
        #endregion
        
        #region Parameter ExpectedRevisionId
        /// <summary>
        /// <para>
        /// <para>A string value that you can use to conditionally update your policy. You can provide
        /// the revision ID of your existing policy to make mutating requests against that policy.</para><note><para>When you provide an expected revision ID, if the revision ID of the existing policy
        /// on the resource doesn't match or if there's no policy attached to the resource, your
        /// request will be rejected with a <c>PolicyNotFoundException</c>.</para></note><para>To conditionally attach a policy when no policy exists for the resource, specify <c>NO_POLICY</c>
        /// for the revision ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedRevisionId { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>An Amazon Web Services resource-based policy document in JSON format.</para><ul><li><para>The maximum size supported for a resource-based policy document is 20 KB. DynamoDB
        /// counts whitespaces when calculating the size of a policy against this limit.</para></li><li><para>Within a resource-based policy, if the action for a DynamoDB service-linked role (SLR)
        /// to replicate data for a global table is denied, adding or deleting a replica will
        /// fail with an error.</para></li></ul><para>For a full list of all considerations that apply while attaching a resource-based
        /// policy, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/rbac-considerations.html">Resource-based
        /// policy considerations</a>.</para>
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
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the DynamoDB resource to which the policy will be
        /// attached. The resources you can specify include tables and streams.</para><para>You can control index permissions using the base table's policy. To specify the same
        /// permission level for your table and its indexes, you can provide both the table and
        /// index Amazon Resource Name (ARN)s in the <c>Resource</c> field of a given <c>Statement</c>
        /// in your policy document. Alternatively, to specify different permissions for your
        /// table, indexes, or both, you can define multiple <c>Statement</c> fields in your policy
        /// document.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.PutResourcePolicyResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.PutResourcePolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RevisionId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-DDBResourcePolicy (PutResourcePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.PutResourcePolicyResponse, WriteDDBResourcePolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConfirmRemoveSelfResourceAccess = this.ConfirmRemoveSelfResourceAccess;
            context.ExpectedRevisionId = this.ExpectedRevisionId;
            context.Policy = this.Policy;
            #if MODULAR
            if (this.Policy == null && ParameterWasBound(nameof(this.Policy)))
            {
                WriteWarning("You are passing $null as a value for parameter Policy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.DynamoDBv2.Model.PutResourcePolicyRequest();
            
            if (cmdletContext.ConfirmRemoveSelfResourceAccess != null)
            {
                request.ConfirmRemoveSelfResourceAccess = cmdletContext.ConfirmRemoveSelfResourceAccess.Value;
            }
            if (cmdletContext.ExpectedRevisionId != null)
            {
                request.ExpectedRevisionId = cmdletContext.ExpectedRevisionId;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
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
        
        private Amazon.DynamoDBv2.Model.PutResourcePolicyResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.PutResourcePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "PutResourcePolicy");
            try
            {
                #if DESKTOP
                return client.PutResourcePolicy(request);
                #elif CORECLR
                return client.PutResourcePolicyAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ConfirmRemoveSelfResourceAccess { get; set; }
            public System.String ExpectedRevisionId { get; set; }
            public System.String Policy { get; set; }
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.PutResourcePolicyResponse, WriteDDBResourcePolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RevisionId;
        }
        
    }
}
