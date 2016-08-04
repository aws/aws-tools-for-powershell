/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Route53Domains;
using Amazon.Route53Domains.Model;

namespace Amazon.PowerShell.Cmdlets.R53D
{
    /// <summary>
    /// This operation renews a domain for the specified number of years. The cost of renewing
    /// your domain is billed to your AWS account.
    /// 
    ///  
    /// <para>
    /// We recommend that you renew your domain several weeks before the expiration date.
    /// Some TLD registries delete domains before the expiration date if you haven't renewed
    /// far enough in advance. For more information about renewing domain registration, see
    /// <a href="http://docs.aws.amazon.com/console/route53/domain-renew">Renewing Registration
    /// for a Domain</a> in the Amazon Route 53 documentation.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "R53DDomainRenewal", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the RenewDomain operation against Amazon Route 53 Domains.", Operation = new[] {"RenewDomain"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Route53Domains.Model.RenewDomainResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateR53DDomainRenewalCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        #region Parameter CurrentExpiryYear
        /// <summary>
        /// <para>
        /// <para>The year when the registration for the domain is set to expire. This value must match
        /// the current expiration date for the domain.</para><para>Type: Integer</para><para>Default: None</para><para>Valid values: Integer</para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 CurrentExpiryYear { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter DurationInYear
        /// <summary>
        /// <para>
        /// <para>The number of years that you want to renew the domain for. The maximum number of years
        /// depends on the top-level domain. For the range of valid values for your domain, see
        /// <a href="http://docs.aws.amazon.com/console/route53/domain-tld-list">Domains that
        /// You Can Register with Amazon Route 53</a> in the Amazon Route 53 documentation.</para><para>Type: Integer</para><para>Default: 1</para><para>Valid values: Integer from 1 to 10</para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DurationInYears")]
        public System.Int32 DurationInYear { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53DDomainRenewal (RenewDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("CurrentExpiryYear"))
                context.CurrentExpiryYear = this.CurrentExpiryYear;
            context.DomainName = this.DomainName;
            if (ParameterWasBound("DurationInYear"))
                context.DurationInYears = this.DurationInYear;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53Domains.Model.RenewDomainRequest();
            
            if (cmdletContext.CurrentExpiryYear != null)
            {
                request.CurrentExpiryYear = cmdletContext.CurrentExpiryYear.Value;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.DurationInYears != null)
            {
                request.DurationInYears = cmdletContext.DurationInYears.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.OperationId;
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
        
        private static Amazon.Route53Domains.Model.RenewDomainResponse CallAWSServiceOperation(IAmazonRoute53Domains client, Amazon.Route53Domains.Model.RenewDomainRequest request)
        {
            return client.RenewDomain(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Int32? CurrentExpiryYear { get; set; }
            public System.String DomainName { get; set; }
            public System.Int32? DurationInYears { get; set; }
        }
        
    }
}
