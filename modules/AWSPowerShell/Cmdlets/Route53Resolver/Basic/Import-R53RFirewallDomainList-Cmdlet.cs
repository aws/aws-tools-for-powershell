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
    /// Imports domain names from a file into a domain list, for use in a DNS firewall rule
    /// group. 
    /// 
    ///  
    /// <para>
    /// Each domain specification in your domain list must satisfy the following requirements:
    /// 
    /// </para><ul><li><para>
    /// It can optionally start with <code>*</code> (asterisk).
    /// </para></li><li><para>
    /// With the exception of the optional starting asterisk, it must only contain the following
    /// characters: <code>A-Z</code>, <code>a-z</code>, <code>0-9</code>, <code>-</code> (hyphen).
    /// </para></li><li><para>
    /// It must be from 1-255 characters in length. 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Import", "R53RFirewallDomainList", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53Resolver.Model.ImportFirewallDomainsResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver ImportFirewallDomains API operation.", Operation = new[] {"ImportFirewallDomains"}, SelectReturnType = typeof(Amazon.Route53Resolver.Model.ImportFirewallDomainsResponse))]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.ImportFirewallDomainsResponse",
        "This cmdlet returns an Amazon.Route53Resolver.Model.ImportFirewallDomainsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportR53RFirewallDomainListCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        #region Parameter DomainFileUrl
        /// <summary>
        /// <para>
        /// <para>The fully qualified URL or URI of the file stored in Amazon Simple Storage Service
        /// (S3) that contains the list of domains to import.</para><para>The file must be in an S3 bucket that's in the same Region as your DNS Firewall. The
        /// file must be a text file and must contain a single domain per line.</para>
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
        public System.String DomainFileUrl { get; set; }
        #endregion
        
        #region Parameter FirewallDomainListId
        /// <summary>
        /// <para>
        /// <para>The ID of the domain list that you want to modify with the import operation.</para>
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
        public System.String FirewallDomainListId { get; set; }
        #endregion
        
        #region Parameter Operation
        /// <summary>
        /// <para>
        /// <para>What you want DNS Firewall to do with the domains that are listed in the file. This
        /// must be set to <code>REPLACE</code>, which updates the domain list to exactly match
        /// the list in the file. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Route53Resolver.FirewallDomainImportOperation")]
        public Amazon.Route53Resolver.FirewallDomainImportOperation Operation { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Resolver.Model.ImportFirewallDomainsResponse).
        /// Specifying the name of a property of type Amazon.Route53Resolver.Model.ImportFirewallDomainsResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FirewallDomainListId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-R53RFirewallDomainList (ImportFirewallDomains)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Resolver.Model.ImportFirewallDomainsResponse, ImportR53RFirewallDomainListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainFileUrl = this.DomainFileUrl;
            #if MODULAR
            if (this.DomainFileUrl == null && ParameterWasBound(nameof(this.DomainFileUrl)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainFileUrl which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FirewallDomainListId = this.FirewallDomainListId;
            #if MODULAR
            if (this.FirewallDomainListId == null && ParameterWasBound(nameof(this.FirewallDomainListId)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallDomainListId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Operation = this.Operation;
            #if MODULAR
            if (this.Operation == null && ParameterWasBound(nameof(this.Operation)))
            {
                WriteWarning("You are passing $null as a value for parameter Operation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53Resolver.Model.ImportFirewallDomainsRequest();
            
            if (cmdletContext.DomainFileUrl != null)
            {
                request.DomainFileUrl = cmdletContext.DomainFileUrl;
            }
            if (cmdletContext.FirewallDomainListId != null)
            {
                request.FirewallDomainListId = cmdletContext.FirewallDomainListId;
            }
            if (cmdletContext.Operation != null)
            {
                request.Operation = cmdletContext.Operation;
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
        
        private Amazon.Route53Resolver.Model.ImportFirewallDomainsResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.ImportFirewallDomainsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "ImportFirewallDomains");
            try
            {
                #if DESKTOP
                return client.ImportFirewallDomains(request);
                #elif CORECLR
                return client.ImportFirewallDomainsAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainFileUrl { get; set; }
            public System.String FirewallDomainListId { get; set; }
            public Amazon.Route53Resolver.FirewallDomainImportOperation Operation { get; set; }
            public System.Func<Amazon.Route53Resolver.Model.ImportFirewallDomainsResponse, ImportR53RFirewallDomainListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
