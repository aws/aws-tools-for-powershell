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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Deletes stack instances for the specified accounts, in the specified regions.
    /// </summary>
    [Cmdlet("Remove", "CFNStackInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation DeleteStackInstances API operation.", Operation = new[] {"DeleteStackInstances"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudFormation.Model.DeleteStackInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveCFNStackInstanceCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter Account
        /// <summary>
        /// <para>
        /// <para>The names of the AWS accounts that you want to delete stack instances for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Accounts")]
        public System.String[] Account { get; set; }
        #endregion
        
        #region Parameter OperationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for this stack set operation. </para><para>If you don't specify an operation ID, the SDK generates one automatically. </para><para>The operation ID also functions as an idempotency token, to ensure that AWS CloudFormation
        /// performs the stack set operation only once, even if you retry the request multiple
        /// times. You can retry stack set operation requests to ensure that AWS CloudFormation
        /// successfully received them.</para><para>Repeating this stack set operation with a new operation ID retries all stack instances
        /// whose status is <code>OUTDATED</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationId { get; set; }
        #endregion
        
        #region Parameter OperationPreference
        /// <summary>
        /// <para>
        /// <para>Preferences for how AWS CloudFormation performs this stack set operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OperationPreferences")]
        public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreference { get; set; }
        #endregion
        
        #region Parameter StackInstanceRegion
        /// <summary>
        /// <para>
        /// <para>The regions where you want to delete stack set instances. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] StackInstanceRegion { get; set; }
        #endregion
        
        #region Parameter RetainStack
        /// <summary>
        /// <para>
        /// <para>Removes the stack instances from the specified stack set, but doesn't delete the stacks.
        /// You can't reassociate a retained stack or add an existing, saved stack to a new stack
        /// set.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-concepts.html#stackset-ops-options">Stack
        /// set operation options</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RetainStacks")]
        public System.Boolean RetainStack { get; set; }
        #endregion
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name or unique ID of the stack set that you want to delete stack instances for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StackSetName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StackSetName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CFNStackInstance (DeleteStackInstances)"))
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
            
            if (this.Account != null)
            {
                context.Accounts = new List<System.String>(this.Account);
            }
            context.OperationId = this.OperationId;
            context.OperationPreferences = this.OperationPreference;
            if (this.StackInstanceRegion != null)
            {
                context.StackInstanceRegion = new List<System.String>(this.StackInstanceRegion);
            }
            if (ParameterWasBound("RetainStack"))
                context.RetainStacks = this.RetainStack;
            context.StackSetName = this.StackSetName;
            
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
            var request = new Amazon.CloudFormation.Model.DeleteStackInstancesRequest();
            
            if (cmdletContext.Accounts != null)
            {
                request.Accounts = cmdletContext.Accounts;
            }
            if (cmdletContext.OperationId != null)
            {
                request.OperationId = cmdletContext.OperationId;
            }
            if (cmdletContext.OperationPreferences != null)
            {
                request.OperationPreferences = cmdletContext.OperationPreferences;
            }
            if (cmdletContext.StackInstanceRegion != null)
            {
                request.Regions = cmdletContext.StackInstanceRegion;
            }
            if (cmdletContext.RetainStacks != null)
            {
                request.RetainStacks = cmdletContext.RetainStacks.Value;
            }
            if (cmdletContext.StackSetName != null)
            {
                request.StackSetName = cmdletContext.StackSetName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.OperationId;
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
        
        private Amazon.CloudFormation.Model.DeleteStackInstancesResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.DeleteStackInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "DeleteStackInstances");
            try
            {
                #if DESKTOP
                return client.DeleteStackInstances(request);
                #elif CORECLR
                return client.DeleteStackInstancesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Accounts { get; set; }
            public System.String OperationId { get; set; }
            public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreferences { get; set; }
            public List<System.String> StackInstanceRegion { get; set; }
            public System.Boolean? RetainStacks { get; set; }
            public System.String StackSetName { get; set; }
        }
        
    }
}
