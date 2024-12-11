/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ControlTower;
using Amazon.ControlTower.Model;

namespace Amazon.PowerShell.Cmdlets.ACT
{
    /// <summary>
    /// Lists all landing zone operations from the past 90 days. Results are sorted by time,
    /// with the most recent operation first.
    /// </summary>
    [Cmdlet("Get", "ACTLandingZoneOperationList")]
    [OutputType("Amazon.ControlTower.Model.LandingZoneOperationSummary")]
    [AWSCmdlet("Calls the AWS Control Tower ListLandingZoneOperations API operation.", Operation = new[] {"ListLandingZoneOperations"}, SelectReturnType = typeof(Amazon.ControlTower.Model.ListLandingZoneOperationsResponse))]
    [AWSCmdletOutput("Amazon.ControlTower.Model.LandingZoneOperationSummary or Amazon.ControlTower.Model.ListLandingZoneOperationsResponse",
        "This cmdlet returns a collection of Amazon.ControlTower.Model.LandingZoneOperationSummary objects.",
        "The service call response (type Amazon.ControlTower.Model.ListLandingZoneOperationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetACTLandingZoneOperationListCmdlet : AmazonControlTowerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_Status
        /// <summary>
        /// <para>
        /// <para>The statuses of the set of landing zone operations selected by the filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Statuses")]
        public System.String[] Filter_Status { get; set; }
        #endregion
        
        #region Parameter Filter_Type
        /// <summary>
        /// <para>
        /// <para>The set of landing zone operation types selected by the filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Types")]
        public System.String[] Filter_Type { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>How many results to return per API call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to continue the list from a previous API call with the same parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LandingZoneOperations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlTower.Model.ListLandingZoneOperationsResponse).
        /// Specifying the name of a property of type Amazon.ControlTower.Model.ListLandingZoneOperationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LandingZoneOperations";
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
                context.Select = CreateSelectDelegate<Amazon.ControlTower.Model.ListLandingZoneOperationsResponse, GetACTLandingZoneOperationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter_Status != null)
            {
                context.Filter_Status = new List<System.String>(this.Filter_Status);
            }
            if (this.Filter_Type != null)
            {
                context.Filter_Type = new List<System.String>(this.Filter_Type);
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
            var request = new Amazon.ControlTower.Model.ListLandingZoneOperationsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.ControlTower.Model.LandingZoneOperationFilter();
            List<System.String> requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Statuses = requestFilter_filter_Status;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Type = null;
            if (cmdletContext.Filter_Type != null)
            {
                requestFilter_filter_Type = cmdletContext.Filter_Type;
            }
            if (requestFilter_filter_Type != null)
            {
                request.Filter.Types = requestFilter_filter_Type;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
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
        
        private Amazon.ControlTower.Model.ListLandingZoneOperationsResponse CallAWSServiceOperation(IAmazonControlTower client, Amazon.ControlTower.Model.ListLandingZoneOperationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Tower", "ListLandingZoneOperations");
            try
            {
                #if DESKTOP
                return client.ListLandingZoneOperations(request);
                #elif CORECLR
                return client.ListLandingZoneOperationsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Filter_Status { get; set; }
            public List<System.String> Filter_Type { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ControlTower.Model.ListLandingZoneOperationsResponse, GetACTLandingZoneOperationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LandingZoneOperations;
        }
        
    }
}
