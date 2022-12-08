/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Creates a link aggregation group (LAG) with the specified number of bundled physical
    /// dedicated connections between the customer network and a specific Direct Connect location.
    /// A LAG is a logical interface that uses the Link Aggregation Control Protocol (LACP)
    /// to aggregate multiple interfaces, enabling you to treat them as a single interface.
    /// 
    ///  
    /// <para>
    /// All connections in a LAG must use the same bandwidth (either 1Gbps or 10Gbps) and
    /// must terminate at the same Direct Connect endpoint.
    /// </para><para>
    /// You can have up to 10 dedicated connections per LAG. Regardless of this limit, if
    /// you request more connections for the LAG than Direct Connect can allocate on a single
    /// endpoint, no LAG is created.
    /// </para><para>
    /// You can specify an existing physical dedicated connection or interconnect to include
    /// in the LAG (which counts towards the total number of connections). Doing so interrupts
    /// the current physical dedicated connection, and re-establishes them as a member of
    /// the LAG. The LAG will be created on the same Direct Connect endpoint to which the
    /// dedicated connection terminates. Any virtual interfaces associated with the dedicated
    /// connection are automatically disassociated and re-associated with the LAG. The connection
    /// ID does not change.
    /// </para><para>
    /// If the Amazon Web Services account used to create a LAG is a registered Direct Connect
    /// Partner, the LAG is automatically enabled to host sub-connections. For a LAG owned
    /// by a partner, any associated virtual interfaces cannot be directly configured.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DCLag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.CreateLagResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect CreateLag API operation.", Operation = new[] {"CreateLag"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.CreateLagResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.CreateLagResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.CreateLagResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDCLagCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter ChildConnectionTag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the automtically created LAGs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChildConnectionTags")]
        public Amazon.DirectConnect.Model.Tag[] ChildConnectionTag { get; set; }
        #endregion
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of an existing dedicated connection to migrate to the LAG.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter ConnectionsBandwidth
        /// <summary>
        /// <para>
        /// <para>The bandwidth of the individual physical dedicated connections bundled by the LAG.
        /// The possible values are 1Gbps and 10Gbps. </para>
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
        public System.String ConnectionsBandwidth { get; set; }
        #endregion
        
        #region Parameter LagName
        /// <summary>
        /// <para>
        /// <para>The name of the LAG.</para>
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
        public System.String LagName { get; set; }
        #endregion
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <para>The location for the LAG.</para>
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
        public System.String Location { get; set; }
        #endregion
        
        #region Parameter NumberOfConnection
        /// <summary>
        /// <para>
        /// <para>The number of physical dedicated connections initially provisioned and bundled by
        /// the LAG.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("NumberOfConnections")]
        public System.Int32? NumberOfConnection { get; set; }
        #endregion
        
        #region Parameter ProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the service provider associated with the LAG.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderName { get; set; }
        #endregion
        
        #region Parameter RequestMACSec
        /// <summary>
        /// <para>
        /// <para>Indicates whether the connection will support MAC Security (MACsec).</para><note><para>All connections in the LAG must be capable of supporting MAC Security (MACsec). For
        /// information about MAC Security (MACsec) prerequisties, see <a href="https://docs.aws.amazon.com/directconnect/latest/UserGuide/direct-connect-mac-sec-getting-started.html#mac-sec-prerequisites">MACsec
        /// prerequisties</a> in the <i>Direct Connect User Guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RequestMACSec { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the LAG.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DirectConnect.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.CreateLagResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.CreateLagResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConnectionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConnectionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConnectionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCLag (CreateLag)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.CreateLagResponse, NewDCLagCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConnectionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ChildConnectionTag != null)
            {
                context.ChildConnectionTag = new List<Amazon.DirectConnect.Model.Tag>(this.ChildConnectionTag);
            }
            context.ConnectionId = this.ConnectionId;
            context.ConnectionsBandwidth = this.ConnectionsBandwidth;
            #if MODULAR
            if (this.ConnectionsBandwidth == null && ParameterWasBound(nameof(this.ConnectionsBandwidth)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionsBandwidth which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LagName = this.LagName;
            #if MODULAR
            if (this.LagName == null && ParameterWasBound(nameof(this.LagName)))
            {
                WriteWarning("You are passing $null as a value for parameter LagName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Location = this.Location;
            #if MODULAR
            if (this.Location == null && ParameterWasBound(nameof(this.Location)))
            {
                WriteWarning("You are passing $null as a value for parameter Location which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NumberOfConnection = this.NumberOfConnection;
            #if MODULAR
            if (this.NumberOfConnection == null && ParameterWasBound(nameof(this.NumberOfConnection)))
            {
                WriteWarning("You are passing $null as a value for parameter NumberOfConnection which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProviderName = this.ProviderName;
            context.RequestMACSec = this.RequestMACSec;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DirectConnect.Model.Tag>(this.Tag);
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
            var request = new Amazon.DirectConnect.Model.CreateLagRequest();
            
            if (cmdletContext.ChildConnectionTag != null)
            {
                request.ChildConnectionTags = cmdletContext.ChildConnectionTag;
            }
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            if (cmdletContext.ConnectionsBandwidth != null)
            {
                request.ConnectionsBandwidth = cmdletContext.ConnectionsBandwidth;
            }
            if (cmdletContext.LagName != null)
            {
                request.LagName = cmdletContext.LagName;
            }
            if (cmdletContext.Location != null)
            {
                request.Location = cmdletContext.Location;
            }
            if (cmdletContext.NumberOfConnection != null)
            {
                request.NumberOfConnections = cmdletContext.NumberOfConnection.Value;
            }
            if (cmdletContext.ProviderName != null)
            {
                request.ProviderName = cmdletContext.ProviderName;
            }
            if (cmdletContext.RequestMACSec != null)
            {
                request.RequestMACSec = cmdletContext.RequestMACSec.Value;
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
        
        private Amazon.DirectConnect.Model.CreateLagResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreateLagRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "CreateLag");
            try
            {
                #if DESKTOP
                return client.CreateLag(request);
                #elif CORECLR
                return client.CreateLagAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.DirectConnect.Model.Tag> ChildConnectionTag { get; set; }
            public System.String ConnectionId { get; set; }
            public System.String ConnectionsBandwidth { get; set; }
            public System.String LagName { get; set; }
            public System.String Location { get; set; }
            public System.Int32? NumberOfConnection { get; set; }
            public System.String ProviderName { get; set; }
            public System.Boolean? RequestMACSec { get; set; }
            public List<Amazon.DirectConnect.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.DirectConnect.Model.CreateLagResponse, NewDCLagCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
