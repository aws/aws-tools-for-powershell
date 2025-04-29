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
using Amazon.EventBridge;
using Amazon.EventBridge.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EVB
{
    /// <summary>
    /// Running <c>PutPermission</c> permits the specified Amazon Web Services account or
    /// Amazon Web Services organization to put events to the specified <i>event bus</i>.
    /// Amazon EventBridge rules in your account are triggered by these events arriving to
    /// an event bus in your account. 
    /// 
    ///  
    /// <para>
    /// For another account to send events to your account, that external account must have
    /// an EventBridge rule with your account's event bus as a target.
    /// </para><para>
    /// To enable multiple Amazon Web Services accounts to put events to your event bus, run
    /// <c>PutPermission</c> once for each of these accounts. Or, if all the accounts are
    /// members of the same Amazon Web Services organization, you can run <c>PutPermission</c>
    /// once specifying <c>Principal</c> as "*" and specifying the Amazon Web Services organization
    /// ID in <c>Condition</c>, to grant permissions to all accounts in that organization.
    /// </para><para>
    /// If you grant permissions using an organization, then accounts in that organization
    /// must specify a <c>RoleArn</c> with proper permissions when they use <c>PutTarget</c>
    /// to add your account's event bus as a target. For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eventbridge-cross-account-event-delivery.html">Sending
    /// and Receiving Events Between Amazon Web Services Accounts</a> in the <i>Amazon EventBridge
    /// User Guide</i>.
    /// </para><para>
    /// The permission policy on the event bus cannot exceed 10 KB in size.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "EVBPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon EventBridge PutPermission API operation.", Operation = new[] {"PutPermission"}, SelectReturnType = typeof(Amazon.EventBridge.Model.PutPermissionResponse))]
    [AWSCmdletOutput("None or Amazon.EventBridge.Model.PutPermissionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.EventBridge.Model.PutPermissionResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteEVBPermissionCmdlet : AmazonEventBridgeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The action that you are enabling the other account to perform.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Action { get; set; }
        #endregion
        
        #region Parameter EventBusName
        /// <summary>
        /// <para>
        /// <para>The name of the event bus associated with the rule. If you omit this, the default
        /// event bus is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventBusName { get; set; }
        #endregion
        
        #region Parameter Condition_Key
        /// <summary>
        /// <para>
        /// <para>Specifies the key for the condition. Currently the only supported key is <c>aws:PrincipalOrgID</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Condition_Key { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>A JSON string that describes the permission policy statement. You can include a <c>Policy</c>
        /// parameter in the request instead of using the <c>StatementId</c>, <c>Action</c>, <c>Principal</c>,
        /// or <c>Condition</c> parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>The 12-digit Amazon Web Services account ID that you are permitting to put events
        /// to your default event bus. Specify "*" to permit any account to put events to your
        /// default event bus.</para><para>If you specify "*" without specifying <c>Condition</c>, avoid creating rules that
        /// may match undesirable events. To create more secure rules, make sure that the event
        /// pattern for each rule contains an <c>account</c> field with a specific account ID
        /// from which to receive events. Rules with an account field do not match any events
        /// sent from other accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Principal { get; set; }
        #endregion
        
        #region Parameter StatementId
        /// <summary>
        /// <para>
        /// <para>An identifier string for the external account that you are granting permissions to.
        /// If you later want to revoke the permission for this external account, specify this
        /// <c>StatementId</c> when you run <a href="https://docs.aws.amazon.com/eventbridge/latest/APIReference/API_RemovePermission.html">RemovePermission</a>.</para><note><para>Each <c>StatementId</c> must be unique.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StatementId { get; set; }
        #endregion
        
        #region Parameter Condition_Type
        /// <summary>
        /// <para>
        /// <para>Specifies the type of condition. Currently the only supported value is <c>StringEquals</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Condition_Type { get; set; }
        #endregion
        
        #region Parameter Condition_Value
        /// <summary>
        /// <para>
        /// <para>Specifies the value for the key. Currently, this must be the ID of the organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Condition_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridge.Model.PutPermissionResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StatementId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EVBPermission (PutPermission)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridge.Model.PutPermissionResponse, WriteEVBPermissionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Action = this.Action;
            context.Condition_Key = this.Condition_Key;
            context.Condition_Type = this.Condition_Type;
            context.Condition_Value = this.Condition_Value;
            context.EventBusName = this.EventBusName;
            context.Policy = this.Policy;
            context.Principal = this.Principal;
            context.StatementId = this.StatementId;
            
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
            var request = new Amazon.EventBridge.Model.PutPermissionRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            
             // populate Condition
            var requestConditionIsNull = true;
            request.Condition = new Amazon.EventBridge.Model.Condition();
            System.String requestCondition_condition_Key = null;
            if (cmdletContext.Condition_Key != null)
            {
                requestCondition_condition_Key = cmdletContext.Condition_Key;
            }
            if (requestCondition_condition_Key != null)
            {
                request.Condition.Key = requestCondition_condition_Key;
                requestConditionIsNull = false;
            }
            System.String requestCondition_condition_Type = null;
            if (cmdletContext.Condition_Type != null)
            {
                requestCondition_condition_Type = cmdletContext.Condition_Type;
            }
            if (requestCondition_condition_Type != null)
            {
                request.Condition.Type = requestCondition_condition_Type;
                requestConditionIsNull = false;
            }
            System.String requestCondition_condition_Value = null;
            if (cmdletContext.Condition_Value != null)
            {
                requestCondition_condition_Value = cmdletContext.Condition_Value;
            }
            if (requestCondition_condition_Value != null)
            {
                request.Condition.Value = requestCondition_condition_Value;
                requestConditionIsNull = false;
            }
             // determine if request.Condition should be set to null
            if (requestConditionIsNull)
            {
                request.Condition = null;
            }
            if (cmdletContext.EventBusName != null)
            {
                request.EventBusName = cmdletContext.EventBusName;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.Principal != null)
            {
                request.Principal = cmdletContext.Principal;
            }
            if (cmdletContext.StatementId != null)
            {
                request.StatementId = cmdletContext.StatementId;
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
        
        private Amazon.EventBridge.Model.PutPermissionResponse CallAWSServiceOperation(IAmazonEventBridge client, Amazon.EventBridge.Model.PutPermissionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge", "PutPermission");
            try
            {
                return client.PutPermissionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Action { get; set; }
            public System.String Condition_Key { get; set; }
            public System.String Condition_Type { get; set; }
            public System.String Condition_Value { get; set; }
            public System.String EventBusName { get; set; }
            public System.String Policy { get; set; }
            public System.String Principal { get; set; }
            public System.String StatementId { get; set; }
            public System.Func<Amazon.EventBridge.Model.PutPermissionResponse, WriteEVBPermissionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
