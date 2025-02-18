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
using Amazon.Route53Resolver;
using Amazon.Route53Resolver.Model;

namespace Amazon.PowerShell.Cmdlets.R53R
{
    /// <summary>
    /// Disassociates a VPC from a query logging configuration.
    /// 
    ///  <note><para>
    /// Before you can delete a query logging configuration, you must first disassociate all
    /// VPCs from the configuration. If you used Resource Access Manager (RAM) to share a
    /// query logging configuration with other accounts, VPCs can be disassociated from the
    /// configuration in the following ways:
    /// </para><ul><li><para>
    /// The accounts that you shared the configuration with can disassociate VPCs from the
    /// configuration.
    /// </para></li><li><para>
    /// You can stop sharing the configuration.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Remove", "R53RResolverQueryLogConfigAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Route53Resolver.Model.ResolverQueryLogConfigAssociation")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver DisassociateResolverQueryLogConfig API operation.", Operation = new[] {"DisassociateResolverQueryLogConfig"}, SelectReturnType = typeof(Amazon.Route53Resolver.Model.DisassociateResolverQueryLogConfigResponse))]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.ResolverQueryLogConfigAssociation or Amazon.Route53Resolver.Model.DisassociateResolverQueryLogConfigResponse",
        "This cmdlet returns an Amazon.Route53Resolver.Model.ResolverQueryLogConfigAssociation object.",
        "The service call response (type Amazon.Route53Resolver.Model.DisassociateResolverQueryLogConfigResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveR53RResolverQueryLogConfigAssociationCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ResolverQueryLogConfigId
        /// <summary>
        /// <para>
        /// <para>The ID of the query logging configuration that you want to disassociate a specified
        /// VPC from.</para>
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
        public System.String ResolverQueryLogConfigId { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon VPC that you want to disassociate from a specified query logging
        /// configuration.</para>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResolverQueryLogConfigAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Resolver.Model.DisassociateResolverQueryLogConfigResponse).
        /// Specifying the name of a property of type Amazon.Route53Resolver.Model.DisassociateResolverQueryLogConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResolverQueryLogConfigAssociation";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-R53RResolverQueryLogConfigAssociation (DisassociateResolverQueryLogConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Resolver.Model.DisassociateResolverQueryLogConfigResponse, RemoveR53RResolverQueryLogConfigAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ResolverQueryLogConfigId = this.ResolverQueryLogConfigId;
            #if MODULAR
            if (this.ResolverQueryLogConfigId == null && ParameterWasBound(nameof(this.ResolverQueryLogConfigId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResolverQueryLogConfigId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53Resolver.Model.DisassociateResolverQueryLogConfigRequest();
            
            if (cmdletContext.ResolverQueryLogConfigId != null)
            {
                request.ResolverQueryLogConfigId = cmdletContext.ResolverQueryLogConfigId;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
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
        
        private Amazon.Route53Resolver.Model.DisassociateResolverQueryLogConfigResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.DisassociateResolverQueryLogConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "DisassociateResolverQueryLogConfig");
            try
            {
                return client.DisassociateResolverQueryLogConfigAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ResolverQueryLogConfigId { get; set; }
            public System.String ResourceId { get; set; }
            public System.Func<Amazon.Route53Resolver.Model.DisassociateResolverQueryLogConfigResponse, RemoveR53RResolverQueryLogConfigAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResolverQueryLogConfigAssociation;
        }
        
    }
}
