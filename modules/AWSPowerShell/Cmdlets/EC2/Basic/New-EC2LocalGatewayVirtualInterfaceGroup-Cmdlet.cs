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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Create a local gateway virtual interface group.
    /// </summary>
    [Cmdlet("New", "EC2LocalGatewayVirtualInterfaceGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.LocalGatewayVirtualInterfaceGroup")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateLocalGatewayVirtualInterfaceGroup API operation.", Operation = new[] {"CreateLocalGatewayVirtualInterfaceGroup"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceGroupResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.LocalGatewayVirtualInterfaceGroup or Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceGroupResponse",
        "This cmdlet returns an Amazon.EC2.Model.LocalGatewayVirtualInterfaceGroup object.",
        "The service call response (type Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2LocalGatewayVirtualInterfaceGroupCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LocalBgpAsn
        /// <summary>
        /// <para>
        /// <para>The Autonomous System Number(ASN) for the local Border Gateway Protocol (BGP).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LocalBgpAsn { get; set; }
        #endregion
        
        #region Parameter LocalBgpAsnExtended
        /// <summary>
        /// <para>
        /// <para>The extended 32-bit ASN for the local BGP configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? LocalBgpAsnExtended { get; set; }
        #endregion
        
        #region Parameter LocalGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the local gateway.</para>
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
        public System.String LocalGatewayId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the local gateway virtual interface group when the resource is
        /// being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LocalGatewayVirtualInterfaceGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceGroupResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LocalGatewayVirtualInterfaceGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LocalGatewayId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LocalGatewayId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LocalGatewayId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LocalGatewayId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2LocalGatewayVirtualInterfaceGroup (CreateLocalGatewayVirtualInterfaceGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceGroupResponse, NewEC2LocalGatewayVirtualInterfaceGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LocalGatewayId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LocalBgpAsn = this.LocalBgpAsn;
            context.LocalBgpAsnExtended = this.LocalBgpAsnExtended;
            context.LocalGatewayId = this.LocalGatewayId;
            #if MODULAR
            if (this.LocalGatewayId == null && ParameterWasBound(nameof(this.LocalGatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter LocalGatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
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
            var request = new Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceGroupRequest();
            
            if (cmdletContext.LocalBgpAsn != null)
            {
                request.LocalBgpAsn = cmdletContext.LocalBgpAsn.Value;
            }
            if (cmdletContext.LocalBgpAsnExtended != null)
            {
                request.LocalBgpAsnExtended = cmdletContext.LocalBgpAsnExtended.Value;
            }
            if (cmdletContext.LocalGatewayId != null)
            {
                request.LocalGatewayId = cmdletContext.LocalGatewayId;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceGroupResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateLocalGatewayVirtualInterfaceGroup");
            try
            {
                #if DESKTOP
                return client.CreateLocalGatewayVirtualInterfaceGroup(request);
                #elif CORECLR
                return client.CreateLocalGatewayVirtualInterfaceGroupAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? LocalBgpAsn { get; set; }
            public System.Int64? LocalBgpAsnExtended { get; set; }
            public System.String LocalGatewayId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceGroupResponse, NewEC2LocalGatewayVirtualInterfaceGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LocalGatewayVirtualInterfaceGroup;
        }
        
    }
}
