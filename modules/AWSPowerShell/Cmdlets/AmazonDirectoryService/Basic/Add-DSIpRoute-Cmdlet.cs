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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// If the DNS server for your on-premises domain uses a publicly addressable IP address,
    /// you must add a CIDR address block to correctly route traffic to and from your Microsoft
    /// AD on Amazon Web Services. <i>AddIpRoutes</i> adds this address block. You can also
    /// use <i>AddIpRoutes</i> to facilitate routing traffic that uses public IP ranges from
    /// your Microsoft AD on AWS to a peer VPC. 
    /// 
    ///  
    /// <para>
    /// Before you call <i>AddIpRoutes</i>, ensure that all of the required permissions have
    /// been explicitly granted through a policy. For details about what permissions are required
    /// to run the <i>AddIpRoutes</i> operation, see <a href="http://docs.aws.amazon.com/directoryservice/latest/admin-guide/UsingWithDS_IAM_ResourcePermissions.html">AWS
    /// Directory Service API Permissions: Actions, Resources, and Conditions Reference</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "DSIpRoute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Directory Service AddIpRoutes API operation.", Operation = new[] {"AddIpRoutes"}, LegacyAlias="Add-DSIpRoutes")]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the DirectoryId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.DirectoryService.Model.AddIpRoutesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddDSIpRouteCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>Identifier (ID) of the directory to which to add the address block.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter IpRoute
        /// <summary>
        /// <para>
        /// <para>IP address blocks, using CIDR format, of the traffic to route. This is often the IP
        /// address block of the DNS server used for your on-premises domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IpRoutes")]
        public Amazon.DirectoryService.Model.IpRoute[] IpRoute { get; set; }
        #endregion
        
        #region Parameter UpdateSecurityGroupForDirectoryController
        /// <summary>
        /// <para>
        /// <para>If set to true, updates the inbound and outbound rules of the security group that
        /// has the description: "AWS created security group for <i>directory ID</i> directory
        /// controllers." Following are the new rules: </para><para>Inbound:</para><ul><li><para>Type: Custom UDP Rule, Protocol: UDP, Range: 88, Source: 0.0.0.0/0</para></li><li><para>Type: Custom UDP Rule, Protocol: UDP, Range: 123, Source: 0.0.0.0/0</para></li><li><para>Type: Custom UDP Rule, Protocol: UDP, Range: 138, Source: 0.0.0.0/0</para></li><li><para>Type: Custom UDP Rule, Protocol: UDP, Range: 389, Source: 0.0.0.0/0</para></li><li><para>Type: Custom UDP Rule, Protocol: UDP, Range: 464, Source: 0.0.0.0/0</para></li><li><para>Type: Custom UDP Rule, Protocol: UDP, Range: 445, Source: 0.0.0.0/0</para></li><li><para>Type: Custom TCP Rule, Protocol: TCP, Range: 88, Source: 0.0.0.0/0</para></li><li><para>Type: Custom TCP Rule, Protocol: TCP, Range: 135, Source: 0.0.0.0/0</para></li><li><para>Type: Custom TCP Rule, Protocol: TCP, Range: 445, Source: 0.0.0.0/0</para></li><li><para>Type: Custom TCP Rule, Protocol: TCP, Range: 464, Source: 0.0.0.0/0</para></li><li><para>Type: Custom TCP Rule, Protocol: TCP, Range: 636, Source: 0.0.0.0/0</para></li><li><para>Type: Custom TCP Rule, Protocol: TCP, Range: 1024-65535, Source: 0.0.0.0/0</para></li><li><para>Type: Custom TCP Rule, Protocol: TCP, Range: 3268-33269, Source: 0.0.0.0/0</para></li><li><para>Type: DNS (UDP), Protocol: UDP, Range: 53, Source: 0.0.0.0/0</para></li><li><para>Type: DNS (TCP), Protocol: TCP, Range: 53, Source: 0.0.0.0/0</para></li><li><para>Type: LDAP, Protocol: TCP, Range: 389, Source: 0.0.0.0/0</para></li><li><para>Type: All ICMP, Protocol: All, Range: N/A, Source: 0.0.0.0/0</para></li></ul><para>Outbound:</para><ul><li><para>Type: All traffic, Protocol: All, Range: All, Destination: 0.0.0.0/0</para></li></ul><para>These security rules impact an internal network interface that is not exposed publicly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UpdateSecurityGroupForDirectoryControllers")]
        public System.Boolean UpdateSecurityGroupForDirectoryController { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the DirectoryId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DirectoryId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-DSIpRoute (AddIpRoutes)"))
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
            
            context.DirectoryId = this.DirectoryId;
            if (this.IpRoute != null)
            {
                context.IpRoutes = new List<Amazon.DirectoryService.Model.IpRoute>(this.IpRoute);
            }
            if (ParameterWasBound("UpdateSecurityGroupForDirectoryController"))
                context.UpdateSecurityGroupForDirectoryControllers = this.UpdateSecurityGroupForDirectoryController;
            
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
            var request = new Amazon.DirectoryService.Model.AddIpRoutesRequest();
            
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.IpRoutes != null)
            {
                request.IpRoutes = cmdletContext.IpRoutes;
            }
            if (cmdletContext.UpdateSecurityGroupForDirectoryControllers != null)
            {
                request.UpdateSecurityGroupForDirectoryControllers = cmdletContext.UpdateSecurityGroupForDirectoryControllers.Value;
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
                    pipelineOutput = this.DirectoryId;
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
        
        private Amazon.DirectoryService.Model.AddIpRoutesResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.AddIpRoutesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "AddIpRoutes");
            try
            {
                #if DESKTOP
                return client.AddIpRoutes(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AddIpRoutesAsync(request);
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
            public System.String DirectoryId { get; set; }
            public List<Amazon.DirectoryService.Model.IpRoute> IpRoutes { get; set; }
            public System.Boolean? UpdateSecurityGroupForDirectoryControllers { get; set; }
        }
        
    }
}
