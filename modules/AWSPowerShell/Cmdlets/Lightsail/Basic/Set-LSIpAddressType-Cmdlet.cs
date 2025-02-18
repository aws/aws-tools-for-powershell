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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Sets the IP address type for an Amazon Lightsail resource.
    /// 
    ///  
    /// <para>
    /// Use this action to enable dual-stack for a resource, which enables IPv4 and IPv6 for
    /// the specified resource. Alternately, you can use this action to disable dual-stack,
    /// and enable IPv4 only.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "LSIpAddressType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail SetIpAddressType API operation.", Operation = new[] {"SetIpAddressType"}, SelectReturnType = typeof(Amazon.Lightsail.Model.SetIpAddressTypeResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.SetIpAddressTypeResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.SetIpAddressTypeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetLSIpAddressTypeCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AcceptBundleUpdate
        /// <summary>
        /// <para>
        /// <para>Required parameter to accept the instance bundle update when changing to, and from,
        /// IPv6-only.</para><note><para>An instance bundle will change when switching from <c>dual-stack</c> or <c>ipv4</c>,
        /// to <c>ipv6</c>. It also changes when switching from <c>ipv6</c>, to <c>dual-stack</c>
        /// or <c>ipv4</c>.</para><para>You must include this parameter in the command to update the bundle. For example,
        /// if you switch from <c>dual-stack</c> to <c>ipv6</c>, the bundle will be updated, and
        /// billing for the IPv6-only instance bundle begins immediately.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AcceptBundleUpdate { get; set; }
        #endregion
        
        #region Parameter IpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address type to set for the specified resource.</para><para>The possible values are <c>ipv4</c> for IPv4 only, <c>ipv6</c> for IPv6 only, and
        /// <c>dualstack</c> for IPv4 and IPv6.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Lightsail.IpAddressType")]
        public Amazon.Lightsail.IpAddressType IpAddressType { get; set; }
        #endregion
        
        #region Parameter ResourceName
        /// <summary>
        /// <para>
        /// <para>The name of the resource for which to set the IP address type.</para>
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
        public System.String ResourceName { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type.</para><para>The resource values are <c>Distribution</c>, <c>Instance</c>, and <c>LoadBalancer</c>.</para><note><para>Distribution-related APIs are available only in the N. Virginia (<c>us-east-1</c>)
        /// Amazon Web Services Region. Set your Amazon Web Services Region configuration to <c>us-east-1</c>
        /// to create, view, or edit distributions.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Lightsail.ResourceType")]
        public Amazon.Lightsail.ResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.SetIpAddressTypeResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.SetIpAddressTypeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operations";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-LSIpAddressType (SetIpAddressType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.SetIpAddressTypeResponse, SetLSIpAddressTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptBundleUpdate = this.AcceptBundleUpdate;
            context.IpAddressType = this.IpAddressType;
            #if MODULAR
            if (this.IpAddressType == null && ParameterWasBound(nameof(this.IpAddressType)))
            {
                WriteWarning("You are passing $null as a value for parameter IpAddressType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceName = this.ResourceName;
            #if MODULAR
            if (this.ResourceName == null && ParameterWasBound(nameof(this.ResourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceType = this.ResourceType;
            #if MODULAR
            if (this.ResourceType == null && ParameterWasBound(nameof(this.ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lightsail.Model.SetIpAddressTypeRequest();
            
            if (cmdletContext.AcceptBundleUpdate != null)
            {
                request.AcceptBundleUpdate = cmdletContext.AcceptBundleUpdate.Value;
            }
            if (cmdletContext.IpAddressType != null)
            {
                request.IpAddressType = cmdletContext.IpAddressType;
            }
            if (cmdletContext.ResourceName != null)
            {
                request.ResourceName = cmdletContext.ResourceName;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
        
        private Amazon.Lightsail.Model.SetIpAddressTypeResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.SetIpAddressTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "SetIpAddressType");
            try
            {
                return client.SetIpAddressTypeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AcceptBundleUpdate { get; set; }
            public Amazon.Lightsail.IpAddressType IpAddressType { get; set; }
            public System.String ResourceName { get; set; }
            public Amazon.Lightsail.ResourceType ResourceType { get; set; }
            public System.Func<Amazon.Lightsail.Model.SetIpAddressTypeResponse, SetLSIpAddressTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operations;
        }
        
    }
}
