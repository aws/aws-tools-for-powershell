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
using Amazon.RAM;
using Amazon.RAM.Model;

namespace Amazon.PowerShell.Cmdlets.RAM
{
    /// <summary>
    /// When you attach a resource-based policy to a resource, RAM automatically creates a
    /// resource share of <c>featureSet</c>=<c>CREATED_FROM_POLICY</c> with a managed permission
    /// that has the same IAM permissions as the original resource-based policy. However,
    /// this type of managed permission is visible to only the resource share owner, and the
    /// associated resource share can't be modified by using RAM.
    /// 
    ///  
    /// <para>
    /// This operation creates a separate, fully manageable customer managed permission that
    /// has the same IAM permissions as the original resource-based policy. You can associate
    /// this customer managed permission to any resource shares.
    /// </para><para>
    /// Before you use <a>PromoteResourceShareCreatedFromPolicy</a>, you should first run
    /// this operation to ensure that you have an appropriate customer managed permission
    /// that can be associated with the promoted resource share.
    /// </para><note><ul><li><para>
    /// The original <c>CREATED_FROM_POLICY</c> policy isn't deleted, and resource shares
    /// using that original policy aren't automatically updated.
    /// </para></li><li><para>
    /// You can't modify a <c>CREATED_FROM_POLICY</c> resource share so you can't associate
    /// the new customer managed permission by using <c>ReplacePermsissionAssociations</c>.
    /// However, if you use <a>PromoteResourceShareCreatedFromPolicy</a>, that operation automatically
    /// associates the fully manageable customer managed permission to the newly promoted
    /// <c>STANDARD</c> resource share.
    /// </para></li><li><para>
    /// After you promote a resource share, if the original <c>CREATED_FROM_POLICY</c> managed
    /// permission has no other associations to A resource share, then RAM automatically deletes
    /// it.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Convert", "RAMPermissionCreatedFromPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RAM.Model.ResourceSharePermissionSummary")]
    [AWSCmdlet("Calls the AWS Resource Access Manager (RAM) PromotePermissionCreatedFromPolicy API operation.", Operation = new[] {"PromotePermissionCreatedFromPolicy"}, SelectReturnType = typeof(Amazon.RAM.Model.PromotePermissionCreatedFromPolicyResponse))]
    [AWSCmdletOutput("Amazon.RAM.Model.ResourceSharePermissionSummary or Amazon.RAM.Model.PromotePermissionCreatedFromPolicyResponse",
        "This cmdlet returns an Amazon.RAM.Model.ResourceSharePermissionSummary object.",
        "The service call response (type Amazon.RAM.Model.PromotePermissionCreatedFromPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ConvertRAMPermissionCreatedFromPolicyCmdlet : AmazonRAMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies a name for the promoted customer managed permission.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PermissionArn
        /// <summary>
        /// <para>
        /// <para>Specifies the <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of the <c>CREATED_FROM_POLICY</c> permission that you want
        /// to promote. You can get this <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> by calling the <a>ListResourceSharePermissions</a> operation.</para>
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
        public System.String PermissionArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Specifies a unique, case-sensitive identifier that you provide to ensure the idempotency
        /// of the request. This lets you safely retry the request without accidentally performing
        /// the same operation a second time. Passing the same value to a later call to an operation
        /// requires that you also pass the same value for all other parameters. We recommend
        /// that you use a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID
        /// type of value.</a>.</para><para>If you don't provide this value, then Amazon Web Services generates a random one for
        /// you.</para><para>If you retry the operation with the same <c>ClientToken</c>, but with different parameters,
        /// the retry fails with an <c>IdempotentParameterMismatch</c> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Permission'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RAM.Model.PromotePermissionCreatedFromPolicyResponse).
        /// Specifying the name of a property of type Amazon.RAM.Model.PromotePermissionCreatedFromPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Permission";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PermissionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Convert-RAMPermissionCreatedFromPolicy (PromotePermissionCreatedFromPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RAM.Model.PromotePermissionCreatedFromPolicyResponse, ConvertRAMPermissionCreatedFromPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PermissionArn = this.PermissionArn;
            #if MODULAR
            if (this.PermissionArn == null && ParameterWasBound(nameof(this.PermissionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RAM.Model.PromotePermissionCreatedFromPolicyRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PermissionArn != null)
            {
                request.PermissionArn = cmdletContext.PermissionArn;
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
        
        private Amazon.RAM.Model.PromotePermissionCreatedFromPolicyResponse CallAWSServiceOperation(IAmazonRAM client, Amazon.RAM.Model.PromotePermissionCreatedFromPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Access Manager (RAM)", "PromotePermissionCreatedFromPolicy");
            try
            {
                #if DESKTOP
                return client.PromotePermissionCreatedFromPolicy(request);
                #elif CORECLR
                return client.PromotePermissionCreatedFromPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Name { get; set; }
            public System.String PermissionArn { get; set; }
            public System.Func<Amazon.RAM.Model.PromotePermissionCreatedFromPolicyResponse, ConvertRAMPermissionCreatedFromPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Permission;
        }
        
    }
}
