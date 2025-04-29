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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a new route server to manage dynamic routing in a VPC.
    /// 
    ///  
    /// <para>
    /// Amazon VPC Route Server simplifies routing for traffic between workloads that are
    /// deployed within a VPC and its internet gateways. With this feature, VPC Route Server
    /// dynamically updates VPC and internet gateway route tables with your preferred IPv4
    /// or IPv6 routes to achieve routing fault tolerance for those workloads. This enables
    /// you to automatically reroute traffic within a VPC, which increases the manageability
    /// of VPC routing and interoperability with third-party workloads.
    /// </para><para>
    /// Route server supports the follow route table types:
    /// </para><ul><li><para>
    /// VPC route tables not associated with subnets
    /// </para></li><li><para>
    /// Subnet route tables
    /// </para></li><li><para>
    /// Internet gateway route tables
    /// </para></li></ul><para>
    /// Route server does not support route tables associated with virtual private gateways.
    /// To propagate routes into a transit gateway route table, use <a href="https://docs.aws.amazon.com/vpc/latest/tgw/tgw-connect.html">Transit
    /// Gateway Connect</a>.
    /// </para><para>
    /// For more information see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/dynamic-routing-route-server.html">Dynamic
    /// routing in your VPC with VPC Route Server</a> in the <i>Amazon VPC User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2RouteServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.RouteServer")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateRouteServer API operation.", Operation = new[] {"CreateRouteServer"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateRouteServerResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.RouteServer or Amazon.EC2.Model.CreateRouteServerResponse",
        "This cmdlet returns an Amazon.EC2.Model.RouteServer object.",
        "The service call response (type Amazon.EC2.Model.CreateRouteServerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2RouteServerCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AmazonSideAsn
        /// <summary>
        /// <para>
        /// <para>The private Autonomous System Number (ASN) for the Amazon side of the BGP session.
        /// Valid values are from 1 to 4294967295. We recommend using a private ASN in the 64512–65534
        /// (16-bit ASN) or 4200000000–4294967294 (32-bit ASN) range.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? AmazonSideAsn { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>A check for whether you have the required permissions for the action without actually
        /// making the request and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter PersistRoute
        /// <summary>
        /// <para>
        /// <para>Indicates whether routes should be persisted after all BGP sessions are terminated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PersistRoutes")]
        [AWSConstantClassSource("Amazon.EC2.RouteServerPersistRoutesAction")]
        public Amazon.EC2.RouteServerPersistRoutesAction PersistRoute { get; set; }
        #endregion
        
        #region Parameter PersistRoutesDuration
        /// <summary>
        /// <para>
        /// <para>The number of minutes a route server will wait after BGP is re-established to unpersist
        /// the routes in the FIB and RIB. Value must be in the range of 1-5. Required if PersistRoutes
        /// is <c>enabled</c>.</para><para>If you set the duration to 1 minute, then when your network appliance re-establishes
        /// BGP with route server, it has 1 minute to relearn it's adjacent network and advertise
        /// those routes to route server before route server resumes normal functionality. In
        /// most cases, 1 minute is probably sufficient. If, however, you have concerns that your
        /// BGP network may not be capable of fully re-establishing and re-learning everything
        /// in 1 minute, you can increase the duration up to 5 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? PersistRoutesDuration { get; set; }
        #endregion
        
        #region Parameter SnsNotificationsEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether SNS notifications should be enabled for route server events. Enabling
        /// SNS notifications persists BGP status changes to an SNS topic provisioned by Amazon
        /// Web Services.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SnsNotificationsEnabled { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the route server during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RouteServer'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateRouteServerResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateRouteServerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RouteServer";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AmazonSideAsn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2RouteServer (CreateRouteServer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateRouteServerResponse, NewEC2RouteServerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AmazonSideAsn = this.AmazonSideAsn;
            #if MODULAR
            if (this.AmazonSideAsn == null && ParameterWasBound(nameof(this.AmazonSideAsn)))
            {
                WriteWarning("You are passing $null as a value for parameter AmazonSideAsn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.DryRun = this.DryRun;
            context.PersistRoute = this.PersistRoute;
            context.PersistRoutesDuration = this.PersistRoutesDuration;
            context.SnsNotificationsEnabled = this.SnsNotificationsEnabled;
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
            var request = new Amazon.EC2.Model.CreateRouteServerRequest();
            
            if (cmdletContext.AmazonSideAsn != null)
            {
                request.AmazonSideAsn = cmdletContext.AmazonSideAsn.Value;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.PersistRoute != null)
            {
                request.PersistRoutes = cmdletContext.PersistRoute;
            }
            if (cmdletContext.PersistRoutesDuration != null)
            {
                request.PersistRoutesDuration = cmdletContext.PersistRoutesDuration.Value;
            }
            if (cmdletContext.SnsNotificationsEnabled != null)
            {
                request.SnsNotificationsEnabled = cmdletContext.SnsNotificationsEnabled.Value;
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
        
        private Amazon.EC2.Model.CreateRouteServerResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateRouteServerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateRouteServer");
            try
            {
                return client.CreateRouteServerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int64? AmazonSideAsn { get; set; }
            public System.String ClientToken { get; set; }
            public System.Boolean? DryRun { get; set; }
            public Amazon.EC2.RouteServerPersistRoutesAction PersistRoute { get; set; }
            public System.Int64? PersistRoutesDuration { get; set; }
            public System.Boolean? SnsNotificationsEnabled { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateRouteServerResponse, NewEC2RouteServerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RouteServer;
        }
        
    }
}
