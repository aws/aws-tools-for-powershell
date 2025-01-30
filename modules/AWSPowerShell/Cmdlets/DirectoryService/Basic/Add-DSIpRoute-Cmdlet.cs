/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// If the DNS server for your self-managed domain uses a publicly addressable IP address,
    /// you must add a CIDR address block to correctly route traffic to and from your Microsoft
    /// AD on Amazon Web Services. <i>AddIpRoutes</i> adds this address block. You can also
    /// use <i>AddIpRoutes</i> to facilitate routing traffic that uses public IP ranges from
    /// your Microsoft AD on Amazon Web Services to a peer VPC. 
    /// 
    ///  
    /// <para>
    /// Before you call <i>AddIpRoutes</i>, ensure that all of the required permissions have
    /// been explicitly granted through a policy. For details about what permissions are required
    /// to run the <i>AddIpRoutes</i> operation, see <a href="http://docs.aws.amazon.com/directoryservice/latest/admin-guide/UsingWithDS_IAM_ResourcePermissions.html">Directory
    /// Service API Permissions: Actions, Resources, and Conditions Reference</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "DSIpRoute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Directory Service AddIpRoutes API operation.", Operation = new[] {"AddIpRoutes"}, SelectReturnType = typeof(Amazon.DirectoryService.Model.AddIpRoutesResponse), LegacyAlias="Add-DSIpRoutes")]
    [AWSCmdletOutput("None or Amazon.DirectoryService.Model.AddIpRoutesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DirectoryService.Model.AddIpRoutesResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddDSIpRouteCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>Identifier (ID) of the directory to which to add the address block.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter IpRoute
        /// <summary>
        /// <para>
        /// <para>IP address blocks, using CIDR format, of the traffic to route. This is often the IP
        /// address block of the DNS server used for your self-managed domain.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("IpRoutes")]
        public Amazon.DirectoryService.Model.IpRoute[] IpRoute { get; set; }
        #endregion
        
        #region Parameter UpdateSecurityGroupForDirectoryController
        /// <summary>
        /// <para>
        /// <para>If set to true, updates the inbound and outbound rules of the security group that
        /// has the description: "Amazon Web Services created security group for <i>directory
        /// ID</i> directory controllers." Following are the new rules: </para><para>Inbound:</para><ul><li><para>Type: Custom UDP Rule, Protocol: UDP, Range: 88, Source: Managed Microsoft AD VPC
        /// IPv4 CIDR</para></li><li><para>Type: Custom UDP Rule, Protocol: UDP, Range: 123, Source: Managed Microsoft AD VPC
        /// IPv4 CIDR</para></li><li><para>Type: Custom UDP Rule, Protocol: UDP, Range: 138, Source: Managed Microsoft AD VPC
        /// IPv4 CIDR</para></li><li><para>Type: Custom UDP Rule, Protocol: UDP, Range: 389, Source: Managed Microsoft AD VPC
        /// IPv4 CIDR</para></li><li><para>Type: Custom UDP Rule, Protocol: UDP, Range: 464, Source: Managed Microsoft AD VPC
        /// IPv4 CIDR</para></li><li><para>Type: Custom UDP Rule, Protocol: UDP, Range: 445, Source: Managed Microsoft AD VPC
        /// IPv4 CIDR</para></li><li><para>Type: Custom TCP Rule, Protocol: TCP, Range: 88, Source: Managed Microsoft AD VPC
        /// IPv4 CIDR</para></li><li><para>Type: Custom TCP Rule, Protocol: TCP, Range: 135, Source: Managed Microsoft AD VPC
        /// IPv4 CIDR</para></li><li><para>Type: Custom TCP Rule, Protocol: TCP, Range: 445, Source: Managed Microsoft AD VPC
        /// IPv4 CIDR</para></li><li><para>Type: Custom TCP Rule, Protocol: TCP, Range: 464, Source: Managed Microsoft AD VPC
        /// IPv4 CIDR</para></li><li><para>Type: Custom TCP Rule, Protocol: TCP, Range: 636, Source: Managed Microsoft AD VPC
        /// IPv4 CIDR</para></li><li><para>Type: Custom TCP Rule, Protocol: TCP, Range: 1024-65535, Source: Managed Microsoft
        /// AD VPC IPv4 CIDR</para></li><li><para>Type: Custom TCP Rule, Protocol: TCP, Range: 3268-33269, Source: Managed Microsoft
        /// AD VPC IPv4 CIDR</para></li><li><para>Type: DNS (UDP), Protocol: UDP, Range: 53, Source: Managed Microsoft AD VPC IPv4 CIDR</para></li><li><para>Type: DNS (TCP), Protocol: TCP, Range: 53, Source: Managed Microsoft AD VPC IPv4 CIDR</para></li><li><para>Type: LDAP, Protocol: TCP, Range: 389, Source: Managed Microsoft AD VPC IPv4 CIDR</para></li><li><para>Type: All ICMP, Protocol: All, Range: N/A, Source: Managed Microsoft AD VPC IPv4 CIDR</para></li></ul><para>Outbound:</para><ul><li><para>Type: All traffic, Protocol: All, Range: All, Destination: 0.0.0.0/0</para></li></ul><para>These security rules impact an internal network interface that is not exposed publicly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateSecurityGroupForDirectoryControllers")]
        public System.Boolean? UpdateSecurityGroupForDirectoryController { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectoryService.Model.AddIpRoutesResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DirectoryId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DirectoryId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DirectoryId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DirectoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-DSIpRoute (AddIpRoutes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectoryService.Model.AddIpRoutesResponse, AddDSIpRouteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DirectoryId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DirectoryId = this.DirectoryId;
            #if MODULAR
            if (this.DirectoryId == null && ParameterWasBound(nameof(this.DirectoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.IpRoute != null)
            {
                context.IpRoute = new List<Amazon.DirectoryService.Model.IpRoute>(this.IpRoute);
            }
            #if MODULAR
            if (this.IpRoute == null && ParameterWasBound(nameof(this.IpRoute)))
            {
                WriteWarning("You are passing $null as a value for parameter IpRoute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UpdateSecurityGroupForDirectoryController = this.UpdateSecurityGroupForDirectoryController;
            
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
            if (cmdletContext.IpRoute != null)
            {
                request.IpRoutes = cmdletContext.IpRoute;
            }
            if (cmdletContext.UpdateSecurityGroupForDirectoryController != null)
            {
                request.UpdateSecurityGroupForDirectoryControllers = cmdletContext.UpdateSecurityGroupForDirectoryController.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
                return client.AddIpRoutesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.DirectoryService.Model.IpRoute> IpRoute { get; set; }
            public System.Boolean? UpdateSecurityGroupForDirectoryController { get; set; }
            public System.Func<Amazon.DirectoryService.Model.AddIpRoutesResponse, AddDSIpRouteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
