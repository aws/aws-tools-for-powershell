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
using Amazon.Inspector;
using Amazon.Inspector.Model;

namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Creates a resource group using the specified set of tags (key and value pairs) that
    /// are used to select the EC2 instances to be included in an Inspector application. The
    /// created resource group is then used to create an Inspector application.
    /// </summary>
    [Cmdlet("New", "INSResourceGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateResourceGroup operation against Amazon Inspector.", Operation = new[] {"CreateResourceGroup"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Inspector.Model.CreateResourceGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewINSResourceGroupCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceGroupTag
        /// <summary>
        /// <para>
        /// <para>A collection of keys and an array of possible values in JSON format.</para><para>For example, [{ "key1" : ["Value1","Value2"]},{"Key2": ["Value3"]}]</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceGroupTags")]
        public System.String ResourceGroupTag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceGroupTag", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-INSResourceGroup (CreateResourceGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ResourceGroupTags = this.ResourceGroupTag;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Inspector.Model.CreateResourceGroupRequest();
            
            if (cmdletContext.ResourceGroupTags != null)
            {
                request.ResourceGroupTags = cmdletContext.ResourceGroupTags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateResourceGroup(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ResourceGroupArn;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ResourceGroupTags { get; set; }
        }
        
    }
}
