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
using Amazon.VPCLattice;
using Amazon.VPCLattice.Model;

namespace Amazon.PowerShell.Cmdlets.VPCL
{
    /// <summary>
    /// Creates a service network. A service network is a logical boundary for a collection
    /// of services. You can associate services and VPCs with a service network.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc-lattice/latest/ug/service-networks.html">Service
    /// networks</a> in the <i>Amazon VPC Lattice User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "VPCLServiceNetwork", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VPCLattice.Model.CreateServiceNetworkResponse")]
    [AWSCmdlet("Calls the VPC Lattice CreateServiceNetwork API operation.", Operation = new[] {"CreateServiceNetwork"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.CreateServiceNetworkResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.CreateServiceNetworkResponse",
        "This cmdlet returns an Amazon.VPCLattice.Model.CreateServiceNetworkResponse object containing multiple properties."
    )]
    public partial class NewVPCLServiceNetworkCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuthType
        /// <summary>
        /// <para>
        /// <para>The type of IAM policy.</para><ul><li><para><c>NONE</c>: The resource does not use an IAM policy. This is the default.</para></li><li><para><c>AWS_IAM</c>: The resource uses an IAM policy. When this type is used, auth is
        /// enabled and an auth policy is required.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.VPCLattice.AuthType")]
        public Amazon.VPCLattice.AuthType AuthType { get; set; }
        #endregion
        
        #region Parameter SharingConfig_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies if the service network is enabled for sharing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SharingConfig_Enabled { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the service network. The name must be unique to the account. The valid
        /// characters are a-z, 0-9, and hyphens (-). You can't use a hyphen as the first or last
        /// character, or immediately after another hyphen.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for the service network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you retry a request that completed successfully using the same client
        /// token and parameters, the retry succeeds without performing any actions. If the parameters
        /// aren't identical, the retry fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.CreateServiceNetworkResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.CreateServiceNetworkResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-VPCLServiceNetwork (CreateServiceNetwork)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.CreateServiceNetworkResponse, NewVPCLServiceNetworkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AuthType = this.AuthType;
            context.ClientToken = this.ClientToken;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SharingConfig_Enabled = this.SharingConfig_Enabled;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.VPCLattice.Model.CreateServiceNetworkRequest();
            
            if (cmdletContext.AuthType != null)
            {
                request.AuthType = cmdletContext.AuthType;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate SharingConfig
            var requestSharingConfigIsNull = true;
            request.SharingConfig = new Amazon.VPCLattice.Model.SharingConfig();
            System.Boolean? requestSharingConfig_sharingConfig_Enabled = null;
            if (cmdletContext.SharingConfig_Enabled != null)
            {
                requestSharingConfig_sharingConfig_Enabled = cmdletContext.SharingConfig_Enabled.Value;
            }
            if (requestSharingConfig_sharingConfig_Enabled != null)
            {
                request.SharingConfig.Enabled = requestSharingConfig_sharingConfig_Enabled.Value;
                requestSharingConfigIsNull = false;
            }
             // determine if request.SharingConfig should be set to null
            if (requestSharingConfigIsNull)
            {
                request.SharingConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.VPCLattice.Model.CreateServiceNetworkResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.CreateServiceNetworkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "CreateServiceNetwork");
            try
            {
                #if DESKTOP
                return client.CreateServiceNetwork(request);
                #elif CORECLR
                return client.CreateServiceNetworkAsync(request).GetAwaiter().GetResult();
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
            public Amazon.VPCLattice.AuthType AuthType { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? SharingConfig_Enabled { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.VPCLattice.Model.CreateServiceNetworkResponse, NewVPCLServiceNetworkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
