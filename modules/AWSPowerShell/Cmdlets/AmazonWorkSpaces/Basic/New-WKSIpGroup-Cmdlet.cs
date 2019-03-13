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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Creates an IP access control group.
    /// 
    ///  
    /// <para>
    /// An IP access control group provides you with the ability to control the IP addresses
    /// from which users are allowed to access their WorkSpaces. To specify the CIDR address
    /// ranges, add rules to your IP access control group and then associate the group with
    /// your directory. You can add rules when you create the group or at any time using <a>AuthorizeIpRules</a>.
    /// </para><para>
    /// There is a default IP access control group associated with your directory. If you
    /// don't associate an IP access control group with your directory, the default group
    /// is used. The default group includes a default rule that allows users to access their
    /// WorkSpaces from anywhere. You cannot modify the default IP access control group for
    /// your directory.
    /// </para>
    /// </summary>
    [Cmdlet("New", "WKSIpGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon WorkSpaces CreateIpGroup API operation.", Operation = new[] {"CreateIpGroup"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.WorkSpaces.Model.CreateIpGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewWKSIpGroupCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        #region Parameter GroupDesc
        /// <summary>
        /// <para>
        /// <para>The description of the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GroupDesc { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>The name of the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String GroupName { get; set; }
        #endregion
        
        #region Parameter UserRule
        /// <summary>
        /// <para>
        /// <para>The rules to add to the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UserRules")]
        public Amazon.WorkSpaces.Model.IpRuleItem[] UserRule { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WKSIpGroup (CreateIpGroup)"))
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
            
            context.GroupDesc = this.GroupDesc;
            context.GroupName = this.GroupName;
            if (this.UserRule != null)
            {
                context.UserRules = new List<Amazon.WorkSpaces.Model.IpRuleItem>(this.UserRule);
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
            var request = new Amazon.WorkSpaces.Model.CreateIpGroupRequest();
            
            if (cmdletContext.GroupDesc != null)
            {
                request.GroupDesc = cmdletContext.GroupDesc;
            }
            if (cmdletContext.GroupName != null)
            {
                request.GroupName = cmdletContext.GroupName;
            }
            if (cmdletContext.UserRules != null)
            {
                request.UserRules = cmdletContext.UserRules;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GroupId;
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
        
        private Amazon.WorkSpaces.Model.CreateIpGroupResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.CreateIpGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "CreateIpGroup");
            try
            {
                #if DESKTOP
                return client.CreateIpGroup(request);
                #elif CORECLR
                return client.CreateIpGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String GroupDesc { get; set; }
            public System.String GroupName { get; set; }
            public List<Amazon.WorkSpaces.Model.IpRuleItem> UserRules { get; set; }
        }
        
    }
}
