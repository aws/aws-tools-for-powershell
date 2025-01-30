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
using Amazon.Finspace;
using Amazon.Finspace.Model;

namespace Amazon.PowerShell.Cmdlets.FINSP
{
    /// <summary>
    /// Updates environment network to connect to your internal network by using a transit
    /// gateway. This API supports request to create a transit gateway attachment from FinSpace
    /// VPC to your transit gateway ID and create a custom Route-53 outbound resolvers.
    /// 
    ///  
    /// <para>
    /// Once you send a request to update a network, you cannot change it again. Network update
    /// might require termination of any clusters that are running in the existing network.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "FINSPKxEnvironmentNetwork", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Finspace.Model.UpdateKxEnvironmentNetworkResponse")]
    [AWSCmdlet("Calls the FinSpace User Environment Management Service UpdateKxEnvironmentNetwork API operation.", Operation = new[] {"UpdateKxEnvironmentNetwork"}, SelectReturnType = typeof(Amazon.Finspace.Model.UpdateKxEnvironmentNetworkResponse))]
    [AWSCmdletOutput("Amazon.Finspace.Model.UpdateKxEnvironmentNetworkResponse",
        "This cmdlet returns an Amazon.Finspace.Model.UpdateKxEnvironmentNetworkResponse object containing multiple properties."
    )]
    public partial class UpdateFINSPKxEnvironmentNetworkCmdlet : AmazonFinspaceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TransitGatewayConfiguration_AttachmentNetworkAclConfiguration
        /// <summary>
        /// <para>
        /// <para> The rules that define how you manage the outbound traffic from kdb network to your
        /// internal network. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Finspace.Model.NetworkACLEntry[] TransitGatewayConfiguration_AttachmentNetworkAclConfiguration { get; set; }
        #endregion
        
        #region Parameter CustomDNSConfiguration
        /// <summary>
        /// <para>
        /// <para>A list of DNS server name and server IP. This is used to set up Route-53 outbound
        /// resolvers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Finspace.Model.CustomDNSServer[] CustomDNSConfiguration { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the kdb environment.</para>
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
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter TransitGatewayConfiguration_RoutableCIDRSpace
        /// <summary>
        /// <para>
        /// <para>The routing CIDR on behalf of kdb environment. It could be any "/26 range in the 100.64.0.0
        /// CIDR space. After providing, it will be added to the customer's transit gateway routing
        /// table so that the traffics could be routed to kdb network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransitGatewayConfiguration_RoutableCIDRSpace { get; set; }
        #endregion
        
        #region Parameter TransitGatewayConfiguration_TransitGatewayID
        /// <summary>
        /// <para>
        /// <para>The identifier of the transit gateway created by the customer to connect outbound
        /// traffics from kdb network to your internal network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransitGatewayConfiguration_TransitGatewayID { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures idempotency. This token expires in 10 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Finspace.Model.UpdateKxEnvironmentNetworkResponse).
        /// Specifying the name of a property of type Amazon.Finspace.Model.UpdateKxEnvironmentNetworkResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EnvironmentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EnvironmentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EnvironmentId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnvironmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FINSPKxEnvironmentNetwork (UpdateKxEnvironmentNetwork)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Finspace.Model.UpdateKxEnvironmentNetworkResponse, UpdateFINSPKxEnvironmentNetworkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EnvironmentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            if (this.CustomDNSConfiguration != null)
            {
                context.CustomDNSConfiguration = new List<Amazon.Finspace.Model.CustomDNSServer>(this.CustomDNSConfiguration);
            }
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TransitGatewayConfiguration_AttachmentNetworkAclConfiguration != null)
            {
                context.TransitGatewayConfiguration_AttachmentNetworkAclConfiguration = new List<Amazon.Finspace.Model.NetworkACLEntry>(this.TransitGatewayConfiguration_AttachmentNetworkAclConfiguration);
            }
            context.TransitGatewayConfiguration_RoutableCIDRSpace = this.TransitGatewayConfiguration_RoutableCIDRSpace;
            context.TransitGatewayConfiguration_TransitGatewayID = this.TransitGatewayConfiguration_TransitGatewayID;
            
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
            var request = new Amazon.Finspace.Model.UpdateKxEnvironmentNetworkRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CustomDNSConfiguration != null)
            {
                request.CustomDNSConfiguration = cmdletContext.CustomDNSConfiguration;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            
             // populate TransitGatewayConfiguration
            var requestTransitGatewayConfigurationIsNull = true;
            request.TransitGatewayConfiguration = new Amazon.Finspace.Model.TransitGatewayConfiguration();
            List<Amazon.Finspace.Model.NetworkACLEntry> requestTransitGatewayConfiguration_transitGatewayConfiguration_AttachmentNetworkAclConfiguration = null;
            if (cmdletContext.TransitGatewayConfiguration_AttachmentNetworkAclConfiguration != null)
            {
                requestTransitGatewayConfiguration_transitGatewayConfiguration_AttachmentNetworkAclConfiguration = cmdletContext.TransitGatewayConfiguration_AttachmentNetworkAclConfiguration;
            }
            if (requestTransitGatewayConfiguration_transitGatewayConfiguration_AttachmentNetworkAclConfiguration != null)
            {
                request.TransitGatewayConfiguration.AttachmentNetworkAclConfiguration = requestTransitGatewayConfiguration_transitGatewayConfiguration_AttachmentNetworkAclConfiguration;
                requestTransitGatewayConfigurationIsNull = false;
            }
            System.String requestTransitGatewayConfiguration_transitGatewayConfiguration_RoutableCIDRSpace = null;
            if (cmdletContext.TransitGatewayConfiguration_RoutableCIDRSpace != null)
            {
                requestTransitGatewayConfiguration_transitGatewayConfiguration_RoutableCIDRSpace = cmdletContext.TransitGatewayConfiguration_RoutableCIDRSpace;
            }
            if (requestTransitGatewayConfiguration_transitGatewayConfiguration_RoutableCIDRSpace != null)
            {
                request.TransitGatewayConfiguration.RoutableCIDRSpace = requestTransitGatewayConfiguration_transitGatewayConfiguration_RoutableCIDRSpace;
                requestTransitGatewayConfigurationIsNull = false;
            }
            System.String requestTransitGatewayConfiguration_transitGatewayConfiguration_TransitGatewayID = null;
            if (cmdletContext.TransitGatewayConfiguration_TransitGatewayID != null)
            {
                requestTransitGatewayConfiguration_transitGatewayConfiguration_TransitGatewayID = cmdletContext.TransitGatewayConfiguration_TransitGatewayID;
            }
            if (requestTransitGatewayConfiguration_transitGatewayConfiguration_TransitGatewayID != null)
            {
                request.TransitGatewayConfiguration.TransitGatewayID = requestTransitGatewayConfiguration_transitGatewayConfiguration_TransitGatewayID;
                requestTransitGatewayConfigurationIsNull = false;
            }
             // determine if request.TransitGatewayConfiguration should be set to null
            if (requestTransitGatewayConfigurationIsNull)
            {
                request.TransitGatewayConfiguration = null;
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
        
        private Amazon.Finspace.Model.UpdateKxEnvironmentNetworkResponse CallAWSServiceOperation(IAmazonFinspace client, Amazon.Finspace.Model.UpdateKxEnvironmentNetworkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace User Environment Management Service", "UpdateKxEnvironmentNetwork");
            try
            {
                #if DESKTOP
                return client.UpdateKxEnvironmentNetwork(request);
                #elif CORECLR
                return client.UpdateKxEnvironmentNetworkAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<Amazon.Finspace.Model.CustomDNSServer> CustomDNSConfiguration { get; set; }
            public System.String EnvironmentId { get; set; }
            public List<Amazon.Finspace.Model.NetworkACLEntry> TransitGatewayConfiguration_AttachmentNetworkAclConfiguration { get; set; }
            public System.String TransitGatewayConfiguration_RoutableCIDRSpace { get; set; }
            public System.String TransitGatewayConfiguration_TransitGatewayID { get; set; }
            public System.Func<Amazon.Finspace.Model.UpdateKxEnvironmentNetworkResponse, UpdateFINSPKxEnvironmentNetworkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
