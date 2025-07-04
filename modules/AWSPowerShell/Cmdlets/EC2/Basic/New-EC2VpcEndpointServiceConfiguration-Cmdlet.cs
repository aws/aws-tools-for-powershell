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
    /// Creates a VPC endpoint service to which service consumers (Amazon Web Services accounts,
    /// users, and IAM roles) can connect.
    /// 
    ///  
    /// <para>
    /// Before you create an endpoint service, you must create one of the following for your
    /// service:
    /// </para><ul><li><para>
    /// A <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/network/">Network
    /// Load Balancer</a>. Service consumers connect to your service using an interface endpoint.
    /// </para></li><li><para>
    /// A <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/gateway/">Gateway
    /// Load Balancer</a>. Service consumers connect to your service using a Gateway Load
    /// Balancer endpoint.
    /// </para></li></ul><para>
    /// If you set the private DNS name, you must prove that you own the private DNS domain
    /// name.
    /// </para><para>
    /// For more information, see the <a href="https://docs.aws.amazon.com/vpc/latest/privatelink/">Amazon
    /// Web Services PrivateLink Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2VpcEndpointServiceConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateVpcEndpointServiceConfiguration API operation.", Operation = new[] {"CreateVpcEndpointServiceConfiguration"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationResponse",
        "This cmdlet returns an Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationResponse object containing multiple properties."
    )]
    public partial class NewEC2VpcEndpointServiceConfigurationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AcceptanceRequired
        /// <summary>
        /// <para>
        /// <para>Indicates whether requests from service consumers to create an endpoint to your service
        /// must be accepted manually.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AcceptanceRequired { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter GatewayLoadBalancerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the Gateway Load Balancers.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GatewayLoadBalancerArns")]
        public System.String[] GatewayLoadBalancerArn { get; set; }
        #endregion
        
        #region Parameter NetworkLoadBalancerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the Network Load Balancers.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("NetworkLoadBalancerArns")]
        public System.String[] NetworkLoadBalancerArn { get; set; }
        #endregion
        
        #region Parameter PrivateDnsName
        /// <summary>
        /// <para>
        /// <para>(Interface endpoint configuration) The private DNS name to assign to the VPC endpoint
        /// service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrivateDnsName { get; set; }
        #endregion
        
        #region Parameter SupportedIpAddressType
        /// <summary>
        /// <para>
        /// <para>The supported IP address types. The possible values are <c>ipv4</c> and <c>ipv6</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SupportedIpAddressTypes")]
        public System.String[] SupportedIpAddressType { get; set; }
        #endregion
        
        #region Parameter SupportedRegion
        /// <summary>
        /// <para>
        /// <para>The Regions from which service consumers can access the service.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SupportedRegions")]
        public System.String[] SupportedRegion { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the service.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">How
        /// to ensure idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NetworkLoadBalancerArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2VpcEndpointServiceConfiguration (CreateVpcEndpointServiceConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationResponse, NewEC2VpcEndpointServiceConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptanceRequired = this.AcceptanceRequired;
            context.ClientToken = this.ClientToken;
            context.DryRun = this.DryRun;
            if (this.GatewayLoadBalancerArn != null)
            {
                context.GatewayLoadBalancerArn = new List<System.String>(this.GatewayLoadBalancerArn);
            }
            if (this.NetworkLoadBalancerArn != null)
            {
                context.NetworkLoadBalancerArn = new List<System.String>(this.NetworkLoadBalancerArn);
            }
            context.PrivateDnsName = this.PrivateDnsName;
            if (this.SupportedIpAddressType != null)
            {
                context.SupportedIpAddressType = new List<System.String>(this.SupportedIpAddressType);
            }
            if (this.SupportedRegion != null)
            {
                context.SupportedRegion = new List<System.String>(this.SupportedRegion);
            }
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
            var request = new Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationRequest();
            
            if (cmdletContext.AcceptanceRequired != null)
            {
                request.AcceptanceRequired = cmdletContext.AcceptanceRequired.Value;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.GatewayLoadBalancerArn != null)
            {
                request.GatewayLoadBalancerArns = cmdletContext.GatewayLoadBalancerArn;
            }
            if (cmdletContext.NetworkLoadBalancerArn != null)
            {
                request.NetworkLoadBalancerArns = cmdletContext.NetworkLoadBalancerArn;
            }
            if (cmdletContext.PrivateDnsName != null)
            {
                request.PrivateDnsName = cmdletContext.PrivateDnsName;
            }
            if (cmdletContext.SupportedIpAddressType != null)
            {
                request.SupportedIpAddressTypes = cmdletContext.SupportedIpAddressType;
            }
            if (cmdletContext.SupportedRegion != null)
            {
                request.SupportedRegions = cmdletContext.SupportedRegion;
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
        
        private Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateVpcEndpointServiceConfiguration");
            try
            {
                return client.CreateVpcEndpointServiceConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AcceptanceRequired { get; set; }
            public System.String ClientToken { get; set; }
            public System.Boolean? DryRun { get; set; }
            public List<System.String> GatewayLoadBalancerArn { get; set; }
            public List<System.String> NetworkLoadBalancerArn { get; set; }
            public System.String PrivateDnsName { get; set; }
            public List<System.String> SupportedIpAddressType { get; set; }
            public List<System.String> SupportedRegion { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateVpcEndpointServiceConfigurationResponse, NewEC2VpcEndpointServiceConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
