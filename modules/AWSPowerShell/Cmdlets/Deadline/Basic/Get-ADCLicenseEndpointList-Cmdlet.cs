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
using Amazon.Deadline;
using Amazon.Deadline.Model;

namespace Amazon.PowerShell.Cmdlets.ADC
{
    /// <summary>
    /// Lists license endpoints.
    /// </summary>
    [Cmdlet("Get", "ADCLicenseEndpointList")]
    [OutputType("Amazon.Deadline.Model.LicenseEndpointSummary")]
    [AWSCmdlet("Calls the AWSDeadlineCloud ListLicenseEndpoints API operation.", Operation = new[] {"ListLicenseEndpoints"}, SelectReturnType = typeof(Amazon.Deadline.Model.ListLicenseEndpointsResponse))]
    [AWSCmdletOutput("Amazon.Deadline.Model.LicenseEndpointSummary or Amazon.Deadline.Model.ListLicenseEndpointsResponse",
        "This cmdlet returns a collection of Amazon.Deadline.Model.LicenseEndpointSummary objects.",
        "The service call response (type Amazon.Deadline.Model.ListLicenseEndpointsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetADCLicenseEndpointListCmdlet : AmazonDeadlineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return. Use this parameter with <c>NextToken</c>
        /// to get results as a set of sequential pages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results, or <c>null</c> to start from the beginning.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LicenseEndpoints'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Deadline.Model.ListLicenseEndpointsResponse).
        /// Specifying the name of a property of type Amazon.Deadline.Model.ListLicenseEndpointsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LicenseEndpoints";
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
                context.Select = CreateSelectDelegate<Amazon.Deadline.Model.ListLicenseEndpointsResponse, GetADCLicenseEndpointListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Deadline.Model.ListLicenseEndpointsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.Deadline.Model.ListLicenseEndpointsResponse CallAWSServiceOperation(IAmazonDeadline client, Amazon.Deadline.Model.ListLicenseEndpointsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSDeadlineCloud", "ListLicenseEndpoints");
            try
            {
                #if DESKTOP
                return client.ListLicenseEndpoints(request);
                #elif CORECLR
                return client.ListLicenseEndpointsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Deadline.Model.ListLicenseEndpointsResponse, GetADCLicenseEndpointListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LicenseEndpoints;
        }
        
    }
}
