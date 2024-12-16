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
using Amazon.IVSRealTime;
using Amazon.IVSRealTime.Model;

namespace Amazon.PowerShell.Cmdlets.IVSRT
{
    /// <summary>
    /// Lists all IngestConfigurations in your account, in the AWS region where the API request
    /// is processed.
    /// </summary>
    [Cmdlet("Get", "IVSRTIngestConfigurationList")]
    [OutputType("Amazon.IVSRealTime.Model.IngestConfigurationSummary")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service RealTime ListIngestConfigurations API operation.", Operation = new[] {"ListIngestConfigurations"}, SelectReturnType = typeof(Amazon.IVSRealTime.Model.ListIngestConfigurationsResponse))]
    [AWSCmdletOutput("Amazon.IVSRealTime.Model.IngestConfigurationSummary or Amazon.IVSRealTime.Model.ListIngestConfigurationsResponse",
        "This cmdlet returns a collection of Amazon.IVSRealTime.Model.IngestConfigurationSummary objects.",
        "The service call response (type Amazon.IVSRealTime.Model.ListIngestConfigurationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIVSRTIngestConfigurationListCmdlet : AmazonIVSRealTimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FilterByStageArn
        /// <summary>
        /// <para>
        /// <para>Filters the response list to match the specified stage ARN. Only one filter (by stage
        /// ARN or by state) can be used at a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterByStageArn { get; set; }
        #endregion
        
        #region Parameter FilterByState
        /// <summary>
        /// <para>
        /// <para>Filters the response list to match the specified state. Only one filter (by stage
        /// ARN or by state) can be used at a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IVSRealTime.IngestConfigurationState")]
        public Amazon.IVSRealTime.IngestConfigurationState FilterByState { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of results to return. Default: 50.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The first IngestConfiguration to retrieve. This is used for pagination; see the <c>nextToken</c>
        /// response field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IngestConfigurations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVSRealTime.Model.ListIngestConfigurationsResponse).
        /// Specifying the name of a property of type Amazon.IVSRealTime.Model.ListIngestConfigurationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IngestConfigurations";
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
                context.Select = CreateSelectDelegate<Amazon.IVSRealTime.Model.ListIngestConfigurationsResponse, GetIVSRTIngestConfigurationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FilterByStageArn = this.FilterByStageArn;
            context.FilterByState = this.FilterByState;
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
            var request = new Amazon.IVSRealTime.Model.ListIngestConfigurationsRequest();
            
            if (cmdletContext.FilterByStageArn != null)
            {
                request.FilterByStageArn = cmdletContext.FilterByStageArn;
            }
            if (cmdletContext.FilterByState != null)
            {
                request.FilterByState = cmdletContext.FilterByState;
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
        
        private Amazon.IVSRealTime.Model.ListIngestConfigurationsResponse CallAWSServiceOperation(IAmazonIVSRealTime client, Amazon.IVSRealTime.Model.ListIngestConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service RealTime", "ListIngestConfigurations");
            try
            {
                #if DESKTOP
                return client.ListIngestConfigurations(request);
                #elif CORECLR
                return client.ListIngestConfigurationsAsync(request).GetAwaiter().GetResult();
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
            public System.String FilterByStageArn { get; set; }
            public Amazon.IVSRealTime.IngestConfigurationState FilterByState { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.IVSRealTime.Model.ListIngestConfigurationsResponse, GetIVSRTIngestConfigurationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IngestConfigurations;
        }
        
    }
}
