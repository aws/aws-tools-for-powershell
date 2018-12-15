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
using Amazon.PinpointEmail;
using Amazon.PinpointEmail.Model;

namespace Amazon.PowerShell.Cmdlets.PINE
{
    /// <summary>
    /// Retrieve inbox placement and engagement rates for the domains that you use to send
    /// email.
    /// </summary>
    [Cmdlet("Get", "PINEDomainStatisticsReport")]
    [OutputType("Amazon.PinpointEmail.Model.GetDomainStatisticsReportResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint Email GetDomainStatisticsReport API operation.", Operation = new[] {"GetDomainStatisticsReport"})]
    [AWSCmdletOutput("Amazon.PinpointEmail.Model.GetDomainStatisticsReportResponse",
        "This cmdlet returns a Amazon.PinpointEmail.Model.GetDomainStatisticsReportResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPINEDomainStatisticsReportCmdlet : AmazonPinpointEmailClientCmdlet, IExecutor
    {
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The domain that you want to obtain deliverability metrics for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The last day (in Unix time) that you want to obtain domain deliverability metrics
        /// for. The <code>EndDate</code> that you specify has to be less than or equal to 30
        /// days after the <code>StartDate</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndDate { get; set; }
        #endregion
        
        #region Parameter StartDate
        /// <summary>
        /// <para>
        /// <para>The first day (in Unix time) that you want to obtain domain deliverability metrics
        /// for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartDate { get; set; }
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
            
            context.Domain = this.Domain;
            if (ParameterWasBound("EndDate"))
                context.EndDate = this.EndDate;
            if (ParameterWasBound("StartDate"))
                context.StartDate = this.StartDate;
            
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
            var request = new Amazon.PinpointEmail.Model.GetDomainStatisticsReportRequest();
            
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate.Value;
            }
            if (cmdletContext.StartDate != null)
            {
                request.StartDate = cmdletContext.StartDate.Value;
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
        
        private Amazon.PinpointEmail.Model.GetDomainStatisticsReportResponse CallAWSServiceOperation(IAmazonPinpointEmail client, Amazon.PinpointEmail.Model.GetDomainStatisticsReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint Email", "GetDomainStatisticsReport");
            try
            {
                #if DESKTOP
                return client.GetDomainStatisticsReport(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetDomainStatisticsReportAsync(request);
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
            public System.String Domain { get; set; }
            public System.DateTime? EndDate { get; set; }
            public System.DateTime? StartDate { get; set; }
        }
        
    }
}
