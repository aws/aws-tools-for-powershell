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
    /// This operation adds or updates tags for a specified domain.
    /// 
    ///  
    /// <para>
    /// All tag operations are eventually consistent; subsequent operations may not immediately
    /// represent all issued operations.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "R53DTagsForDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the UpdateTagsForDomain operation against Amazon Route 53 Domains.", Operation = new[] {"UpdateTagsForDomain"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the DomainName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Route53Domains.Model.UpdateTagsForDomainResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateR53DTagsForDomainCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The domain for which you want to add or update tags.</para><para>The name of a domain.</para><para>Type: String</para><para>Default: None</para><para>Constraints: The domain name can contain only the letters a through z, the numbers
        /// 0 through 9, and hyphen (-). Hyphens are allowed only when theyaposre surrounded by
        /// letters, numbers, or other hyphens. You canapost specify a hyphen at the beginning
        /// or end of a label. To specify an Internationalized Domain Name, you must convert the
        /// name to Punycode.</para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of the tag keys and values that you want to add or update. If you specify a
        /// key that already exists, the corresponding value will be replaced.</para><para>Type: A complex type containing a list of tags</para><para>Default: None</para><para>Required: No</para>
        /// '&gt; 
        /// <para>Each tag includes the following elements:</para><ul><li><para>Key</para><para>The key (name) of a tag.</para><para>Type: String</para><para>Default: None</para><para>Valid values: Unicode characters including alphanumeric, space, and ".:/=+\-@"</para><para>Constraints: Each key can be 1-128 characters long.</para><para>Required: Yes</para></li><li><para>Value</para><para>The value of a tag.</para><para>Type: String</para><para>Default: None</para><para>Valid values: Unicode characters including alphanumeric, space, and ".:/=+\-@"</para><para>Constraints: Each value can be 0-256 characters long.</para><para>Required: Yes</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Route53Domains.Model.Tag[] TagsToUpdate { get; set; }
        
        /// <summary>
        /// Returns the value passed to the DomainName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53DTagsForDomain (UpdateTagsForDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DomainName = this.DomainName;
            if (this.TagsToUpdate != null)
            {
                context.TagsToUpdate = new List<Amazon.Route53Domains.Model.Tag>(this.TagsToUpdate);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53Domains.Model.UpdateTagsForDomainRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.TagsToUpdate != null)
            {
                request.TagsToUpdate = cmdletContext.TagsToUpdate;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateTagsForDomain(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.DomainName;
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
            public List<Amazon.Route53Domains.Model.Tag> TagsToUpdate { get; set; }
        }
        
    }
}
