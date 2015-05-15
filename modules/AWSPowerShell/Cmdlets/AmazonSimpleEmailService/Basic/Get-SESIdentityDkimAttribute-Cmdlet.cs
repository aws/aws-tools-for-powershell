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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Returns the current status of Easy DKIM signing for an entity. For domain name identities,
    /// this action also returns the DKIM tokens that are required for Easy DKIM signing,
    /// and whether Amazon SES has successfully verified that these tokens have been published.
    /// 
    ///  
    /// <para>
    /// This action takes a list of identities as input and returns the following information
    /// for each:
    /// </para><ul><li>Whether Easy DKIM signing is enabled or disabled.</li><li>A set of DKIM
    /// tokens that represent the identity. If the identity is an email address, the tokens
    /// represent the domain of that address.</li><li>Whether Amazon SES has successfully
    /// verified the DKIM tokens published in the domain's DNS. This information is only returned
    /// for domain name identities, not for email addresses.</li></ul><para>
    /// This action is throttled at one request per second.
    /// </para><para>
    /// For more information about creating DNS records using DKIM tokens, go to the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/easy-dkim-dns-records.html">Amazon
    /// SES Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SESIdentityDkimAttribute")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the GetIdentityDkimAttributes operation against Amazon Simple Email Service.", Operation = new[] {"GetIdentityDkimAttributes"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type GetIdentityDkimAttributesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetSESIdentityDkimAttributeCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A list of one or more verified identities - email addresses, domains, or both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("Identities")]
        public System.String[] Identity { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Identity != null)
            {
                context.Identities = new List<String>(this.Identity);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new GetIdentityDkimAttributesRequest();
            
            if (cmdletContext.Identities != null)
            {
                request.Identities = cmdletContext.Identities;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetIdentityDkimAttributes(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DkimAttributes;
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
            public List<String> Identities { get; set; }
        }
        
    }
}
