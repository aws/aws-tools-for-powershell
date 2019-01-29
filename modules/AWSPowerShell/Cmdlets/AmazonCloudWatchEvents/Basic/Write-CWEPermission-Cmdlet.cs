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
using Amazon.CloudWatchEvents;
using Amazon.CloudWatchEvents.Model;

namespace Amazon.PowerShell.Cmdlets.CWE
{
    /// <summary>
    /// Running <code>PutPermission</code> permits the specified AWS account or AWS organization
    /// to put events to your account's default <i>event bus</i>. CloudWatch Events rules
    /// in your account are triggered by these events arriving to your default event bus.
    /// 
    /// 
    ///  
    /// <para>
    /// For another account to send events to your account, that external account must have
    /// a CloudWatch Events rule with your account's default event bus as a target.
    /// </para><para>
    /// To enable multiple AWS accounts to put events to your default event bus, run <code>PutPermission</code>
    /// once for each of these accounts. Or, if all the accounts are members of the same AWS
    /// organization, you can run <code>PutPermission</code> once specifying <code>Principal</code>
    /// as "*" and specifying the AWS organization ID in <code>Condition</code>, to grant
    /// permissions to all accounts in that organization.
    /// </para><para>
    /// If you grant permissions using an organization, then accounts in that organization
    /// must specify a <code>RoleArn</code> with proper permissions when they use <code>PutTarget</code>
    /// to add your account's event bus as a target. For more information, see <a href="http://docs.aws.amazon.com/AmazonCloudWatch/latest/events/CloudWatchEvents-CrossAccountEventDelivery.html">Sending
    /// and Receiving Events Between AWS Accounts</a> in the <i>Amazon CloudWatch Events User
    /// Guide</i>.
    /// </para><para>
    /// The permission policy on the default event bus cannot exceed 10 KB in size.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWEPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon CloudWatch Events PutPermission API operation.", Operation = new[] {"PutPermission"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the StatementId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CloudWatchEvents.Model.PutPermissionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCWEPermissionCmdlet : AmazonCloudWatchEventsClientCmdlet, IExecutor
    {
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The action that you are enabling the other account to perform. Currently, this must
        /// be <code>events:PutEvents</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Action { get; set; }
        #endregion
        
        #region Parameter Condition_Key
        /// <summary>
        /// <para>
        /// <para>Specifies the key for the condition. Currently the only supported key is <code>aws:PrincipalOrgID</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Condition_Key { get; set; }
        #endregion
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>The 12-digit AWS account ID that you are permitting to put events to your default
        /// event bus. Specify "*" to permit any account to put events to your default event bus.</para><para>If you specify "*" without specifying <code>Condition</code>, avoid creating rules
        /// that may match undesirable events. To create more secure rules, make sure that the
        /// event pattern for each rule contains an <code>account</code> field with a specific
        /// account ID from which to receive events. Rules with an account field do not match
        /// any events sent from other accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Principal { get; set; }
        #endregion
        
        #region Parameter StatementId
        /// <summary>
        /// <para>
        /// <para>An identifier string for the external account that you are granting permissions to.
        /// If you later want to revoke the permission for this external account, specify this
        /// <code>StatementId</code> when you run <a>RemovePermission</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StatementId { get; set; }
        #endregion
        
        #region Parameter Condition_Type
        /// <summary>
        /// <para>
        /// <para>Specifies the type of condition. Currently the only supported value is <code>StringEquals</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Condition_Type { get; set; }
        #endregion
        
        #region Parameter Condition_Value
        /// <summary>
        /// <para>
        /// <para>Specifies the value for the key. Currently, this must be the ID of the organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Condition_Value { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the StatementId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StatementId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWEPermission (PutPermission)"))
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
            
            context.Action = this.Action;
            context.Condition_Key = this.Condition_Key;
            context.Condition_Type = this.Condition_Type;
            context.Condition_Value = this.Condition_Value;
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
            var request = new Amazon.CloudWatchEvents.Model.PutPermissionRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            
             // populate Condition
            bool requestConditionIsNull = true;
            request.Condition = new Amazon.CloudWatchEvents.Model.Condition();
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.StatementId;
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
        
        private Amazon.CloudWatchEvents.Model.PutPermissionResponse CallAWSServiceOperation(IAmazonCloudWatchEvents client, Amazon.CloudWatchEvents.Model.PutPermissionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Events", "PutPermission");
            try
            {
                #if DESKTOP
                return client.PutPermission(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutPermissionAsync(request);
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
            public System.String Action { get; set; }
            public System.String Condition_Key { get; set; }
            public System.String Condition_Type { get; set; }
            public System.String Condition_Value { get; set; }
            public System.String Principal { get; set; }
            public System.String StatementId { get; set; }
        }
        
    }
}
