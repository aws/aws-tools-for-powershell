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
using Amazon.AWSSupport;
using Amazon.AWSSupport.Model;

namespace Amazon.PowerShell.Cmdlets.ASA
{
    /// <summary>
    /// Requests a refresh of the Trusted Advisor check that has the specified check ID. Check
    /// IDs can be obtained by calling <a>DescribeTrustedAdvisorChecks</a>.
    /// 
    ///  <note><para>
    /// Some checks are refreshed automatically, and they cannot be refreshed by using this
    /// operation. Use of the <code>RefreshTrustedAdvisorCheck</code> operation for these
    /// checks causes an <code>InvalidParameterValue</code> error.
    /// </para></note><para>
    /// The response contains a <a>TrustedAdvisorCheckRefreshStatus</a> object, which contains
    /// these fields:
    /// </para><ul><li><para><b>status.</b> The refresh status of the check: "none", "enqueued", "processing",
    /// "success", or "abandoned".
    /// </para></li><li><para><b>millisUntilNextRefreshable.</b> The amount of time, in milliseconds, until the
    /// check is eligible for refresh.
    /// </para></li><li><para><b>checkId.</b> The unique identifier for the check.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Request", "ASATrustedAdvisorCheckRefresh", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AWSSupport.Model.TrustedAdvisorCheckRefreshStatus")]
    [AWSCmdlet("Invokes the RefreshTrustedAdvisorCheck operation against AWS Support API.", Operation = new[] {"RefreshTrustedAdvisorCheck"})]
    [AWSCmdletOutput("Amazon.AWSSupport.Model.TrustedAdvisorCheckRefreshStatus",
        "This cmdlet returns a TrustedAdvisorCheckRefreshStatus object.",
        "The service call response (type Amazon.AWSSupport.Model.RefreshTrustedAdvisorCheckResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RequestASATrustedAdvisorCheckRefreshCmdlet : AmazonAWSSupportClientCmdlet, IExecutor
    {
        
        #region Parameter CheckId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the Trusted Advisor check to refresh. <b>Note:</b> Specifying
        /// the check ID of a check that is automatically refreshed causes an <code>InvalidParameterValue</code>
        /// error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CheckId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CheckId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-ASATrustedAdvisorCheckRefresh (RefreshTrustedAdvisorCheck)"))
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
            
            context.CheckId = this.CheckId;
            
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
            var request = new Amazon.AWSSupport.Model.RefreshTrustedAdvisorCheckRequest();
            
            if (cmdletContext.CheckId != null)
            {
                request.CheckId = cmdletContext.CheckId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Status;
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
        
        private Amazon.AWSSupport.Model.RefreshTrustedAdvisorCheckResponse CallAWSServiceOperation(IAmazonAWSSupport client, Amazon.AWSSupport.Model.RefreshTrustedAdvisorCheckRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Support API", "RefreshTrustedAdvisorCheck");
            #if DESKTOP
            return client.RefreshTrustedAdvisorCheck(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.RefreshTrustedAdvisorCheckAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String CheckId { get; set; }
        }
        
    }
}
