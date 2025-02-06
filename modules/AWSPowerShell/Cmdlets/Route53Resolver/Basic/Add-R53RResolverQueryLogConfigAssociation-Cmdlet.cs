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
using Amazon.Route53Resolver;
using Amazon.Route53Resolver.Model;

namespace Amazon.PowerShell.Cmdlets.R53R
{
    /// <summary>
    /// Associates an Amazon VPC with a specified query logging configuration. Route 53 Resolver
    /// logs DNS queries that originate in all of the Amazon VPCs that are associated with
    /// a specified query logging configuration. To associate more than one VPC with a configuration,
    /// submit one <c>AssociateResolverQueryLogConfig</c> request for each VPC.
    /// 
    ///  <note><para>
    /// The VPCs that you associate with a query logging configuration must be in the same
    /// Region as the configuration.
    /// </para></note><para>
    /// To remove a VPC from a query logging configuration, see <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_route53resolver_DisassociateResolverQueryLogConfig.html">DisassociateResolverQueryLogConfig</a>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Add", "R53RResolverQueryLogConfigAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53Resolver.Model.ResolverQueryLogConfigAssociation")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver AssociateResolverQueryLogConfig API operation.", Operation = new[] {"AssociateResolverQueryLogConfig"}, SelectReturnType = typeof(Amazon.Route53Resolver.Model.AssociateResolverQueryLogConfigResponse))]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.ResolverQueryLogConfigAssociation or Amazon.Route53Resolver.Model.AssociateResolverQueryLogConfigResponse",
        "This cmdlet returns an Amazon.Route53Resolver.Model.ResolverQueryLogConfigAssociation object.",
        "The service call response (type Amazon.Route53Resolver.Model.AssociateResolverQueryLogConfigResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddR53RResolverQueryLogConfigAssociationCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResolverQueryLogConfigId
        /// <summary>
        /// <para>
        /// <para>The ID of the query logging configuration that you want to associate a VPC with.</para>
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
        /// <para>The ID of an Amazon VPC that you want this query logging configuration to log queries
        /// for.</para><note><para>The VPCs and the query logging configuration must be in the same Region.</para></note>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Resolver.Model.AssociateResolverQueryLogConfigResponse).
        /// Specifying the name of a property of type Amazon.Route53Resolver.Model.AssociateResolverQueryLogConfigResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-R53RResolverQueryLogConfigAssociation (AssociateResolverQueryLogConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Resolver.Model.AssociateResolverQueryLogConfigResponse, AddR53RResolverQueryLogConfigAssociationCmdlet>(Select) ??
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
            var request = new Amazon.Route53Resolver.Model.AssociateResolverQueryLogConfigRequest();
            
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
        
        private Amazon.Route53Resolver.Model.AssociateResolverQueryLogConfigResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.AssociateResolverQueryLogConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "AssociateResolverQueryLogConfig");
            try
            {
                #if DESKTOP
                return client.AssociateResolverQueryLogConfig(request);
                #elif CORECLR
                return client.AssociateResolverQueryLogConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String ResolverQueryLogConfigId { get; set; }
            public System.String ResourceId { get; set; }
            public System.Func<Amazon.Route53Resolver.Model.AssociateResolverQueryLogConfigResponse, AddR53RResolverQueryLogConfigAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResolverQueryLogConfigAssociation;
        }
        
    }
}
