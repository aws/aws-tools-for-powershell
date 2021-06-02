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
using Amazon.Route53Resolver;
using Amazon.Route53Resolver.Model;

namespace Amazon.PowerShell.Cmdlets.R53R
{
    /// <summary>
    /// Creates a Resolver endpoint. There are two types of Resolver endpoints, inbound and
    /// outbound:
    /// 
    ///  <ul><li><para>
    /// An <i>inbound Resolver endpoint</i> forwards DNS queries to the DNS service for a
    /// VPC from your network.
    /// </para></li><li><para>
    /// An <i>outbound Resolver endpoint</i> forwards DNS queries from the DNS service for
    /// a VPC to your network.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "R53RResolverEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53Resolver.Model.ResolverEndpoint")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver CreateResolverEndpoint API operation.", Operation = new[] {"CreateResolverEndpoint"}, SelectReturnType = typeof(Amazon.Route53Resolver.Model.CreateResolverEndpointResponse))]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.ResolverEndpoint or Amazon.Route53Resolver.Model.CreateResolverEndpointResponse",
        "This cmdlet returns an Amazon.Route53Resolver.Model.ResolverEndpoint object.",
        "The service call response (type Amazon.Route53Resolver.Model.CreateResolverEndpointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewR53RResolverEndpointCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows failed requests to be
        /// retried without the risk of running the operation twice. <code>CreatorRequestId</code>
        /// can be any unique string, for example, a date/time stamp. </para>
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
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter Direction
        /// <summary>
        /// <para>
        /// <para>Specify the applicable value:</para><ul><li><para><code>INBOUND</code>: Resolver forwards DNS queries to the DNS service for a VPC
        /// from your network</para></li><li><para><code>OUTBOUND</code>: Resolver forwards DNS queries from the DNS service for a VPC
        /// to your network</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Route53Resolver.ResolverEndpointDirection")]
        public Amazon.Route53Resolver.ResolverEndpointDirection Direction { get; set; }
        #endregion
        
        #region Parameter IpAddress
        /// <summary>
        /// <para>
        /// <para>The subnets and IP addresses in your VPC that DNS queries originate from (for outbound
        /// endpoints) or that you forward DNS queries to (for inbound endpoints). The subnet
        /// ID uniquely identifies a VPC. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("IpAddresses")]
        public Amazon.Route53Resolver.Model.IpAddressRequest[] IpAddress { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A friendly name that lets you easily find a configuration in the Resolver dashboard
        /// in the Route 53 console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of one or more security groups that you want to use to control access to this
        /// VPC. The security group that you specify must include one or more inbound rules (for
        /// inbound Resolver endpoints) or outbound rules (for outbound Resolver endpoints). Inbound
        /// and outbound rules must allow TCP and UDP access. For inbound access, open port 53.
        /// For outbound access, open the port that you're using for DNS queries on your network.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of the tag keys and values that you want to associate with the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Route53Resolver.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResolverEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Resolver.Model.CreateResolverEndpointResponse).
        /// Specifying the name of a property of type Amazon.Route53Resolver.Model.CreateResolverEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResolverEndpoint";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53RResolverEndpoint (CreateResolverEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Resolver.Model.CreateResolverEndpointResponse, NewR53RResolverEndpointCmdlet>(Select) ??
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
            context.CreatorRequestId = this.CreatorRequestId;
            #if MODULAR
            if (this.CreatorRequestId == null && ParameterWasBound(nameof(this.CreatorRequestId)))
            {
                WriteWarning("You are passing $null as a value for parameter CreatorRequestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Direction = this.Direction;
            #if MODULAR
            if (this.Direction == null && ParameterWasBound(nameof(this.Direction)))
            {
                WriteWarning("You are passing $null as a value for parameter Direction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.IpAddress != null)
            {
                context.IpAddress = new List<Amazon.Route53Resolver.Model.IpAddressRequest>(this.IpAddress);
            }
            #if MODULAR
            if (this.IpAddress == null && ParameterWasBound(nameof(this.IpAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter IpAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            #if MODULAR
            if (this.SecurityGroupId == null && ParameterWasBound(nameof(this.SecurityGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecurityGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Route53Resolver.Model.Tag>(this.Tag);
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
            var request = new Amazon.Route53Resolver.Model.CreateResolverEndpointRequest();
            
            if (cmdletContext.CreatorRequestId != null)
            {
                request.CreatorRequestId = cmdletContext.CreatorRequestId;
            }
            if (cmdletContext.Direction != null)
            {
                request.Direction = cmdletContext.Direction;
            }
            if (cmdletContext.IpAddress != null)
            {
                request.IpAddresses = cmdletContext.IpAddress;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
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
        
        private Amazon.Route53Resolver.Model.CreateResolverEndpointResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.CreateResolverEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "CreateResolverEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateResolverEndpoint(request);
                #elif CORECLR
                return client.CreateResolverEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.String CreatorRequestId { get; set; }
            public Amazon.Route53Resolver.ResolverEndpointDirection Direction { get; set; }
            public List<Amazon.Route53Resolver.Model.IpAddressRequest> IpAddress { get; set; }
            public System.String Name { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public List<Amazon.Route53Resolver.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Route53Resolver.Model.CreateResolverEndpointResponse, NewR53RResolverEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResolverEndpoint;
        }
        
    }
}
