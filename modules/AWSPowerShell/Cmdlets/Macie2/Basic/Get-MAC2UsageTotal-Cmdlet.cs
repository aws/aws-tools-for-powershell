/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Macie2;
using Amazon.Macie2.Model;

namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Retrieves (queries) aggregated usage data for an account.
    /// </summary>
    [Cmdlet("Get", "MAC2UsageTotal")]
    [OutputType("Amazon.Macie2.Model.UsageTotal")]
    [AWSCmdlet("Calls the Amazon Macie 2 GetUsageTotals API operation.", Operation = new[] {"GetUsageTotals"}, SelectReturnType = typeof(Amazon.Macie2.Model.GetUsageTotalsResponse))]
    [AWSCmdletOutput("Amazon.Macie2.Model.UsageTotal or Amazon.Macie2.Model.GetUsageTotalsResponse",
        "This cmdlet returns a collection of Amazon.Macie2.Model.UsageTotal objects.",
        "The service call response (type Amazon.Macie2.Model.GetUsageTotalsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMAC2UsageTotalCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TimeRange
        /// <summary>
        /// <para>
        /// <para>The inclusive time period to retrieve the data for. Valid values are: MONTH_TO_DATE,
        /// for the current calendar month to date; and, PAST_30_DAYS, for the preceding 30 days.
        /// If you don't specify a value for this parameter, Amazon Macie provides aggregated
        /// usage data for the preceding 30 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TimeRange { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UsageTotals'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.GetUsageTotalsResponse).
        /// Specifying the name of a property of type Amazon.Macie2.Model.GetUsageTotalsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UsageTotals";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.GetUsageTotalsResponse, GetMAC2UsageTotalCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TimeRange = this.TimeRange;
            
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
            var request = new Amazon.Macie2.Model.GetUsageTotalsRequest();
            
            if (cmdletContext.TimeRange != null)
            {
                request.TimeRange = cmdletContext.TimeRange;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.Macie2.Model.GetUsageTotalsResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.GetUsageTotalsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "GetUsageTotals");
            try
            {
                #if DESKTOP
                return client.GetUsageTotals(request);
                #elif CORECLR
                return client.GetUsageTotalsAsync(request).GetAwaiter().GetResult();
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
            public System.String TimeRange { get; set; }
            public System.Func<Amazon.Macie2.Model.GetUsageTotalsResponse, GetMAC2UsageTotalCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UsageTotals;
        }
        
    }
}
