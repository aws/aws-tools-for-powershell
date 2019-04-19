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
    /// Gets the specified limit for the current account, for example, the maximum number
    /// of health checks that you can create using the account.
    /// 
    ///  
    /// <para>
    /// For the default limit, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/DNSLimitations.html">Limits</a>
    /// in the <i>Amazon Route 53 Developer Guide</i>. To request a higher limit, <a href="https://console.aws.amazon.com/support/home#/case/create?issueType=service-limit-increase&amp;limitType=service-code-route53">open
    /// a case</a>.
    /// </para><note><para>
    /// You can also view account limits in AWS Trusted Advisor. Sign in to the AWS Management
    /// Console and open the Trusted Advisor console at <a href="https://console.aws.amazon.com/trustedadvisor">https://console.aws.amazon.com/trustedadvisor/</a>.
    /// Then choose <b>Service limits</b> in the navigation pane.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "R53AccountLimit")]
    [OutputType("System.Int64")]
    [AWSCmdlet("Calls the Amazon Route 53 GetAccountLimit API operation.", Operation = new[] {"GetAccountLimit"})]
    [AWSCmdletOutput("System.Int64",
        "This cmdlet returns a Int64 object.",
        "The service call response (type Amazon.Route53.Model.GetAccountLimitResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Limit (type Amazon.Route53.Model.AccountLimit)"
    )]
    public partial class GetR53AccountLimitCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The limit that you want to get. Valid values include the following:</para><ul><li><para><b>MAX_HEALTH_CHECKS_BY_OWNER</b>: The maximum number of health checks that you can
        /// create using the current account.</para></li><li><para><b>MAX_HOSTED_ZONES_BY_OWNER</b>: The maximum number of hosted zones that you can
        /// create using the current account.</para></li><li><para><b>MAX_REUSABLE_DELEGATION_SETS_BY_OWNER</b>: The maximum number of reusable delegation
        /// sets that you can create using the current account.</para></li><li><para><b>MAX_TRAFFIC_POLICIES_BY_OWNER</b>: The maximum number of traffic policies that
        /// you can create using the current account.</para></li><li><para><b>MAX_TRAFFIC_POLICY_INSTANCES_BY_OWNER</b>: The maximum number of traffic policy
        /// instances that you can create using the current account. (Traffic policy instances
        /// are referred to as traffic flow policy records in the Amazon Route 53 console.)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53.AccountLimitType")]
        public Amazon.Route53.AccountLimitType Type { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Type = this.Type;
            
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
            var request = new Amazon.Route53.Model.GetAccountLimitRequest();
            
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Count;
                notes = new Dictionary<string, object>();
                notes["Limit"] = response.Limit;
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
        
        private Amazon.Route53.Model.GetAccountLimitResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.GetAccountLimitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "GetAccountLimit");
            try
            {
                #if DESKTOP
                return client.GetAccountLimit(request);
                #elif CORECLR
                return client.GetAccountLimitAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Route53.AccountLimitType Type { get; set; }
        }
        
    }
}
