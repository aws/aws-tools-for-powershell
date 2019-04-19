/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// If the hosted zone was created by another service, such as AWS Cloud Map, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/DeleteHostedZone.html#delete-public-hosted-zone-created-by-another-service">Deleting
    /// Public Hosted Zones That Were Created by Another Service</a> in the <i>Amazon Route
    /// 53 Developer Guide</i> for information about how to delete it. (The process is the
    /// same for public and private hosted zones that were created by another service.)
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
    /// with Route 53, see <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_domains_UpdateDomainNameservers.html">UpdateDomainNameservers</a>
    /// for information about how to replace Route 53 name servers with name servers for the
    /// new DNS service. If the domain is registered with another registrar, use the method
    /// provided by the registrar to update name servers for the domain registration. For
    /// more information, perform an internet search on "free DNS service."
    /// </para><para>
    /// You can delete a hosted zone only if it contains only the default SOA record and NS
    /// resource record sets. If the hosted zone contains other resource record sets, you
    /// must delete them before you can delete the hosted zone. If you try to delete a hosted
    /// zone that contains other resource record sets, the request fails, and Route 53 returns
    /// a <code>HostedZoneNotEmpty</code> error. For information about deleting records from
    /// your hosted zone, see <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_ChangeResourceRecordSets.html">ChangeResourceRecordSets</a>.
    /// </para><para>
    /// To verify that the hosted zone has been deleted, do one of the following:
    /// </para><ul><li><para>
    /// Use the <code>GetHostedZone</code> action to request information about the hosted
    /// zone.
    /// </para></li><li><para>
    /// Use the <code>ListHostedZones</code> action to get a list of the hosted zones associated
    /// with the current AWS account.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Remove", "R53HostedZone", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Route53.Model.ChangeInfo")]
    [AWSCmdlet("Calls the Amazon Route 53 DeleteHostedZone API operation.", Operation = new[] {"DeleteHostedZone"})]
    [AWSCmdletOutput("Amazon.Route53.Model.ChangeInfo",
        "This cmdlet returns a ChangeInfo object.",
        "The service call response (type Amazon.Route53.Model.DeleteHostedZoneResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveR53HostedZoneCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone you want to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Id", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-R53HostedZone (DeleteHostedZone)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Id = this.Id;
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ChangeInfo;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        }
        
    }
}
