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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Deletes a permission for a network interface. By default, you cannot delete the permission
    /// if the account for which you're removing the permission has attached the network interface
    /// to an instance. However, you can force delete the permission, regardless of any attachment.
    /// </summary>
    [Cmdlet("Remove", "EC2NetworkInterfacePermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DeleteNetworkInterfacePermission API operation.", Operation = new[] {"DeleteNetworkInterfacePermission"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
        "The service call response (type Amazon.EC2.Model.DeleteNetworkInterfacePermissionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveEC2NetworkInterfacePermissionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter IgnoreAttachedStatus
        /// <summary>
        /// <para>
        /// <para>Specify <code>true</code> to remove the permission even if the network interface is
        /// attached to an instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean IgnoreAttachedStatus { get; set; }
        #endregion
        
        #region Parameter NetworkInterfacePermissionId
        /// <summary>
        /// <para>
        /// <para>The ID of the network interface permission.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String NetworkInterfacePermissionId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("NetworkInterfacePermissionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2NetworkInterfacePermission (DeleteNetworkInterfacePermission)"))
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
            
            if (ParameterWasBound("IgnoreAttachedStatus"))
                context.IgnoreAttachedStatus = this.IgnoreAttachedStatus;
            context.NetworkInterfacePermissionId = this.NetworkInterfacePermissionId;
            
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
            var request = new Amazon.EC2.Model.DeleteNetworkInterfacePermissionRequest();
            
            if (cmdletContext.IgnoreAttachedStatus != null)
            {
                request.Force = cmdletContext.IgnoreAttachedStatus.Value;
            }
            if (cmdletContext.NetworkInterfacePermissionId != null)
            {
                request.NetworkInterfacePermissionId = cmdletContext.NetworkInterfacePermissionId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Return;
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
        
        private Amazon.EC2.Model.DeleteNetworkInterfacePermissionResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DeleteNetworkInterfacePermissionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DeleteNetworkInterfacePermission");
            try
            {
                #if DESKTOP
                return client.DeleteNetworkInterfacePermission(request);
                #elif CORECLR
                return client.DeleteNetworkInterfacePermissionAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? IgnoreAttachedStatus { get; set; }
            public System.String NetworkInterfacePermissionId { get; set; }
        }
        
    }
}
