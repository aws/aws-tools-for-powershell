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
using System.Threading;
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Creates a public virtual interface. A virtual interface is the VLAN that transports
    /// Direct Connect traffic. A public virtual interface supports sending traffic to public
    /// services of Amazon Web Services such as Amazon S3.
    /// 
    ///  
    /// <para>
    /// When creating an IPv6 public virtual interface (<c>addressFamily</c> is <c>ipv6</c>),
    /// leave the <c>customer</c> and <c>amazon</c> address fields blank to use auto-assigned
    /// IPv6 space. Custom IPv6 addresses are not supported.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DCPublicVirtualInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect CreatePublicVirtualInterface API operation.", Operation = new[] {"CreatePublicVirtualInterface"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse object containing multiple properties."
    )]
    public partial class NewDCPublicVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NewPublicVirtualInterface_AddressFamily
        /// <summary>
        /// <para>
        /// <para>The address family for the BGP peer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectConnect.AddressFamily")]
        public Amazon.DirectConnect.AddressFamily NewPublicVirtualInterface_AddressFamily { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_AmazonAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the Amazon interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewPublicVirtualInterface_AmazonAddress { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_Asn
        /// <summary>
        /// <para>
        /// <para>The autonomous system number (ASN). The valid range is from 1 to 2147483646 for Border
        /// Gateway Protocol (BGP) configuration. If you provide a number greater than the maximum,
        /// an error is returned. Use <c>asnLong</c> instead.</para><note><para>You can use <c>asnLong</c> or <c>asn</c>, but not both. We recommend using <c>asnLong</c>
        /// as it supports a greater pool of numbers. </para><ul><li><para>The <c>asnLong</c> attribute accepts both ASN and long ASN ranges.</para></li><li><para>If you provide a value in the same API call for both <c>asn</c> and <c>asnLong</c>,
        /// the API will only accept the value for <c>asnLong</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NewPublicVirtualInterface_Asn { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_AsnLong
        /// <summary>
        /// <para>
        /// <para>The long ASN for a new public virtual interface. The valid range is from 1 to 4294967294
        /// for BGP configuration.</para><note><para>You can use <c>asnLong</c> or <c>asn</c>, but not both. We recommend using <c>asnLong</c>
        /// as it supports a greater pool of numbers. </para><ul><li><para>The <c>asnLong</c> attribute accepts both ASN and long ASN ranges.</para></li><li><para>If you provide a value in the same API call for both <c>asn</c> and <c>asnLong</c>,
        /// the API will only accept the value for <c>asnLong</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? NewPublicVirtualInterface_AsnLong { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_AuthKey
        /// <summary>
        /// <para>
        /// <para>The authentication key for BGP configuration. This string has a minimum length of
        /// 6 characters and and a maximun lenth of 80 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewPublicVirtualInterface_AuthKey { get; set; }
        #endregion
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the connection.</para>
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
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_CustomerAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the customer interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewPublicVirtualInterface_CustomerAddress { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_RouteFilterPrefix
        /// <summary>
        /// <para>
        /// <para>The routes to be advertised to the Amazon Web Services network in this Region. Applies
        /// to public virtual interfaces.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewPublicVirtualInterface_RouteFilterPrefixes")]
        public Amazon.DirectConnect.Model.RouteFilterPrefix[] NewPublicVirtualInterface_RouteFilterPrefix { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_Tag
        /// <summary>
        /// <para>
        /// <para>The tags associated with the public virtual interface.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewPublicVirtualInterface_Tags")]
        public Amazon.DirectConnect.Model.Tag[] NewPublicVirtualInterface_Tag { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_VirtualInterfaceName
        /// <summary>
        /// <para>
        /// <para>The name of the virtual interface assigned by the customer network. The name has a
        /// maximum of 100 characters. The following are valid characters: a-z, 0-9 and a hyphen
        /// (-).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String NewPublicVirtualInterface_VirtualInterfaceName { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_Vlan
        /// <summary>
        /// <para>
        /// <para>The ID of the VLAN.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? NewPublicVirtualInterface_Vlan { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCPublicVirtualInterface (CreatePublicVirtualInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse, NewDCPublicVirtualInterfaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectionId = this.ConnectionId;
            #if MODULAR
            if (this.ConnectionId == null && ParameterWasBound(nameof(this.ConnectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewPublicVirtualInterface_AddressFamily = this.NewPublicVirtualInterface_AddressFamily;
            context.NewPublicVirtualInterface_AmazonAddress = this.NewPublicVirtualInterface_AmazonAddress;
            context.NewPublicVirtualInterface_Asn = this.NewPublicVirtualInterface_Asn;
            context.NewPublicVirtualInterface_AsnLong = this.NewPublicVirtualInterface_AsnLong;
            context.NewPublicVirtualInterface_AuthKey = this.NewPublicVirtualInterface_AuthKey;
            context.NewPublicVirtualInterface_CustomerAddress = this.NewPublicVirtualInterface_CustomerAddress;
            if (this.NewPublicVirtualInterface_RouteFilterPrefix != null)
            {
                context.NewPublicVirtualInterface_RouteFilterPrefix = new List<Amazon.DirectConnect.Model.RouteFilterPrefix>(this.NewPublicVirtualInterface_RouteFilterPrefix);
            }
            if (this.NewPublicVirtualInterface_Tag != null)
            {
                context.NewPublicVirtualInterface_Tag = new List<Amazon.DirectConnect.Model.Tag>(this.NewPublicVirtualInterface_Tag);
            }
            context.NewPublicVirtualInterface_VirtualInterfaceName = this.NewPublicVirtualInterface_VirtualInterfaceName;
            #if MODULAR
            if (this.NewPublicVirtualInterface_VirtualInterfaceName == null && ParameterWasBound(nameof(this.NewPublicVirtualInterface_VirtualInterfaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter NewPublicVirtualInterface_VirtualInterfaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewPublicVirtualInterface_Vlan = this.NewPublicVirtualInterface_Vlan;
            #if MODULAR
            if (this.NewPublicVirtualInterface_Vlan == null && ParameterWasBound(nameof(this.NewPublicVirtualInterface_Vlan)))
            {
                WriteWarning("You are passing $null as a value for parameter NewPublicVirtualInterface_Vlan which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceRequest();
            
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            
             // populate NewPublicVirtualInterface
            var requestNewPublicVirtualInterfaceIsNull = true;
            request.NewPublicVirtualInterface = new Amazon.DirectConnect.Model.NewPublicVirtualInterface();
            Amazon.DirectConnect.AddressFamily requestNewPublicVirtualInterface_newPublicVirtualInterface_AddressFamily = null;
            if (cmdletContext.NewPublicVirtualInterface_AddressFamily != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_AddressFamily = cmdletContext.NewPublicVirtualInterface_AddressFamily;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_AddressFamily != null)
            {
                request.NewPublicVirtualInterface.AddressFamily = requestNewPublicVirtualInterface_newPublicVirtualInterface_AddressFamily;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
            System.String requestNewPublicVirtualInterface_newPublicVirtualInterface_AmazonAddress = null;
            if (cmdletContext.NewPublicVirtualInterface_AmazonAddress != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_AmazonAddress = cmdletContext.NewPublicVirtualInterface_AmazonAddress;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_AmazonAddress != null)
            {
                request.NewPublicVirtualInterface.AmazonAddress = requestNewPublicVirtualInterface_newPublicVirtualInterface_AmazonAddress;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
            System.Int32? requestNewPublicVirtualInterface_newPublicVirtualInterface_Asn = null;
            if (cmdletContext.NewPublicVirtualInterface_Asn != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_Asn = cmdletContext.NewPublicVirtualInterface_Asn.Value;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_Asn != null)
            {
                request.NewPublicVirtualInterface.Asn = requestNewPublicVirtualInterface_newPublicVirtualInterface_Asn.Value;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
            System.Int64? requestNewPublicVirtualInterface_newPublicVirtualInterface_AsnLong = null;
            if (cmdletContext.NewPublicVirtualInterface_AsnLong != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_AsnLong = cmdletContext.NewPublicVirtualInterface_AsnLong.Value;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_AsnLong != null)
            {
                request.NewPublicVirtualInterface.AsnLong = requestNewPublicVirtualInterface_newPublicVirtualInterface_AsnLong.Value;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
            System.String requestNewPublicVirtualInterface_newPublicVirtualInterface_AuthKey = null;
            if (cmdletContext.NewPublicVirtualInterface_AuthKey != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_AuthKey = cmdletContext.NewPublicVirtualInterface_AuthKey;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_AuthKey != null)
            {
                request.NewPublicVirtualInterface.AuthKey = requestNewPublicVirtualInterface_newPublicVirtualInterface_AuthKey;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
            System.String requestNewPublicVirtualInterface_newPublicVirtualInterface_CustomerAddress = null;
            if (cmdletContext.NewPublicVirtualInterface_CustomerAddress != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_CustomerAddress = cmdletContext.NewPublicVirtualInterface_CustomerAddress;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_CustomerAddress != null)
            {
                request.NewPublicVirtualInterface.CustomerAddress = requestNewPublicVirtualInterface_newPublicVirtualInterface_CustomerAddress;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
            List<Amazon.DirectConnect.Model.RouteFilterPrefix> requestNewPublicVirtualInterface_newPublicVirtualInterface_RouteFilterPrefix = null;
            if (cmdletContext.NewPublicVirtualInterface_RouteFilterPrefix != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_RouteFilterPrefix = cmdletContext.NewPublicVirtualInterface_RouteFilterPrefix;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_RouteFilterPrefix != null)
            {
                request.NewPublicVirtualInterface.RouteFilterPrefixes = requestNewPublicVirtualInterface_newPublicVirtualInterface_RouteFilterPrefix;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
            List<Amazon.DirectConnect.Model.Tag> requestNewPublicVirtualInterface_newPublicVirtualInterface_Tag = null;
            if (cmdletContext.NewPublicVirtualInterface_Tag != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_Tag = cmdletContext.NewPublicVirtualInterface_Tag;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_Tag != null)
            {
                request.NewPublicVirtualInterface.Tags = requestNewPublicVirtualInterface_newPublicVirtualInterface_Tag;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
            System.String requestNewPublicVirtualInterface_newPublicVirtualInterface_VirtualInterfaceName = null;
            if (cmdletContext.NewPublicVirtualInterface_VirtualInterfaceName != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_VirtualInterfaceName = cmdletContext.NewPublicVirtualInterface_VirtualInterfaceName;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_VirtualInterfaceName != null)
            {
                request.NewPublicVirtualInterface.VirtualInterfaceName = requestNewPublicVirtualInterface_newPublicVirtualInterface_VirtualInterfaceName;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
            System.Int32? requestNewPublicVirtualInterface_newPublicVirtualInterface_Vlan = null;
            if (cmdletContext.NewPublicVirtualInterface_Vlan != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_Vlan = cmdletContext.NewPublicVirtualInterface_Vlan.Value;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_Vlan != null)
            {
                request.NewPublicVirtualInterface.Vlan = requestNewPublicVirtualInterface_newPublicVirtualInterface_Vlan.Value;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
             // determine if request.NewPublicVirtualInterface should be set to null
            if (requestNewPublicVirtualInterfaceIsNull)
            {
                request.NewPublicVirtualInterface = null;
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
        
        private Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "CreatePublicVirtualInterface");
            try
            {
                return client.CreatePublicVirtualInterfaceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectionId { get; set; }
            public Amazon.DirectConnect.AddressFamily NewPublicVirtualInterface_AddressFamily { get; set; }
            public System.String NewPublicVirtualInterface_AmazonAddress { get; set; }
            public System.Int32? NewPublicVirtualInterface_Asn { get; set; }
            public System.Int64? NewPublicVirtualInterface_AsnLong { get; set; }
            public System.String NewPublicVirtualInterface_AuthKey { get; set; }
            public System.String NewPublicVirtualInterface_CustomerAddress { get; set; }
            public List<Amazon.DirectConnect.Model.RouteFilterPrefix> NewPublicVirtualInterface_RouteFilterPrefix { get; set; }
            public List<Amazon.DirectConnect.Model.Tag> NewPublicVirtualInterface_Tag { get; set; }
            public System.String NewPublicVirtualInterface_VirtualInterfaceName { get; set; }
            public System.Int32? NewPublicVirtualInterface_Vlan { get; set; }
            public System.Func<Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse, NewDCPublicVirtualInterfaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
