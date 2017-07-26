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
    /// Updates the stack set and <i>all</i> associated stack instances.
    /// 
    ///  
    /// <para>
    /// Even if the stack set operation created by updating the stack set fails (completely
    /// or partially, below or above a specified failure tolerance), the stack set is updated
    /// with your changes. Subsequent <a>CreateStackInstances</a> calls on the specified stack
    /// set use the updated stack set.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CFNStackSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateStackSet operation against AWS CloudFormation.", Operation = new[] {"UpdateStackSet"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudFormation.Model.UpdateStackSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCFNStackSetCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter Capability
        /// <summary>
        /// <para>
        /// <para>A list of values that you must specify before AWS CloudFormation can create certain
        /// stack sets. Some stack set templates might include resources that can affect permissions
        /// in your AWS account—for example, by creating new AWS Identity and Access Management
        /// (IAM) users. For those stack sets, you must explicitly acknowledge their capabilities
        /// by specifying this parameter.</para><para>The only valid values are CAPABILITY_IAM and CAPABILITY_NAMED_IAM. The following resources
        /// require you to specify this parameter: </para><ul><li><para>AWS::IAM::AccessKey</para></li><li><para>AWS::IAM::Group</para></li><li><para>AWS::IAM::InstanceProfile</para></li><li><para>AWS::IAM::Policy</para></li><li><para>AWS::IAM::Role</para></li><li><para>AWS::IAM::User</para></li><li><para>AWS::IAM::UserToGroupAddition</para></li></ul><para>If your stack template contains these resources, we recommend that you review all
        /// permissions that are associated with them and edit their permissions if necessary.</para><para>If you have IAM resources, you can specify either capability. If you have IAM resources
        /// with custom names, you must specify CAPABILITY_NAMED_IAM. If you don't specify this
        /// parameter, this action returns an <code>InsufficientCapabilities</code> error.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-iam-template.html#capabilities">Acknowledging
        /// IAM Resources in AWS CloudFormation Templates.</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Capabilities")]
        public System.String[] Capability { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A brief description of updates that you are making.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter OperationId
        /// <summary>
        /// <para>
        /// <para>The unique ID for this stack set operation. </para><para>The operation ID also functions as an idempotency token, to ensure that AWS CloudFormation
        /// performs the stack set operation only once, even if you retry the request multiple
        /// times. You might retry stack set operation requests to ensure that AWS CloudFormation
        /// successfully received them.</para><para>If you don't specify an operation ID, AWS CloudFormation generates one automatically.</para><para>Repeating this stack set operation with a new operation ID retries all stack instances
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
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of input parameters for the stack set template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Parameters")]
        public Amazon.CloudFormation.Model.Parameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name or unique ID of the stack set that you want to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StackSetName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pairs to associate with this stack set and the stacks created from it.
        /// AWS CloudFormation also propagates these tags to supported resources that are created
        /// in the stacks. You can specify a maximum number of 50 tags.</para><para>If you specify tags for this parameter, those tags replace any list of tags that are
        /// currently associated with this stack set. This means:</para><ul><li><para>If you don't specify this parameter, AWS CloudFormation doesn't modify the stack's
        /// tags. </para></li><li><para>If you specify <i>any</i> tags using this parameter, you must specify <i>all</i> the
        /// tags that you want associated with this stack set, even tags you've specifed before
        /// (for example, when creating the stack set or during a previous update of the stack
        /// set.). Any tags that you don't include in the updated list of tags are removed from
        /// the stack set, and therefore from the stacks and resources as well. </para></li><li><para>If you specify an empty value, AWS CloudFormation removes all currently associated
        /// tags.</para></li></ul><para>If you specify new tags as part of an <code>UpdateStackSet</code> action, AWS CloudFormation
        /// checks to see if you have the required IAM permission to tag resources. If you omit
        /// tags that are currently associated with the stack set from the list of tags you specify,
        /// AWS CloudFormation assumes that you want to remove those tags from the stack set,
        /// and checks to see if you have permission to untag resources. If you don't have the
        /// necessary permission(s), the entire <code>UpdateStackSet</code> action fails with
        /// an <code>access denied</code> error, and the stack set is not updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.CloudFormation.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>The structure that contains the template body, with a minimum length of 1 byte and
        /// a maximum length of 51,200 bytes. For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the AWS CloudFormation User Guide.</para><para>Conditional: You must specify only one of the following parameters: <code>TemplateBody</code>
        /// or <code>TemplateURL</code>—or set <code>UsePreviousTemplate</code> to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateURL
        /// <summary>
        /// <para>
        /// <para>The location of the file that contains the template body. The URL must point to a
        /// template (maximum size: 460,800 bytes) that is located in an Amazon S3 bucket. For
        /// more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the AWS CloudFormation User Guide.</para><para>Conditional: You must specify only one of the following parameters: <code>TemplateBody</code>
        /// or <code>TemplateURL</code>—or set <code>UsePreviousTemplate</code> to true. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateURL { get; set; }
        #endregion
        
        #region Parameter UsePreviousTemplate
        /// <summary>
        /// <para>
        /// <para>Use the existing template that's associated with the stack set that you're updating.</para><para>Conditional: You must specify only one of the following parameters: <code>TemplateBody</code>
        /// or <code>TemplateURL</code>—or set <code>UsePreviousTemplate</code> to true. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean UsePreviousTemplate { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFNStackSet (UpdateStackSet)"))
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
            
            if (this.Capability != null)
            {
                context.Capabilities = new List<System.String>(this.Capability);
            }
            context.Description = this.Description;
            context.OperationId = this.OperationId;
            context.OperationPreferences = this.OperationPreference;
            if (this.Parameter != null)
            {
                context.Parameters = new List<Amazon.CloudFormation.Model.Parameter>(this.Parameter);
            }
            context.StackSetName = this.StackSetName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.CloudFormation.Model.Tag>(this.Tag);
            }
            context.TemplateBody = this.TemplateBody;
            context.TemplateURL = this.TemplateURL;
            if (ParameterWasBound("UsePreviousTemplate"))
                context.UsePreviousTemplate = this.UsePreviousTemplate;
            
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
            var request = new Amazon.CloudFormation.Model.UpdateStackSetRequest();
            
            if (cmdletContext.Capabilities != null)
            {
                request.Capabilities = cmdletContext.Capabilities;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.OperationId != null)
            {
                request.OperationId = cmdletContext.OperationId;
            }
            if (cmdletContext.OperationPreferences != null)
            {
                request.OperationPreferences = cmdletContext.OperationPreferences;
            }
            if (cmdletContext.Parameters != null)
            {
                request.Parameters = cmdletContext.Parameters;
            }
            if (cmdletContext.StackSetName != null)
            {
                request.StackSetName = cmdletContext.StackSetName;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.TemplateBody != null)
            {
                request.TemplateBody = cmdletContext.TemplateBody;
            }
            if (cmdletContext.TemplateURL != null)
            {
                request.TemplateURL = cmdletContext.TemplateURL;
            }
            if (cmdletContext.UsePreviousTemplate != null)
            {
                request.UsePreviousTemplate = cmdletContext.UsePreviousTemplate.Value;
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
        
        private Amazon.CloudFormation.Model.UpdateStackSetResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.UpdateStackSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "UpdateStackSet");
            #if DESKTOP
            return client.UpdateStackSet(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateStackSetAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> Capabilities { get; set; }
            public System.String Description { get; set; }
            public System.String OperationId { get; set; }
            public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreferences { get; set; }
            public List<Amazon.CloudFormation.Model.Parameter> Parameters { get; set; }
            public System.String StackSetName { get; set; }
            public List<Amazon.CloudFormation.Model.Tag> Tags { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateURL { get; set; }
            public System.Boolean? UsePreviousTemplate { get; set; }
        }
        
    }
}
