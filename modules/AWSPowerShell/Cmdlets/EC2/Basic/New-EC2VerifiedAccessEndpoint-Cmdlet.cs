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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// An Amazon Web Services Verified Access endpoint is where you define your application
    /// along with an optional endpoint-level access policy.
    /// </summary>
    [Cmdlet("New", "EC2VerifiedAccessEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VerifiedAccessEndpoint")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateVerifiedAccessEndpoint API operation.", Operation = new[] {"CreateVerifiedAccessEndpoint"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateVerifiedAccessEndpointResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VerifiedAccessEndpoint or Amazon.EC2.Model.CreateVerifiedAccessEndpointResponse",
        "This cmdlet returns an Amazon.EC2.Model.VerifiedAccessEndpoint object.",
        "The service call response (type Amazon.EC2.Model.CreateVerifiedAccessEndpointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2VerifiedAccessEndpointCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationDomain
        /// <summary>
        /// <para>
        /// <para>The DNS name for users to reach your application.</para>
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
        public System.String ApplicationDomain { get; set; }
        #endregion
        
        #region Parameter AttachmentType
        /// <summary>
        /// <para>
        /// <para>The type of attachment.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.VerifiedAccessEndpointAttachmentType")]
        public Amazon.EC2.VerifiedAccessEndpointAttachmentType AttachmentType { get; set; }
        #endregion
        
        #region Parameter SseSpecification_CustomerManagedKeyEnabled
        /// <summary>
        /// <para>
        /// <para> Enable or disable the use of customer managed KMS keys for server side encryption.
        /// </para><para>Valid values: <code>True</code> | <code>False</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SseSpecification_CustomerManagedKeyEnabled { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the Verified Access endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainCertificateArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the public TLS/SSL certificate in Amazon Web Services Certificate Manager
        /// to associate with the endpoint. The CN in the certificate must match the DNS name
        /// your end users will use to reach your application.</para>
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
        public System.String DomainCertificateArn { get; set; }
        #endregion
        
        #region Parameter EndpointDomainPrefix
        /// <summary>
        /// <para>
        /// <para>A custom identifier that is prepended to the DNS name that is generated for the endpoint.</para>
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
        public System.String EndpointDomainPrefix { get; set; }
        #endregion
        
        #region Parameter EndpointType
        /// <summary>
        /// <para>
        /// <para>The type of Verified Access endpoint to create.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.VerifiedAccessEndpointType")]
        public Amazon.EC2.VerifiedAccessEndpointType EndpointType { get; set; }
        #endregion
        
        #region Parameter SseSpecification_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the KMS key. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SseSpecification_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter LoadBalancerOptions_LoadBalancerArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoadBalancerOptions_LoadBalancerArn { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceOptions_NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkInterfaceOptions_NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter PolicyDocument
        /// <summary>
        /// <para>
        /// <para>The Verified Access policy document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyDocument { get; set; }
        #endregion
        
        #region Parameter LoadBalancerOptions_Port
        /// <summary>
        /// <para>
        /// <para>The IP port number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoadBalancerOptions_Port { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceOptions_Port
        /// <summary>
        /// <para>
        /// <para>The IP port number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NetworkInterfaceOptions_Port { get; set; }
        #endregion
        
        #region Parameter LoadBalancerOptions_Protocol
        /// <summary>
        /// <para>
        /// <para>The IP protocol.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VerifiedAccessEndpointProtocol")]
        public Amazon.EC2.VerifiedAccessEndpointProtocol LoadBalancerOptions_Protocol { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceOptions_Protocol
        /// <summary>
        /// <para>
        /// <para>The IP protocol.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VerifiedAccessEndpointProtocol")]
        public Amazon.EC2.VerifiedAccessEndpointProtocol NetworkInterfaceOptions_Protocol { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups to associate with the Verified Access endpoint. Required
        /// if <code>AttachmentType</code> is set to <code>vpc</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter LoadBalancerOptions_SubnetId
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancerOptions_SubnetIds")]
        public System.String[] LoadBalancerOptions_SubnetId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the Verified Access endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter VerifiedAccessGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the Verified Access group to associate the endpoint with.</para>
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
        public System.String VerifiedAccessGroupId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive token that you provide to ensure idempotency of your modification
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VerifiedAccessEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateVerifiedAccessEndpointResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateVerifiedAccessEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VerifiedAccessEndpoint";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VerifiedAccessGroupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VerifiedAccessGroupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VerifiedAccessGroupId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainCertificateArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2VerifiedAccessEndpoint (CreateVerifiedAccessEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateVerifiedAccessEndpointResponse, NewEC2VerifiedAccessEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VerifiedAccessGroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationDomain = this.ApplicationDomain;
            #if MODULAR
            if (this.ApplicationDomain == null && ParameterWasBound(nameof(this.ApplicationDomain)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationDomain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AttachmentType = this.AttachmentType;
            #if MODULAR
            if (this.AttachmentType == null && ParameterWasBound(nameof(this.AttachmentType)))
            {
                WriteWarning("You are passing $null as a value for parameter AttachmentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DomainCertificateArn = this.DomainCertificateArn;
            #if MODULAR
            if (this.DomainCertificateArn == null && ParameterWasBound(nameof(this.DomainCertificateArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainCertificateArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointDomainPrefix = this.EndpointDomainPrefix;
            #if MODULAR
            if (this.EndpointDomainPrefix == null && ParameterWasBound(nameof(this.EndpointDomainPrefix)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointDomainPrefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointType = this.EndpointType;
            #if MODULAR
            if (this.EndpointType == null && ParameterWasBound(nameof(this.EndpointType)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoadBalancerOptions_LoadBalancerArn = this.LoadBalancerOptions_LoadBalancerArn;
            context.LoadBalancerOptions_Port = this.LoadBalancerOptions_Port;
            context.LoadBalancerOptions_Protocol = this.LoadBalancerOptions_Protocol;
            if (this.LoadBalancerOptions_SubnetId != null)
            {
                context.LoadBalancerOptions_SubnetId = new List<System.String>(this.LoadBalancerOptions_SubnetId);
            }
            context.NetworkInterfaceOptions_NetworkInterfaceId = this.NetworkInterfaceOptions_NetworkInterfaceId;
            context.NetworkInterfaceOptions_Port = this.NetworkInterfaceOptions_Port;
            context.NetworkInterfaceOptions_Protocol = this.NetworkInterfaceOptions_Protocol;
            context.PolicyDocument = this.PolicyDocument;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            context.SseSpecification_CustomerManagedKeyEnabled = this.SseSpecification_CustomerManagedKeyEnabled;
            context.SseSpecification_KmsKeyArn = this.SseSpecification_KmsKeyArn;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.VerifiedAccessGroupId = this.VerifiedAccessGroupId;
            #if MODULAR
            if (this.VerifiedAccessGroupId == null && ParameterWasBound(nameof(this.VerifiedAccessGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter VerifiedAccessGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CreateVerifiedAccessEndpointRequest();
            
            if (cmdletContext.ApplicationDomain != null)
            {
                request.ApplicationDomain = cmdletContext.ApplicationDomain;
            }
            if (cmdletContext.AttachmentType != null)
            {
                request.AttachmentType = cmdletContext.AttachmentType;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainCertificateArn != null)
            {
                request.DomainCertificateArn = cmdletContext.DomainCertificateArn;
            }
            if (cmdletContext.EndpointDomainPrefix != null)
            {
                request.EndpointDomainPrefix = cmdletContext.EndpointDomainPrefix;
            }
            if (cmdletContext.EndpointType != null)
            {
                request.EndpointType = cmdletContext.EndpointType;
            }
            
             // populate LoadBalancerOptions
            var requestLoadBalancerOptionsIsNull = true;
            request.LoadBalancerOptions = new Amazon.EC2.Model.CreateVerifiedAccessEndpointLoadBalancerOptions();
            System.String requestLoadBalancerOptions_loadBalancerOptions_LoadBalancerArn = null;
            if (cmdletContext.LoadBalancerOptions_LoadBalancerArn != null)
            {
                requestLoadBalancerOptions_loadBalancerOptions_LoadBalancerArn = cmdletContext.LoadBalancerOptions_LoadBalancerArn;
            }
            if (requestLoadBalancerOptions_loadBalancerOptions_LoadBalancerArn != null)
            {
                request.LoadBalancerOptions.LoadBalancerArn = requestLoadBalancerOptions_loadBalancerOptions_LoadBalancerArn;
                requestLoadBalancerOptionsIsNull = false;
            }
            System.Int32? requestLoadBalancerOptions_loadBalancerOptions_Port = null;
            if (cmdletContext.LoadBalancerOptions_Port != null)
            {
                requestLoadBalancerOptions_loadBalancerOptions_Port = cmdletContext.LoadBalancerOptions_Port.Value;
            }
            if (requestLoadBalancerOptions_loadBalancerOptions_Port != null)
            {
                request.LoadBalancerOptions.Port = requestLoadBalancerOptions_loadBalancerOptions_Port.Value;
                requestLoadBalancerOptionsIsNull = false;
            }
            Amazon.EC2.VerifiedAccessEndpointProtocol requestLoadBalancerOptions_loadBalancerOptions_Protocol = null;
            if (cmdletContext.LoadBalancerOptions_Protocol != null)
            {
                requestLoadBalancerOptions_loadBalancerOptions_Protocol = cmdletContext.LoadBalancerOptions_Protocol;
            }
            if (requestLoadBalancerOptions_loadBalancerOptions_Protocol != null)
            {
                request.LoadBalancerOptions.Protocol = requestLoadBalancerOptions_loadBalancerOptions_Protocol;
                requestLoadBalancerOptionsIsNull = false;
            }
            List<System.String> requestLoadBalancerOptions_loadBalancerOptions_SubnetId = null;
            if (cmdletContext.LoadBalancerOptions_SubnetId != null)
            {
                requestLoadBalancerOptions_loadBalancerOptions_SubnetId = cmdletContext.LoadBalancerOptions_SubnetId;
            }
            if (requestLoadBalancerOptions_loadBalancerOptions_SubnetId != null)
            {
                request.LoadBalancerOptions.SubnetIds = requestLoadBalancerOptions_loadBalancerOptions_SubnetId;
                requestLoadBalancerOptionsIsNull = false;
            }
             // determine if request.LoadBalancerOptions should be set to null
            if (requestLoadBalancerOptionsIsNull)
            {
                request.LoadBalancerOptions = null;
            }
            
             // populate NetworkInterfaceOptions
            var requestNetworkInterfaceOptionsIsNull = true;
            request.NetworkInterfaceOptions = new Amazon.EC2.Model.CreateVerifiedAccessEndpointEniOptions();
            System.String requestNetworkInterfaceOptions_networkInterfaceOptions_NetworkInterfaceId = null;
            if (cmdletContext.NetworkInterfaceOptions_NetworkInterfaceId != null)
            {
                requestNetworkInterfaceOptions_networkInterfaceOptions_NetworkInterfaceId = cmdletContext.NetworkInterfaceOptions_NetworkInterfaceId;
            }
            if (requestNetworkInterfaceOptions_networkInterfaceOptions_NetworkInterfaceId != null)
            {
                request.NetworkInterfaceOptions.NetworkInterfaceId = requestNetworkInterfaceOptions_networkInterfaceOptions_NetworkInterfaceId;
                requestNetworkInterfaceOptionsIsNull = false;
            }
            System.Int32? requestNetworkInterfaceOptions_networkInterfaceOptions_Port = null;
            if (cmdletContext.NetworkInterfaceOptions_Port != null)
            {
                requestNetworkInterfaceOptions_networkInterfaceOptions_Port = cmdletContext.NetworkInterfaceOptions_Port.Value;
            }
            if (requestNetworkInterfaceOptions_networkInterfaceOptions_Port != null)
            {
                request.NetworkInterfaceOptions.Port = requestNetworkInterfaceOptions_networkInterfaceOptions_Port.Value;
                requestNetworkInterfaceOptionsIsNull = false;
            }
            Amazon.EC2.VerifiedAccessEndpointProtocol requestNetworkInterfaceOptions_networkInterfaceOptions_Protocol = null;
            if (cmdletContext.NetworkInterfaceOptions_Protocol != null)
            {
                requestNetworkInterfaceOptions_networkInterfaceOptions_Protocol = cmdletContext.NetworkInterfaceOptions_Protocol;
            }
            if (requestNetworkInterfaceOptions_networkInterfaceOptions_Protocol != null)
            {
                request.NetworkInterfaceOptions.Protocol = requestNetworkInterfaceOptions_networkInterfaceOptions_Protocol;
                requestNetworkInterfaceOptionsIsNull = false;
            }
             // determine if request.NetworkInterfaceOptions should be set to null
            if (requestNetworkInterfaceOptionsIsNull)
            {
                request.NetworkInterfaceOptions = null;
            }
            if (cmdletContext.PolicyDocument != null)
            {
                request.PolicyDocument = cmdletContext.PolicyDocument;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            
             // populate SseSpecification
            var requestSseSpecificationIsNull = true;
            request.SseSpecification = new Amazon.EC2.Model.VerifiedAccessSseSpecificationRequest();
            System.Boolean? requestSseSpecification_sseSpecification_CustomerManagedKeyEnabled = null;
            if (cmdletContext.SseSpecification_CustomerManagedKeyEnabled != null)
            {
                requestSseSpecification_sseSpecification_CustomerManagedKeyEnabled = cmdletContext.SseSpecification_CustomerManagedKeyEnabled.Value;
            }
            if (requestSseSpecification_sseSpecification_CustomerManagedKeyEnabled != null)
            {
                request.SseSpecification.CustomerManagedKeyEnabled = requestSseSpecification_sseSpecification_CustomerManagedKeyEnabled.Value;
                requestSseSpecificationIsNull = false;
            }
            System.String requestSseSpecification_sseSpecification_KmsKeyArn = null;
            if (cmdletContext.SseSpecification_KmsKeyArn != null)
            {
                requestSseSpecification_sseSpecification_KmsKeyArn = cmdletContext.SseSpecification_KmsKeyArn;
            }
            if (requestSseSpecification_sseSpecification_KmsKeyArn != null)
            {
                request.SseSpecification.KmsKeyArn = requestSseSpecification_sseSpecification_KmsKeyArn;
                requestSseSpecificationIsNull = false;
            }
             // determine if request.SseSpecification should be set to null
            if (requestSseSpecificationIsNull)
            {
                request.SseSpecification = null;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.VerifiedAccessGroupId != null)
            {
                request.VerifiedAccessGroupId = cmdletContext.VerifiedAccessGroupId;
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
        
        private Amazon.EC2.Model.CreateVerifiedAccessEndpointResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateVerifiedAccessEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateVerifiedAccessEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateVerifiedAccessEndpoint(request);
                #elif CORECLR
                return client.CreateVerifiedAccessEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationDomain { get; set; }
            public Amazon.EC2.VerifiedAccessEndpointAttachmentType AttachmentType { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String DomainCertificateArn { get; set; }
            public System.String EndpointDomainPrefix { get; set; }
            public Amazon.EC2.VerifiedAccessEndpointType EndpointType { get; set; }
            public System.String LoadBalancerOptions_LoadBalancerArn { get; set; }
            public System.Int32? LoadBalancerOptions_Port { get; set; }
            public Amazon.EC2.VerifiedAccessEndpointProtocol LoadBalancerOptions_Protocol { get; set; }
            public List<System.String> LoadBalancerOptions_SubnetId { get; set; }
            public System.String NetworkInterfaceOptions_NetworkInterfaceId { get; set; }
            public System.Int32? NetworkInterfaceOptions_Port { get; set; }
            public Amazon.EC2.VerifiedAccessEndpointProtocol NetworkInterfaceOptions_Protocol { get; set; }
            public System.String PolicyDocument { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public System.Boolean? SseSpecification_CustomerManagedKeyEnabled { get; set; }
            public System.String SseSpecification_KmsKeyArn { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.String VerifiedAccessGroupId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateVerifiedAccessEndpointResponse, NewEC2VerifiedAccessEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VerifiedAccessEndpoint;
        }
        
    }
}
