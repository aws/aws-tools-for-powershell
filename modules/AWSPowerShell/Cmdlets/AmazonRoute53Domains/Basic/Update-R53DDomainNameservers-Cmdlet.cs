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
    /// This operation replaces the current set of name servers for the domain with the specified
    /// set of name servers. If you use Amazon Route 53 as your DNS service, specify the four
    /// name servers in the delegation set for the hosted zone for the domain. 
    /// 
    ///  
    /// <para>
    /// If successful, this operation returns an operation ID that you can use to track the
    /// progress and completion of the action. If the request is not completed successfully,
    /// the domain registrant will be notified by email.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "R53DDomainNameservers", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateDomainNameservers operation against AWS Route 53 Domains.", Operation = new[] {"UpdateDomainNameservers"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Route53Domains.Model.UpdateDomainNameserversResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateR53DDomainNameserversCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of a domain.</para><para>Type: String</para><para>Default: None</para><para>Constraints: The domain name can contain only the letters a through z, the numbers
        /// 0 through 9, and hyphen (-). Internationalized Domain Names are not supported.</para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The authorization key for .fi domains</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FIAuthKey { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of new name servers for the domain.</para><para>Type: Complex</para><para>Children: <code>Name</code>, <code>GlueIps</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Nameservers")]
        public Amazon.Route53Domains.Model.Nameserver[] Nameserver { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53DDomainNameservers (UpdateDomainNameservers)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DomainName = this.DomainName;
            context.FIAuthKey = this.FIAuthKey;
            if (this.Nameserver != null)
            {
                context.Nameservers = new List<Amazon.Route53Domains.Model.Nameserver>(this.Nameserver);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53Domains.Model.UpdateDomainNameserversRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.FIAuthKey != null)
            {
                request.FIAuthKey = cmdletContext.FIAuthKey;
            }
            if (cmdletContext.Nameservers != null)
            {
                request.Nameservers = cmdletContext.Nameservers;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateDomainNameservers(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String DomainName { get; set; }
            public System.String FIAuthKey { get; set; }
            public List<Amazon.Route53Domains.Model.Nameserver> Nameservers { get; set; }
        }
        
    }
}
