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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Adds one or more tags to an IAM role. The role can be a regular role or a service-linked
    /// role. If a tag with the same key name already exists, then that tag is overwritten
    /// with the new value.
    /// 
    ///  
    /// <para>
    /// A tag consists of a key name and an associated value. By assigning tags to your resources,
    /// you can do the following:
    /// </para><ul><li><para><b>Administrative grouping and discovery</b> - Attach tags to resources to aid in
    /// organization and search. For example, you could search for all resources with the
    /// key name <i>Project</i> and the value <i>MyImportantProject</i>. Or search for all
    /// resources with the key name <i>Cost Center</i> and the value <i>41200</i>. 
    /// </para></li><li><para><b>Access control</b> - Reference tags in IAM user-based and resource-based policies.
    /// You can use tags to restrict access to only an IAM user or role that has a specified
    /// tag attached. You can also restrict access to only those resources that have a certain
    /// tag attached. For examples of policies that show how to use tags to control access,
    /// see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/access_tags.html">Control
    /// Access Using IAM Tags</a> in the <i>IAM User Guide</i>.
    /// </para></li><li><para><b>Cost allocation</b> - Use tags to help track which individuals and teams are using
    /// which AWS resources.
    /// </para></li></ul><note><ul><li><para>
    /// Make sure that you have no invalid tags and that you do not exceed the allowed number
    /// of tags per role. In either case, the entire request fails and <i>no</i> tags are
    /// added to the role.
    /// </para></li><li><para>
    /// AWS always interprets the tag <code>Value</code> as a single string. If you need to
    /// store an array, you can store comma-separated values in the string. However, you must
    /// interpret the value in your code.
    /// </para></li></ul></note><para>
    /// For more information about tagging, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_tags.html">Tagging
    /// IAM Identities</a> in the <i>IAM User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "IAMRoleTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Identity and Access Management TagRole API operation.", Operation = new[] {"TagRole"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.IdentityManagement.Model.TagRoleResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddIAMRoleTagCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter RoleName
        /// <summary>
        /// <para>
        /// <para>The name of the role that you want to add tags to.</para><para>This parameter accepts (through its <a href="http://wikipedia.org/wiki/regex">regex
        /// pattern</a>) a string of characters that consist of upper and lowercase alphanumeric
        /// characters with no spaces. You can also include any of the following characters: _+=,.@-</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of tags that you want to attach to the role. Each tag consists of a key name
        /// and an associated value. You can specify this with a JSON string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.IdentityManagement.Model.Tag[] Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RoleName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-IAMRoleTag (TagRole)"))
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
            
            context.RoleName = this.RoleName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.IdentityManagement.Model.Tag>(this.Tag);
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
            var request = new Amazon.IdentityManagement.Model.TagRoleRequest();
            
            if (cmdletContext.RoleName != null)
            {
                request.RoleName = cmdletContext.RoleName;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private Amazon.IdentityManagement.Model.TagRoleResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.TagRoleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "TagRole");
            try
            {
                #if DESKTOP
                return client.TagRole(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.TagRoleAsync(request);
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
            public System.String RoleName { get; set; }
            public List<Amazon.IdentityManagement.Model.Tag> Tags { get; set; }
        }
        
    }
}
