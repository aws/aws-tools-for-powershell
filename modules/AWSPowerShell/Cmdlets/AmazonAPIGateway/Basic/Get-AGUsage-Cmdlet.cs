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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Gets the usage data of a usage plan in a specified time interval.
    /// </summary>
    [Cmdlet("Get", "AGUsage")]
    [OutputType("Amazon.APIGateway.Model.GetUsageResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway GetUsage API operation.", Operation = new[] {"GetUsage"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.GetUsageResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.GetUsageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetAGUsageCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>[Required] The ending date (e.g., 2016-12-31) of the usage data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EndDate { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The Id of the API key associated with the resultant usage data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter StartDate
        /// <summary>
        /// <para>
        /// <para>[Required] The starting date (e.g., 2016-01-01) of the usage data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StartDate { get; set; }
        #endregion
        
        #region Parameter UsagePlanId
        /// <summary>
        /// <para>
        /// <para>[Required] The Id of the usage plan associated with the usage data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String UsagePlanId { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of returned results per page. The default value is 25 and the maximum
        /// value is 500.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Limit { get; set; }
        #endregion
        
        #region Parameter Position
        /// <summary>
        /// <para>
        /// <para>The current pagination position in the paged result set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Position { get; set; }
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
            
            context.EndDate = this.EndDate;
            context.KeyId = this.KeyId;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.Position = this.Position;
            context.StartDate = this.StartDate;
            context.UsagePlanId = this.UsagePlanId;
            
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
            var request = new Amazon.APIGateway.Model.GetUsageRequest();
            
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate;
            }
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.Position != null)
            {
                request.Position = cmdletContext.Position;
            }
            if (cmdletContext.StartDate != null)
            {
                request.StartDate = cmdletContext.StartDate;
            }
            if (cmdletContext.UsagePlanId != null)
            {
                request.UsagePlanId = cmdletContext.UsagePlanId;
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
        
        private Amazon.APIGateway.Model.GetUsageResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.GetUsageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "GetUsage");
            try
            {
                #if DESKTOP
                return client.GetUsage(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetUsageAsync(request);
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
            public System.String EndDate { get; set; }
            public System.String KeyId { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String Position { get; set; }
            public System.String StartDate { get; set; }
            public System.String UsagePlanId { get; set; }
        }
        
    }
}
