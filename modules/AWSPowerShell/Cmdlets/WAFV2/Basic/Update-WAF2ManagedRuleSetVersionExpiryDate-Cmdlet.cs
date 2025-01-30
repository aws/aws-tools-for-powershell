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
using Amazon.WAFV2;
using Amazon.WAFV2.Model;

namespace Amazon.PowerShell.Cmdlets.WAF2
{
    /// <summary>
    /// Updates the expiration information for your managed rule set. Use this to initiate
    /// the expiration of a managed rule group version. After you initiate expiration for
    /// a version, WAF excludes it from the response to <a>ListAvailableManagedRuleGroupVersions</a>
    /// for the managed rule group. 
    /// 
    ///  <note><para>
    /// This is intended for use only by vendors of managed rule sets. Vendors are Amazon
    /// Web Services and Amazon Web Services Marketplace sellers. 
    /// </para><para>
    /// Vendors, you can use the managed rule set APIs to provide controlled rollout of your
    /// versioned managed rule group offerings for your customers. The APIs are <c>ListManagedRuleSets</c>,
    /// <c>GetManagedRuleSet</c>, <c>PutManagedRuleSetVersions</c>, and <c>UpdateManagedRuleSetVersionExpiryDate</c>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "WAF2ManagedRuleSetVersionExpiryDate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WAFV2.Model.UpdateManagedRuleSetVersionExpiryDateResponse")]
    [AWSCmdlet("Calls the AWS WAF V2 UpdateManagedRuleSetVersionExpiryDate API operation.", Operation = new[] {"UpdateManagedRuleSetVersionExpiryDate"}, SelectReturnType = typeof(Amazon.WAFV2.Model.UpdateManagedRuleSetVersionExpiryDateResponse))]
    [AWSCmdletOutput("Amazon.WAFV2.Model.UpdateManagedRuleSetVersionExpiryDateResponse",
        "This cmdlet returns an Amazon.WAFV2.Model.UpdateManagedRuleSetVersionExpiryDateResponse object containing multiple properties."
    )]
    public partial class UpdateWAF2ManagedRuleSetVersionExpiryDateCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExpiryTimestamp
        /// <summary>
        /// <para>
        /// <para>The time that you want the version to expire.</para><para>Times are in Coordinated Universal Time (UTC) format. UTC format includes the special
        /// designator, Z. For example, "2016-09-27T14:50Z". </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? ExpiryTimestamp { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the managed rule set. The ID is returned in the responses
        /// to commands like <c>list</c>. You provide it to operations like <c>get</c> and <c>update</c>.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter LockToken
        /// <summary>
        /// <para>
        /// <para>A token used for optimistic locking. WAF returns a token to your <c>get</c> and <c>list</c>
        /// requests, to mark the state of the entity at the time of the request. To make changes
        /// to the entity associated with the token, you provide the token to operations like
        /// <c>update</c> and <c>delete</c>. WAF uses the token to ensure that no changes have
        /// been made to the entity since you last retrieved it. If a change has been made, the
        /// update fails with a <c>WAFOptimisticLockException</c>. If this happens, perform another
        /// <c>get</c>, and use the new token returned by that operation. </para>
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
        public System.String LockToken { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the managed rule set. You use this, along with the rule set ID, to identify
        /// the rule set.</para><para>This name is assigned to the corresponding managed rule group, which your customers
        /// can access and use. </para>
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
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>Specifies whether this is for an Amazon CloudFront distribution or for a regional
        /// application. A regional application can be an Application Load Balancer (ALB), an
        /// Amazon API Gateway REST API, an AppSync GraphQL API, an Amazon Cognito user pool,
        /// an App Runner service, or an Amazon Web Services Verified Access instance. </para><para>To work with CloudFront, you must also specify the Region US East (N. Virginia) as
        /// follows: </para><ul><li><para>CLI - Specify the Region when you use the CloudFront scope: <c>--scope=CLOUDFRONT
        /// --region=us-east-1</c>. </para></li><li><para>API and SDKs - For all calls, use the Region endpoint us-east-1. </para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WAFV2.Scope")]
        public Amazon.WAFV2.Scope Scope { get; set; }
        #endregion
        
        #region Parameter VersionToExpire
        /// <summary>
        /// <para>
        /// <para>The version that you want to remove from your list of offerings for the named managed
        /// rule group. </para>
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
        public System.String VersionToExpire { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.UpdateManagedRuleSetVersionExpiryDateResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.UpdateManagedRuleSetVersionExpiryDateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAF2ManagedRuleSetVersionExpiryDate (UpdateManagedRuleSetVersionExpiryDate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.UpdateManagedRuleSetVersionExpiryDateResponse, UpdateWAF2ManagedRuleSetVersionExpiryDateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExpiryTimestamp = this.ExpiryTimestamp;
            #if MODULAR
            if (this.ExpiryTimestamp == null && ParameterWasBound(nameof(this.ExpiryTimestamp)))
            {
                WriteWarning("You are passing $null as a value for parameter ExpiryTimestamp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LockToken = this.LockToken;
            #if MODULAR
            if (this.LockToken == null && ParameterWasBound(nameof(this.LockToken)))
            {
                WriteWarning("You are passing $null as a value for parameter LockToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Scope = this.Scope;
            #if MODULAR
            if (this.Scope == null && ParameterWasBound(nameof(this.Scope)))
            {
                WriteWarning("You are passing $null as a value for parameter Scope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VersionToExpire = this.VersionToExpire;
            #if MODULAR
            if (this.VersionToExpire == null && ParameterWasBound(nameof(this.VersionToExpire)))
            {
                WriteWarning("You are passing $null as a value for parameter VersionToExpire which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAFV2.Model.UpdateManagedRuleSetVersionExpiryDateRequest();
            
            if (cmdletContext.ExpiryTimestamp != null)
            {
                request.ExpiryTimestamp = cmdletContext.ExpiryTimestamp.Value;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.LockToken != null)
            {
                request.LockToken = cmdletContext.LockToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
            }
            if (cmdletContext.VersionToExpire != null)
            {
                request.VersionToExpire = cmdletContext.VersionToExpire;
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
        
        private Amazon.WAFV2.Model.UpdateManagedRuleSetVersionExpiryDateResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.UpdateManagedRuleSetVersionExpiryDateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF V2", "UpdateManagedRuleSetVersionExpiryDate");
            try
            {
                #if DESKTOP
                return client.UpdateManagedRuleSetVersionExpiryDate(request);
                #elif CORECLR
                return client.UpdateManagedRuleSetVersionExpiryDateAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? ExpiryTimestamp { get; set; }
            public System.String Id { get; set; }
            public System.String LockToken { get; set; }
            public System.String Name { get; set; }
            public Amazon.WAFV2.Scope Scope { get; set; }
            public System.String VersionToExpire { get; set; }
            public System.Func<Amazon.WAFV2.Model.UpdateManagedRuleSetVersionExpiryDateResponse, UpdateWAF2ManagedRuleSetVersionExpiryDateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
