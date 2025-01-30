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
using Amazon.WorkMail;
using Amazon.WorkMail.Model;

namespace Amazon.PowerShell.Cmdlets.WM
{
    /// <summary>
    /// Adds a new access control rule for the specified organization. The rule allows or
    /// denies access to the organization for the specified IPv4 addresses, access protocol
    /// actions, user IDs and impersonation IDs. Adding a new rule with the same name as an
    /// existing rule replaces the older rule.
    /// </summary>
    [Cmdlet("Write", "WMAccessControlRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkMail PutAccessControlRule API operation.", Operation = new[] {"PutAccessControlRule"}, SelectReturnType = typeof(Amazon.WorkMail.Model.PutAccessControlRuleResponse))]
    [AWSCmdletOutput("None or Amazon.WorkMail.Model.PutAccessControlRuleResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkMail.Model.PutAccessControlRuleResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteWMAccessControlRuleCmdlet : AmazonWorkMailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>Access protocol actions to include in the rule. Valid values include <c>ActiveSync</c>,
        /// <c>AutoDiscover</c>, <c>EWS</c>, <c>IMAP</c>, <c>SMTP</c>, <c>WindowsOutlook</c>,
        /// and <c>WebMail</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Actions")]
        public System.String[] Action { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The rule description.</para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Effect
        /// <summary>
        /// <para>
        /// <para>The rule effect.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WorkMail.AccessControlRuleEffect")]
        public Amazon.WorkMail.AccessControlRuleEffect Effect { get; set; }
        #endregion
        
        #region Parameter ImpersonationRoleId
        /// <summary>
        /// <para>
        /// <para>Impersonation role IDs to include in the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImpersonationRoleIds")]
        public System.String[] ImpersonationRoleId { get; set; }
        #endregion
        
        #region Parameter IpRange
        /// <summary>
        /// <para>
        /// <para>IPv4 CIDR ranges to include in the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IpRanges")]
        public System.String[] IpRange { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The rule name.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NotAction
        /// <summary>
        /// <para>
        /// <para>Access protocol actions to exclude from the rule. Valid values include <c>ActiveSync</c>,
        /// <c>AutoDiscover</c>, <c>EWS</c>, <c>IMAP</c>, <c>SMTP</c>, <c>WindowsOutlook</c>,
        /// and <c>WebMail</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotActions")]
        public System.String[] NotAction { get; set; }
        #endregion
        
        #region Parameter NotImpersonationRoleId
        /// <summary>
        /// <para>
        /// <para>Impersonation role IDs to exclude from the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotImpersonationRoleIds")]
        public System.String[] NotImpersonationRoleId { get; set; }
        #endregion
        
        #region Parameter NotIpRange
        /// <summary>
        /// <para>
        /// <para>IPv4 CIDR ranges to exclude from the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotIpRanges")]
        public System.String[] NotIpRange { get; set; }
        #endregion
        
        #region Parameter NotUserId
        /// <summary>
        /// <para>
        /// <para>User IDs to exclude from the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotUserIds")]
        public System.String[] NotUserId { get; set; }
        #endregion
        
        #region Parameter OrganizationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the organization.</para>
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
        public System.String OrganizationId { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>User IDs to include in the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserIds")]
        public System.String[] UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkMail.Model.PutAccessControlRuleResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-WMAccessControlRule (PutAccessControlRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkMail.Model.PutAccessControlRuleResponse, WriteWMAccessControlRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Action != null)
            {
                context.Action = new List<System.String>(this.Action);
            }
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Effect = this.Effect;
            #if MODULAR
            if (this.Effect == null && ParameterWasBound(nameof(this.Effect)))
            {
                WriteWarning("You are passing $null as a value for parameter Effect which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ImpersonationRoleId != null)
            {
                context.ImpersonationRoleId = new List<System.String>(this.ImpersonationRoleId);
            }
            if (this.IpRange != null)
            {
                context.IpRange = new List<System.String>(this.IpRange);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NotAction != null)
            {
                context.NotAction = new List<System.String>(this.NotAction);
            }
            if (this.NotImpersonationRoleId != null)
            {
                context.NotImpersonationRoleId = new List<System.String>(this.NotImpersonationRoleId);
            }
            if (this.NotIpRange != null)
            {
                context.NotIpRange = new List<System.String>(this.NotIpRange);
            }
            if (this.NotUserId != null)
            {
                context.NotUserId = new List<System.String>(this.NotUserId);
            }
            context.OrganizationId = this.OrganizationId;
            #if MODULAR
            if (this.OrganizationId == null && ParameterWasBound(nameof(this.OrganizationId)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UserId != null)
            {
                context.UserId = new List<System.String>(this.UserId);
            }
            
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
            var request = new Amazon.WorkMail.Model.PutAccessControlRuleRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Actions = cmdletContext.Action;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Effect != null)
            {
                request.Effect = cmdletContext.Effect;
            }
            if (cmdletContext.ImpersonationRoleId != null)
            {
                request.ImpersonationRoleIds = cmdletContext.ImpersonationRoleId;
            }
            if (cmdletContext.IpRange != null)
            {
                request.IpRanges = cmdletContext.IpRange;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NotAction != null)
            {
                request.NotActions = cmdletContext.NotAction;
            }
            if (cmdletContext.NotImpersonationRoleId != null)
            {
                request.NotImpersonationRoleIds = cmdletContext.NotImpersonationRoleId;
            }
            if (cmdletContext.NotIpRange != null)
            {
                request.NotIpRanges = cmdletContext.NotIpRange;
            }
            if (cmdletContext.NotUserId != null)
            {
                request.NotUserIds = cmdletContext.NotUserId;
            }
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserIds = cmdletContext.UserId;
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
        
        private Amazon.WorkMail.Model.PutAccessControlRuleResponse CallAWSServiceOperation(IAmazonWorkMail client, Amazon.WorkMail.Model.PutAccessControlRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkMail", "PutAccessControlRule");
            try
            {
                #if DESKTOP
                return client.PutAccessControlRule(request);
                #elif CORECLR
                return client.PutAccessControlRuleAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Action { get; set; }
            public System.String Description { get; set; }
            public Amazon.WorkMail.AccessControlRuleEffect Effect { get; set; }
            public List<System.String> ImpersonationRoleId { get; set; }
            public List<System.String> IpRange { get; set; }
            public System.String Name { get; set; }
            public List<System.String> NotAction { get; set; }
            public List<System.String> NotImpersonationRoleId { get; set; }
            public List<System.String> NotIpRange { get; set; }
            public List<System.String> NotUserId { get; set; }
            public System.String OrganizationId { get; set; }
            public List<System.String> UserId { get; set; }
            public System.Func<Amazon.WorkMail.Model.PutAccessControlRuleResponse, WriteWMAccessControlRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
