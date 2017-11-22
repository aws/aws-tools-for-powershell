/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Updates the parameter values for stack instances for the specified accounts, within
    /// the specified regions. A stack instance refers to a stack in a specific account and
    /// region. 
    /// 
    ///  
    /// <para>
    /// You can only update stack instances in regions and accounts where they already exist;
    /// to create additional stack instances, use <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_CreateStackInstances.html">CreateStackInstances</a>.
    /// 
    /// </para><para>
    /// During stack set updates, any parameters overridden for a stack instance are not updated,
    /// but retain their overridden value.
    /// </para><para>
    /// You can only update the parameter <i>values</i> that are specified in the stack set;
    /// to add or delete a parameter itself, use <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_UpdateStackSet.html">UpdateStackSet</a>
    /// to update the stack set template. If you add a parameter to a template, before you
    /// can override the parameter value specified in the stack set you must first use <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_UpdateStackSet.html">UpdateStackSet</a>
    /// to update all stack instances with the updated template and parameter value specified
    /// in the stack set. Once a stack instance has been updated with the new parameter, you
    /// can then override the parameter value using <code>UpdateStackInstances</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CFNStackInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation UpdateStackInstances API operation.", Operation = new[] {"UpdateStackInstances"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudFormation.Model.UpdateStackInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCFNStackInstanceCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter Account
        /// <summary>
        /// <para>
        /// <para>The names of one or more AWS accounts for which you want to update parameter values
        /// for stack instances. The overridden parameter values will be applied to all stack
        /// instances in the specified accounts and regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Accounts")]
        public System.String[] Account { get; set; }
        #endregion
        
        #region Parameter OperationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for this stack set operation. </para><para>The operation ID also functions as an idempotency token, to ensure that AWS CloudFormation
        /// performs the stack set operation only once, even if you retry the request multiple
        /// times. You might retry stack set operation requests to ensure that AWS CloudFormation
        /// successfully received them.</para><para>If you don't specify an operation ID, the SDK generates one automatically. </para>
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
        
        #region Parameter ParameterOverride
        /// <summary>
        /// <para>
        /// <para> A list of input parameters whose values you want to update for the specified stack
        /// instances. </para><para>Any overridden parameter values will be applied to all stack instances in the specified
        /// accounts and regions. When specifying parameters and their values, be aware of how
        /// AWS CloudFormation sets parameter values during stack instance update operations:</para><ul><li><para>To override the current value for a parameter, include the parameter and specify its
        /// value.</para></li><li><para>To leave a parameter set to its present value, you can do one of the following:</para><ul><li><para>Do not include the parameter in the list.</para></li><li><para>Include the parameter and specify <code>UsePreviousValue</code> as <code>true</code>.
        /// (You cannot specify both a value and set <code>UsePreviousValue</code> to <code>true</code>.)</para></li></ul></li><li><para>To set all overridden parameter back to the values specified in the stack set, specify
        /// a parameter list but do not include any parameters.</para></li><li><para>To leave all parameters set to their present values, do not specify this property
        /// at all.</para></li></ul><para>During stack set updates, any parameter values overridden for a stack instance are
        /// not updated, but retain their overridden value.</para><para>You can only override the parameter <i>values</i> that are specified in the stack
        /// set; to add or delete a parameter itself, use <code>UpdateStackSet</code> to update
        /// the stack set template. If you add a parameter to a template, before you can override
        /// the parameter value specified in the stack set you must first use <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_UpdateStackSet.html">UpdateStackSet</a>
        /// to update all stack instances with the updated template and parameter value specified
        /// in the stack set. Once a stack instance has been updated with the new parameter, you
        /// can then override the parameter value using <code>UpdateStackInstances</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ParameterOverrides")]
        public Amazon.CloudFormation.Model.Parameter[] ParameterOverride { get; set; }
        #endregion
        
        #region Parameter StackInstanceRegion
        /// <summary>
        /// <para>
        /// <para>The names of one or more regions in which you want to update parameter values for
        /// stack instances. The overridden parameter values will be applied to all stack instances
        /// in the specified accounts and regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] StackInstanceRegion { get; set; }
        #endregion
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name or unique ID of the stack set associated with the stack instances.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFNStackInstance (UpdateStackInstances)"))
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
            if (this.ParameterOverride != null)
            {
                context.ParameterOverrides = new List<Amazon.CloudFormation.Model.Parameter>(this.ParameterOverride);
            }
            if (this.StackInstanceRegion != null)
            {
                context.StackInstanceRegion = new List<System.String>(this.StackInstanceRegion);
            }
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
            var request = new Amazon.CloudFormation.Model.UpdateStackInstancesRequest();
            
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
            if (cmdletContext.ParameterOverrides != null)
            {
                request.ParameterOverrides = cmdletContext.ParameterOverrides;
            }
            if (cmdletContext.StackInstanceRegion != null)
            {
                request.Regions = cmdletContext.StackInstanceRegion;
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
        
        private Amazon.CloudFormation.Model.UpdateStackInstancesResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.UpdateStackInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "UpdateStackInstances");
            try
            {
                #if DESKTOP
                return client.UpdateStackInstances(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateStackInstancesAsync(request);
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
            public List<System.String> Accounts { get; set; }
            public System.String OperationId { get; set; }
            public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreferences { get; set; }
            public List<Amazon.CloudFormation.Model.Parameter> ParameterOverrides { get; set; }
            public List<System.String> StackInstanceRegion { get; set; }
            public System.String StackSetName { get; set; }
        }
        
    }
}
