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
using Amazon.NetworkManager;
using Amazon.NetworkManager.Model;

namespace Amazon.PowerShell.Cmdlets.NMGR
{
    /// <summary>
    /// Starts analyzing the routing path between the specified source and destination. For
    /// more information, see <a href="https://docs.aws.amazon.com/vpc/latest/tgw/route-analyzer.html">Route
    /// Analyzer</a>.
    /// </summary>
    [Cmdlet("Start", "NMGRRouteAnalysis", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkManager.Model.RouteAnalysis")]
    [AWSCmdlet("Calls the AWS Network Manager StartRouteAnalysis API operation.", Operation = new[] {"StartRouteAnalysis"}, SelectReturnType = typeof(Amazon.NetworkManager.Model.StartRouteAnalysisResponse))]
    [AWSCmdletOutput("Amazon.NetworkManager.Model.RouteAnalysis or Amazon.NetworkManager.Model.StartRouteAnalysisResponse",
        "This cmdlet returns an Amazon.NetworkManager.Model.RouteAnalysis object.",
        "The service call response (type Amazon.NetworkManager.Model.StartRouteAnalysisResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartNMGRRouteAnalysisCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        #region Parameter GlobalNetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the global network.</para>
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
        public System.String GlobalNetworkId { get; set; }
        #endregion
        
        #region Parameter IncludeReturnPath
        /// <summary>
        /// <para>
        /// <para>Indicates whether to analyze the return path. The default is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeReturnPath { get; set; }
        #endregion
        
        #region Parameter Destination_IpAddress
        /// <summary>
        /// <para>
        /// <para>The IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Destination_IpAddress { get; set; }
        #endregion
        
        #region Parameter Source_IpAddress
        /// <summary>
        /// <para>
        /// <para>The IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_IpAddress { get; set; }
        #endregion
        
        #region Parameter Destination_TransitGatewayAttachmentArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the transit gateway attachment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Destination_TransitGatewayAttachmentArn { get; set; }
        #endregion
        
        #region Parameter Source_TransitGatewayAttachmentArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the transit gateway attachment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_TransitGatewayAttachmentArn { get; set; }
        #endregion
        
        #region Parameter UseMiddlebox
        /// <summary>
        /// <para>
        /// <para>Indicates whether to include the location of middlebox appliances in the route analysis.
        /// The default is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UseMiddleboxes")]
        public System.Boolean? UseMiddlebox { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RouteAnalysis'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkManager.Model.StartRouteAnalysisResponse).
        /// Specifying the name of a property of type Amazon.NetworkManager.Model.StartRouteAnalysisResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RouteAnalysis";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GlobalNetworkId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GlobalNetworkId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GlobalNetworkId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GlobalNetworkId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-NMGRRouteAnalysis (StartRouteAnalysis)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.StartRouteAnalysisResponse, StartNMGRRouteAnalysisCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GlobalNetworkId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Destination_IpAddress = this.Destination_IpAddress;
            context.Destination_TransitGatewayAttachmentArn = this.Destination_TransitGatewayAttachmentArn;
            context.GlobalNetworkId = this.GlobalNetworkId;
            #if MODULAR
            if (this.GlobalNetworkId == null && ParameterWasBound(nameof(this.GlobalNetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalNetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IncludeReturnPath = this.IncludeReturnPath;
            context.Source_IpAddress = this.Source_IpAddress;
            context.Source_TransitGatewayAttachmentArn = this.Source_TransitGatewayAttachmentArn;
            context.UseMiddlebox = this.UseMiddlebox;
            
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
            var request = new Amazon.NetworkManager.Model.StartRouteAnalysisRequest();
            
            
             // populate Destination
            var requestDestinationIsNull = true;
            request.Destination = new Amazon.NetworkManager.Model.RouteAnalysisEndpointOptionsSpecification();
            System.String requestDestination_destination_IpAddress = null;
            if (cmdletContext.Destination_IpAddress != null)
            {
                requestDestination_destination_IpAddress = cmdletContext.Destination_IpAddress;
            }
            if (requestDestination_destination_IpAddress != null)
            {
                request.Destination.IpAddress = requestDestination_destination_IpAddress;
                requestDestinationIsNull = false;
            }
            System.String requestDestination_destination_TransitGatewayAttachmentArn = null;
            if (cmdletContext.Destination_TransitGatewayAttachmentArn != null)
            {
                requestDestination_destination_TransitGatewayAttachmentArn = cmdletContext.Destination_TransitGatewayAttachmentArn;
            }
            if (requestDestination_destination_TransitGatewayAttachmentArn != null)
            {
                request.Destination.TransitGatewayAttachmentArn = requestDestination_destination_TransitGatewayAttachmentArn;
                requestDestinationIsNull = false;
            }
             // determine if request.Destination should be set to null
            if (requestDestinationIsNull)
            {
                request.Destination = null;
            }
            if (cmdletContext.GlobalNetworkId != null)
            {
                request.GlobalNetworkId = cmdletContext.GlobalNetworkId;
            }
            if (cmdletContext.IncludeReturnPath != null)
            {
                request.IncludeReturnPath = cmdletContext.IncludeReturnPath.Value;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.NetworkManager.Model.RouteAnalysisEndpointOptionsSpecification();
            System.String requestSource_source_IpAddress = null;
            if (cmdletContext.Source_IpAddress != null)
            {
                requestSource_source_IpAddress = cmdletContext.Source_IpAddress;
            }
            if (requestSource_source_IpAddress != null)
            {
                request.Source.IpAddress = requestSource_source_IpAddress;
                requestSourceIsNull = false;
            }
            System.String requestSource_source_TransitGatewayAttachmentArn = null;
            if (cmdletContext.Source_TransitGatewayAttachmentArn != null)
            {
                requestSource_source_TransitGatewayAttachmentArn = cmdletContext.Source_TransitGatewayAttachmentArn;
            }
            if (requestSource_source_TransitGatewayAttachmentArn != null)
            {
                request.Source.TransitGatewayAttachmentArn = requestSource_source_TransitGatewayAttachmentArn;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
            }
            if (cmdletContext.UseMiddlebox != null)
            {
                request.UseMiddleboxes = cmdletContext.UseMiddlebox.Value;
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
        
        private Amazon.NetworkManager.Model.StartRouteAnalysisResponse CallAWSServiceOperation(IAmazonNetworkManager client, Amazon.NetworkManager.Model.StartRouteAnalysisRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Manager", "StartRouteAnalysis");
            try
            {
                #if DESKTOP
                return client.StartRouteAnalysis(request);
                #elif CORECLR
                return client.StartRouteAnalysisAsync(request).GetAwaiter().GetResult();
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
            public System.String Destination_IpAddress { get; set; }
            public System.String Destination_TransitGatewayAttachmentArn { get; set; }
            public System.String GlobalNetworkId { get; set; }
            public System.Boolean? IncludeReturnPath { get; set; }
            public System.String Source_IpAddress { get; set; }
            public System.String Source_TransitGatewayAttachmentArn { get; set; }
            public System.Boolean? UseMiddlebox { get; set; }
            public System.Func<Amazon.NetworkManager.Model.StartRouteAnalysisResponse, StartNMGRRouteAnalysisCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RouteAnalysis;
        }
        
    }
}
