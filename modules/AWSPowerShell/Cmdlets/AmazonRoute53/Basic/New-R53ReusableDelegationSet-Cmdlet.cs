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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// This action creates a reusable delegationSet.
    /// 
    ///  
    /// <para>
    ///  To create a new reusable delegationSet, send a <code>POST</code> request to the <code>2013-04-01/delegationset</code>
    /// resource. The request body must include an XML document with a <code>CreateReusableDelegationSetRequest</code>
    /// element. The response returns the <code>CreateReusableDelegationSetResponse</code>
    /// element that contains metadata about the delegationSet. 
    /// </para><para>
    ///  If the optional parameter HostedZoneId is specified, it marks the delegationSet associated
    /// with that particular hosted zone as reusable. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "R53ReusableDelegationSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.CreateReusableDelegationSetResponse")]
    [AWSCmdlet("Invokes the CreateReusableDelegationSet operation against AWS Route 53.", Operation = new[] {"CreateReusableDelegationSet"})]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateReusableDelegationSetResponse",
        "This cmdlet returns a CreateReusableDelegationSetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewR53ReusableDelegationSetCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows failed <code>CreateReusableDelegationSet</code>
        /// requests to be retried without the risk of executing the operation twice. You must
        /// use a unique <code>CallerReference</code> string every time you create a reusable
        /// delegation set. <code>CallerReference</code> can be any unique string; you might choose
        /// to use a string that identifies your project, such as <code>DNSMigration_01</code>.</para><para>Valid characters are any Unicode code points that are legal in an XML 1.0 document.
        /// The UTF-8 encoding of the value must be less than 128 bytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String CallerReference { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone whose delegation set you want to mark as reusable. It is
        /// an optional parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String HostedZoneId { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("HostedZoneId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53ReusableDelegationSet (CreateReusableDelegationSet)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CallerReference = this.CallerReference;
            context.HostedZoneId = this.HostedZoneId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateReusableDelegationSetRequest();
            
            if (cmdletContext.CallerReference != null)
            {
                request.CallerReference = cmdletContext.CallerReference;
            }
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateReusableDelegationSet(request);
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
            public String CallerReference { get; set; }
            public String HostedZoneId { get; set; }
        }
        
    }
}
