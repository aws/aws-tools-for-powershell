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

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Creates an interconnect between an Direct Connect Partner's network and a specific
    /// Direct Connect location.
    /// 
    ///  
    /// <para>
    /// An interconnect is a connection that is capable of hosting other connections. The
    /// Direct Connect Partner can use an interconnect to provide Direct Connect hosted connections
    /// to customers through their own network services. Like a standard connection, an interconnect
    /// links the partner's network to an Direct Connect location over a standard Ethernet
    /// fiber-optic cable. One end is connected to the partner's router, the other to an Direct
    /// Connect router.
    /// </para><para>
    /// You can automatically add the new interconnect to a link aggregation group (LAG) by
    /// specifying a LAG ID in the request. This ensures that the new interconnect is allocated
    /// on the same Direct Connect endpoint that hosts the specified LAG. If there are no
    /// available ports on the endpoint, the request fails and no interconnect is created.
    /// </para><para>
    /// For each end customer, the Direct Connect Partner provisions a connection on their
    /// interconnect by calling <a>AllocateHostedConnection</a>. The end customer can then
    /// connect to Amazon Web Services resources by creating a virtual interface on their
    /// connection, using the VLAN assigned to them by the Direct Connect Partner.
    /// </para><note><para>
    /// Intended for use by Direct Connect Partners only.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "DCInterconnect", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.CreateInterconnectResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect CreateInterconnect API operation.", Operation = new[] {"CreateInterconnect"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.CreateInterconnectResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.CreateInterconnectResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.CreateInterconnectResponse object containing multiple properties."
    )]
    public partial class NewDCInterconnectCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Bandwidth
        /// <summary>
        /// <para>
        /// <para>The port bandwidth, in Gbps. The possible values are 1, 10, and 100.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Bandwidth { get; set; }
        #endregion
        
        #region Parameter InterconnectName
        /// <summary>
        /// <para>
        /// <para>The name of the interconnect.</para>
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
        public System.String InterconnectName { get; set; }
        #endregion
        
        #region Parameter LagId
        /// <summary>
        /// <para>
        /// <para>The ID of the LAG.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LagId { get; set; }
        #endregion
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <para>The location of the interconnect.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Location { get; set; }
        #endregion
        
        #region Parameter ProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the service provider associated with the interconnect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the interconnect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DirectConnect.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.CreateInterconnectResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.CreateInterconnectResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InterconnectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCInterconnect (CreateInterconnect)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.CreateInterconnectResponse, NewDCInterconnectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Bandwidth = this.Bandwidth;
            #if MODULAR
            if (this.Bandwidth == null && ParameterWasBound(nameof(this.Bandwidth)))
            {
                WriteWarning("You are passing $null as a value for parameter Bandwidth which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InterconnectName = this.InterconnectName;
            #if MODULAR
            if (this.InterconnectName == null && ParameterWasBound(nameof(this.InterconnectName)))
            {
                WriteWarning("You are passing $null as a value for parameter InterconnectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LagId = this.LagId;
            context.Location = this.Location;
            #if MODULAR
            if (this.Location == null && ParameterWasBound(nameof(this.Location)))
            {
                WriteWarning("You are passing $null as a value for parameter Location which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProviderName = this.ProviderName;
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
            var request = new Amazon.DirectConnect.Model.CreateInterconnectRequest();
            
            if (cmdletContext.Bandwidth != null)
            {
                request.Bandwidth = cmdletContext.Bandwidth;
            }
            if (cmdletContext.InterconnectName != null)
            {
                request.InterconnectName = cmdletContext.InterconnectName;
            }
            if (cmdletContext.LagId != null)
            {
                request.LagId = cmdletContext.LagId;
            }
            if (cmdletContext.Location != null)
            {
                request.Location = cmdletContext.Location;
            }
            if (cmdletContext.ProviderName != null)
            {
                request.ProviderName = cmdletContext.ProviderName;
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
        
        private Amazon.DirectConnect.Model.CreateInterconnectResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreateInterconnectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "CreateInterconnect");
            try
            {
                return client.CreateInterconnectAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Bandwidth { get; set; }
            public System.String InterconnectName { get; set; }
            public System.String LagId { get; set; }
            public System.String Location { get; set; }
            public System.String ProviderName { get; set; }
            public List<Amazon.DirectConnect.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.DirectConnect.Model.CreateInterconnectResponse, NewDCInterconnectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
