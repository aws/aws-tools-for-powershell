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
using Amazon.Route53GlobalResolver;
using Amazon.Route53GlobalResolver.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.R53GR
{
    /// <summary>
    /// Creates a core network endpoint, which enables DNS resolution for Amazon Web Services
    /// Cloud WAN core network segments. The endpoint connects a Route 53 Global Resolver
    /// to an Amazon Web Services Cloud WAN core network so that resources attached to the
    /// core network can send DNS queries to the resolver.
    /// 
    ///  <important><para>
    /// Route 53 Global Resolver is a global service that supports resolvers in multiple Amazon
    /// Web Services Regions, but you must specify the US East (Ohio) Region to create, update,
    /// or otherwise work with Route 53 Global Resolver resources. That is, for example, specify
    /// <c>--region us-east-2</c> on Amazon Web Services CLI commands.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "R53GRCoreNetworkEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53GlobalResolver.Model.CreateCoreNetworkEndpointResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 Global Resolver CreateCoreNetworkEndpoint API operation.", Operation = new[] {"CreateCoreNetworkEndpoint"}, SelectReturnType = typeof(Amazon.Route53GlobalResolver.Model.CreateCoreNetworkEndpointResponse))]
    [AWSCmdletOutput("Amazon.Route53GlobalResolver.Model.CreateCoreNetworkEndpointResponse",
        "This cmdlet returns an Amazon.Route53GlobalResolver.Model.CreateCoreNetworkEndpointResponse object containing multiple properties."
    )]
    public partial class NewR53GRCoreNetworkEndpointCmdlet : AmazonRoute53GlobalResolverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CoreNetworkArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services Cloud WAN core network to
        /// connect to this endpoint.</para>
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
        public System.String CoreNetworkArn { get; set; }
        #endregion
        
        #region Parameter GlobalResolverId
        /// <summary>
        /// <para>
        /// <para>The ID of the Route 53 Global Resolver to associate with this core network endpoint.</para>
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
        public System.String GlobalResolverId { get; set; }
        #endregion
        
        #region Parameter IpAddress
        /// <summary>
        /// <para>
        /// <para>The IP addresses that the core network endpoint uses to resolve DNS queries within
        /// the Amazon Web Services Cloud WAN core network.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        public Amazon.Route53GlobalResolver.Model.CoreNetworkEndpointDnsIpInputItem[] IpAddress { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A descriptive name for the core network endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of user-defined keys and optional values that you can use to categorize and
        /// organize the core network endpoint.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that ensures the request is idempotent. Making
        /// the same request multiple times with the same <c>clientToken</c> produces the same
        /// result every time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53GlobalResolver.Model.CreateCoreNetworkEndpointResponse).
        /// Specifying the name of a property of type Amazon.Route53GlobalResolver.Model.CreateCoreNetworkEndpointResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.GlobalResolverId),
                nameof(this.CoreNetworkArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53GRCoreNetworkEndpoint (CreateCoreNetworkEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53GlobalResolver.Model.CreateCoreNetworkEndpointResponse, NewR53GRCoreNetworkEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.CoreNetworkArn = this.CoreNetworkArn;
            #if MODULAR
            if (this.CoreNetworkArn == null && ParameterWasBound(nameof(this.CoreNetworkArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CoreNetworkArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GlobalResolverId = this.GlobalResolverId;
            #if MODULAR
            if (this.GlobalResolverId == null && ParameterWasBound(nameof(this.GlobalResolverId)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalResolverId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.IpAddress != null)
            {
                context.IpAddress = new List<Amazon.Route53GlobalResolver.Model.CoreNetworkEndpointDnsIpInputItem>(this.IpAddress);
            }
            #if MODULAR
            if (this.IpAddress == null && ParameterWasBound(nameof(this.IpAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter IpAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
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
            var request = new Amazon.Route53GlobalResolver.Model.CreateCoreNetworkEndpointRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CoreNetworkArn != null)
            {
                request.CoreNetworkArn = cmdletContext.CoreNetworkArn;
            }
            if (cmdletContext.GlobalResolverId != null)
            {
                request.GlobalResolverId = cmdletContext.GlobalResolverId;
            }
            if (cmdletContext.IpAddress != null)
            {
                request.IpAddresses = cmdletContext.IpAddress;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.Route53GlobalResolver.Model.CreateCoreNetworkEndpointResponse CallAWSServiceOperation(IAmazonRoute53GlobalResolver client, Amazon.Route53GlobalResolver.Model.CreateCoreNetworkEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Global Resolver", "CreateCoreNetworkEndpoint");
            try
            {
                return client.CreateCoreNetworkEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String CoreNetworkArn { get; set; }
            public System.String GlobalResolverId { get; set; }
            public List<Amazon.Route53GlobalResolver.Model.CoreNetworkEndpointDnsIpInputItem> IpAddress { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Route53GlobalResolver.Model.CreateCoreNetworkEndpointResponse, NewR53GRCoreNetworkEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
