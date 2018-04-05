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
using Amazon.FMS;
using Amazon.FMS.Model;

namespace Amazon.PowerShell.Cmdlets.FMS
{
    /// <summary>
    /// Returns detailed compliance information about the specified member account. Details
    /// include resources that are in and out of compliance with the specified policy. Resources
    /// are considered non-compliant if the specified policy has not been applied to them.
    /// </summary>
    [Cmdlet("Get", "FMSComplianceDetail")]
    [OutputType("Amazon.FMS.Model.PolicyComplianceDetail")]
    [AWSCmdlet("Calls the Firewall Management Service GetComplianceDetail API operation.", Operation = new[] {"GetComplianceDetail"})]
    [AWSCmdletOutput("Amazon.FMS.Model.PolicyComplianceDetail",
        "This cmdlet returns a PolicyComplianceDetail object.",
        "The service call response (type Amazon.FMS.Model.GetComplianceDetailResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetFMSComplianceDetailCmdlet : AmazonFMSClientCmdlet, IExecutor
    {
        
        #region Parameter MemberAccount
        /// <summary>
        /// <para>
        /// <para>The AWS account that owns the resources that you want to get the details for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MemberAccount { get; set; }
        #endregion
        
        #region Parameter PolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the policy that you want to get the details for. <code>PolicyId</code> is
        /// returned by <code>PutPolicy</code> and by <code>ListPolicies</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PolicyId { get; set; }
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
            
            context.MemberAccount = this.MemberAccount;
            context.PolicyId = this.PolicyId;
            
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
            var request = new Amazon.FMS.Model.GetComplianceDetailRequest();
            
            if (cmdletContext.MemberAccount != null)
            {
                request.MemberAccount = cmdletContext.MemberAccount;
            }
            if (cmdletContext.PolicyId != null)
            {
                request.PolicyId = cmdletContext.PolicyId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.PolicyComplianceDetail;
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
        
        private Amazon.FMS.Model.GetComplianceDetailResponse CallAWSServiceOperation(IAmazonFMS client, Amazon.FMS.Model.GetComplianceDetailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Firewall Management Service", "GetComplianceDetail");
            try
            {
                #if DESKTOP
                return client.GetComplianceDetail(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetComplianceDetailAsync(request);
                return task.Result;
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
            public System.String MemberAccount { get; set; }
            public System.String PolicyId { get; set; }
        }
        
    }
}
