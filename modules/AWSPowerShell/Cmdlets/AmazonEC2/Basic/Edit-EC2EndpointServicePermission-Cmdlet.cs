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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the permissions for your VPC endpoint service. You can add or remove permissions
    /// for service consumers (IAM users, IAM roles, and AWS accounts) to discover your endpoint
    /// service.
    /// </summary>
    [Cmdlet("Edit", "EC2EndpointServicePermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud ModifyVpcEndpointServicePermissions API operation.", Operation = new[] {"ModifyVpcEndpointServicePermissions"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
        "The service call response (type Amazon.EC2.Model.ModifyVpcEndpointServicePermissionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2EndpointServicePermissionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AddAllowedPrincipal
        /// <summary>
        /// <para>
        /// <para>One or more Amazon Resource Names (ARNs) of principals for which to allow permission.
        /// Specify <code>*</code> to allow all principals.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AddAllowedPrincipals")]
        public System.String[] AddAllowedPrincipal { get; set; }
        #endregion
        
        #region Parameter RemoveAllowedPrincipal
        /// <summary>
        /// <para>
        /// <para>One or more Amazon Resource Names (ARNs) of principals for which to remove permission.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RemoveAllowedPrincipals")]
        public System.String[] RemoveAllowedPrincipal { get; set; }
        #endregion
        
        #region Parameter ServiceId
        /// <summary>
        /// <para>
        /// <para>The ID of the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ServiceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2EndpointServicePermission (ModifyVpcEndpointServicePermissions)"))
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
            
            if (this.AddAllowedPrincipal != null)
            {
                context.AddAllowedPrincipals = new List<System.String>(this.AddAllowedPrincipal);
            }
            if (this.RemoveAllowedPrincipal != null)
            {
                context.RemoveAllowedPrincipals = new List<System.String>(this.RemoveAllowedPrincipal);
            }
            context.ServiceId = this.ServiceId;
            
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
            var request = new Amazon.EC2.Model.ModifyVpcEndpointServicePermissionsRequest();
            
            if (cmdletContext.AddAllowedPrincipals != null)
            {
                request.AddAllowedPrincipals = cmdletContext.AddAllowedPrincipals;
            }
            if (cmdletContext.RemoveAllowedPrincipals != null)
            {
                request.RemoveAllowedPrincipals = cmdletContext.RemoveAllowedPrincipals;
            }
            if (cmdletContext.ServiceId != null)
            {
                request.ServiceId = cmdletContext.ServiceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ReturnValue;
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
        
        private Amazon.EC2.Model.ModifyVpcEndpointServicePermissionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVpcEndpointServicePermissionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ModifyVpcEndpointServicePermissions");
            try
            {
                #if DESKTOP
                return client.ModifyVpcEndpointServicePermissions(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyVpcEndpointServicePermissionsAsync(request);
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
            public List<System.String> AddAllowedPrincipals { get; set; }
            public List<System.String> RemoveAllowedPrincipals { get; set; }
            public System.String ServiceId { get; set; }
        }
        
    }
}
