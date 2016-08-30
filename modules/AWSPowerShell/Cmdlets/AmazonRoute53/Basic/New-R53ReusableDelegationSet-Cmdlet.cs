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
    /// Creates a delegation set (a group of four anem servers) that can be reused by multiple
    /// hosted zones. If a hosted zoned ID is specified, <code>CreateReusableDelegationSet</code>
    /// marks the delegation set associated with that zone as reusable
    /// 
    ///  
    /// <para>
    /// Send a <code>POST</code> request to the <code>/<i>Amazon Route 53 API version</i>/delegationset</code>
    /// resource. The request body must include an XML document with a <code>CreateReusableDelegationSetRequest</code>
    /// element.
    /// </para><note><para>
    /// A reusable delegation set cannot be associated with a private hosted zone/
    /// </para></note><para>
    /// For more information, including a procedure on how to create and configure a reusable
    /// delegation set (also known as white label name servers), see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/white-label-name-servers.html">Configuring
    /// White Label Name Servers</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "R53ReusableDelegationSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.CreateReusableDelegationSetResponse")]
    [AWSCmdlet("Invokes the CreateReusableDelegationSet operation against Amazon Route 53.", Operation = new[] {"CreateReusableDelegationSet"})]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateReusableDelegationSetResponse",
        "This cmdlet returns a Amazon.Route53.Model.CreateReusableDelegationSetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewR53ReusableDelegationSetCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request, and that allows you to retry failed <code>CreateReusableDelegationSet</code>
        /// requests without the risk of executing the operation twice. You must use a unique
        /// <code>CallerReference</code> string every time you submit a <code>CreateReusableDelegationSet</code>
        /// request. <code>CallerReference</code> can be any unique string, for example a date/time
        /// stamp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CallerReference { get; set; }
        #endregion
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>If you want to mark the delegation set for an existing hosted zone as reusable, the
        /// ID for that hosted zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HostedZoneId { get; set; }
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CallerReference = this.CallerReference;
            context.HostedZoneId = this.HostedZoneId;
            
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
            var request = new Amazon.Route53.Model.CreateReusableDelegationSetRequest();
            
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private static Amazon.Route53.Model.CreateReusableDelegationSetResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.CreateReusableDelegationSetRequest request)
        {
            #if DESKTOP
            return client.CreateReusableDelegationSet(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateReusableDelegationSetAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String CallerReference { get; set; }
            public System.String HostedZoneId { get; set; }
        }
        
    }
}
