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
    /// If you created a Shield Advanced policy, returns policy-level attack summary information
    /// in the event of a potential DDoS attack.
    /// </summary>
    [Cmdlet("Get", "FMSProtectionStatus")]
    [OutputType("Amazon.FMS.Model.GetProtectionStatusResponse")]
    [AWSCmdlet("Calls the Firewall Management Service GetProtectionStatus API operation.", Operation = new[] {"GetProtectionStatus"})]
    [AWSCmdletOutput("Amazon.FMS.Model.GetProtectionStatusResponse",
        "This cmdlet returns a Amazon.FMS.Model.GetProtectionStatusResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetFMSProtectionStatusCmdlet : AmazonFMSClientCmdlet, IExecutor
    {
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time period to query for the attacks. This is a <code>timestamp</code>
        /// type. The sample request above indicates a number type because the default used by
        /// AWS Firewall Manager is Unix time in seconds. However, any valid <code>timestamp</code>
        /// format is allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndTime { get; set; }
        #endregion
        
        #region Parameter MemberAccountId
        /// <summary>
        /// <para>
        /// <para>The AWS account that is in scope of the policy that you want to get the details for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MemberAccountId { get; set; }
        #endregion
        
        #region Parameter PolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the policy for which you want to get the attack information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PolicyId { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the time period to query for the attacks. This is a <code>timestamp</code>
        /// type. The sample request above indicates a number type because the default used by
        /// AWS Firewall Manager is Unix time in seconds. However, any valid <code>timestamp</code>
        /// format is allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Specifies the number of objects that you want AWS Firewall Manager to return for this
        /// request. If you have more objects than the number that you specify for <code>MaxResults</code>,
        /// the response includes a <code>NextToken</code> value that you can use to get another
        /// batch of objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If you specify a value for <code>MaxResults</code> and you have more objects than
        /// the number that you specify for <code>MaxResults</code>, AWS Firewall Manager returns
        /// a <code>NextToken</code> value in the response that allows you to list another group
        /// of objects. For the second and subsequent <code>GetProtectionStatus</code> requests,
        /// specify the value of <code>NextToken</code> from the previous response to get information
        /// about another batch of objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
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
            
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.MemberAccountId = this.MemberAccountId;
            context.NextToken = this.NextToken;
            context.PolicyId = this.PolicyId;
            if (ParameterWasBound("StartTime"))
                context.StartTime = this.StartTime;
            
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
            var request = new Amazon.FMS.Model.GetProtectionStatusRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.MemberAccountId != null)
            {
                request.MemberAccountId = cmdletContext.MemberAccountId;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.PolicyId != null)
            {
                request.PolicyId = cmdletContext.PolicyId;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        private Amazon.FMS.Model.GetProtectionStatusResponse CallAWSServiceOperation(IAmazonFMS client, Amazon.FMS.Model.GetProtectionStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Firewall Management Service", "GetProtectionStatus");
            try
            {
                #if DESKTOP
                return client.GetProtectionStatus(request);
                #elif CORECLR
                return client.GetProtectionStatusAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String MemberAccountId { get; set; }
            public System.String NextToken { get; set; }
            public System.String PolicyId { get; set; }
            public System.DateTime? StartTime { get; set; }
        }
        
    }
}
