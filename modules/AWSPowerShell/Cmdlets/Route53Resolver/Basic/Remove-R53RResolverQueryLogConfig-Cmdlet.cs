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
    /// Deletes a query logging configuration. When you delete a configuration, Resolver stops
    /// logging DNS queries for all of the Amazon VPCs that are associated with the configuration.
    /// This also applies if the query logging configuration is shared with other Amazon Web
    /// Services accounts, and the other accounts have associated VPCs with the shared configuration.
    /// 
    ///  
    /// <para>
    /// Before you can delete a query logging configuration, you must first disassociate all
    /// VPCs from the configuration. See <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_route53resolver_DisassociateResolverQueryLogConfig.html">DisassociateResolverQueryLogConfig</a>.
    /// </para><para>
    /// If you used Resource Access Manager (RAM) to share a query logging configuration with
    /// other accounts, you must stop sharing the configuration before you can delete a configuration.
    /// The accounts that you shared the configuration with can first disassociate VPCs that
    /// they associated with the configuration, but that's not necessary. If you stop sharing
    /// the configuration, those VPCs are automatically disassociated from the configuration.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "R53RResolverQueryLogConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Route53Resolver.Model.ResolverQueryLogConfig")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver DeleteResolverQueryLogConfig API operation.", Operation = new[] {"DeleteResolverQueryLogConfig"}, SelectReturnType = typeof(Amazon.Route53Resolver.Model.DeleteResolverQueryLogConfigResponse))]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.ResolverQueryLogConfig or Amazon.Route53Resolver.Model.DeleteResolverQueryLogConfigResponse",
        "This cmdlet returns an Amazon.Route53Resolver.Model.ResolverQueryLogConfig object.",
        "The service call response (type Amazon.Route53Resolver.Model.DeleteResolverQueryLogConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveR53RResolverQueryLogConfigCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        #region Parameter ResolverQueryLogConfigId
        /// <summary>
        /// <para>
        /// <para>The ID of the query logging configuration that you want to delete.</para>
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
        public System.String ResolverQueryLogConfigId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResolverQueryLogConfig'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Resolver.Model.DeleteResolverQueryLogConfigResponse).
        /// Specifying the name of a property of type Amazon.Route53Resolver.Model.DeleteResolverQueryLogConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResolverQueryLogConfig";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResolverQueryLogConfigId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResolverQueryLogConfigId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResolverQueryLogConfigId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResolverQueryLogConfigId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-R53RResolverQueryLogConfig (DeleteResolverQueryLogConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Resolver.Model.DeleteResolverQueryLogConfigResponse, RemoveR53RResolverQueryLogConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResolverQueryLogConfigId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ResolverQueryLogConfigId = this.ResolverQueryLogConfigId;
            #if MODULAR
            if (this.ResolverQueryLogConfigId == null && ParameterWasBound(nameof(this.ResolverQueryLogConfigId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResolverQueryLogConfigId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53Resolver.Model.DeleteResolverQueryLogConfigRequest();
            
            if (cmdletContext.ResolverQueryLogConfigId != null)
            {
                request.ResolverQueryLogConfigId = cmdletContext.ResolverQueryLogConfigId;
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
        
        private Amazon.Route53Resolver.Model.DeleteResolverQueryLogConfigResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.DeleteResolverQueryLogConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "DeleteResolverQueryLogConfig");
            try
            {
                #if DESKTOP
                return client.DeleteResolverQueryLogConfig(request);
                #elif CORECLR
                return client.DeleteResolverQueryLogConfigAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Route53Resolver.Model.DeleteResolverQueryLogConfigResponse, RemoveR53RResolverQueryLogConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResolverQueryLogConfig;
        }
        
    }
}
