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
    /// For operations that require confirmation that the email address for the registrant
    /// contact is valid, such as registering a new domain, this operation returns information
    /// about whether the registrant contact has responded.
    /// 
    ///  
    /// <para>
    /// If you want us to resend the email, use the <code>ResendContactReachabilityEmail</code>
    /// operation.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "R53DContactReachabilityStatus")]
    [OutputType("Amazon.Route53Domains.Model.GetContactReachabilityStatusResponse")]
    [AWSCmdlet("Invokes the GetContactReachabilityStatus operation against Amazon Route 53 Domains.", Operation = new[] {"GetContactReachabilityStatus"})]
    [AWSCmdletOutput("Amazon.Route53Domains.Model.GetContactReachabilityStatusResponse",
        "This cmdlet returns a Amazon.Route53Domains.Model.GetContactReachabilityStatusResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetR53DContactReachabilityStatusCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain for which you want to know whether the registrant contact has
        /// confirmed that the email address is valid.</para><para>Type: String</para><para>Default: None</para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DomainName = this.DomainName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53Domains.Model.GetContactReachabilityStatusRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetContactReachabilityStatus(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        }
        
    }
}
