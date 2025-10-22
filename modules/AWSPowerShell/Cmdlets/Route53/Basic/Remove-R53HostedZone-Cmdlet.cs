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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Deletes a hosted zone.
    /// 
    ///  
    /// <para>
    /// If the hosted zone was created by another service, such as Cloud Map, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/DeleteHostedZone.html#delete-public-hosted-zone-created-by-another-service">Deleting
    /// Public Hosted Zones That Were Created by Another Service</a> in the <i>Amazon Route 53
    /// Developer Guide</i> for information about how to delete it. (The process is the same
    /// for public and private hosted zones that were created by another service.)
    /// </para><para>
    /// If you want to keep your domain registration but you want to stop routing internet
    /// traffic to your website or web application, we recommend that you delete resource
    /// record sets in the hosted zone instead of deleting the hosted zone.
    /// </para><important><para>
    /// If you delete a hosted zone, you can't undelete it. You must create a new hosted zone
    /// and update the name servers for your domain registration, which can require up to
    /// 48 hours to take effect. (If you delegated responsibility for a subdomain to a hosted
    /// zone and you delete the child hosted zone, you must update the name servers in the
    /// parent hosted zone.) In addition, if you delete a hosted zone, someone could hijack
    /// the domain and route traffic to their own resources using your domain name.
    /// </para></important><para>
    /// If you want to avoid the monthly charge for the hosted zone, you can transfer DNS
    /// service for the domain to a free DNS service. When you transfer DNS service, you have
    /// to update the name servers for the domain registration. If the domain is registered
    /// with Route 53, see <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_domains_UpdateDomainNameservers.html">UpdateDomainNameservers</a>
    /// for information about how to replace Route 53 name servers with name servers for the
    /// new DNS service. If the domain is registered with another registrar, use the method
    /// provided by the registrar to update name servers for the domain registration. For
    /// more information, perform an internet search on "free DNS service."
    /// </para><para>
    /// You can delete a hosted zone only if it contains only the default SOA and NS records
    /// and has DNSSEC signing disabled. If the hosted zone contains other records or has
    /// DNSSEC enabled, you must delete the records and disable DNSSEC before deletion. Attempting
    /// to delete a hosted zone with additional records or DNSSEC enabled returns a <c>HostedZoneNotEmpty</c>
    /// error. For information about deleting records, see <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_ChangeResourceRecordSets.html">ChangeResourceRecordSets</a>.
    /// 
    /// </para><para>
    /// To verify that the hosted zone has been deleted, do one of the following:
    /// </para><ul><li><para>
    /// Use the <c>GetHostedZone</c> action to request information about the hosted zone.
    /// </para></li><li><para>
    /// Use the <c>ListHostedZones</c> action to get a list of the hosted zones associated
    /// with the current Amazon Web Services account.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Remove", "R53HostedZone", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Route53.Model.ChangeInfo")]
    [AWSCmdlet("Calls the Amazon Route 53 DeleteHostedZone API operation.", Operation = new[] {"DeleteHostedZone"}, SelectReturnType = typeof(Amazon.Route53.Model.DeleteHostedZoneResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.ChangeInfo or Amazon.Route53.Model.DeleteHostedZoneResponse",
        "This cmdlet returns an Amazon.Route53.Model.ChangeInfo object.",
        "The service call response (type Amazon.Route53.Model.DeleteHostedZoneResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveR53HostedZoneCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone you want to delete.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChangeInfo'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.DeleteHostedZoneResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.DeleteHostedZoneResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChangeInfo";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-R53HostedZone (DeleteHostedZone)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.DeleteHostedZoneResponse, RemoveR53HostedZoneCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53.Model.DeleteHostedZoneRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
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
        
        private Amazon.Route53.Model.DeleteHostedZoneResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.DeleteHostedZoneRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "DeleteHostedZone");
            try
            {
                #if DESKTOP
                return client.DeleteHostedZone(request);
                #elif CORECLR
                return client.DeleteHostedZoneAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.Func<Amazon.Route53.Model.DeleteHostedZoneResponse, RemoveR53HostedZoneCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChangeInfo;
        }
        
    }
}
