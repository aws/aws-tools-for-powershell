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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Enables the standards specified by the standards ARNs. In the context of Security
    /// Hub, supported standards (for example, CIS AWS Foundations) are automated and continuous
    /// checks that help determine your compliance status against security industry (including
    /// AWS) best practices.
    /// </summary>
    [Cmdlet("Enable", "SHUBStandardsBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityHub.Model.StandardsSubscription")]
    [AWSCmdlet("Calls the AWS Security Hub BatchEnableStandards API operation.", Operation = new[] {"BatchEnableStandards"})]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.StandardsSubscription",
        "This cmdlet returns a collection of StandardsSubscription objects.",
        "The service call response (type Amazon.SecurityHub.Model.BatchEnableStandardsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EnableSHUBStandardsBatchCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        #region Parameter StandardsSubscriptionRequest
        /// <summary>
        /// <para>
        /// <para>The list of standards that you want to enable.</para><important><para>In this release, Security Hub only supports the CIS AWS Foundations standard. </para><para>Its ARN is arn:aws:securityhub:::ruleset/cis-aws-foundations-benchmark/v/1.2.0.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("StandardsSubscriptionRequests")]
        public Amazon.SecurityHub.Model.StandardsSubscriptionRequest[] StandardsSubscriptionRequest { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StandardsSubscriptionRequest", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-SHUBStandardsBatch (BatchEnableStandards)"))
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
            
            if (this.StandardsSubscriptionRequest != null)
            {
                context.StandardsSubscriptionRequests = new List<Amazon.SecurityHub.Model.StandardsSubscriptionRequest>(this.StandardsSubscriptionRequest);
            }
            
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
            var request = new Amazon.SecurityHub.Model.BatchEnableStandardsRequest();
            
            if (cmdletContext.StandardsSubscriptionRequests != null)
            {
                request.StandardsSubscriptionRequests = cmdletContext.StandardsSubscriptionRequests;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.StandardsSubscriptions;
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
        
        private Amazon.SecurityHub.Model.BatchEnableStandardsResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.BatchEnableStandardsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "BatchEnableStandards");
            try
            {
                #if DESKTOP
                return client.BatchEnableStandards(request);
                #elif CORECLR
                return client.BatchEnableStandardsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityHub.Model.StandardsSubscriptionRequest> StandardsSubscriptionRequests { get; set; }
        }
        
    }
}
