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
    /// Enables Resource Public Key Infrastructure (RPKI) on an existing IPAM internet registry
    /// association by providing BGP Public Key Infrastructure (BPKI) certificate details.
    /// After enabling, you can create Route Origin Authorizations (ROAs) for prefixes registered
    /// with the internet registry.
    /// </summary>
    [Cmdlet("Enable", "EC2IpamInternetRegistryAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.IpamInternetRegistryAssociation")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) EnableIpamInternetRegistryAssociation API operation.", Operation = new[] {"EnableIpamInternetRegistryAssociation"}, SelectReturnType = typeof(Amazon.EC2.Model.EnableIpamInternetRegistryAssociationResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IpamInternetRegistryAssociation or Amazon.EC2.Model.EnableIpamInternetRegistryAssociationResponse",
        "This cmdlet returns an Amazon.EC2.Model.IpamInternetRegistryAssociation object.",
        "The service call response (type Amazon.EC2.Model.EnableIpamInternetRegistryAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnableEC2IpamInternetRegistryAssociationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChildHandle
        /// <summary>
        /// <para>
        /// <para>The child handle for the BPKI certificate hierarchy from the Parent Response XML.</para>
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
        public System.String ChildHandle { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the operation, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter IpamInternetRegistryAssociationId
        /// <summary>
        /// <para>
        /// <para>The ID of the IPAM internet registry association to enable.</para>
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
        public System.String IpamInternetRegistryAssociationId { get; set; }
        #endregion
        
        #region Parameter ParentBpkiTa
        /// <summary>
        /// <para>
        /// <para>The parent BPKI Trust Anchor certificate in PEM format from the Parent Response XML.</para>
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
        public System.String ParentBpkiTa { get; set; }
        #endregion
        
        #region Parameter ParentHandle
        /// <summary>
        /// <para>
        /// <para>The parent handle for the BPKI certificate hierarchy from the Parent Response XML.</para>
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
        public System.String ParentHandle { get; set; }
        #endregion
        
        #region Parameter RpkiVersion
        /// <summary>
        /// <para>
        /// <para>The RPKI version to use from the Parent Response XML.</para>
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
        public System.String RpkiVersion { get; set; }
        #endregion
        
        #region Parameter ServiceUri
        /// <summary>
        /// <para>
        /// <para>The RPKI service URI for the publication point from the Parent Response XML.</para>
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
        public System.String ServiceUri { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, the operation ignores the
        /// request, but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IpamInternetRegistryAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.EnableIpamInternetRegistryAssociationResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.EnableIpamInternetRegistryAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IpamInternetRegistryAssociation";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-EC2IpamInternetRegistryAssociation (EnableIpamInternetRegistryAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.EnableIpamInternetRegistryAssociationResponse, EnableEC2IpamInternetRegistryAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChildHandle = this.ChildHandle;
            #if MODULAR
            if (this.ChildHandle == null && ParameterWasBound(nameof(this.ChildHandle)))
            {
                WriteWarning("You are passing $null as a value for parameter ChildHandle which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.DryRun = this.DryRun;
            context.IpamInternetRegistryAssociationId = this.IpamInternetRegistryAssociationId;
            #if MODULAR
            if (this.IpamInternetRegistryAssociationId == null && ParameterWasBound(nameof(this.IpamInternetRegistryAssociationId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamInternetRegistryAssociationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ParentBpkiTa = this.ParentBpkiTa;
            #if MODULAR
            if (this.ParentBpkiTa == null && ParameterWasBound(nameof(this.ParentBpkiTa)))
            {
                WriteWarning("You are passing $null as a value for parameter ParentBpkiTa which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ParentHandle = this.ParentHandle;
            #if MODULAR
            if (this.ParentHandle == null && ParameterWasBound(nameof(this.ParentHandle)))
            {
                WriteWarning("You are passing $null as a value for parameter ParentHandle which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RpkiVersion = this.RpkiVersion;
            #if MODULAR
            if (this.RpkiVersion == null && ParameterWasBound(nameof(this.RpkiVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter RpkiVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceUri = this.ServiceUri;
            #if MODULAR
            if (this.ServiceUri == null && ParameterWasBound(nameof(this.ServiceUri)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.EnableIpamInternetRegistryAssociationRequest();
            
            if (cmdletContext.ChildHandle != null)
            {
                request.ChildHandle = cmdletContext.ChildHandle;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.IpamInternetRegistryAssociationId != null)
            {
                request.IpamInternetRegistryAssociationId = cmdletContext.IpamInternetRegistryAssociationId;
            }
            if (cmdletContext.ParentBpkiTa != null)
            {
                request.ParentBpkiTa = cmdletContext.ParentBpkiTa;
            }
            if (cmdletContext.ParentHandle != null)
            {
                request.ParentHandle = cmdletContext.ParentHandle;
            }
            if (cmdletContext.RpkiVersion != null)
            {
                request.RpkiVersion = cmdletContext.RpkiVersion;
            }
            if (cmdletContext.ServiceUri != null)
            {
                request.ServiceUri = cmdletContext.ServiceUri;
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
        
        private Amazon.EC2.Model.EnableIpamInternetRegistryAssociationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.EnableIpamInternetRegistryAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "EnableIpamInternetRegistryAssociation");
            try
            {
                return client.EnableIpamInternetRegistryAssociationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ChildHandle { get; set; }
            public System.String ClientToken { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String IpamInternetRegistryAssociationId { get; set; }
            public System.String ParentBpkiTa { get; set; }
            public System.String ParentHandle { get; set; }
            public System.String RpkiVersion { get; set; }
            public System.String ServiceUri { get; set; }
            public System.Func<Amazon.EC2.Model.EnableIpamInternetRegistryAssociationResponse, EnableEC2IpamInternetRegistryAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamInternetRegistryAssociation;
        }
        
    }
}
